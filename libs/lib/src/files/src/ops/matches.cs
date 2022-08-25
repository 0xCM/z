//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct FS
    {
        [Op]
        public static bool matches(FileName name, FileExt ext)
            => name.Format().EndsWith(ext.Name, NoCase);
    }
}