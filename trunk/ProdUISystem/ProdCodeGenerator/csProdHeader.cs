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
#line 1 "C:\Documents and Settings\PRP9434\My Documents\Projects\produi\ProdUISystem\ProdCodeGenerator\csProdHeader.tt"

    [GeneratedCode("Microsoft.VisualStudio.TextTemplating", "10.0.0.0")]
    public class CsProdHeader : CsProdHeaderBase
    {
        #region ToString Helpers

        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private IFormatProvider _formatProviderField = CultureInfo.InvariantCulture;

            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public IFormatProvider FormatProvider
            {
                get { return _formatProviderField; }
                set
                {
                    if ((value != null))
                    {
                        _formatProviderField = value;
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
                return ((string)(method.Invoke(objectToConvert, new object[] { _formatProviderField })));
            }
        }

        private readonly ToStringInstanceHelper _toStringHelperField = new ToStringInstanceHelper();

        public ToStringInstanceHelper ToStringHelper
        {
            get { return _toStringHelperField; }
        }

        #endregion ToString Helpers

        public virtual string TransformText()
        {
            GenerationEnvironment = null;
            Write("\r\nList<ProdLogger> loggers = new  List<ProdLogger>();\r\nloggers.Add(example);\r\nPro" + "dWindow window = new ProdWindow(\"");

#line 8 "C:\Documents and Settings\PRP9434\My Documents\Projects\produi\ProdUISystem\ProdCodeGenerator\csProdHeader.tt"
            Write(ToStringHelper.ToStringWithCulture(WindowName));

#line default
#line hidden
            Write("\");\r\n");

#line 9 "C:\Documents and Settings\PRP9434\My Documents\Projects\produi\ProdUISystem\ProdCodeGenerator\csProdHeader.tt"
            Write(ToStringHelper.ToStringWithCulture(ControlType));

#line default
#line hidden
            Write(" ctrl = new ");

#line 9 "C:\Documents and Settings\PRP9434\My Documents\Projects\produi\ProdUISystem\ProdCodeGenerator\csProdHeader.tt"
            Write(ToStringHelper.ToStringWithCulture(ControlType));

#line default
#line hidden
            Write("(window,\"");

#line 9 "C:\Documents and Settings\PRP9434\My Documents\Projects\produi\ProdUISystem\ProdCodeGenerator\csProdHeader.tt"
            Write(ToStringHelper.ToStringWithCulture(ControlName));

#line default
#line hidden
            Write("\");");
            return GenerationEnvironment.ToString();
        }

#line 1 "C:\Documents and Settings\PRP9434\My Documents\Projects\produi\ProdUISystem\ProdCodeGenerator\csProdHeader.tt"

        private string _windowNameField;

        /// <summary>
        /// Access the WindowName parameter of the template.
        /// </summary>
        private string WindowName
        {
            get { return _windowNameField; }
        }

        private string _controlTypeField;

        /// <summary>
        /// Access the ControlType parameter of the template.
        /// </summary>
        private string ControlType
        {
            get { return _controlTypeField; }
        }

        /// <summary>
        /// Access the ControlName parameter of the template.
        /// </summary>
        private string ControlName { get; set; }

        public virtual void Initialize()
        {
            if (Errors.HasErrors) return;
            bool windowNameValueAcquired = false;
            if (Session.ContainsKey("WindowName"))
            {
                if ((typeof(string).IsAssignableFrom(Session["WindowName"].GetType()) == false))
                {
                    Error("The type \'System.String\' of the parameter \'WindowName\' did not match the type of " + "the data passed to the template.");
                }
                else
                {
                    _windowNameField = ((string)(Session["WindowName"]));
                    windowNameValueAcquired = true;
                }
            }
            if ((windowNameValueAcquired == false))
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
                        _windowNameField = ((string)(data));
                    }
                }
            }
            bool controlTypeValueAcquired = false;
            if (Session.ContainsKey("ControlType"))
            {
                if ((typeof(string).IsAssignableFrom(Session["ControlType"].GetType()) == false))
                {
                    Error("The type \'System.String\' of the parameter \'ControlType\' did not match the type of" + " the data passed to the template.");
                }
                else
                {
                    _controlTypeField = ((string)(Session["ControlType"]));
                    controlTypeValueAcquired = true;
                }
            }
            if ((controlTypeValueAcquired == false))
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
                        _controlTypeField = ((string)(data));
                    }
                }
            }
            bool controlNameValueAcquired = false;
            if (Session.ContainsKey("ControlName"))
            {
                if ((typeof(string).IsAssignableFrom(Session["ControlName"].GetType()) == false))
                {
                    Error("The type \'System.String\' of the parameter \'ControlName\' did not match the type of" + " the data passed to the template.");
                }
                else
                {
                    ControlName = ((string)(Session["ControlName"]));
                    controlNameValueAcquired = true;
                }
            }
            if ((controlNameValueAcquired == false))
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
                        ControlName = ((string)(data));
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
    public class CsProdHeaderBase
    {
        #region Fields

        private string _currentIndentField = "";
        private bool _endsWithNewline;
        private CompilerErrorCollection _errorsField;
        private StringBuilder _generationEnvironmentField;
        private List<int> _indentLengthsField;

        #endregion Fields

        #region Properties

        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected StringBuilder GenerationEnvironment
        {
            get
            {
                if ((_generationEnvironmentField == null))
                {
                    _generationEnvironmentField = new StringBuilder();
                }
                return _generationEnvironmentField;
            }
            set { _generationEnvironmentField = value; }
        }

        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public CompilerErrorCollection Errors
        {
            get
            {
                if ((_errorsField == null))
                {
                    _errorsField = new CompilerErrorCollection();
                }
                return _errorsField;
            }
        }

        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private List<int> indentLengths
        {
            get
            {
                if ((_indentLengthsField == null))
                {
                    _indentLengthsField = new List<int>();
                }
                return _indentLengthsField;
            }
        }

        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get { return _currentIndentField; }
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
            if (((GenerationEnvironment.Length == 0) || _endsWithNewline))
            {
                GenerationEnvironment.Append(_currentIndentField);
                _endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(Environment.NewLine, StringComparison.CurrentCulture))
            {
                _endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((_currentIndentField.Length == 0))
            {
                GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(Environment.NewLine, (Environment.NewLine + _currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (_endsWithNewline)
            {
                GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - _currentIndentField.Length));
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
            _endsWithNewline = true;
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
            CompilerError error = new CompilerError
            {
                ErrorText = message
            };
            Errors.Add(error);
        }

        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            CompilerError error = new CompilerError
            {
                ErrorText = message,
                IsWarning = true
            };
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
            _currentIndentField = (_currentIndentField + indent);
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
                    returnValue = _currentIndentField.Substring((_currentIndentField.Length - indentLength));
                    _currentIndentField = _currentIndentField.Remove((_currentIndentField.Length - indentLength));
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
            _currentIndentField = "";
        }

        #endregion Transform-time helpers
    }

    #endregion Base class
}