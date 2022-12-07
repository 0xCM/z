//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct NasmEncodingBlocks
    {
        public NasmLabel Label {get;}

        public List<NasmEncoding> Code {get;}

        [MethodImpl(Inline), Op]
        public NasmEncodingBlocks(NasmLabel label, List<NasmEncoding> code)
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

        public NasmCodeBlock ToBlock()
            => new NasmCodeBlock(Label, Code.ToArray());
    }
}