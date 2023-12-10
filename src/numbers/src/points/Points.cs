//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

[ApiHost,Free]
public class Points
{
    const NumericKind Closure = UnsignedInts;

    [MethodImpl(Inline)]
    public static Point<A,B> point<A,B>(A a, B b)
        where A : unmanaged
        where B : unmanaged
            => new (a,b);

    [MethodImpl(Inline)]
    public static Point<A,B,C> point<A,B,C>(A a, B b, C c)
        where A : unmanaged
        where B : unmanaged
        where C : unmanaged
            => new (a,b,c);

    public static MultiLinear<T> multilinear<T>(Dim<T> shape)
        where T : unmanaged
    {
        var m = bw64(shape.I);
        var n = bw64(shape.J);
        var count = m*n;
        var dst = alloc<MultiPoint<T>>(count);
        for(ulong i=0,k=0; i<m; i++)
            for(ulong j=0; j<n; j++,k++)
            {
                var p = @as<T>(i);
                var q = @as<T>(j);
                seek(dst,k) = ((p,q),(q,p));
            }
        return dst;
    }

    public static LinearIndex<T> linearize<T>(Dim<T> shape)
        where T : unmanaged
    {
        var m = bw64(shape.I);
        var n = bw64(shape.J);
        var count = m*n;
        var dst = alloc<Point<T>>(count);
        for(ulong i=0,k=0; i<m; i++)
        for(ulong j=0; j<n; j++,k++)
            seek(dst,k) = (@as<T>(i),@as<T>(j));
        return dst;
    }

    public static void render<T>(MultiLinear<T> src, ITextEmitter dst)
        where T : unmanaged
    {
        for(var i=0; i<src.Count; i++)
        {
            ref readonly var point = ref src[i];
            dst.AppendLineFormat("{0:X4} | ({1:X2}, {2:X2}) | ({3:X2}, {4:X2})", i, (T)point.X.X, (T)point.X.Y, (T)point.Y.X, (T)point.Y.Y);
        }
    }

    public static void render<T>(LinearIndex<T> src, ITextEmitter dst)
        where T : unmanaged
    {
        for(var i=0; i<src.Count; i++)
        {
            ref readonly var point = ref src[i];
            dst.AppendLineFormat("{0:X4} | ({1:X2}, {2:X2})", i, (T)point.X, (T)point.Y);
        }
    }

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static ColPoint<T> col<T>(T x, T y)
        where T : unmanaged
            => new (x,y);

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static RowPoint<T> row<T>(T x, T y)
        where T : unmanaged
            => new (x,y);

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Point<T> point<T>(T x, T y)
        where T : unmanaged
            => new (x,y);

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static MultiPoint<T> multi<T>(RowPoint<T> x, ColPoint<T> y)
        where T : unmanaged
            => new (x,y);
}
