using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Linq;

namespace QMAC
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /*
         * Found here: http://www.digitallycreated.net/Blog/61/combining-multiple-assemblies-into-a-single-exe-for-a-wpf-application
         */

        public App()
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(ResolveAssembly);  
        }

        static Assembly ResolveAssembly(object sender, ResolveEventArgs args)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            string resourceName = executingAssembly.FullName.Split(',').First() + ".Resources." + new AssemblyName(args.Name).Name + ".dll";

            using (var stream = executingAssembly.GetManifestResourceStream(resourceName))
	        {
                byte[] assemblyData = new byte[stream.Length];
                stream.Read(assemblyData, 0, assemblyData.Length);
                return Assembly.Load(assemblyData);
	        }
        }
    }
}
