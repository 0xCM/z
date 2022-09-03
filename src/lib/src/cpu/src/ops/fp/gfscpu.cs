//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using static Root;
    using static core;
    using static cpu;

    /// <summary>
    /// Generic scalar intrinsics over floating-point domains
    /// </summary>
    [ApiHost]
    public static class gfscpu
    {
        [MethodImpl(Inline), Op, Closures(Floats)]
        public static Vector128<T> load<T>(T src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(fscpu.vloads(float32(src)));
            else if(typeof(T) == typeof(double))
                return generic<T>(fscpu.vloads(float64(src)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Floats)]
        public static T store<T>(Vector128<T> src)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(fscpu.vstores(v32f(src)));
            else if(typeof(T) == typeof(double))
                return generic<T>(fscpu.vstores(v64f(src)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Floats)]
        public static Vector128<T> add<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(fscpu.vadds(v32f(x), v32f(y)));
            else if(typeof(T) == typeof(double))
                return generic<T>(fscpu.vadds(v64f(x), v64f(y)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Floats)]
        public static Vector128<T> sub<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(fscpu.sub(v32f(x), v32f(y)));
            else if(typeof(T) == typeof(double))
                return generic<T>(fscpu.sub(v64f(x), v64f(y)));
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Floats)]
        public static Vector128<T> mul<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(fscpu.vmuls(v32f(x), v32f(y)));
            else if(typeof(T) == typeof(double))
                return generic<T>(fscpu.vmuls(v64f(x), v64f(y)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Floats)]
        public static Vector128<T> div<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(fscpu.vdivs(v32f(x), v32f(y)));
            else if(typeof(T) == typeof(double))
                return generic<T>(fscpu.vdivs(v64f(x), v64f(y)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Floats)]
        public static Vector128<T> min<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(fscpu.min(v32f(x), v32f(y)));
            else if(typeof(T) == typeof(double))
                return generic<T>(fscpu.min(v64f(x), v64f(y)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Floats)]
        public static Vector128<T> max<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(fscpu.max(v32f(x), v32f(y)));
            else if(typeof(T) == typeof(double))
                return generic<T>(fscpu.max(v64f(x), v64f(y)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Floats)]
        public static Vector128<T> ceil<T>(Vector128<T> x)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(fscpu.ceil(v32f(x)));
            else if(typeof(T) == typeof(double))
                return generic<T>(fscpu.ceil(v64f(x)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Floats)]
        public static Vector128<T> floor<T>(Vector128<T> x)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(fscpu.floor(v32f(x)));
            else if(typeof(T) == typeof(double))
                return generic<T>(fscpu.floor(v64f(x)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Floats)]
        public static Vector128<T> sqrt<T>(Vector128<T> x)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(fscpu.sqrt(v32f(x)));
            else if(typeof(T) == typeof(double))
                return generic<T>(fscpu.sqrt(v64f(x)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Floats)]
        public static Vector128<T> fmadd<T>(Vector128<T> x, Vector128<T> y, Vector128<T> z)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(fmadd(v32f(x), v32f(y), v32f(z)));
            else if(typeof(T) == typeof(double))
                return generic<T>(fmadd(v64f(x), v64f(y), v64f(z)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Floats)]
        public static Vector128<T> fmsub<T>(Vector128<T> a, Vector128<T> b, Vector128<T> c)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(fscpu.fmsub(v32f(a), v32f(b), v32f(c)));
            else if(typeof(T) == typeof(double))
                return generic<T>(fscpu.fmsub(v64f(a), v64f(b), v64f(c)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Floats)]
        public static Vector128<T> fnmadd<T>(Vector128<T> a, Vector128<T> b, Vector128<T> c)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(fscpu.fnmadd(v32f(a), v32f(b), v32f(c)));
            else if(typeof(T) == typeof(double))
                return generic<T>(fscpu.fnmadd(v64f(a), v64f(b), v64f(c)));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Floats)]
        public static bool eq<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return fscpu.eq(v32f(x), v32f(y));
            else if(typeof(T) == typeof(double))
                return fscpu.eq(v64f(x), v64f(y));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Floats)]
        public static bool neq<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return fscpu.neq(v32f(x), v32f(y));
            else if(typeof(T) == typeof(double))
                return fscpu.neq(v64f(x), v64f(y));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Floats)]
        public static bool lteq<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return fscpu.lteq(v32f(x), v32f(y));
            else if(typeof(T) == typeof(double))
                return fscpu.lteq(v32f(x), v32f(y));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Floats)]
        public static bool ngt<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return fscpu.ngt(v32f(x), v32f(y));
            else if(typeof(T) == typeof(double))
                return fscpu.ngt(v32f(x), v32f(y));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Floats)]
        public static bool nlt<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return fscpu.nlt(v32f(x), v32f(y));
            else if(typeof(T) == typeof(double))
                return fscpu.nlt(v32f(x), v32f(y));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Floats)]
        public static bool gt<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return fscpu.gt(v32f(x), v32f(y));
            else if(typeof(T) == typeof(double))
                return fscpu.gt(v64f(x), v64f(y));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Floats)]
        public static bool gteq<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return fscpu.gteq(v32f(x), v32f(y));
            else if(typeof(T) == typeof(double))
                return fscpu.gteq(v64f(x), v64f(y));
            else
                throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Floats)]
        public static bool lt<T>(Vector128<T> x, Vector128<T> y)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return fscpu.lt(v32f(x), v32f(y));
            else if(typeof(T) == typeof(double))
                return fscpu.lt(v64f(x), v64f(y));
            throw no<T>();
        }

        [MethodImpl(Inline), Op, Closures(Floats)]
        public static Vector128<T> cmp<T>(Vector128<T> x, Vector128<T> y, FpCmpMode mode)
            where T : unmanaged
        {
            if(typeof(T) == typeof(float))
                return generic<T>(fscpu.cmp(v32f(x), v32f(y),mode));
            else if(typeof(T) == typeof(double))
                return generic<T>(fscpu.cmp(v64f(x), v64f(y),mode));
            throw no<T>();
        }
    }
}