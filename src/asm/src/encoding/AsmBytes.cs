//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm;

using static sys;

using Asm;

[ApiHost]
public class AsmBytes
{
    const NumericKind Closure = UnsignedInts;

    public static string format<T>(T src)
        where T : unmanaged, IAsmByte
            => src.Value().FormatHex(zpad:true, specifier:true, uppercase:true);

    [MethodImpl(Inline), Op]
    public static ByteSize size(ReadOnlySpan<HexDataRow> src)
    {
        var dst = 0ul;
        for(var i=0; i<src.Length; i++)
            dst += skip(src,i).Data.Count;
        return dst;
    }

    [MethodImpl(Inline), Op]
    public static ByteSize size(ReadOnlySpan<BinaryCode> src)
    {
        var dst = 0ul;
        for(var i=0; i<src.Length; i++)
            dst += skip(src,i).Count;
        return dst;
    }
    
    [Op]
    public static bool parse(ReadOnlySpan<char> src, out AsmHexCode dst)
    {
        var buffer = ByteBlock16.Empty;
        var bytes = sys.bytes(buffer);
        var result = Hex.parse(src, bytes);
        if(result)
        {
            var size = Demand.lteq((byte)result.Data,(byte)15);
            var data = slice(bytes,0,size);
            seek(bytes,15) = size;
            dst = new AsmHexCode(@as<ByteBlock16,Cell128>(buffer));
        }
        else
            dst = AsmHexCode.Empty;
        return result;
    }

    [Op]
    public static Outcome hexdat(FilePath src, out BinaryCode dst)
    {
        var result = Outcome.Success;
        var cells = src.ReadLines().SelectMany(x => text.split(x,Chars.Space));
        var count = cells.Count;
        var data = sys.alloc<byte>(count);
        for(var i=0; i<count; i++)
        {
            ref readonly var cell = ref cells[i];
            result = Hex.parse8u(cell, out seek(data,i));
            if(result.Fail)
                break;
        }
        if(result)
            dst = data;
        else
            dst = BinaryCode.Empty;
        return result;
    }

    [MethodImpl(Inline), Op]
    public static MemoryBlock max(ReadOnlySpan<MemoryBlock> src)
    {
        var max = MemoryBlock.Empty;
        var count = src.Length;
        if(count == 0)
            return max;
        for(var i=0; i<count; i++)
        {
            ref readonly var block = ref skip(src,i);
            if(block.Size > max.Size)
                max = block;
        }
        return max;
    }

    [Op]
    public static EncodedMember member(in ApiEncoded src)
    {
        var token = src.Token;
        var dst = new EncodedMember();
        dst.Id = token.Id;
        dst.EntryAddress = token.EntryAddress;
        dst.TargetAddress = token.TargetAddress;
        if(token.EntryAddress != token.TargetAddress)
        {
            dst.Disp = AsmRel.disp32((token.EntryAddress, JmpRel32.InstSize), token.TargetAddress);
            dst.StubAsm = string.Format("jmp near ptr {0:x}h", (int)AsmRel.target(dst.Disp));
        }
        dst.CodeSize = (ushort)src.Code.Size;
        dst.Sig = token.Sig.Format();
        dst.Uri = token.Uri.Format();
        var result = ApiIdentity.parse(dst.Uri, out var uri);
        if(result.Fail)
            Errors.Throw(AppMsg.ParseFailure.Format(nameof(uri), dst.Uri));
        dst.Host = uri.Host.Format();
        return dst;
    }

    [Op]
    public static MemoryAddress stub(MemoryAddress src, out AsmHexCode stub)
    {
        const byte StubSize = JmpRel32.InstSize;
        stub = AsmHexCode.Empty;
        var target = src;
        var buffer = sys.bytes(Cells.alloc(w64));
        ref var data = ref src.Ref<byte>();
        ByteReader.read6(data, buffer);
        if(JmpRel32.test(buffer))
        {
            stub = asm.asmhex(slice(buffer, 0, StubSize));
            AsmRip rip = (src, StubSize);
            target = AsmRel.target(rip, stub.Bytes);
        }
        return target;
    }

    [MethodImpl(Inline), Op]
    public static void pack(in EncodingOffsets src, Span<byte> dst)
    {
        var offsets = @readonly(bytes(src));
        pack4x4(skip(offsets,0), skip(offsets,1), skip(offsets,2), skip(offsets,3), ref seek16(dst,0));
        pack4x2(skip(offsets,4), skip(offsets,5), ref seek(dst,4));
    }

    [MethodImpl(Inline), Op]
    static ref byte pack4x2(byte a, byte b, ref byte dst)
    {
        dst = (byte)((a & 0xF) | (b >> 4));
        return ref dst;
    }

    [MethodImpl(Inline), Op]
    static ref ushort pack4x4(byte a0, byte a1, byte a2, byte a3, ref ushort dst)
    {
        dst = (ushort)((a0 & 0xF) | ((a1 & 0xF0) >> 4)  | ((a2 & 0xF00) >> 8)  | ((a3 & 0xF000) >> 12));
        return ref dst;
    }
    
    [MethodImpl(Inline), Op]
    public static ModRm modrm(byte mod, byte reg, byte rm)
        => new (join((rm, 0), (reg, 3), (mod, 6)));

    [MethodImpl(Inline), Op]
    public static ModRm modrm(RegIndex reg, RegIndex rm)
        => modrm(0b11, (byte)reg, (byte)rm);

    [MethodImpl(Inline), Op]
    public static ModRm modrm(byte mod, RegIndex reg, RegIndex rm)
        => modrm(mod, (byte)reg, (byte)rm);

    [MethodImpl(Inline), Op]
    public static Sib sib(num3 @base, num3 index, num2 scale)
        => new (join((scale, 0), (index, 2), (@base, 6)));

    public static string bitstring(Sib src)
        => string.Format("{0} {1} {2}", BitRender.format2(src.Scale), BitRender.format3(src.Index), BitRender.format3(src.Base));

    [MethodImpl(Inline), Op]
    static uint sib(Sib src, ref uint i, Span<char> dst)
    {
        const string FieldSep = " | ";
        var i0=i;
        BitRender.render2(src.Scale, ref i, dst);
        text.copy(FieldSep, ref i, dst);

        BitRender.render3(src.Index, ref i, dst);
        text.copy(FieldSep, ref i, dst);

        BitRender.render3(src.Base, ref i, dst);

        text.copy(FieldSep, ref i, dst);

        text.copy(src.Value().FormatHex(2), ref i, dst);
        seek(dst,i++) = Chars.Space;
        text.copy(FieldSep, ref i, dst);

        text.copy(bitstring(src), ref i, dst);

        return i-i0;
    }

    [Op]
    public static uint SibTable(Span<char> dst)
    {
        const string Header = "scale | index | base | hex | bitstring";

        var m=0u;
        text.copy(Header, ref m, dst);
        text.crlf(ref m, dst);

        var f0 = BitSeq.bits(n3);
        var f1 = BitSeq.bits(n3);
        var f2 = BitSeq.bits(n2);

        for(var k=0; k<f2.Length; k++)
        {
            for(var j=0; j<f1.Length; j++)
            {
                for(var i=0; i<f0.Length; i++)
                {
                    var b0 = skip(f0, i);
                    var b1 = skip(f1, j);
                    var b2 = skip(f2, k);
                    sib(new Sib(Numbers.pack(b0,b1,b2)), ref m, dst);
                    text.crlf(ref m, dst);
                }
            }
        }
        return m;
    }

    public static Index<SibRegCodes> SibRegCodes()
    {
        var count = 256*4;
        var dst = sys.alloc<SibRegCodes>(count);
        var offset = 0u;
        offset += SibRegCodes(RegClassCode.GP, NativeSizeCode.W8, offset, dst);
        offset += SibRegCodes(RegClassCode.GP, NativeSizeCode.W16, offset, dst);
        offset += SibRegCodes(RegClassCode.GP, NativeSizeCode.W32, offset, dst);
        offset += SibRegCodes(RegClassCode.GP, NativeSizeCode.W64, offset, dst);
        return dst;
    }

    public static Index<SibBitfieldRow> SibRows()
    {
        var buffer = sys.alloc<SibBitfieldRow>(256);
        var f0 = BitSeq.nbits(n3);
        var f1 = BitSeq.nbits(n3);
        var f2 = BitSeq.nbits(n2);
        ref var dst = ref first(buffer);
        var m = 0u;
        for(var k=0; k<f2.Length; k++)
        {
            for(var j=0; j<f1.Length; j++)
            {
                for(var i=0; i<f0.Length; i++)
                {
                    ref var row = ref seek(dst,m);
                    row.@base = skip(f0, i);
                    row.index = skip(f1, j);
                    row.scale = skip(f2, k);
                    var sib = new Sib(Numbers.pack(row.@base, row.index, row.scale));
                    row.bitstring = bitstring(sib);
                    row.hex = (byte)m;
                    m++;
                }
            }
        }
        return buffer;
    }

    public static Index<SibRegCodes> SibRegCodes(RegClassCode @class, NativeSize size)
    {
        var buffer = sys.alloc<SibRegCodes>(256);
        SibRegCodes(@class,size,0,buffer);
        return buffer;
    }

    public static uint SibRegCodes(RegClassCode @class, NativeSize size, uint offset, Span<SibRegCodes> buffer)
    {
        var f0 = BitSeq.bits(n3);
        var f1 = BitSeq.bits(n3);
        var f2 = BitSeq.bits(n2);
        ref var dst = ref first(buffer);
        var counter = 0u;
        var q = offset;
        for(var k=0; k<f2.Length; k++)
        {
            for(var j=0; j<f1.Length; j++)
            {
                for(var i=0; i<f0.Length; i++, counter++, q++)
                {
                    ref var row = ref seek(dst, q);
                    var @base = skip(f0, i);
                    var index = skip(f1, j);
                    var scale = skip(f2,k);
                    row.Base = AsmRegs.name(size, @class, (RegIndexCode)(byte)@base);
                    row.Index  = AsmRegs.name(size, @class, (RegIndexCode)(byte)index);
                    row.Scale = scale;
                    var sib = new Sib(Numbers.pack(@base, index, scale));
                    row.Bits = bitstring(sib);
                    row.Hex= (byte)counter;
                }
            }
        }
        return counter;
    }

    [MethodImpl(Inline), Op]
    public static BinaryCode code(in CodeBlock src, uint offset, byte size)
        => sys.slice(src.View, offset, size).ToArray();

    [MethodImpl(Inline), Op]
    public static void encode(RexPrefix a0, Hex8 a1, Imm64 a2, AsmHexWriter dst)
        => dst.Write(a0,a1,a2);

    [MethodImpl(Inline), Op]
    public static byte encode(RexPrefix a0, Hex8 a1, Imm64 a2, Span<byte> dst)
    {
        var i = z8;
        seek(dst,i++) = (byte)a0;
        seek(dst,i++) = a1;
        seek64(dst,i) = a2;
        i+=8;
        return i;
    }

    [MethodImpl(Inline), Op]
    public static byte join(Pair<byte> a, Pair<byte> b, Pair<byte> c)
    {
        var dst = Bytes.sll(a.Left, a.Right);
        dst = Bytes.or(dst, Bytes.sll(b.Left, b.Right));
        dst = Bytes.or(dst, Bytes.sll(c.Left, c.Right));
        return dst;
    }
}
