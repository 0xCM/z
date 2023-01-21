//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XTend
    {
        public static FileExt Ext(this FileUri src)
            => new (System.IO.Path.GetExtension(src.LocalPath).TrimStart('.'));
    }
}
