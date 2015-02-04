using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows;

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

        private void OnStartup(object sender, StartupEventArgs e)
        {
            AppDomain.CurrentDomain.AssemblyResolve += OnResolveAssembly;
        }

        static Assembly OnResolveAssembly(object sender, ResolveEventArgs args)
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
	        AssemblyName assemblyName = new AssemblyName(args.Name);

	        string path = assemblyName.Name + ".dll";
	        if (assemblyName.CultureInfo.Equals(CultureInfo.InvariantCulture) == false)
	        {
	            path = String.Format(@"{0}\{1}", assemblyName.CultureInfo, path);
	        }
	 
	        using (Stream stream = executingAssembly.GetManifestResourceStream(path))
	        {
	            if (stream == null)
	                return null;
	 
	            byte[] assemblyRawBytes = new byte[stream.Length];
	            stream.Read(assemblyRawBytes, 0, assemblyRawBytes.Length);
	            return Assembly.Load(assemblyRawBytes);
	        }
        }
    }
}
