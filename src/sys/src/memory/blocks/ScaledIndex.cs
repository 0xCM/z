//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a linear relationship between two address spaces
    /// </summary>
    [StructLayout(StructLayout,Pack=1)]
    public readonly struct ScaledIndex
    {
        /// <summary>
        /// The displacement of the index from the source base address
        /// </summary>
        public readonly uint Offset;

        /// <summary>
        /// Specifies a scaling factor and restricted to the domain {-8,-4,-2,-1,0,1,2,4,8}
        /// </summary>
        public readonly sbyte Scale;

        /// <summary>
        /// Measures the count of unaligned bits with respect to the offset/scale
        /// </summary>
        public readonly byte Mod;

        /// <summary>
        /// The width of the smallest addressable unit
        /// </summary>
        public readonly ushort CellWidth;

        [MethodImpl(Inline)]
        public ScaledIndex(ushort wCell, sbyte scale, uint index)
        {
            CellWidth = wCell;
            Offset = (uint)(index/scale);
            Scale = scale;
            Mod = (byte)(Offset%scale);
        }

        public bool Aligned
        {
            [MethodImpl(Inline)]
            get => Mod == 0;
        }

        /// <summary>
        ///  The scale sign
        /// </summary>
        public Sign Sign
        {
            [MethodImpl(Inline)]
            get => Scale;
        }

        public string Format()
        {
            var dst = new StringBuilder();
            dst.Append(Offset.FormatHex());
            dst.Append(Chars.Space);
            dst.Append((char)Sign);
            dst.Append(Chars.Space);
            dst.Append(Chars.x);
            return dst.ToString();
        }

        public override string ToString()
            => Format();
    }
}