using System;
using ProdUI.Exceptions;

namespace ProdUI.Verification
{
    internal static class ValueVerifier<T, K> where T : IComparable
    {
        internal static bool Verify(T expectedValue, K actualValue)
        {
            if (expectedValue.CompareTo(actualValue) == 0) return true;
            throw new ProdVerificationException(expectedValue + " does not match " + actualValue);
        }

        //internal static bool VerifyItemInList(T listItem, List<K> currentList)
        //{
        //    currentList.GetEnumerator();
        //    foreach (T k in currentList)
        //    {
        //        if (k.CompareTo(listItem) == 0) return true;
        //    }
        //    if (currentList.Contains(listItem)) return true;
        //    throw new ProdVerificationException(listItem + " does not found in " + currentList);
        //}
    }
}