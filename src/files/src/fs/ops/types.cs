//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct FS
    {
        public static FileTypes types(params Assembly[] src)
            => new (src.Types().Tagged<FileTypeAttribute>().Concrete().Map(x => (IFileType)Activator.CreateInstance(x)).ToHashSet());     
    }
}