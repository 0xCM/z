//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a labled statement block
    /// </summary>
    public readonly struct NasmCodeBlock
    {
        /// <summary>
        /// The label
        /// </summary>
        public NasmLabel Label {get;}

        /// <summary>
        /// The labeled code
        /// </summary>
        public Index<NasmEncoding> Code {get;}

        [MethodImpl(Inline), Op]
        public NasmCodeBlock(NasmLabel label, Index<NasmEncoding> code)
        {
            Label = label;
            Code  = code;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline), Op]
            get => Label.IsEmpty && Code.Count == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline), Op]
            get => Label.IsNonEmpty || Code.Count != 0;
        }
    }
}