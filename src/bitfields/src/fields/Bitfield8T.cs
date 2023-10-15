//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

using api = Bitfields;
using S = System.Byte;

/// <summary>
/// Defines an 8-bit bitfield over a parametric type
/// </summary>
[StructLayout(LayoutKind.Sequential, Size=1)]
public struct Bitfield8<T>
    where T : unmanaged
{
    S _State;

    [MethodImpl(Inline)]
    public Bitfield8(T state)
        => _State = uint8(state);

    [MethodImpl(Inline)]
    public Bitfield8(S state)
        => _State = state;

    public readonly T State
    {
        [MethodImpl(Inline)]
        get => @as<uint,T>(_State);
    }

    internal S State8u
    {
        [MethodImpl(Inline)]
        get => _State;
    }

    public bit this[byte pos]
    {
        [MethodImpl(Inline)]
        get => bits.test(_State, pos);

        [MethodImpl(Inline)]
        set => bits.set(_State, pos, value);
    }

    public T this[byte min, byte max]
    {
        [MethodImpl(Inline)]
        get => Extract(min, max);

        [MethodImpl(Inline)]
        set => Store(value, min, max);
    }

    [MethodImpl(Inline)]
    public readonly T Extract(byte min, byte max)
        => api.seg(this, min, max);

    [MethodImpl(Inline)]
    public void Store(T src, byte min, byte max)
        => bits.store(u8(src), min, max, ref _State);

    [MethodImpl(Inline)]
    public readonly V Extract<V>(byte min, byte max)
        => @as<T,V>(Extract(min,max));

    [MethodImpl(Inline)]
    public void Store<V>(V src, byte min, byte max)
        => Store(@as<V,T>(src),min,max);

    public readonly string Format()
        => api.format(this);

    public override string ToString()
        => Format();

    [MethodImpl(Inline)]
    internal void Overwrite(S src)
        => _State = src;

    [MethodImpl(Inline)]
    public static implicit operator Bitfield8<T>(T src)
        => new Bitfield8<T>(src);

    [MethodImpl(Inline)]
    public static implicit operator Bitfield8<T>(S src)
        => new Bitfield8<T>(src);

    [MethodImpl(Inline)]
    public static explicit operator S(Bitfield8<T> src)
        => src.State8u;

    [MethodImpl(Inline)]
    public static implicit operator T(Bitfield8<T> src)
        => src.State;

    [MethodImpl(Inline)]
    public static implicit operator Bitfield8(Bitfield8<T> src)
        => new Bitfield8(src.State8u);
}
