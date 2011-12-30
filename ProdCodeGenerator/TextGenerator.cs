// License Rider: I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
using Microsoft.VisualStudio.TextTemplating;
using ProdCodeGenerator.Properties;

namespace ProdCodeGenerator
{
    /// <summary>
    /// The language to use when generating code snip output
    /// </summary>
    public enum OutputLanguage
    {
        /// <summary>
        /// C++
        /// </summary>
        CPlusPlus,
        /// <summary>
        /// C#
        /// </summary>
        CSharp,
        /// <summary>
        /// VB.Net
        /// </summary>
        VB
    }

    /// <summary>
    /// Used to process a T4 template to provide a text version code required to invoke method
    /// </summary>
    public class TextGenerator
    {
        /// <summary>
        /// Generates the prod code.
        /// </summary>
        /// <param name="template">The template to use in generating.</param>
        /// <param name="language">The language to generate.</param>
        /// <returns>The generated code</returns>
        public string GenerateProd(ProdTextTemplate template, OutputLanguage language)
        {
            string codeOut = string.Empty;

            switch (language)
            {
                case OutputLanguage.CSharp:
                    codeOut = csGenerateProd(template);
                    break;
                case OutputLanguage.VB:
                    break;
                case OutputLanguage.CPlusPlus:
                    break;
                default:
                    break;
            }
            return codeOut;
        }

        /// <summary>
        /// Generate the c# code for the prod.
        /// </summary>
        /// <param name="template">The template to use.</param>
        /// <returns>The generated code</returns>
        private static string csGenerateProd(ProdTextTemplate template)
        {
            CsProd cs = new CsProd
            {
                Session = new TextTemplatingSession()
            };

            cs.Session[Resources.WINDOW_NAME] = template.WindowName;
            cs.Session[Resources.CONTROL_TYPE] = template.ControlType;
            cs.Session[Resources.CONTROL_NAME] = template.ControlName;
            cs.Session[Resources.METHOD_NAME] = template.MethodName;
            cs.Session[Resources.METHOD_PARAMS] = template.MethodParameters;

            /* This seems to be an easier way to handle a void instead of in the template */
            if (template.ReturnType == "System.Void")
                cs.Session[Resources.RET_TYPE] = string.Empty;
            else
                cs.Session[Resources.RET_TYPE] = template.ReturnType;

            cs.Initialize();
            return cs.TransformText();
        }
    }
}