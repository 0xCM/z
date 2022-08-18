//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct FS
    {
        public static uint render(ReadOnlySpan<FS.FilePath> src, ITextBuffer dst)
        {
            var count = (uint)src.Length;
            dst.AppendLine(string.Format("{0,-6} | {1}", "Seq", "Path"));
            for(var i=0; i<count; i++)
                dst.AppendLine(string.Format("{0,-6} | {1}", i.Format(4), skip(src,i).ToUri()));
            return count + 1;
        }
    }
}