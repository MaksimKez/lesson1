using System.Runtime.Loader;

namespace lesson1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new AssemblyLoadContext("Context", true);
            var assemblyPath = Path.Combine(Directory.GetCurrentDirectory(), "myLib.dll");
            var assembly = context.LoadFromAssemblyPath(assemblyPath);
            var type1 = assembly.GetType("myLib.Class1");
            var type2 = assembly.GetType("myLib.Class2");

            var method1 = type1.GetMethod("PrintHelloWorld");
            var method2 = type2.GetMethod("PrintE");

            method1.Invoke(null, null);
            method2.Invoke(null, null);

            context.Unload();
        }
    }
}
