//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a version schema that supports 2, 3 or 4 32-bit segments
    /// </summary>
    [StructLayout(StructLayout)]
    public readonly record struct Version128 : IDataString<Version128>
    {
        /// <summary>
        /// The most-significant segment value
        /// </summary>
        public readonly uint A;

        /// <summary>
        /// The secondary segment value
        /// </summary>
        public readonly uint B;

        /// <summary>
        /// The tertiary segment value, or 0 if none
        /// </summary>
        public readonly uint C;

        /// <summary>
        /// The least-significant segment value, or 0 if none
        /// </summary>
        public readonly uint D;

        [MethodImpl(Inline)]
        public Version128(uint a, uint b = 0, uint c = 0, uint d = 0)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => HashCodes.hash(A, B, C, D);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => A == 0 && B == 0 && C == 0 && D == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => A != 0 || B != 0 || C != 0 || D != 0;
        }

        public string Format()
            => string.Format(RP.SlotDot4, A, B, C, D);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(Version128 src)
            => A == src.A && B == src.B && C == src.C && D == src.D;


        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public int CompareTo(Version128 src)
        {
            var result = A.CompareTo(src.A);
            if(result == 0)
            {
                result = B.CompareTo(src.B);
                if(result==0)
                {
                    result = C.CompareTo(src.C);
                    if(result == 0)
                        result = D.CompareTo(src.D);
                }
            }

            return result;
        }

        [MethodImpl(Inline)]
        public static bool operator <(Version128 a, Version128 b)
            => a.CompareTo(b) < 0;

        [MethodImpl(Inline)]
        public static bool operator <=(Version128 a, Version128 b)
            => a.CompareTo(b) <= 0;

        [MethodImpl(Inline)]
        public static bool operator >(Version128 a, Version128 b)
            => b < a;

        [MethodImpl(Inline)]
        public static bool operator >=(Version128 a, Version128 b)
            => b <= a;

        [MethodImpl(Inline)]
        public static implicit operator Version128((uint a, uint b) src)
            => new Version128(src.a, src.b);

        [MethodImpl(Inline)]
        public static implicit operator Version128(Version src)
            => new Version128((uint)src.Major, (uint)src.Minor, (uint)src.MajorRevision, (uint)src.MinorRevision);
    }
}