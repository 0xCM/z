//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class PolyBits
    {
        public static Index<BfModel> bitvectors(IDbSources sources, string filter)
            => bitvectors(sources.Files(FileKind.Csv).Where(f => f.FileName.StartsWith(filter)));

        struct BvParser : IParser<object>
        {
            public static BvParser Service => default;

            public Outcome Parse(string src, out object dst)
            {
                dst = src;
                return true;
            }
        }

        public static Index<BfModel> bitvectors(Files src)
        {
            var items = sys.empty<ListItem>();
            var counter = 0u;
            var count = src.Count;
            var bitfields = alloc<BfModel>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var source = ref src[i];
                ItemLists.list(source, true, Chars.Pipe, BvParser.Service, out items).Require();
                seek(bitfields, i) = bitvector(origin(source.ToUri()), source.FileName.WithoutExtension.Format(), items);
            }

            return bitfields;
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
}