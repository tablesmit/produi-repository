/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

using System.Runtime.InteropServices;
using System.Text;

namespace ProdEhllapi
{
    internal static class NativeMethods
    {
        /// <summary>
        /// Generic native call to terminl emulator api
        /// </summary>
        /// <param name="func">Function Number.</param>
        /// <param name="QueryData">Varies with each function</param>
        /// <param name="Len">Varies with each function</param>
        /// <param name="rc">Varies with each function, often hold return value</param>
        /// <returns>Varies, but rc usually contains the desired return</returns>
        /// <remarks>QueryData is a char</remarks>
        [DllImport("PCSHLL32.dll", SetLastError = true)]
        internal static extern long hllapi(ref int func, ref char QueryData, ref int Len, ref int rc);

        /// <summary>
        /// Generic native call to terminl emulator api
        /// </summary>
        /// <param name="func">Function Number.</param>
        /// <param name="QueryData">Varies with each function</param>
        /// <param name="Len">Varies with each function</param>
        /// <param name="rc">Varies with each function, often hold return value</param>
        /// <returns>Varies, but rc usually contains the desired return</returns>
        /// <remarks>QueryData is a string</remarks>
        [DllImport("PCSHLL32.dll", SetLastError = true)]
        internal static extern long hllapi(ref int func, ref string QueryData, ref int Len, ref int rc);

        /// <summary>
        /// Generic native call to terminl emulator api
        /// </summary>
        /// <param name="func">Function Number.</param>
        /// <param name="QueryData">Varies with each function</param>
        /// <param name="Len">Varies with each function</param>
        /// <param name="rc">Varies with each function, often hold return value</param>
        /// <returns>Varies, but rc usually contains the desired return</returns>
        /// <remarks>QueryData is a StringBuilder</remarks>
        [DllImport("PCSHLL32.dll", SetLastError = true, CharSet = CharSet.Unicode, BestFitMapping = true)]
        internal static extern long hllapi(ref int func, StringBuilder QueryData, ref int Len, ref int rc);
    }
}