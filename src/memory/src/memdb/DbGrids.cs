//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    public readonly struct DbGrids
    {
        [MethodImpl(Inline)]
        public static void CalcRowOffsets<S,T>(Dim2<S> shape, Index<T> dst)
            where S : unmanaged
            where T : unmanaged
        {
            var m = bw64(shape.I);
            var n = bw64(shape.J);
            for(var i=0ul; i<m; i++)
                dst[i] = @as<T>(i*n);
        }

        [MethodImpl(Inline)]
        public static void CalcColOffsets<S,T>(Dim2<S> shape, Index<T> dst)
            where S : unmanaged
            where T : unmanaged
        {
            var m = bw64(shape.I);
            var n = bw64(shape.J);
            for(var i=0ul; i<n; i++)
                dst[i] = @as<T>(i*m);
        }

        public static Index<T> CalcRowOffsets<S,T>(Dim2<S> shape, T t = default)
            where S : unmanaged
            where T : unmanaged
        {
            var dst = sys.alloc<T>(bw64(shape.I));
            CalcRowOffsets(shape,dst.Index());
            return dst;
        }

        public static Index<T> CalcRowOffsets<T>(Dim2<T> shape)
            where T : unmanaged
        {
            var dst = sys.alloc<T>(bw64(shape.I));
            CalcRowOffsets(shape,dst.Index());
            return dst;
        }

        public static Index<T> CalcColOffsets<S,T>(Dim2<S> shape, T t = default)
            where S : unmanaged
            where T : unmanaged
        {
            var dst = sys.alloc<T>(bw64(shape.I));
            CalcColOffsets(shape,dst.Index());
            return dst;
        }

        public static Index<T> CalcColOffsets<T>(Dim2<T> shape)
            where T : unmanaged
        {
            var dst = sys.alloc<T>(bw64(shape.I));
            CalcColOffsets(shape,dst.Index());
            return dst;
        }
    }
}