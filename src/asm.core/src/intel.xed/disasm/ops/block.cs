//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedDisasmModels;

    partial class XedDisasm
    {
        [MethodImpl(Inline)]
        public static DisasmBlock block(TextLine[] src)
            => new DisasmBlock(src);

        static DetailBlock block(in XedDisasmLines src)
        {
            parse(src, out Instruction inst);
            return new DetailBlock(row(src), src, inst);
        }
    }
}