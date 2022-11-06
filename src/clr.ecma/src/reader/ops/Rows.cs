//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class EcmaReader
    {
        public uint Rows(ReadOnlySpan<FieldDefinitionHandle> src, Span<EcmaFieldDef> dst)
        {
            var count = (uint)min(src.Length, dst.Length);
            for(var i=0; i<count; i++)
                 Row(skip(src,i), ref seek(dst,i));
            return count;
        }

        public ReadOnlySpan<EcmaFieldDef> Rows(ReadOnlySpan<FieldDefinitionHandle> src)
        {
            var count = (uint)src.Length;
            var dst = span<EcmaFieldDef>(count);
            Rows(src,dst);
            return dst;
        }
    }
}