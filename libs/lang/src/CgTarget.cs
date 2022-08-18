//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public enum CgTarget : byte
    {
        None,

        [Symbol("cg.common")]
        Common,

        [Symbol("cg.intel")]
        Intel,

        [Symbol("cg.llvm")]
        Llvm,
    }
}