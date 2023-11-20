//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System.Linq;

using static sys;

partial struct Bitfields
{
    public static ReadOnlySeq<BfDef> bitvectors(IDbArchive sources, string filter)
        => bitvectors(sources.Files(FileKind.Csv).Where(f => f.FileName.StartsWith(filter)).Array());

    struct BvParser : IParser<object>
    {
        public static BvParser Service => default;

        public Outcome Parse(string src, out object dst)
        {
            dst = src;
            return true;
        }
    }

    public static ReadOnlySeq<BfDef> bitvectors(Files src)
    {
        var items = empty<ListItem>();
        var counter = 0u;
        var count = src.Count;
        var dst = alloc<BfDef>(count);
        for(var i=0; i<count; i++)
        {
            ref readonly var source = ref src[i];
            using var reader = source.Utf8LineReader();
            ItemLists.list(reader, true, Chars.Pipe, BvParser.Service, out items).Require();
            seek(dst, i) = bitvector(source.FileName.WithoutExtension.Format(), items);
        }

        return dst;
    }

    /// <summary>
    /// Defines a bitfield specification that represents a bitvector
    /// </summary>
    /// <param name="name">The bitvector name</param>
    /// <param name="src">The list items that correspond to bits in the vector</param>
    public static BfDef bitvector(string name, ReadOnlySpan<ListItem> src)
    {
        var count = src.Length;
        var segs = alloc<BfSegDef>(count);
        for(var i=0u; i<count; i++)
            seek(segs,i) = segdef(skip(src,i).Value.ToString(), (byte)i, (byte)i, i >= 64 ? one(64,63) : one((byte)i,(byte)i));
        return define(segs);
    }    
}
