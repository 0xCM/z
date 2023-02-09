//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a sequence of regsters of uniform width
    /// </summary>    
    [Record(TableName),StructLayout(LayoutKind.Sequential,Pack =1)]
    public readonly struct RegSeqSpec
    {
        const string TableName = "regseq";

        /// <summary>
        /// A surrogate key
        /// </summary>
        public readonly uint Id;

        /// <summary>
        /// The number of registers in the sequence
        /// </summary>
        public readonly uint RegCount;

        /// <summary>
        /// The size of each register
        /// </summary>
        public readonly NativeSize RegSize;

        [MethodImpl(Inline)]
        public RegSeqSpec(uint id, uint count, NativeSize size)
        {
            Id = id;
            RegCount = count;
            RegSize = size;
        }

        public string Format()
            => string.Format("{0}x{1}", RegCount, RegSize.Width);

        public override string ToString()
            => Format();
    }
}