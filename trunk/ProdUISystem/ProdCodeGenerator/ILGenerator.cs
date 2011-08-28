/* License Rider:
 * I really don't care how you use this code, or if you give credit. Just don't blame me for any damage you do
 */

namespace ProdCodeGenerator
{
    public class ILGenerator
    {

    }
}


/*
producing code to execute Prods

in-project consumers:
ProdSpy - snippets (strings)
*needs to generate snippets of single use code in a few languages.
*involves possible variation of paramters
*does not need to be compiled, or run.

Testing - code (assembly)
*needs to generate a series of steps to take by invoking Prods
*needs to provide a mechanism to determine if the code performed correctly.
*user doesnt really need to see the code (but it'd allow modification). 
*generated program needs to execute on demand during runtime
*program needs to be able to be modifiable and provide for storage for import/export
 
 Snippets: 
 T4 for runtime text gen.
 Reflection to build text version
 XML storage
 
 code:
 CodeDom/IGenerator
 Write to xml, comile using services
 T4 preprocessed stuff - dont know if it supports paramter substitution
*/