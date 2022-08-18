//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    using api = memory;

    /// <summary>
    /// Captures a <see cref="char"/> pointer
    /// </summary>
    public unsafe struct PChar : IPtr<char>
    {
        public char* P;

        [MethodImpl(Inline)]
        public PChar(char* src)
            => P = src;

        public ref char this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref seek(P,index);
        }

        public ref char this[long index]
        {
            [MethodImpl(Inline)]
            get => ref seek(P,index);
        }

        public readonly MemoryAddress Address
        {
            [MethodImpl(Inline)]
            get => P;
        }

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => (uint)P;
        }

        public string Format()
            => Address.Format();

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => (int)Hash;

        [MethodImpl(Inline)]
        public bool Equals(PChar src)
            => P == src.P;

        public override bool Equals(object src)
            => src is PChar p && Equals(p);

        [MethodImpl(Inline)]
        public static ushort operator !(PChar x)
            => *x.P;

        [MethodImpl(Inline)]
        public static PChar operator ++(PChar x)
            => api.next(x);

        [MethodImpl(Inline)]
        public static PChar operator --(PChar x)
            => api.prior(x);

        [MethodImpl(Inline)]
        public static implicit operator Ptr<char>(PChar src)
            => new Ptr<char>(src.P);

        [MethodImpl(Inline)]
        public static implicit operator MemoryAddress(PChar src)
            => src.Address;

        public char* Target
        {
            [MethodImpl(Inline)]
            get => P;
        }
    }
}