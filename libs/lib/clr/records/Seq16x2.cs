//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct Seq16x2 : IComparable<Seq16x2>, IEquatable<Seq16x2>
    {
        [MethodImpl(Inline), Op]
        public static Seq16x2 create(ushort lo, ushort hi)
            => new Seq16x2(lo, hi);

        public ushort Lo;

        public ushort Hi;

        [MethodImpl(Inline)]
        public Seq16x2(ushort lo, ushort hi)
        {
            Lo = lo;
            Hi = hi;
        }

        public uint Joined
        {
            [MethodImpl(Inline)]
            get => (uint)Lo | ((uint)Hi << 16);
        }

        [MethodImpl(Inline)]
        public void IncLo()
        {
            Lo++;
        }

        [MethodImpl(Inline)]
        public void IncHi()
        {
            Hi++;
        }

        [MethodImpl(Inline)]
        public void DecLo()
        {
            Lo--;
        }

        [MethodImpl(Inline)]
        public void DecHi()
        {
            Hi--;
        }

        [MethodImpl(Inline)]
        public bool Equals(Seq16x2 src)
            => Joined == src.Joined;

        [MethodImpl(Inline)]
        public int CompareTo(Seq16x2 src)
            => Joined.CompareTo(src.Joined);

        public string Format()
            => Joined.FormatHex();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static Seq16x2 operator ++(Seq16x2 src)
        {
            src.IncLo();
            return src;
        }

        [MethodImpl(Inline)]
        public static Seq16x2 operator --(Seq16x2 src)
        {
            src.DecLo();
            return src;
        }

        [MethodImpl(Inline)]
        public static implicit operator Seq16x2((ushort lo, ushort hi) src)
            => new Seq16x2(src.lo,src.hi);
    }
}