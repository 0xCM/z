//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct HexLineConfig
    {
        /// <summary>
        /// The maximum byte-count per line
        /// </summary>
        public readonly ushort BytesPerLine;

        /// <summary>
        /// Specifies whether offset labels should be emitted
        /// </summary>
        public readonly bool LineLabels;

        /// <summary>
        /// If offset lables are emitted, the separator between the label and the data
        /// </summary>
        public readonly char Delimiter;

        /// <summary>
        /// Specifies whether the last line should be zero-padded to <see cref='BytesPerLine'/>
        /// </summary>
        public readonly bool ZeroPad;

        [MethodImpl(Inline)]
        public HexLineConfig(ushort bpl, bool labels, char delimiter = Chars.Space, bool zeropad = false)
        {
            BytesPerLine = bpl;
            LineLabels = labels;
            Delimiter = delimiter;
            ZeroPad = zeropad;
        }
    }
}