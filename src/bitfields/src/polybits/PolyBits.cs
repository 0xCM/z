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
        => Data("BitMasks", () => Bitfields.masks(typeof(BitMaskLiterals)));

    public void Emit(Index<BitMaskInfo> src)
        => Channel.TableEmit(src, AppDb.Service.ApiTargets().Table<BitMaskInfo>());

    public ReadOnlySeq<BfDef> BvEmit(IDbArchive sources, string filter, FolderPath dst)
        => BvEmit(Bitfields.bitvectors(sources, filter), dst);

    public ReadOnlySeq<BfDef> BvEmit(ReadOnlySeq<BfDef> src, FolderPath dst)
    {
        dst.Clear();
        var count = src.Count;
        for(var i=0; i<count; i++)
        {
            ref readonly var bv = ref src[i];
            // var target = dst + FS.file(bv.Name, FS.ext("bv"));
            // var msg = string.Format("{0} -> {1}", bv.Origin, target.ToUri());
            // Channel.FileEmit(bv, msg, target);
        }
        return src;
    }

    public void EmitDescriptions(string name, ReadOnlySpan<BpInfo> src, IDbArchive dst)
    {
        var emitter = text.emitter();
        for(var i=0u; i<src.Length; i++)
            BitPatterns.render(skip(src,i), i, emitter);
        Channel.FileEmit(emitter.Emit(), 12, dst.Path(name, FileKind.Txt));
    }

    public static Index<CharBlock8> blocks(W8 w, byte start = 0, byte end = byte.MaxValue)
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

    public static Index<CharBlock16> blocks(W16 w, ushort start = 0, ushort end = ushort.MaxValue)
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
