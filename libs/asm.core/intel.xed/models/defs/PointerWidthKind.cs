//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(xed)]
        public enum PointerWidthKind
        {
            [Symbol("")]
            None,

            [Symbol("b")]
            Byte = 1,

            [Symbol("w")]
            Word = 2,

            [Symbol("l")]
            DWord = 4,

            [Symbol("q")]
            QWord = 8,

            [Symbol("x")]
            XmmWord = 16,

            [Symbol("y")]
            YmmWord = 32,

            [Symbol("z")]
            ZmmWord = 64
        }
    }
}