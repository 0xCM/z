//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct FS
    {
        public static FileQuery query(FolderPath src, bool recurse, params FileKind[] kinds)
            => new(from file in src.Files(recurse) 
                    where FileTypes.@is(file,kinds)
                    select file);
    }
}