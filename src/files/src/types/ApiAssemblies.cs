//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static sys;

    public class ApiAssemblies : ClrAssemblySet
    {
        public static Assembly[] Parts => _Parts;

        public ApiAssemblies()
            : base(_Parts)
        {

        }
        
        static Assembly[] _Parts;

        static ApiAssemblies()
        {
            _Parts = parts();
        }

        static Assembly[] parts()        
        {
            var root = FS.path(controller().Location).FolderPath;                    
            var modules = Archives.modules(root,false).Members().Where(x => FS.managed(x.Path) && !x.Path.FileName.Contains("System.Private.CoreLib"));
            return modules.Where(m => m.FileName. StartsWith("z0.")).Map(x => Assembly.LoadFile(x.Path.Format()));         
        }
    }
}