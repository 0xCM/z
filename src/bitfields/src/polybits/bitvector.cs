//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using System.Linq;

using static sys;

partial class PolyBits
{
    public static ReadOnlySeq<BfModel> bitvectors(IDbArchive sources, string filter)
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

    public static ReadOnlySeq<BfModel> bitvectors(Files src)
    {
        var items = empty<ListItem>();
        var counter = 0u;
        var count = src.Count;
        var dst = alloc<BfModel>(count);
        for(var i=0; i<count; i++)
        {
            ref readonly var source = ref src[i];
            using var reader = source.Utf8LineReader();
            ItemLists.list(reader, true, Chars.Pipe, BvParser.Service, out items).Require();
            seek(dst, i) = bitvector(origin(source.ToUri()), source.FileName.WithoutExtension.Format(), items);
        }

        return dst;
    }

    /// <summary>
    /// Defines a bitfield specification that represents a bitvector
    /// </summary>
    /// <param name="name">The bitvector name</param>
    /// <param name="src">The list items that correspond to bits in the vector</param>
    public static BfModel bitvector(BfOrigin origin, string name, ReadOnlySpan<ListItem> src)
    {
        var count = src.Length;
        var segs = alloc<BfSegModel>(count);
        for(var i=0u; i<count; i++)
            seek(segs,i) = seg(skip(src,i).Value.ToString(), i, i, i >= 64 ? BitMask.one(64,63) : BitMask.one((byte)i,(byte)i));
        return model(origin, name, segs);
    }
}
