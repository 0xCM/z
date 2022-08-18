//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a generic digit representation relative to a natural base
    /// </summary>
    /// <typeparam name="N">The natural base type</typeparam>
    /// <typeparam name="T">The digit's primal type</typeparam>
    public readonly struct Digit<N,T> : INatDigit<N,Digit<N,T>,T>
        where T : unmanaged
        where N : unmanaged, ITypeNat
    {
        readonly T value;

        [MethodImpl(Inline)]
        public Digit(T src)
            => value = src;

        public uint ToUInt()
            => core.bw32(value);

        [MethodImpl(Inline)]
        public string format()
            => ToUInt().ToString();

        [MethodImpl(Inline)]
        public bool Equals(Digit<N,T> rhs)
            => value.Equals(rhs);

        [MethodImpl(Inline)]
        public override bool Equals(object rhs)
            => rhs is Digit<N,T> d && Equals(d);

        [MethodImpl(Inline)]
        public override int GetHashCode()
            => value.GetHashCode();

        public override string ToString()
            => format();

        [MethodImpl(Inline)]
        public static bool operator ==(Digit<N,T> lhs, Digit<N,T> rhs)
            => lhs.Equals(rhs);

        [MethodImpl(Inline)]
        public static bool operator !=(Digit<N,T> lhs, Digit<N,T> rhs)
            => !lhs.Equals(rhs);

        [MethodImpl(Inline)]
        public static implicit operator uint(Digit<N,T> src)
            => src.ToUInt();

        [MethodImpl(Inline)]
        public static implicit operator T(Digit<N,T> src)
            => src.value;
    }
}