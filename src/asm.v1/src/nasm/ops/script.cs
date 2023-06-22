//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Nasm
    {
        [MethodImpl(Inline), Op]
        public static NasmCaseScript script(NasmCase @case, FilePath src)
            => new NasmCaseScript(@case, src);
    }
}