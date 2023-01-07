//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public readonly partial struct AsciG
    {
        [Op,Closures(UInt8k)]
        public static AsciGrid<T> grid<T>(Symbols<T> src, uint width)
            where T : unmanaged
        {
            var count = src.Count;
            var size = count*width;
            var dst = alloc<byte>(size);
            var offset = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var symbol = ref src[i];
                offset += AsciG.encode(w8, n5, symbol.Expr, symbol.Kind, offset, dst);
            }
            return new AsciGrid<T>(Asci.seq(dst), width);
        }

        [Op, Closures(UInt8k)]
        public static ReadOnlySpan<byte> row<T>(AsciGrid<T> src, uint index)
            where T : unmanaged
                => slice(src.Rows, index*src.RowWidth, src.RowWidth);

        [Op, Closures(UInt8k)]
        public static ReadOnlySpan<byte> row(AsciGrid src, uint index)
            => slice(src.Rows, index*src.RowWidth, src.RowWidth);

        public static Outcome parse<S,N>(string src, N n, out S dst)
            where S : struct, IAsciSeq<S,N>
            where N : unmanaged, ITypeNat
        {
            var result = Outcome.Success;
            dst = new();
            var input = text.ifempty(src, EmptyString);
            if(input.Length > (int)n.NatValue)
                result = (false, AppMsg.CapacityExceeded(src,n).Format());
            else
                encode<S,N>(src, out dst);
            return result;
        }

        [Op, Closures(UInt8k)]
        public static AsciSeq seq<T>(W8 w, in Sym<T> src)
            where T : unmanaged
                => seq(w, n5, src.Expr, src.Kind);

        public static AsciSeq seq<T>(W8 w, N5 n, in SymExpr src, T kind)
            where T : unmanaged
        {
            const string RenderPattern = "{0,-2} {1,-4} {2,-2} {3,-5}";
            var index = u8(kind);
            var bits = BitRender.format5(index);
            var hex = index.FormatHex(specifier:false);
            var desc = string.Format(RenderPattern,index, src, hex, bits);
            var width = desc.Length;
            var dst = alloc<byte>(width);
            Asci.encode(desc, dst);
            return Asci.seq(dst);
        }

        public static uint encode<T>(W8 w, N5 n, in SymExpr symbol, T kind, uint offset, Span<byte> dst)
            where T : unmanaged
        {
            const string RenderPattern = "{0,-2} {1,-4} {2,-2} {3,-5}";
            var index = u8(kind);
            var bits = BitRender.format5(index);
            var hex = index.FormatHex(specifier:false);
            var desc = string.Format(RenderPattern,index, symbol, hex, bits);
            var width = desc.Length;
            Asci.encode(desc, slice(dst,offset));
            return (uint)width;
        }

        public static void encode<S,N>(string src, out S dst)
            where S : struct, IAsciSeq<S,N>
            where N : unmanaged, ITypeNat
        {
            dst = new();
            if(typeof(N) == typeof(N2))
                dst = @as<asci2,S>((asci2)src);
            else if(typeof(N) == typeof(N4))
                dst = @as<asci4,S>((asci4)src);
            else if(typeof(N) == typeof(N8))
                dst = @as<asci8,S>((asci8)src);
            else if(typeof(N) == typeof(N16))
                dst = @as<asci16,S>((asci16)src);
            else if(typeof(N) == typeof(N32))
                dst = @as<asci32,S>((asci32)src);
            else if(typeof(N) == typeof(N64))
                dst = @as<asci64,S>((asci64)src);
            else
                throw no<S>();
        }

        [MethodImpl(Inline)]
        public static bool contains<T>(in T src, AsciCharSym match)
            where T : unmanaged,IAsciSeq
        {
            var code = (byte)match;
            var count = src.Length;
            var data = sys.bytes(src);
            for(var i=0; i<count; i++)
                if(skip(data,i) == code)
                    return true;
            return false;
        }

        [MethodImpl(Inline)]
        public static int index<T>(in T src, AsciCharSym match)
            where T : unmanaged, IAsciSeq
        {
            var code = (byte)match;
            var count = src.Length;
            var data = sys.bytes(src);
            for(var i=0; i<count; i++)
                if(skip(data,i) == code)
                    return i;

            return NotFound;
        }

        [MethodImpl(Inline)]
        public static string @string<A>(in A src)
            where A : unmanaged, IString
                => src.Format();

        [MethodImpl(Inline)]
        public static ref readonly asci2 cast<A>(N2 n, in A src)
            where A : unmanaged, IByteSeq
                => ref @as<A,asci2>(src);

        [MethodImpl(Inline)]
        public static ref readonly asci4 cast<A>(N4 n, in A src)
            where A : unmanaged, IByteSeq
                => ref @as<A,asci4>(src);

        [MethodImpl(Inline)]
        public static ref readonly asci8 cast<A>(N8 n, in A src)
            where A : unmanaged, IByteSeq
                => ref @as<A,asci8>(src);

        [MethodImpl(Inline)]
        public static ref readonly asci16 cast<A>(N16 n, in A src)
            where A : unmanaged, IByteSeq
                => ref @as<A,asci16>(src);

        [MethodImpl(Inline)]
        public static ref readonly asci32 cast<A>(N32 n, in A src)
            where A : unmanaged, IByteSeq
                => ref @as<A,asci32>(src);

        [MethodImpl(Inline)]
        public static ref readonly asci64 cast<A>(N64 n, in A src)
            where A : unmanaged, IByteSeq
                => ref @as<A,asci64>(src);

        [MethodImpl(Inline), Op]
        public static unsafe void copy<A>(ReadOnlySpan<A> src, Span<byte> dst)
            where A : unmanaged, IByteSeq
        {
            for(var i=0u; i<src.Length; i++)
                copy(skip(src,i), ref seek(dst,i*64));
        }

        [MethodImpl(Inline)]
        public static void copy<A>(in A src, ref byte dst)
            where A : unmanaged, IByteSeq
                => copy(n2, src, ref dst);

        [MethodImpl(Inline)]
        static void copy<A>(N2 n, in A src, ref byte dst)
            where A : unmanaged, IByteSeq
        {
            if(typeof(A) == typeof(asci2))
                copy(cast(n2, src), ref dst);
            else if(typeof(A) == typeof(asci4))
                copy(cast(n4, src), ref dst);
            else if(typeof(A) == typeof(asci8))
                copy(cast(n8, src), ref dst);
            else if(typeof(A) == typeof(asci16))
                copy(cast(n16, src), ref dst);
            else
                copy(n32, src, ref dst);
        }

        [MethodImpl(Inline)]
        static void copy<A>(N32 n, in A src, ref byte dst)
            where A : unmanaged, IByteSeq
        {
            if(typeof(A) == typeof(asci32))
                copy(cast(n32, src), ref dst);
            else if(typeof(A) == typeof(asci64))
                copy(cast(n64, src), ref dst);
            else
                throw no<A>();
        }

        [MethodImpl(Inline)]
        public static ReadOnlySpan<char> chars<A>(in A src)
            where A : unmanaged, IByteSeq
                => chars(n2, src);

        [MethodImpl(Inline)]
        static ReadOnlySpan<char> chars<A>(N2 n, in A src)
            where A : unmanaged, IByteSeq
        {
            if(typeof(A) == typeof(asci2))
                return Asci.decode(cast(n2,src));
            else if(typeof(A) == typeof(asci4))
                return Asci.decode(cast(n4,src));
            else if(typeof(A) == typeof(asci8))
                return Asci.decode(cast(n8,src));
            else if(typeof(A) == typeof(asci16))
                return Asci.decode(cast(n16,src));
            else
                return chars(n32, src);
        }

        [MethodImpl(Inline)]
        static ReadOnlySpan<char> chars<A>(N32 n, in A src)
            where A : unmanaged, IByteSeq
        {
            if(typeof(A) == typeof(asci32))
                return Asci.decode(cast(n32,src));
            else if(typeof(A) == typeof(asci64))
                return Asci.decode(cast(n64,src));
            else
                return ReadOnlySpan<char>.Empty;
        }
    }
}