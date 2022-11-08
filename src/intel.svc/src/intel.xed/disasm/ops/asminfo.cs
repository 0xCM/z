//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedDisasmModels;

    partial class XedDisasm
    {
        public static AsmInfo asminfo(in DisasmBlock src)
        {
            DisasmParse.parse(src.XDis.Content, out AsmInfo dst).Require();
            return dst;
        }
    }
}