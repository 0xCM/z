//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

[ApiHost]
public partial class PolyBits : AppService<PolyBits>
{
    const NumericKind Closure = UInt64k;

    public Index<BitMaskInfo> ApiBitMasks
        => Data("BitMasks", () => BitMask.masks(typeof(BitMaskLiterals)));

    public void Emit(Index<BitMaskInfo> src)
        => Channel.TableEmit(src, AppDb.Service.ApiTargets().Table<BitMaskInfo>());

    public ReadOnlySeq<BfModel> BvEmit(IDbArchive sources, string filter, FolderPath dst)
        => BvEmit(bitvectors(sources, filter), dst);

    public ReadOnlySeq<BfModel> BvEmit(ReadOnlySeq<BfModel> src, FolderPath dst)
    {
        dst.Clear();
        var count = src.Count;
        for(var i=0; i<count; i++)
        {
            ref readonly var bv = ref src[i];
            var target = dst + FS.file(bv.Name, FS.ext("bv"));
            var msg = string.Format("{0} -> {1}", bv.Origin, target.ToUri());
            Channel.FileEmit(bv, msg, target);
        }
        return src;
    }

    public void EmitPatterns(Type src, IDbArchive dst)
    {
        var attrib = src.Tag<LiteralProviderAttribute>();
        var name = attrib ? text.ifempty(attrib.Value.Group, src.Name) : src.Name;
        var patterns = BitPatterns.reflected(src);
        EmitDescriptions(name, patterns, dst);
        EmitRecords(name, patterns, dst);
    }

    public void EmitDescriptions(string name, ReadOnlySpan<BpInfo> src, IDbArchive dst)
    {
        var emitter = text.emitter();
        for(var i=0u; i<src.Length; i++)
            render(skip(src,i), i, emitter);
        Channel.FileEmit(emitter.Emit(), 12, dst.Path(name, FileKind.Txt));
    }

    public void EmitRecords(string name, ReadOnlySpan<BpInfo> src, IDbArchive dst)
    {
        var count = src.Length;
        var specs = alloc<BpSpec>(count);
        var segs = BitPatterns.segs(src);
        for(var i=0; i<src.Length; i++)
            seek(specs,i) = skip(src,i).Spec;
        Channel.TableEmit(segs, dst.PrefixedTable<BpSeg>(name));
        Channel.TableEmit(specs, dst.PrefixedTable<BpSpec>(name));
    }

    public static Index<CharBlock8> BitBlocks(W8 w, byte start = 0, byte end = byte.MaxValue)
    {
        var count = end - start + 1;
        var buffer = alloc<CharBlock8>(count);
        ref var dst = ref first(buffer);
        var k = 0;
        for(uint i=start; i<=end; i++, k++)
        {
            var block = CharBlock8.Null;
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
            var block = CharBlock16.Null;
            var data = block.Data;
            for(var j=0; j<16; j++)
                seek(data,j) = bit.test(i,(byte)j).ToChar();
            block.Data.Invert();
            seek(dst,k) = block;
        }

        return buffer;
    }
}
