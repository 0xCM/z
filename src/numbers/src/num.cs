//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[ApiHost]
public readonly struct num
{
    internal const NumericKind Closure = UnsignedInts;

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static T inc<T>(T src)
        where T : unmanaged
            => gmath.inc(src);

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static T dec<T>(T src)
        where T : unmanaged
            => gmath.dec(src);

    [MethodImpl(Inline), Factory, Closures(Closure)]
    public static num<T> generic<T>(T value)
        where T : unmanaged
            => new num<T>(value);

    [MethodImpl(Inline), Op, Closures(Closure)]
    public static num<T> zero<T>()
        where T : unmanaged
            => new num<T>(sys.zero<T>());

    [MethodImpl(Inline), One, Closures(Closure)]
    public static num<T> one<T>()
        where T : unmanaged
            => new num<T>(sys.one<T>());

    [MethodImpl(Inline), Ones, Closures(Closure)]
    public static num<T> ones<T>()
        where T : unmanaged
            => new num<T>(sys.ones<T>());

    [MethodImpl(Inline), Add, Closures(Closure)]
    public static num<T> add<T>(num<T> a, num<T> b)
        where T : unmanaged
            => generic(gmath.add(a.Value, b.Value));

    [MethodImpl(Inline), Mul, Closures(Closure)]
    public static num<T> mul<T>(num<T> a, num<T> b)
        where T : unmanaged
            => generic(gmath.mul(a.Value, b.Value));

    [MethodImpl(Inline), Sub, Closures(Closure)]
    public static num<T> sub<T>(num<T> a, num<T> b)
        where T : unmanaged
            => generic(gmath.sub(a.Value, b.Value));

    [MethodImpl(Inline), Div, Closures(Closure)]
    public static num<T> div<T>(num<T> a, num<T> b)
        where T : unmanaged
            => generic(gmath.div(a.Value, b.Value));

    [MethodImpl(Inline), Mod, Closures(Closure)]
    public static num<T> mod<T>(num<T> a, num<T> b)
        where T : unmanaged
            => generic(gmath.mod(a.Value, b.Value));

    [MethodImpl(Inline), Negate, Closures(Closure)]
    public static num<T> negate<T>(num<T> a)
        where T : unmanaged
            => generic(gmath.negate(a.Value));

    [MethodImpl(Inline), And, Closures(Integers)]
    public static num<T> and<T>(num<T> a, num<T> b)
        where T : unmanaged
            => generic(gmath.and(a.Value, b.Value));

    [MethodImpl(Inline), Or, Closures(Integers)]
    public static num<T> or<T>(num<T> a, num<T> b)
        where T : unmanaged
            => generic(gmath.or(a.Value, b.Value));

    [MethodImpl(Inline), Xor, Closures(Integers)]
    public static num<T> xor<T>(num<T> a, num<T> b)
        where T : unmanaged
            => generic(gmath.xor(a.Value, b.Value));

    [MethodImpl(Inline), Not, Closures(Integers)]
    public static num<T> not<T>(num<T> a)
        where T : unmanaged
            => generic(gmath.not(a.Value));

    [MethodImpl(Inline), Sll, Closures(Integers)]
    public static num<T> sll<T>(num<T> a, byte offset)
        where T : unmanaged
            => generic(gmath.sll(a.Value, offset));

    [MethodImpl(Inline), Srl, Closures(Integers)]
    public static num<T> srl<T>(num<T> a, byte offset)
        where T : unmanaged
            => generic(gmath.srl(a.Value, offset));

    [MethodImpl(Inline), Eq, Closures(Closure)]
    public static bit eq<T>(num<T> a, num<T> b)
        where T : unmanaged
            => gmath.eq(a.Value,b.Value);

    [MethodImpl(Inline), Neq, Closures(Closure)]
    public static bit neq<T>(num<T> a, num<T> b)
        where T : unmanaged
            => gmath.neq(a.Value,b.Value);

    [MethodImpl(Inline), Lt, Closures(Closure)]
    public static bit lt<T>(num<T> a, num<T> b)
        where T : unmanaged
            => gmath.lt(a.Value,b.Value);

    [MethodImpl(Inline), Gt, Closures(Closure)]
    public static bit gt<T>(num<T> a, num<T> b)
        where T : unmanaged
            => gmath.gt(a.Value,b.Value);

    [MethodImpl(Inline), LtEq, Closures(Closure)]
    public static bit lteq<T>(num<T> a, num<T> b)
        where T : unmanaged
            => gmath.lteq(a.Value,b.Value);

    [MethodImpl(Inline), GtEq, Closures(Closure)]
    public static bit gteq<T>(num<T> a, num<T> b)
        where T : unmanaged
            => gmath.gteq(a.Value,b.Value);
}
