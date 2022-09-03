//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public readonly struct CellEmitter
    {
        const NumericKind Closure = UnsignedInts;

        readonly ISource Source;

        [MethodImpl(Inline), Op]
        public CellEmitter(ISource provider)
            => Source = provider;

        [MethodImpl(Inline), Op]
        public Cell8 Next(W8 w)
            => PolyCells.emitter<Cell8>(Source).Next();

        [MethodImpl(Inline), Op]
        public Cell16 Next(W16 w)
            => PolyCells.emitter<Cell16>(Source).Next();

        [MethodImpl(Inline), Op]
        public Cell32 Next(W32 w)
            => PolyCells.emitter<Cell32>(Source).Next();

        [MethodImpl(Inline), Op]
        public Cell64 Next(W64 w)
            => PolyCells.emitter<Cell64>(Source).Next();

        [MethodImpl(Inline), Op]
        public Cell128 Next(W128 w)
            => PolyCells.emitter<Cell128>(Source).Next();

        [MethodImpl(Inline), Op]
        public Cell256 Next(W256 w)
            => PolyCells.emitter<Cell256>(Source).Next();

        [MethodImpl(Inline), Op]
        public Cell512 Next(W512 w)
            => PolyCells.emitter<Cell512>(Source).Next();

        [MethodImpl(Inline), Op]
        public static Func<Cell64> create(ISource source, W64 w, NumericKind nk)
            => create<Cell64>(source, CpuCellWidth.W64, nk);

        [Op, Closures(Closure)]
        public static Func<F> create<F>(ISource source, CpuCellWidth width, NumericKind nk)
            where F : unmanaged
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
            F f8i() => @as<sbyte,F>(source.Next<sbyte>());

            [MethodImpl(Inline)]
            F f8u() => @as<byte,F>(source.Next<byte>());

            [MethodImpl(Inline)]
            F f16u() => @as<ushort,F>(source.Next<ushort>());

            [MethodImpl(Inline)]
            F f16i() => @as<short,F>(source.Next<short>());

            [MethodImpl(Inline)]
            F f32i() => @as<int,F>(source.Next<int>());

            [MethodImpl(Inline)]
            F f32u() => @as<uint,F>(source.Next<uint>());

            [MethodImpl(Inline)]
            F f64u() => @as<ulong,F>(source.Next<ulong>());

            [MethodImpl(Inline)]
            F f64i() => @as<long,F>(source.Next<long>());

            [MethodImpl(Inline)]
            F f32f() => @as<float,F>(source.Next<float>());

            [MethodImpl(Inline)]
            F f64f() => @as<double,F>(source.Next<double>());

            [MethodImpl(Inline)]
            F f128() => @as<Cell128,F>(source.Cell(w128));

            [MethodImpl(Inline)]
            F f256() => @as<Cell256,F>(source.Cell(w256));

            [MethodImpl(Inline)]
            F f512() => @as<Cell512,F>(source.Cell(w512));
        }
    }
}