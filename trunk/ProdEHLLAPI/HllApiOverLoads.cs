/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System.Runtime.InteropServices;
using System.Text;

namespace ProdEhllapi
{
    internal static class NativeMethods
    {
        [DllImport("PCSHLL32.dll", SetLastError = true)]
        internal static extern long hllapi(ref int func, ref char QueryData, ref int Len, ref int rc);

        [DllImport("PCSHLL32.dll", SetLastError = true)]
        internal static extern long hllapi(ref int func, ref string QueryData, ref int Len, ref int rc);

        [DllImport("PCSHLL32.dll", SetLastError = true, CharSet = CharSet.Unicode, BestFitMapping = true)]
        internal static extern long hllapi(ref int func, StringBuilder QueryData, ref int Len, ref int rc);
    }
}