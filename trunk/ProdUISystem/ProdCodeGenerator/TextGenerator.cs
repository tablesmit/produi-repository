/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

/* Example use:
ProdTextTemplate template = new ProdTextTemplate("ProdButton", "7", "Click",string.Empty,string.Empty,"WindowName");
TextGenerator gen = new TextGenerator();
code =  gen.GenerateProd(template, OutputLanguage.CSharp);
*/

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
        /// <param name="template">The template to use in generatin.</param>
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
            csProd cs = new csProd();

            cs.Session = new Microsoft.VisualStudio.TextTemplating.TextTemplatingSession();
            cs.Session[Properties.Resources.WINDOW_NAME] = template.WindowName;
            cs.Session[Properties.Resources.CONTROL_TYPE] = template.ControlType;
            cs.Session[Properties.Resources.CONTROL_NAME] = template.ControlName;
            cs.Session[Properties.Resources.METHOD_NAME] = template.MethodName;
            cs.Session[Properties.Resources.METHOD_PARAMS] = template.MethodParameters;

            /* This seems to be an easier way to handle a void instead of in the template */
            if (template.ReturnType == "System.Void")
                cs.Session[Properties.Resources.RET_TYPE] = string.Empty;
            else
                cs.Session[Properties.Resources.RET_TYPE] = template.ReturnType;

            cs.Initialize();
            return cs.TransformText();

        }

    }
}
