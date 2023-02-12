//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedDisasmModels;

    partial class XedDisasm
    {
        [MethodImpl(Inline)]
        public static DisasmBlock block(TextLine[] src)
            => new DisasmBlock(src);

        static DisasmDetailBlock block(in DisasmLines src)
        {
            parse(src, out Instruction inst);
            return new DisasmDetailBlock(row(src), src, inst);
        }
    }
}