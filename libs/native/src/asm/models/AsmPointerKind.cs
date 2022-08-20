//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    [SymSource(asm)]
    public enum AsmPointerKind : byte
    {
        [Symbol("byte")]
        @byte = NativeSizeCode.W8,

        [Symbol("word")]
        word = NativeSizeCode.W16,

        [Symbol("dword")]
        dword = NativeSizeCode.W32,

        [Symbol("qword")]
        qword = NativeSizeCode.W64,

        [Symbol("xmmword")]
        xmmword = NativeSizeCode.W128,

        [Symbol("ymmword")]
        ymmword = NativeSizeCode.W256,

        [Symbol("zmmword")]
        zmmword = NativeSizeCode.W512,
    }
}