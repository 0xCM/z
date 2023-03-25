//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct NasmCaseScript
    {
        public NasmCase Case {get;}

        public FilePath Path {get;}

        [MethodImpl(Inline)]
        public NasmCaseScript(NasmCase @case, FilePath path)
        {
            Case = @case;
            Path = path;
        }
    }
}