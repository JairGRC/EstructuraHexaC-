using System;
using System.Collections.Generic;
using System.Composition.Hosting;
using System.Text;
using System.Composition.Convention;
using System.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace Util
{
    public static class MEFContainer
    {
        private static CompositionHost _container = null;

        public static CompositionHost Container
        {
            get
            {
                if (_container == null)
                {
                    //composition container, which contains all the parts available and performs composition.
                    //Composition is the matching up of imports to exports.
                    var executableLocation = Assembly.GetEntryAssembly().Location;
                    var pathAssembly = Path.GetDirectoryName(executableLocation);
					
                    
						
				     var assemblies = Directory
                       .GetFiles(pathAssembly, "EP_*.dll", SearchOption.TopDirectoryOnly)
                       //.Where(obj => !obj.Contains("View"))
                       //.Where(obj => !obj.Contains("Select.HtmlToPdf"))                                        
                       .Select(AssemblyLoadContext.GetAssemblyName)
                       .Select(AssemblyLoadContext.Default.LoadFromAssemblyName)
                       .ToList();
					   
                    var configuration = new ContainerConfiguration().WithAssemblies(assemblies);                    
                    _container = configuration.CreateContainer();
                }
                return _container;
            }
        }
    }
}
