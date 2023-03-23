//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedTool
    {
        [SymSource(group)]
        public enum InputKind : byte
        {
            None = 0,

            [Symbol("i", "A pecoff file")]
            PeCoffFile,

            [Symbol("ir", "A raw unformatted binary file")]
            RawBinFile,

            [Symbol("ih", "A raw unformatted ASCII hex file")]
            HexFile,

            [Symbol("d", "A sequence of hex-formatted bytes")]
            HexText,
        }
    }
}