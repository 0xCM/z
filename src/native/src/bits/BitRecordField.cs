//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct BitRecordField
    {
        /// <summary>
        /// The field name
        /// </summary>
        public readonly asci16 Name;

        /// <summary>
        /// The 0-based, record-relative field position/index
        /// </summary>
        public readonly byte FieldIndex;

        /// <summary>
        /// The position of the first bit in the field
        /// </summary>
        public readonly uint FieldOffset;

        /// <summary>
        /// The number of semantic bits required by the field
        /// </summary>
        public readonly byte ContentWidth;

        [MethodImpl(Inline)]
        public BitRecordField(asci16 name, byte index, uint offset, byte width)
        {
            Name = name;
            FieldIndex = index;
            FieldOffset = offset;
            ContentWidth = width;
        }

        /// <summary>
        /// The position of the last bit in the field
        /// </summary>
        public uint LastBit
        {
            [MethodImpl(Inline)]
            get => FieldOffset + ContentWidth;
        }
    }
}