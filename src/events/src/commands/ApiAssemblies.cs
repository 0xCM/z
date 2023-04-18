//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
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
            return _modules.Map(x => Assembly.UnsafeLoadFrom(x.Format())).Where(x => x.PartName().IsNonEmpty);
        }
    }
}