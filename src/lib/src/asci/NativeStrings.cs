//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost, Free]
    public class NativeStrings
    {
        [MethodImpl(Inline)]
        static ref readonly T @as<S,T>(ReadOnlySpan<S> src)
            where S : unmanaged
            where T : unmanaged
                => ref first(sys.recover<S,T>(src));

        [MethodImpl(Inline)]
        public static @string<C> @string<C>(in C src)
            where C : unmanaged, ICharBlock<C>
                => new @string<C>(src);

        [MethodImpl(Inline)]
        public static NativeString<K,B> load<K,B>(ReadOnlySpan<char> src)
            where K : unmanaged, IEquatable<K>, IComparable<K>
            where B : unmanaged, IStorageBlock<B>
        {
            var data = sys.recover<byte>(src);
            var dst = NativeString<K,B>.Empty;
            if(data.Length >= NativeString<K,B>.StorageSize)
                dst = new NativeString<K,B>(@as<byte,B>(data));
            else
                dst = new NativeString<K,B>(Storage.block<B>(data));
            return dst;
        }

        [MethodImpl(Inline)]
        public static AsciString<B> asci<B>(ReadOnlySpan<byte> src)
            where B : unmanaged, IStorageBlock<B>
        {
            var data = src;
            var dst = AsciString<B>.Empty;
            if(data.Length >= AsciString<B>.StorageSize)
                dst = new AsciString<B>(@as<byte,B>(data));
            else
                dst = new AsciString<B>(Storage.block<B>(data));
            return dst;
        }

        [MethodImpl(Inline)]
        public static AsciString<B> load<B>(ReadOnlySpan<AsciSymbol> src)
            where B : unmanaged, IStorageBlock<B>
                => asci<B>(sys.recover<AsciSymbol,byte>(src));

        [MethodImpl(Inline)]
        public static AsciString<B> load<B>(ReadOnlySpan<AsciCode> src)
            where B : unmanaged, IStorageBlock<B>
                => asci<B>(recover<AsciCode,byte>(src));

        [MethodImpl(Inline)]
        public static NativeString<K,B> load<K,B>(string src)
            where K : unmanaged, IEquatable<K>, IComparable<K>
            where B : unmanaged, IStorageBlock<B>
                => load<K,B>(sys.span(src));

        public static uint lines<K,B>(string src, Span<NativeString<K,B>> dst, bool keepblank = false, bool trim = true)
            where B : unmanaged, IStorageBlock<B>
            where K : unmanaged, IEquatable<K>, IComparable<K>
        {
            var k=0u;
            var capacity = (uint)dst.Length;
            using(var reader = new StringReader(src))
            {
                var next = reader.ReadLine();
                while(next != null && k<capacity)
                {
                    if(Z0.text.blank(next))
                        if(keepblank)
                            seek(dst,k++) = load<K,B>(next);
                    else
                        seek(dst, k++) = load<K,B>(trim ? text.trim(next) : next);
                    next = reader.ReadLine();
                }
            }
            return k;
        }

        [MethodImpl(Inline), Op]
        public static uint lines<C>(string src, Span<@string<C>> dst, bool keepblank = false, bool trim = true)
            where C : unmanaged, ICharBlock<C>
        {
            var k=0u;
            var capacity = (uint)dst.Length;
            using(var reader = new StringReader(src))
            {
                var next = reader.ReadLine();
                while(next != null && k<capacity)
                {
                    if(text.blank(next))
                        if(keepblank)
                            seek(dst,k++) = next;
                    else
                        seek(dst, k++) = trim ? text.trim(next) : next;
                    next = reader.ReadLine();
                }
            }
            return k;
        }

        [MethodImpl(Inline), Op]
        public static @string<CharBlock1> c16(N1 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static @string<CharBlock2> c16(N2 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static @string<CharBlock3> c16(N3 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static @string<CharBlock4> c16(N4 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static @string<CharBlock5> c16(N5 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static @string<CharBlock6> c16(N6 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static @string<CharBlock7> c16(N7 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static @string<CharBlock8> c16(N8 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static @string<CharBlock9> c16(N9 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static @string<CharBlock10> c16(N10 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static @string<CharBlock11> c16(N11 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static @string<CharBlock12> c16(N12 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static @string<CharBlock13> c16(N13 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static @string<CharBlock14> c16(N14 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static @string<CharBlock15> c16(N15 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static @string<CharBlock16> c16(N16 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static @string<CharBlock24> c16(N24 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static @string<CharBlock32> c16(N32 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static @string<CharBlock48> c16(N48 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static @string<CharBlock64> c16(N64 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static @string<CharBlock80> c16(N80 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static @string<CharBlock84> c16(N84 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static @string<CharBlock128> c16(N128 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static @string<CharBlock256> c16(N256 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static @string<CharBlock512> c16(N512 n, string src = EmptyString)
            => src;
    }
}