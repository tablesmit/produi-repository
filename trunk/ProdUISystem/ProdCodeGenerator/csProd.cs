// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace ProdCodeGenerator
{
#line 1 "C:\Documents and Settings\PRP9434\My Documents\Projects\produi\trunk\ProdUISystem\ProdCodeGenerator\csProd.tt"

    [GeneratedCode("Microsoft.VisualStudio.TextTemplating", "10.0.0.0")]
    public class csProd : csProdBase
    {
        #region ToString Helpers

        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private IFormatProvider formatProviderField = CultureInfo.InvariantCulture;

            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public IFormatProvider FormatProvider
            {
                get { return formatProviderField; }
                set
                {
                    if ((value != null))
                    {
                        formatProviderField = value;
                    }
                }
            }

            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new ArgumentNullException("objectToConvert");
                }
                Type t = objectToConvert.GetType();
                MethodInfo method = t.GetMethod("ToString", new[] { typeof(IFormatProvider) });
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] { formatProviderField })));
                }
            }
        }

        private readonly ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();

        public ToStringInstanceHelper ToStringHelper
        {
            get { return toStringHelperField; }
        }

        #endregion ToString Helpers

        public virtual string TransformText()
        {
            GenerationEnvironment = null;
            Write("ProdWindow window = new ProdWindow(\"");

#line 8 "C:\Documents and Settings\PRP9434\My Documents\Projects\produi\trunk\ProdUISystem\ProdCodeGenerator\csProdHeader.tt"
            Write(ToStringHelper.ToStringWithCulture(WindowName));

#line default
#line hidden
            Write("\");\r\n");

#line 9 "C:\Documents and Settings\PRP9434\My Documents\Projects\produi\trunk\ProdUISystem\ProdCodeGenerator\csProdHeader.tt"
            Write(ToStringHelper.ToStringWithCulture(ControlType));

#line default
#line hidden
            Write(" ctrl = new ");

#line 9 "C:\Documents and Settings\PRP9434\My Documents\Projects\produi\trunk\ProdUISystem\ProdCodeGenerator\csProdHeader.tt"
            Write(ToStringHelper.ToStringWithCulture(ControlType));

#line default
#line hidden
            Write("(window,\"");

#line 9 "C:\Documents and Settings\PRP9434\My Documents\Projects\produi\trunk\ProdUISystem\ProdCodeGenerator\csProdHeader.tt"
            Write(ToStringHelper.ToStringWithCulture(ControlName));

#line default
#line hidden
            Write("\");");
            Write("\r\n");
            Write("\r\n");

#line 7 "C:\Documents and Settings\PRP9434\My Documents\Projects\produi\trunk\ProdUISystem\ProdCodeGenerator\csProd.tt"
            if (ReturnType.Length != 0)
            {
#line default
#line hidden

#line 8 "C:\Documents and Settings\PRP9434\My Documents\Projects\produi\trunk\ProdUISystem\ProdCodeGenerator\csProd.tt"
                Write(ToStringHelper.ToStringWithCulture(ReturnType));

#line default
#line hidden
                Write(" retVal = ctrl.");

#line 8 "C:\Documents and Settings\PRP9434\My Documents\Projects\produi\trunk\ProdUISystem\ProdCodeGenerator\csProd.tt"
                Write(ToStringHelper.ToStringWithCulture(MethodName));

#line default
#line hidden
                Write("(");

#line 8 "C:\Documents and Settings\PRP9434\My Documents\Projects\produi\trunk\ProdUISystem\ProdCodeGenerator\csProd.tt"
                Write(ToStringHelper.ToStringWithCulture(MethodParameters));

#line default
#line hidden
                Write(");\r\n");

#line 9 "C:\Documents and Settings\PRP9434\My Documents\Projects\produi\trunk\ProdUISystem\ProdCodeGenerator\csProd.tt"
            }

#line default
#line hidden

#line 10 "C:\Documents and Settings\PRP9434\My Documents\Projects\produi\trunk\ProdUISystem\ProdCodeGenerator\csProd.tt"
            else
            {
#line default
#line hidden
                Write("ctrl.");

#line 11 "C:\Documents and Settings\PRP9434\My Documents\Projects\produi\trunk\ProdUISystem\ProdCodeGenerator\csProd.tt"
                Write(ToStringHelper.ToStringWithCulture(MethodName));

#line default
#line hidden
                Write("(");

#line 11 "C:\Documents and Settings\PRP9434\My Documents\Projects\produi\trunk\ProdUISystem\ProdCodeGenerator\csProd.tt"
                Write(ToStringHelper.ToStringWithCulture(MethodParameters));

#line default
#line hidden
                Write(");\r\n");

#line 12 "C:\Documents and Settings\PRP9434\My Documents\Projects\produi\trunk\ProdUISystem\ProdCodeGenerator\csProd.tt"
            }

#line default
#line hidden
            return GenerationEnvironment.ToString();
        }

#line 1 "C:\Documents and Settings\PRP9434\My Documents\Projects\produi\trunk\ProdUISystem\ProdCodeGenerator\csProd.tt"

        private string _WindowNameField;

        /// <summary>
        /// Access the WindowName parameter of the template.
        /// </summary>
        private string WindowName
        {
            get { return _WindowNameField; }
        }

        private string _ControlTypeField;

        /// <summary>
        /// Access the ControlType parameter of the template.
        /// </summary>
        private string ControlType
        {
            get { return _ControlTypeField; }
        }

        private string _ControlNameField;

        /// <summary>
        /// Access the ControlName parameter of the template.
        /// </summary>
        private string ControlName
        {
            get { return _ControlNameField; }
        }

        private string _ReturnTypeField;

        /// <summary>
        /// Access the ReturnType parameter of the template.
        /// </summary>
        private string ReturnType
        {
            get { return _ReturnTypeField; }
        }

        private string _MethodNameField;

        /// <summary>
        /// Access the MethodName parameter of the template.
        /// </summary>
        private string MethodName
        {
            get { return _MethodNameField; }
        }

        private string _MethodParametersField;

        /// <summary>
        /// Access the MethodParameters parameter of the template.
        /// </summary>
        private string MethodParameters
        {
            get { return _MethodParametersField; }
        }

        public virtual void Initialize()
        {
            if ((Errors.HasErrors == false))
            {
                bool WindowNameValueAcquired = false;
                if (Session.ContainsKey("WindowName"))
                {
                    if ((typeof(string).IsAssignableFrom(Session["WindowName"].GetType()) == false))
                    {
                        Error("The type \'System.String\' of the parameter \'WindowName\' did not match the type of " + "the data passed to the template.");
                    }
                    else
                    {
                        _WindowNameField = ((string)(Session["WindowName"]));
                        WindowNameValueAcquired = true;
                    }
                }
                if ((WindowNameValueAcquired == false))
                {
                    object data = CallContext.LogicalGetData("WindowName");
                    if ((data != null))
                    {
                        if ((typeof(string).IsAssignableFrom(data.GetType()) == false))
                        {
                            Error("The type \'System.String\' of the parameter \'WindowName\' did not match the type of " + "the data passed to the template.");
                        }
                        else
                        {
                            _WindowNameField = ((string)(data));
                        }
                    }
                }
                bool ControlTypeValueAcquired = false;
                if (Session.ContainsKey("ControlType"))
                {
                    if ((typeof(string).IsAssignableFrom(Session["ControlType"].GetType()) == false))
                    {
                        Error("The type \'System.String\' of the parameter \'ControlType\' did not match the type of" + " the data passed to the template.");
                    }
                    else
                    {
                        _ControlTypeField = ((string)(Session["ControlType"]));
                        ControlTypeValueAcquired = true;
                    }
                }
                if ((ControlTypeValueAcquired == false))
                {
                    object data = CallContext.LogicalGetData("ControlType");
                    if ((data != null))
                    {
                        if ((typeof(string).IsAssignableFrom(data.GetType()) == false))
                        {
                            Error("The type \'System.String\' of the parameter \'ControlType\' did not match the type of" + " the data passed to the template.");
                        }
                        else
                        {
                            _ControlTypeField = ((string)(data));
                        }
                    }
                }
                bool ControlNameValueAcquired = false;
                if (Session.ContainsKey("ControlName"))
                {
                    if ((typeof(string).IsAssignableFrom(Session["ControlName"].GetType()) == false))
                    {
                        Error("The type \'System.String\' of the parameter \'ControlName\' did not match the type of" + " the data passed to the template.");
                    }
                    else
                    {
                        _ControlNameField = ((string)(Session["ControlName"]));
                        ControlNameValueAcquired = true;
                    }
                }
                if ((ControlNameValueAcquired == false))
                {
                    object data = CallContext.LogicalGetData("ControlName");
                    if ((data != null))
                    {
                        if ((typeof(string).IsAssignableFrom(data.GetType()) == false))
                        {
                            Error("The type \'System.String\' of the parameter \'ControlName\' did not match the type of" + " the data passed to the template.");
                        }
                        else
                        {
                            _ControlNameField = ((string)(data));
                        }
                    }
                }
                bool ReturnTypeValueAcquired = false;
                if (Session.ContainsKey("ReturnType"))
                {
                    if ((typeof(string).IsAssignableFrom(Session["ReturnType"].GetType()) == false))
                    {
                        Error("The type \'System.String\' of the parameter \'ReturnType\' did not match the type of " + "the data passed to the template.");
                    }
                    else
                    {
                        _ReturnTypeField = ((string)(Session["ReturnType"]));
                        ReturnTypeValueAcquired = true;
                    }
                }
                if ((ReturnTypeValueAcquired == false))
                {
                    object data = CallContext.LogicalGetData("ReturnType");
                    if ((data != null))
                    {
                        if ((typeof(string).IsAssignableFrom(data.GetType()) == false))
                        {
                            Error("The type \'System.String\' of the parameter \'ReturnType\' did not match the type of " + "the data passed to the template.");
                        }
                        else
                        {
                            _ReturnTypeField = ((string)(data));
                        }
                    }
                }
                bool MethodNameValueAcquired = false;
                if (Session.ContainsKey("MethodName"))
                {
                    if ((typeof(string).IsAssignableFrom(Session["MethodName"].GetType()) == false))
                    {
                        Error("The type \'System.String\' of the parameter \'MethodName\' did not match the type of " + "the data passed to the template.");
                    }
                    else
                    {
                        _MethodNameField = ((string)(Session["MethodName"]));
                        MethodNameValueAcquired = true;
                    }
                }
                if ((MethodNameValueAcquired == false))
                {
                    object data = CallContext.LogicalGetData("MethodName");
                    if ((data != null))
                    {
                        if ((typeof(string).IsAssignableFrom(data.GetType()) == false))
                        {
                            Error("The type \'System.String\' of the parameter \'MethodName\' did not match the type of " + "the data passed to the template.");
                        }
                        else
                        {
                            _MethodNameField = ((string)(data));
                        }
                    }
                }
                bool MethodParametersValueAcquired = false;
                if (Session.ContainsKey("MethodParameters"))
                {
                    if ((typeof(string).IsAssignableFrom(Session["MethodParameters"].GetType()) == false))
                    {
                        Error("The type \'System.String\' of the parameter \'MethodParameters\' did not match the ty" + "pe of the data passed to the template.");
                    }
                    else
                    {
                        _MethodParametersField = ((string)(Session["MethodParameters"]));
                        MethodParametersValueAcquired = true;
                    }
                }
                if ((MethodParametersValueAcquired == false))
                {
                    object data = CallContext.LogicalGetData("MethodParameters");
                    if ((data != null))
                    {
                        if ((typeof(string).IsAssignableFrom(data.GetType()) == false))
                        {
                            Error("The type \'System.String\' of the parameter \'MethodParameters\' did not match the ty" + "pe of the data passed to the template.");
                        }
                        else
                        {
                            _MethodParametersField = ((string)(data));
                        }
                    }
                }
            }
        }

#line default
#line hidden
    }

#line default
#line hidden

    #region Base class

    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [GeneratedCode("Microsoft.VisualStudio.TextTemplating", "10.0.0.0")]
    public class csProdBase
    {
        #region Fields

        private string currentIndentField = "";
        private bool endsWithNewline;
        private CompilerErrorCollection errorsField;
        private StringBuilder generationEnvironmentField;
        private List<int> indentLengthsField;

        #endregion Fields

        #region Properties

        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected StringBuilder GenerationEnvironment
        {
            get
            {
                if ((generationEnvironmentField == null))
                {
                    generationEnvironmentField = new StringBuilder();
                }
                return generationEnvironmentField;
            }
            set { generationEnvironmentField = value; }
        }

        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public CompilerErrorCollection Errors
        {
            get
            {
                if ((errorsField == null))
                {
                    errorsField = new CompilerErrorCollection();
                }
                return errorsField;
            }
        }

        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private List<int> indentLengths
        {
            get
            {
                if ((indentLengthsField == null))
                {
                    indentLengthsField = new List<int>();
                }
                return indentLengthsField;
            }
        }

        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get { return currentIndentField; }
        }

        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual IDictionary<string, object> Session { get; set; }

        #endregion Properties

        #region Transform-time helpers

        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((GenerationEnvironment.Length == 0) || endsWithNewline))
            {
                GenerationEnvironment.Append(currentIndentField);
                endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(Environment.NewLine, StringComparison.CurrentCulture))
            {
                endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((currentIndentField.Length == 0))
            {
                GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(Environment.NewLine, (Environment.NewLine + currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (endsWithNewline)
            {
                GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - currentIndentField.Length));
            }
            else
            {
                GenerationEnvironment.Append(textToAppend);
            }
        }

        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            Write(textToAppend);
            GenerationEnvironment.AppendLine();
            endsWithNewline = true;
        }

        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            Write(string.Format(CultureInfo.CurrentCulture, format, args));
        }

        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            WriteLine(string.Format(CultureInfo.CurrentCulture, format, args));
        }

        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            CompilerError error = new CompilerError();
            error.ErrorText = message;
            Errors.Add(error);
        }

        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            CompilerError error = new CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            Errors.Add(error);
        }

        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new ArgumentNullException("indent");
            }
            currentIndentField = (currentIndentField + indent);
            indentLengths.Add(indent.Length);
        }

        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((indentLengths.Count > 0))
            {
                int indentLength = indentLengths[(indentLengths.Count - 1)];
                indentLengths.RemoveAt((indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = currentIndentField.Substring((currentIndentField.Length - indentLength));
                    currentIndentField = currentIndentField.Remove((currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }

        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            indentLengths.Clear();
            currentIndentField = "";
        }

        #endregion Transform-time helpers
    }

    #endregion Base class
}