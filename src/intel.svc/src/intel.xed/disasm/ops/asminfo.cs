//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedDisasm
    {
        public static AsmInfo asminfo(in XedDisasmBlock src)
        {
            XedDisasmParse.parse(src.XDis.Content, out AsmInfo dst).Require();
            return dst;
        }
    }
}