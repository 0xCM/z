//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;
using static sys;

public unsafe class ApiRes
{
    [MethodImpl(Inline), Op]
    public static byte extract(SpanResAccessor src, out ByteBlock16 dst)
    {
        dst = ByteBlock16.Empty;
        var seg = ApiRes.data(src);
        var size = (byte)seg.Size;
        var data = cover<byte>(seg.BaseAddress.Pointer<byte>(), seg.Size);
        for(var i=0; i<size; i++)
            dst[i] = skip(data,i);
        return size;
    }

    [Op]
    public static MemorySegment data(SpanResAccessor src)
        => AccessorData(AsmBytes.stub(src.Member.Location, out _));

    [Op]
    public static MemorySegment code(SpanResAccessor src)
        => new (AsmBytes.stub(src.Member.Location, out _), 24);

    /// <summary>
    /// Queries the source type for ByteSpan property getters
    /// </summary>
    /// <param name="src">The type to query</param>
    [Op]
    public void FindAccessors(SymbolDispenser symbols, Type src, List<CapturedAccessor> dst)
    {
        var candidates = src.StaticProperties()
                .Ignore()
                .WithPropertyType(ResAccessorTypes)
                .Select(p => p.GetGetMethod(true))
                .Where(m  => m != null)
                .Concrete();
        var count = candidates.Length;
        for(var i=0; i<count; i++)
        {
            var target = ClrJit.jit(skip(candidates,i));
        }
    }

    static Type ByteSpanAcessorType
        => typeof(ReadOnlySpan<byte>);

    static Type CharSpanAcessorType
        => typeof(ReadOnlySpan<char>);

    static Type[] ResAccessorTypes
        => new Type[]{ByteSpanAcessorType, CharSpanAcessorType};

    // 24 bytes: [48 b8 c0 f3 bf 2b 38 01 00 00] [48 89 01] [c7 41 08 20 00 00 00] [48 8b c1 c3]
    // 0 | 00 | mov r64,imm64       # 10        | [48 b8] [c0 f3 bf 2b 38 01 00 00]
    // 1 | 10 | mov [rcx],rax       # 3         | 48 89 01
    // 2 | 13 | mov r/m32, imm32    # 7         | [c7 41 08] 20 00 00 00
    // 3 | 20 | mov r64, r/m64      # 3         | 48 8b c1
    // 4 | 23 ret                   # 1         | c3
    static MemorySegment AccessorData(MemoryAddress dst)
    {
        var data = cover(dst.Pointer<byte>(), 24);
        var address = @as<MemoryAddress>(slice(data,2,8));
        return new (address, @as<uint>(slice(data, 13 + 3, 4)));
    }
}
