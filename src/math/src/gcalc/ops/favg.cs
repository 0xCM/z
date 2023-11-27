//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial struct gcalc
{
    [MethodImpl(Inline), Avg, Closures(Floats)]
    public static T favg<T>(ReadOnlySpan<T> src, bool @checked)
        where T : unmanaged
    {
        if(typeof(T) == typeof(float))
            return generic<T>(math.avg(float32(src), @checked));
        else if(typeof(T) == typeof(double))
            return generic<T>(math.avg(float64(src), @checked));
        else
            throw no<T>();
    }

    [MethodImpl(Inline), Avg, Closures(Floats)]
    public static T favg<T>(ReadOnlySpan<T> src)
        where T : unmanaged
            => favg(src,true);
}
