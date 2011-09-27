// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using System.Reflection;

namespace ProdCodeGenerator
{
    /// <summary>
    /// Used to process a Prod function through a T4 template for code generation
    /// </summary>
    public class ProdTextTemplate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProdTextTemplate"/> class.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="windowName">Name of the window.</param>
        /// <param name="controlName">Name of the control.</param>
        /// <param name="methodParameters">The method parameters.</param>
        public ProdTextTemplate(MethodInfo method, string windowName, string controlName, string methodParameters)
        {
            WindowName = windowName;
            ControlName = controlName;
            ControlType = method.DeclaringType.Name;
            MethodName = method.Name;
            MethodParameters = methodParameters;
            ReturnType = method.ReturnType.ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProdTextTemplate"/> class.
        /// </summary>
        /// <param name="controlType">Type of the control.</param>
        /// <param name="controlName">Name of the control.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="methodParameters">The method parameters.</param>
        /// <param name="returnType">Return Type of the method.</param>
        /// <param name="windowName">Title of the window.</param>
        public ProdTextTemplate(string controlType, string controlName, string methodName, string methodParameters, string returnType, string windowName)
        {
            WindowName = windowName;
            ControlName = controlName;
            ControlType = controlType;
            MethodName = methodName;
            MethodParameters = methodParameters;
            ReturnType = returnType;
        }

        /// <summary>
        /// Gets or sets the title of the window.
        /// </summary>
        /// <value>
        /// The name of the window.
        /// </value>
        public string WindowName { get; set; }

        /// <summary>
        /// Gets or sets the ProdUI type of the control.
        /// </summary>
        /// <value>
        /// The type of the control.
        /// </value>
        public string ControlType { get; set; }

        /// <summary>
        /// Th automationID or name of the control
        /// </summary>
        /// <value>
        /// The name of the control.
        /// </value>
        public string ControlName { get; set; }

        /// <summary>
        /// Gets or sets the name of the method.
        /// </summary>
        /// <value>
        /// The name of the method.
        /// </value>
        public string MethodName { get; set; }

        /// <summary>
        /// Gets or sets the method parameters.
        /// </summary>
        /// <value>
        /// The method parameters.
        /// </value>
        public string MethodParameters { get; set; }

        /// <summary>
        /// Gets or sets the return type of the Prod.
        /// </summary>
        /// <value>
        /// The return type of the Prod.
        /// </value>
        public string ReturnType { get; set; }
    }
}