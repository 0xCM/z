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
    public readonly record struct Digit<N,T> : INatDigit<N,Digit<N,T>,T>
        where T : unmanaged
        where N : unmanaged, ITypeNat
    {
        readonly T value;

        [MethodImpl(Inline)]
        public Digit(T src)
            => value = src;

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => sys.bw32(value);
        }

        public uint ToUInt()
            => sys.bw32(value);

        [MethodImpl(Inline)]
        public string format()
            => ToUInt().ToString();

        [MethodImpl(Inline)]
        public bool Equals(Digit<N,T> src)
            => Hash == src.Hash;

        [MethodImpl(Inline)]
        public override int GetHashCode()
            => Hash;

        public override string ToString()
            => format();

        [MethodImpl(Inline)]
        public static implicit operator uint(Digit<N,T> src)
            => src.ToUInt();

        [MethodImpl(Inline)]
        public static implicit operator T(Digit<N,T> src)
            => src.value;
    }
}