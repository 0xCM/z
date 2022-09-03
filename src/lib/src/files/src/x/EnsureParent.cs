//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        public static FilePath EnsureParentExists(this FilePath src)
        {
            if(src.IsEmpty)
                sys.@throw("The source path is unspecified");

            var dir = System.IO.Path.GetDirectoryName(src.Name.Format());
            if(!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            return src;
        }

        public static FilePath CreateParentIfMissing(this FilePath src)
            => src.EnsureParentExists();
    }
}