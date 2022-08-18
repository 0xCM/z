//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct NasmCaseScript
    {
        public NasmCase Case {get;}

        public FS.FilePath Path {get;}

        [MethodImpl(Inline)]
        public NasmCaseScript(NasmCase @case, FS.FilePath path)
        {
            Case = @case;
            Path = path;
        }
    }
}