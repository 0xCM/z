//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

[ApiHost]
public readonly partial struct Bitfields
{
    const NumericKind Closure = UnsignedInts;

    [MethodImpl(Inline)]
    public static BitSegType segtype(NativeClass @class, ushort total, ushort cell)
        => new (@class, total, cell == 0 ? (ushort)1 : cell);

    public static void emit(IWfChannel channel, ReadOnlySeq<BitMaskInfo> src)
        => channel.TableEmit(src, AppDb.Service.ApiTargets().Table<BitMaskInfo>());

    public static void emit(IWfChannel channel, string name, ReadOnlySpan<BpInfo> src, IDbArchive dst)
    {
        var emitter = text.emitter();
        for(var i=0u; i<src.Length; i++)
            BitPatterns.render(skip(src,i), i, emitter);
        channel.FileEmit(emitter.Emit(), 12, dst.Path(name, FileKind.Txt));
    }

}
