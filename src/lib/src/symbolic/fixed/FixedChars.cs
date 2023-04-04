//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly struct FixedChars
    {
        [MethodImpl(Inline), Op]
        public static uint hash(text7 src)
            => sys.hash(src.Storage);

        [MethodImpl(Inline),Op, Closures(UnsignedInts)]
        public static uint expr<T>(Symbols<T> src, Span<text7> dst)
            where T : unmanaged
        {
            var count = (uint)min(src.Length, dst.Length);
            var symbols = src.View;
            for(var i=0; i<count; i++)
                seek(dst, i) = txt(n7, skip(symbols,i).Expr.Data);
            return count;
        }

        [Op]
        public static string format(in text7 src)
        {
            Span<char> dst = stackalloc char[text7.MaxLength];
            var count = src.Length;
            var data = src.Bytes;
            for(var i=0; i<count; i++)
                seek(dst, i) = (char)skip(data,i);
            return text.format(slice(dst,0,count));
        }

        [MethodImpl(Inline), Op]
        public static text7 txt(N7 n, ReadOnlySpan<char> src)
        {
            var length = (byte)min(available(src), text7.MaxLength);
            var storage = 0ul;
            var dst = bytes(storage);
            pack(src, length, dst);
            seek(dst,7) = length;
            return new text7(storage);
        }

        [MethodImpl(Inline), Op]
        public static text7 txt(N7 n, ReadOnlySpan<byte> src)
        {
            var length = (byte)min(available(src), text7.MaxLength);
            var storage = 0ul;
            var dst = bytes(storage);
            for(var i=0; i<length; i++)
                seek(dst,i) = skip(src,i);
            seek(dst,7) = length;
            return new text7(storage);
        }

        [Op]
        public static text7 trim(in text7 src)
        {
            var data = src.Bytes;
            var l0 = (int)src.Length;
            var i0 = 0;
            var i1 = l0 - 1;
            for(var i=0; i<l0; i++)
            {
                ref readonly var b = ref skip(data,i);
                if(SQ.whitespace((AsciCode)b))
                    i0++;
                else
                    break;
            }

            for(var i=l0-1; i>=0; i--)
            {
                ref readonly var b = ref skip(data,i);
                if(SQ.whitespace((AsciCode)b))
                    i1--;
                else
                    break;
            }

            var l1 = i1 - i0;
            if(l0 != l1)
                return txt(n7, segment(data, i0, i1));
            else
                return src;
        }

        [MethodImpl(Inline), Op]
        public static text7 txt(N7 n7, char src)
        {
            var storage = (ulong)src;
            return new text7(storage);
        }

        [MethodImpl(Inline), Op]
        public static bool eq(text47 a, text47 b)
        {
            var aBytes = a.Storage.Bytes;
            var bBytes = b.Storage.Bytes;
            var a256 = vcpu.vload(w256, slice(aBytes,0, 32));
            var b256 = vcpu.vload(w256, slice(bBytes,0, 32));
            var result = vcpu.vtestc(vcpu.veq(a256,b256));
            if(result)
            {
                var a128 = vcpu.vload(w128, slice(aBytes,32, 16));
                var b128 = vcpu.vload(w128, slice(bBytes,32, 16));
                result = vcpu.vtestc(vcpu.veq(a128,b128));
            }
            return result;
        }

        [MethodImpl(Inline), Op]
        public static bool eq(text7 a, text7 b)
            => a.Storage == b.Storage;

        [MethodImpl(Inline), Op]
        public static bool neq(text7 a, text7 b)
            => a.Storage != b.Storage;

        [MethodImpl(Inline), Op]
        public static text15 txt(N15 n, ReadOnlySpan<char> src)
        {
            const byte Max = text15.MaxLength;
            var length = (byte)min(available(src), Max);
            var storage = text15.StorageType.Empty;
            var dst = storage.Bytes;
            pack(src, length, dst);
            seek(dst,Max) = length;
            return new text15(storage);
        }

        [MethodImpl(Inline), Op]
        public static text15 txt(N15 n, ReadOnlySpan<byte> src)
        {
            const byte Max = text15.MaxLength;
            var length = (byte)min(available(src), Max);
            var storage = text15.StorageType.Empty;
            var dst = storage.Bytes;
            for(var i=0; i<length; i++)
                seek(dst,i) = skip(src,i);
            seek(dst,Max) = length;
            return new text15(storage);
        }

        [Op]
        public static string format(in text15 src)
        {
            Span<char> dst = stackalloc char[text15.MaxLength];
            var count = src.Length;
            var data = src.Bytes;
            for(var i=0; i<count; i++)
                seek(dst,i) = (char)skip(data,i);
            return text.format(slice(dst,0,count));
        }

        [Op]
        public static text15 trim(in text15 src)
        {
            var data = src.Bytes;
            var l0 = (int)src.Length;
            var i0 = 0;
            var i1 = l0 - 1;
            for(var i=0; i<l0; i++)
            {
                ref readonly var b = ref skip(data,i);
                if(SQ.whitespace((AsciCode)b))
                    i0++;
                else
                    break;
            }
            for(var i=l0-1; i>=0; i--)
            {
                ref readonly var b = ref skip(data,i);
                if(SQ.whitespace((AsciCode)b))
                    i1--;
                else
                    break;
            }

            var l1 = i1 - i0;
            if(l0 != l1)
                return txt(n15, segment(data, i0, i1));
            else
                return src;

        }

        [MethodImpl(Inline), Op]
        public static text31 txt(N31 n, ReadOnlySpan<char> src)
        {
            const byte Max = text31.MaxLength;
            var length = (byte)min(available(src), Max);
            var storage = text31.StorageType.Empty;
            var dst = storage.Data;
            pack(src, length, dst);
            seek(dst,Max) = length;
            return new text31(storage);
        }

        [MethodImpl(Inline), Op]
        public static text31 txt(N31 n, ReadOnlySpan<byte> src)
        {
            const byte Max = text31.MaxLength;
            var length = (byte)min(available(src), Max);
            var storage = text31.StorageType.Empty;
            var dst = storage.Data;
            for(var i=0; i<length; i++)
                seek(dst,i) = skip(src,i);
            seek(dst,Max) = length;
            return new text31(storage);
        }

        [Op]
        public static string format(in text31 src)
        {
            Span<char> dst = stackalloc char[text31.MaxLength];
            var count = src.Length;
            var data = src.Cells;
            for(var i=0; i<count; i++)
                seek(dst,i) = (char)skip(data,i);
            return text.format(slice(dst,0,count));
        }

        [MethodImpl(Inline), Op]
        public static text47 txt(N47 n, ReadOnlySpan<char> src)
        {
            const byte Max = text47.MaxLength;
            var length = (byte)min(available(src), Max);
            var storage = text47.StorageType.Empty;
            var dst = storage.Bytes;
            pack(src, length, dst);
            seek(dst,Max) = length;
            return new text47(storage);
        }

        [MethodImpl(Inline), Op]
        public static text47 txt(N47 n, ReadOnlySpan<byte> src)
        {
            const byte Max = text47.MaxLength;
            var length = (byte)min(available(src), Max);
            var storage = text47.StorageType.Empty;
            var dst = storage.Bytes;
            for(var i=0; i<length; i++)
                seek(dst,i) = skip(src,i);
            seek(dst,Max) = length;
            return new text47(storage);
        }

        [Op]
        public static string format(in text47 src)
        {
            Span<char> dst = stackalloc char[text47.MaxLength];
            var count = src.Length;
            var data = src.Bytes;
            for(var i=0; i<count; i++)
                seek(dst,i) = (char)skip(data,i);
            return text.format(slice(dst,0,count));
        }

        [MethodImpl(Inline), Op]
        public static uint hash(in text47 src)
            => sys.hash(src.Bytes);

        [MethodImpl(Inline), Op]
        static uint available(ReadOnlySpan<char> src)
        {
            var present = 0u;
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                if(skip(src,i) != 0)
                    present++;
                else
                    break;
            }
            return present;
        }

        [MethodImpl(Inline), Op]
        static uint available(ReadOnlySpan<byte> src)
        {
            var present = 0u;
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                if(skip(src,i) != 0)
                    present++;
                else
                    break;
            }
            return present;
        }

        [MethodImpl(Inline), Op]
        static void pack(ReadOnlySpan<char> src, uint count, Span<byte> dst)
        {
            for(var i=0; i<count; i++)
                seek(dst,i) = (byte)skip(src,i);
        }
    }
}