//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static sys;
    using static ApiAtomic;

    [ApiHost]
    public partial class PolyBits : WfSvc<PolyBits>
    {
        const NumericKind Closure = UInt64k;

        DbArchive Targets => AppDb.DbOut().Targets(polybits);

        [CmdOp("api/emit/bitmasks")]
        void EmitApiBitMasks()
            => Emit(ApiBitMasks);

        public Index<BitMaskInfo> ApiBitMasks
            => Data("BitMasks", () => BitMask.masks(typeof(BitMaskLiterals)));


        public void Emit(Index<BitMaskInfo> src)
            => TableEmit(src, AppDb.ApiTargets().Table<BitMaskInfo>());

        public Index<BfModel> BvEmit(DbSources sources, string filter, FolderPath dst)
            => BvEmit(PolyBits.bitvectors(sources, filter), dst);

        public Index<BfModel> BvEmit(Index<BfModel> src, FolderPath dst)
        {
            dst.Clear();
            var count = src.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var bv = ref src[i];
                ref readonly var name = ref bv.Name;
                var target = dst + FS.file(name.Format(), FS.ext("bv"));
                var msg = string.Format("{0} -> {1}", bv.Origin, target.ToUri());
                FileEmit(bv, msg, target);
            }
            return src;
        }

        public void EmitPatterns()
        {
            var types = array(typeof(AsmBitPatterns));
            iter(types, EmitPatterns);
        }

        public void EmitPatterns(Type src)
        {
            var attrib = src.Tag<LiteralProviderAttribute>();
            var name = attrib ? text.ifempty(attrib.Value.Group, src.Name) : src.Name;
            var patterns = BitPatterns.reflected(src);
            EmitDescriptions(name, patterns);
            EmitRecords(name, patterns);
        }

        public void EmitDescriptions(string name, ReadOnlySpan<BpInfo> src)
        {
            var dst = text.emitter();
            for(var i=0u; i<src.Length; i++)
                PbRender.render(skip(src,i), i, dst);
            FileEmit(dst.Emit(), 12, Targets.Path(name, FileKind.Txt));
        }

        public void EmitRecords(string name, ReadOnlySpan<BpInfo> src)
        {
            var count = src.Length;
            var specs = alloc<BpSpec>(count);
            var segs = BitPatterns.segs(src);
            for(var i=0; i<src.Length; i++)
                seek(specs,i) = skip(src,i).Spec;
            TableEmit(segs, Targets.PrefixedTable<BpSeg>(name));
            TableEmit(specs, Targets.PrefixedTable<BpSpec>(name));
        }

        public static Index<CharBlock8> BitBlocks(W8 w, byte start = 0, byte end = byte.MaxValue)
        {
            var count = end - start + 1;
            var buffer = alloc<CharBlock8>(count);
            ref var dst = ref first(buffer);
            var k = 0;
            for(uint i=start; i<=end; i++, k++)
            {
                var block = Storage.chars(n8);
                var data = block.Data;
                for(var j=0; j<8; j++)
                    seek(data,j) = bit.test(i,(byte)j).ToChar();
                block.Data.Invert();
                seek(dst,k) = block;
            }

            return buffer;
        }

        public static Index<CharBlock16> BitBlocks(W16 w, ushort start = 0, ushort end = ushort.MaxValue)
        {
            var count = end - start + 1;
            var buffer = alloc<CharBlock16>(count);
            ref var dst = ref first(buffer);
            var k = 0;
            for(uint i=start; i<=end; i++, k++)
            {
                var block = Storage.chars(n16);
                var data = block.Data;
                for(var j=0; j<16; j++)
                    seek(data,j) = bit.test(i,(byte)j).ToChar();
                block.Data.Invert();
                seek(dst,k) = block;
            }

            return buffer;
        }
    }
}