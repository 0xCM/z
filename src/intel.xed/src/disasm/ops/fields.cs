//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static XedRules;

partial class XedDisasm
{
    public static InstFieldValues fields(in XedDisasmBlock src)
    {
        parse(src, out InstFieldValues dst);
        return dst;
    }
}
