//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class AssemblyArchives
    {
        public static Assembly[] assemblies(FilePath[] src)
            => src.Where(x => FS.managed(x)).Map(assembly).Where(x => x.IsSome()).Select(x => x.Value);

        static Option<Assembly> assembly(FilePath src)
        {
            try
            {
                return Assembly.LoadFrom(src.Name);
            }
            catch(Exception e)
            {
                term.warn(string.Format("Unable to load {0}: {1}", src.ToUri(), e.Message));
                return default;
            }
        }       
    }
}