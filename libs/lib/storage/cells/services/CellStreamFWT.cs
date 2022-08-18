//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    class CellStream<F,W,T> : ICellStream<F,W,T>
        where F : unmanaged, IDataCell
        where W : unmanaged, ITypeWidth
        where T : unmanaged
    {
        readonly ISource Source;

        readonly CpuCellWidth Width;

        readonly NumericKind Kind;

        readonly Func<F> ValueEmitter;

        public CellStream(ISource src)
        {
            Source = src;
            Width = (CpuCellWidth)default(F).Width;
            Kind = typeof(T).NumericKind();
            ValueEmitter = CreateEmitter(src, Width, Kind);
        }

        public IEnumerable<F> Stream
        {
            get
            {
                while(true)
                    yield return ValueEmitter();
            }
        }

        [MethodImpl(Inline)]
        static F Fixed<K>(in K x)
            where K : struct
                => @as<K,F>(x);

        public static Func<F> CreateEmitter(ISource source, CpuCellWidth width, NumericKind nk)
        {

            if(width <= CpuCellWidth.W64)
            {
                switch(nk)
                {
                    case NumericKind.I8:
                        return f8i;
                    case NumericKind.U8:
                        return f8u;
                    case NumericKind.I16:
                        return f16i;
                    case NumericKind.U16:
                        return f16u;
                    case NumericKind.I32:
                        return f32i;
                    case NumericKind.U32:
                        return f32u;
                    case NumericKind.I64:
                        return f64i;
                    case NumericKind.U64:
                        return f64u;
                    case NumericKind.F32:
                        return f32f;
                    case NumericKind.F64:
                        return f64f;
                }
            }
            else
            {
                switch(width)
                {
                    case CpuCellWidth.W128:
                        return f128;
                    case CpuCellWidth.W256:
                        return f256;
                    case CpuCellWidth.W512:
                        return f512;
                }
            }

            return () => default;

            [MethodImpl(Inline)]
            F f8i() => Fixed(source.Next<sbyte>());

            [MethodImpl(Inline)]
            F f8u() => Fixed(source.Next<byte>());

            [MethodImpl(Inline)]
            F f16u() => Fixed(source.Next<ushort>());

            [MethodImpl(Inline)]
            F f16i() => Fixed(source.Next<short>());

            [MethodImpl(Inline)]
            F f32i() => Fixed(source.Next<int>());

            [MethodImpl(Inline)]
            F f32u() => Fixed(source.Next<uint>());

            [MethodImpl(Inline)]
            F f64u() => Fixed(source.Next<ulong>());

            [MethodImpl(Inline)]
            F f64i() => Fixed(source.Next<long>());

            [MethodImpl(Inline)]
            F f32f() => Fixed(source.Next<float>());

            [MethodImpl(Inline)]
            F f64f() => Fixed(source.Next<double>());

            [MethodImpl(Inline)]
            F f128() => Fixed(source.Cell(w128));

            [MethodImpl(Inline)]
            F f256() => Fixed(source.Cell(w256));

            [MethodImpl(Inline)]
            F f512() => Fixed(source.Cell(w512));
        }

        [MethodImpl(Inline)]
        public Cell128 f128V(W128 w)
            => Source.Cell(w128);

        [MethodImpl(Inline)]
        public Cell256 Fixed(W256 w)
            =>  (Source.Cell(w128), Source.Cell(w128));

        [MethodImpl(Inline)]
        public Cell512 Fixed(W512 w)
            => (Source.Cell(w256), Source.Cell(w256));
    }
}