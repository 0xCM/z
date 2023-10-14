//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static ScalarCast;
using static sys;

[ApiHost]
public readonly struct Sizes
{
    public const ulong BytesPerKb = 1024;

    public const ulong BytesPerMb = 1000*BytesPerKb;

    public const ulong BytesPerGb = 1073741824;

    const ulong BitsPerByte = 8;

    public const ulong BitsPerKb = BytesPerKb*BitsPerByte;

    public const ulong BitsPerMb = 1000*BitsPerKb;

    public const ulong BitsPerGb = 1000*BitsPerMb;

    [Parser]
    public static bool parse(string src, out DataSize dst)
    {
        dst = DataSize.Empty;
        var parts = text.split(text.trim(text.despace(src)), Chars.Space);
        var result = parts.Length == 2;
        if(result)
        {
            result &= uint.TryParse(skip(parts,0), out uint p);
            result &= uint.TryParse(skip(parts,1), out uint n);
            dst = new DataSize(p,n);
        }
        return result;
    }

    [MethodImpl(Inline)]
    public static NativeSize native<T>()
        where T : unmanaged
            => native(width<T>());

    [MethodImpl(Inline)]
    public static uint bits<T>()
        => bits(typeof(T));

    [MethodImpl(Inline)]
    public static DataSize datasize(BitWidth packed)
        => new DataSize(packed,(uint)(packed % 8 == 0 ? packed/8 : (packed/8) + 1));

    [MethodImpl(Inline), Op]
    public static ByteSize size(Mb mb)
        => mb.Count * BytesPerMb;

    [MethodImpl(Inline), Op]
    public static ByteSize size(Gb gb)
        => gb.Count * BytesPerGb;

    [MethodImpl(Inline), Op]
    public static ByteSize size(Kb src)
        => new ByteSize((uint64(src.Count) * BytesPerKb) + uint64(src.Rem)/BitsPerByte);

    [MethodImpl(Inline), Op]
    public static BitWidth bits(Kb src)
    {
        var bits = (ulong)size(src).Bits;
        var rem = (ulong)src.Rem;
        return new BitWidth(bits + rem);
    }

    [MethodImpl(Inline), Op]
    public static BitWidth bits(ulong src)
        => new BitWidth(src);

    [MethodImpl(Inline), Op]
    public static BitWidth bits(long src)
        => new BitWidth(src);

    [MethodImpl(Inline), Op]
    public static BitWidth bits(NativeSizeCode src)
        => src != NativeSizeCode.W80 ? (Pow2.pow((byte)src)*8ul) : 80;

    [MethodImpl(Inline), Op]
    public static BitWidth width(NativeSizeCode src)
        => bits(src);

    [MethodImpl(Inline), Op]
    public static uint bits(NativeTypeWidth src)
    {
        var dst = (uint)src;
        if(dst == 1)
            dst = 8;
        return dst;
    }

    public static uint bits(Type src)
    {
        if(src is null || src == typeof(void) || src == typeof(Null))
            return 0;
        try
        {
            var type = typeof(SizeCalc<>).MakeGenericType(src);
            var method = first(type.StaticMethods().Public());
            return ((uint)method.Invoke(null, sys.empty<object>()))*8;
        }
        catch(Exception)
        {
            return 0;
        }
    }

    [MethodImpl(Inline), Op]
    public static NativeSize native(BitWidth src)
        => Sized.native(src);
    
    public static DataSize measure(Type src)
    {
        var dst = DataSize.Empty;
        var width = bits(src);
        var tag = src.Tag<DataWidthAttribute>();
        if(src.IsEnum)
        {
            width = bits(PrimalBits.width(Enums.@base(src)));
            if(tag)
                dst = new (tag.Value.PackedWidth, width);
            else
                dst = (width, width);
        }
        else
        {
            if(tag)
                dst = new (tag.Value.PackedWidth, width);
            else
                dst = (width,width);
        }
        return dst;
    }

    [MethodImpl(Inline), Op]
    public static DataSize sum(ReadOnlySpan<DataSize> src)
    {
        var dst = DataSize.Zero;
        for(var i=0; i<src.Length; i++)
            dst += skip(src,i);
        return dst;
    }

    [MethodImpl(Inline), Op]
    public static DataSize max(ReadOnlySpan<DataSize> src)
    {
        var dst = DataSize.Zero;
        for(var i=0; i<src.Length; i++)
        {
            ref readonly var x = ref skip(src,i);
            if(x > dst)
                dst = x;
        }
        return dst;
    }

    [MethodImpl(Inline), Op]
    public static ByteSize bytes(NativeSizeCode src)
        => (ByteSize)width(src);

    [MethodImpl(Inline), Op]
    public static ByteSize bytes(ulong src)
        => new ByteSize(src);

    [MethodImpl(Inline), Op]
    public static ByteSize bytes(long src)
        => new ByteSize(src);

    [MethodImpl(Inline), Op]
    public static uint hash(Kb src)
        => src.Count | src.Rem;

    [MethodImpl(Inline), Op]
    public static bool eq(Kb a, Kb b)
        => a.Count == b.Count && a.Rem == b.Rem;

    [MethodImpl(Inline), Op]
    public static bool neq(Kb a, Kb b)
        => a.Count != b.Count || a.Rem != b.Rem;

    [Parser]
    public static Outcome parse(string src, out ByteSize dst)
    {
        if(NumericParser.parse<ulong>(text.remove(src, Chars.Comma), out var x))
        {
            dst = x;
            return true;
        }
        else
        {
            dst = default;
            return false;
        }
    }

    [Parser]
    public static bool parse(string src, out BitWidth dst)
    {
        if(NumericParser.parse<ulong>(src, out var x))
        {
            dst = x;
            return true;
        }
        else
        {
            dst = default;
            return false;
        }
    }

    public static bool parse<T>(string src, out Size<T> dst)
        where T : unmanaged
    {
        if(NumericParser.parse<ulong>(src, out var x))
        {
            dst = new Size<T>(sys.@as<T>(x));
            return true;
        }
        else
        {
            dst = default;
            return false;
        }
    }

    readonly struct SizeCalc<T>
    {
        [MethodImpl(Inline)]
        public static uint calc()
            => (uint)Unsafe.SizeOf<T>();
    }
}
