//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedDisasm
    {
        [MethodImpl(Inline)]
        public static XedDisasmBlock block(TextLine[] src)
            => new XedDisasmBlock(src);

        static XedDisasmDetailBlock block(in XedDisasmLines src)
        {
            parse(src, out Instruction inst);
            return new XedDisasmDetailBlock(row(src), src, inst);
        }
    }
}