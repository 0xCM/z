//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[ApiHost]
readonly unsafe partial struct MemFx
{
    const NumericKind Closure = Integers;

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static delegate* unmanaged<T,T,T> binop<T>(void* f)
        where T : unmanaged
            => (delegate* unmanaged<T,T,T>) f;

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static delegate* unmanaged<T,T,T> binop<T>(MemoryAddress f)
        where T : unmanaged
            => (delegate* unmanaged<T,T,T>) f.Pointer();

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static delegate* unmanaged<T*,T*,T*> binop_ptr<T>(void* f)
        where T : unmanaged
            => (delegate* unmanaged<T*,T*,T*>) f;

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static delegate* unmanaged<T0*,R*> func_ptr<T0,R>(void* f)
        where T0 : unmanaged
        where R : unmanaged
            => (delegate* unmanaged<T0*,R*>) f;

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static delegate* unmanaged<T0*,T1*,R*> func_ptr<T0,T1,R>(void* f)
        where T0 : unmanaged
        where T1 : unmanaged
        where R : unmanaged
            => (delegate* unmanaged<T0*,T1*,R*>) f;

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static delegate* unmanaged<T0,R> func<T0,R>(void* f)
        where T0 : unmanaged
        where R : unmanaged
            => (delegate* unmanaged<T0,R>) f;

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static delegate* unmanaged<T0,T1,R> func<T0,T1,R>(void* f)
        where T0 : unmanaged
        where T1 : unmanaged
        where R : unmanaged
            => (delegate* unmanaged<T0,T1,R>) f;

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static delegate* unmanaged<T*,T*,T*> binop_ptr<T>(ReadOnlySpan<byte> code)
        where T : unmanaged
            => (delegate* unmanaged<T*,T*,T*>) memory.liberate(code);

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static delegate* unmanaged<T,T,T> binop<T>(ReadOnlySpan<byte> code)
        where T : unmanaged
            => (delegate* unmanaged<T,T,T>) memory.liberate(code);

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static delegate* unmanaged<T,T> unaryop<T>(void* f)
        where T : unmanaged
            => (delegate* unmanaged<T,T>) f;

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static delegate* unmanaged<T,T> unaryop<T>(MemoryAddress f)
        where T : unmanaged
            => (delegate* unmanaged<T,T>) f.Pointer();

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static delegate* unmanaged<T,T> unaryop<T>(ReadOnlySpan<byte> code)
        where T : unmanaged
            => (delegate* unmanaged<T,T>) memory.liberate(code);

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Vector128<T> invoke<T>(delegate* unmanaged<T*,T*,T*> f, Vector128<T> a, Vector128<T> b)
        where T : unmanaged
            => *((Vector128<T>*)f((T*)&a, (T*)&b));

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static Vector128<T> invoke<T>(delegate* unmanaged<T*,T*,T*> f, Vector256<T> a, Vector256<T> b)
        where T : unmanaged
            => *((Vector128<T>*)f((T*)&a, (T*)&b));
}
