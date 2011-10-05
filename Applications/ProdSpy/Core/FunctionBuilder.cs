/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Windows.Automation;
using System.Windows.Forms;
using MapLib;
using ProdUI.Controls.Static;
using ProdUI.Controls.Windows;
using ProdUI.Exceptions;

namespace ProdSpy.Core
{
    /// <summary>
    /// Builds the functions from reflection for use with the Activator
    /// </summary>
    internal class FunctionBuilder : IDisposable
    {
        private static MappedControl _focusedControl;
        private readonly IntPtr _parentWindowHandle;

        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionBuilder"/> class.
        /// </summary>
        /// <param name="parentWindowHandle">The parent window handle.</param>
        /// <param name="focusedControl">The focused control.</param>
        public FunctionBuilder(IntPtr parentWindowHandle, MappedControl focusedControl)
        {
            /* get the handle of the parent window */
            _parentWindowHandle = parentWindowHandle;

            /* The element under focus */
            _focusedControl = focusedControl;
        }

        /// <summary>
        /// Begin putting together the requested action
        /// </summary>
        /// <param name="methodIndex">Index of the method.</param>
        /// <returns>
        /// Arguments needed to invoke function
        /// </returns>
        internal object[] BuildAction(int methodIndex)
        {
            object type;
            CreateActivator(out type);

            MethodInfo[] methodInfos = type.GetType().GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);
            MethodInfo mi = methodInfos[methodIndex];

            /* figure out inputs (if any) */
            object[] args = new object[mi.GetParameters().Length];
            int arglen = args.Length;
            args = BeginFunctionParse(mi);
            if (args == null && arglen > 0)
            {
                return null;
            }

            return InvokeMethod(mi, args, type);
        }

        /// <summary>
        /// Creates the activator for this method.
        /// </summary>
        /// <param name="type">The underlying Prod type.</param>
        private void CreateActivator(out object type)
        {
            string originalName;

            Assembly prodAssembly = Assembly.LoadFrom(@"ProdUI.dll");
            Type[] types = prodAssembly.GetTypes();
            Type thetype = null;

            foreach (Type t in types)
            {
                if (t.UnderlyingSystemType.Name == _focusedControl.ProdControlType.UnderlyingSystemType.Name)
                {
                    thetype = t;
                }
            }

            if (_focusedControl.AutomationId.Length == 0)
            {
                originalName = _focusedControl.Name;
            }
            else
            {
                originalName = _focusedControl.AutomationId;
            }

            /* instantiate the underlying Prod type */
            if (thetype != null)
            {
                type = Activator.CreateInstance(thetype, SetConstructorParameters(originalName));
                return;
            }
            type = null;
        }

        /// <summary>
        /// Begins parsing the method to invoke.
        /// </summary>
        /// <param name="mi">The method to evaluate.</param>
        /// <returns>
        /// parameters reflected from the method
        /// </returns>
        private static object[] BeginFunctionParse(MethodInfo mi)
        {
            ParameterInfo[] pi = mi.GetParameters();

            /* function with no args */
            if (pi.Length < 1)
            {
                return null;
            }


            object[] args = new object[pi.Length];

            GetInputValues(pi, args);

            foreach (object t in args)
            {
                if (t == null)
                {
                    return null;
                }
            }
            return args;
        }

        /// <summary>
        /// Gets the input values from the ParameterInfo array.
        /// </summary>
        /// <param name="pi">The  ParameterInfo array of the method being interrogated.</param>
        /// <param name="args">Any additional arguments.</param>
        private static void GetInputValues(IList<ParameterInfo> pi, IList<object> args)
        {
            string[] elements = null;

            for (int i = 0; i < pi.Count; i++)
            {
                if (pi[i].ParameterType.Name == "AutomationElement")
                {
                    ConvertInputParameters(pi, args, i, _focusedControl);
                    return;
                }

                /* check if enumeration, then build choices */
                if (pi[i].ParameterType.IsEnum)
                {
                    elements = Enum.GetNames(pi[i].ParameterType);
                }

                SetValueForm form = new SetValueForm
                    {
                        ParamName = pi[i].Name,
                        ParamChoices = elements,
                        ParamType = pi[i].ParameterType
                    };

                if (form.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                /* Handles a ToggleState */
                if (pi[i].ParameterType == typeof(ToggleState))
                {
                    ConvertInputParameters(pi, args, i, form.returnState);
                    return;
                }

                /* Strings and number values */
                ConvertInputParameters(pi, args, i, form.returnValue);
            }
        }

        /// <summary>
        /// Sets the constructor parameters for the ProdSession and ProdWindow.
        /// </summary>
        /// <param name="originalName">Name of the original control.</param>
        /// <returns>
        /// An array of the necessary constructors needed for instance methods
        /// </returns>
        /// <remarks>
        /// This is just an empty, "Dummy" session
        /// </remarks>
        private object[] SetConstructorParameters(string originalName)
        {
            ProdWindow fake = new ProdWindow(_parentWindowHandle);
            object[] o = new object[] { fake, originalName };
            return o;
        }

        /// <summary>
        /// Parses the input parameters.
        /// </summary>
        /// <param name="pi">A list of method parameters.</param>
        /// <param name="args">The argument values.</param>
        /// <param name="i">The counter to iterate over the parameters</param>
        /// <param name="val">The value passed from the input dialog.</param>
        private static void ConvertInputParameters(IList<ParameterInfo> pi, IList<object> args, int i, object val)
        {
            if (pi[i].ParameterType == typeof(string))
            {
                args[i] = val;
                return;
            }
            if (pi[i].ParameterType == typeof(ToggleState))
            {
                if (ProcessToggleState(args, i, val) == 1)
                {
                    return;
                }

            }
            if (pi[i].ParameterType == typeof(int))
            {
                args[i] = int.Parse(val.ToString(), CultureInfo.CurrentCulture);
                return;
            }
            args[i] = val;
        }

        private static int ProcessToggleState(IList<object> args, int i, object val)
        {
            foreach (ToggleState item in Enum.GetValues(typeof(ToggleState)))
            {
                string t = item.ToString();
                if (String.Compare(t, val.ToString(), true, CultureInfo.CurrentCulture) != 0) continue;
                args[i] = item;
                return 1;
            }
            return 0;
        }

        private object[] InvokeMethod(MethodInfo mi, object[] args, object type)
        {
            object ret;
            try
            {
                Prod.ActivateWindow(_parentWindowHandle);
                ret = mi.Invoke(type, args);
            }
            catch (TargetInvocationException err)
            {
                MessageBox.Show(@"An error occurred while executing this method from within ProdSpy: " + err.InnerException.Message, @"Invocation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                object[] error = new object[1];
                error[0] = "ERR";
                return error;
            }
            catch (ProdOperationException err)
            {
                MessageBox.Show(err.Message);
                object[] error = new object[1];
                error[0] = "ERR";
                return error;
            }

            /* handle displays of return values */
            if (ret != null)
                MessageBox.Show(ret.ToString(), mi.Name);

            return args;
        }

        protected bool Disposed/* = false*/;

        protected virtual void Dispose(bool disposing)
        {
            lock (this)
            {
                /* Do nothing if the object has already been disposed of. */
                if (Disposed)
                    return;

                if (disposing)
                {
                    // Release disposable objects used by this instance here.

                }
                // Remember that the object has been disposed of.
                Disposed = true;
            }
        }

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}