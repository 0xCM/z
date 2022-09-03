//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Designates a rectangular multi-line text segment
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack =1)]
    public readonly struct TextArea
    {
        /// <summary>
        /// The first line included in the block
        /// </summary>
        public readonly LineNumber MinLine;

        /// <summary>
        /// The first column of the first line
        /// </summary>
        public readonly ushort MinCol;

        /// <summary>
        /// The last line included in the block
        /// </summary>
        public readonly LineNumber MaxLine;

        /// <summary>
        /// The last column of the last line
        /// </summary>
        public readonly ushort MaxCol;

        [MethodImpl(Inline)]
        public TextArea(LineNumber minL, ushort minC, LineNumber maxL, ushort maxC)
        {
            MinLine = minL;
            MinCol = minC;
            MaxLine = maxL;
            MaxCol = maxC;
        }
    }
}