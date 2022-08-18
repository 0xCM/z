//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Identifies a rectangular region within a table
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly record struct GridRegion : IEquatable<GridRegion>, IComparable<GridRegion>, IHashed
    {
        /// <summary>
        /// The top-left cell
        /// </summary>
        public readonly CellIndex Min;

        /// <summary>
        /// The bottom-right cell
        /// </summary>
        public readonly CellIndex Max;

        [MethodImpl(Inline)]
        public GridRegion(CellIndex min, CellIndex max)
        {
            Min = min;
            Max = max;
        }

        public string Format()
            => string.Format("[{0}..{1}]", Min, Max);

        public override string ToString()
            => Format();

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => alg.hash.combine(Min.Hash, Max.Hash);
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(GridRegion src)
            => Min == src.Min && Max == src.Max;

        [MethodImpl(Inline)]
        public int CompareTo(GridRegion src)
            => Min == src.Min ? Max.CompareTo(src.Max) : Min.CompareTo(src.Min);

        [MethodImpl(Inline)]
        public static implicit operator GridRegion((CellIndex ul, CellIndex lr) src)
            => new GridRegion(src.ul, src.lr);

        public static CellIndex Zero => default;

        public static CellIndex Empty
            => new CellIndex(uint.MaxValue, uint.MaxValue);
    }
}