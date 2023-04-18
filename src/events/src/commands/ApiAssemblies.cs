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
        public static Assembly[] Components => _Parts;

        public ApiAssemblies()
            : base(_Parts)
        {

        }
        
        static Assembly[] _Parts;

        static ApiAssemblies()
        {
            _Parts = components();
        }

        static Assembly[] components()        
        {
            var root = FS.path(controller().Location).FolderPath;
            var _modules = root.Files(FileKind.Dll).Where(x => x.FileName.StartsWith("z0."));
            //var modules = ModuleArchives.modules(root,false).Members().Where(x => FS.managed(x.Path) && !x.Path.FileName.Contains("System.Private.CoreLib"));
            return _modules.Map(x => Assembly.UnsafeLoadFrom(x.Format())).Where(x => x.PartName().IsNonEmpty);
        }
    }
}