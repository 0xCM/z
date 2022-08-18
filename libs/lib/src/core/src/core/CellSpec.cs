//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Describes a cell
    /// </summary>
    public readonly struct CellSpec : IEquatable<CellSpec>, IComparable<CellSpec>
    {
        /// <summary>
        /// The number of available bits
        /// </summary>
        public readonly ushort Capacity;

        /// <summary>
        /// The number of bits used
        /// </summary>
        public readonly ushort DataWidth;

        [MethodImpl(Inline)]
        public CellSpec(ushort cap, ushort dw)
        {
            Capacity = cap;
            DataWidth = dw;
        }

        [MethodImpl(Inline)]
        public int CompareTo(CellSpec src)
        {
            if(Capacity == src.Capacity)
                return DataWidth.CompareTo(src.DataWidth);
            else
                return Capacity.CompareTo(src.Capacity);
        }

        public bool Equals(CellSpec src)
            => Capacity.Equals(src.Capacity) && DataWidth.Equals(src.DataWidth);

        public override bool Equals(object src)
            => src is CellSpec x && Equals(x);

        public string Format()
            => string.Format("{0}:{1}", DataWidth, Capacity);

        public override int GetHashCode()
            => (int)alg.hash.calc(Capacity,DataWidth);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator CellSpec((ushort cap, ushort dw) src)
            => new CellSpec(src.cap, src.dw);
    }
}