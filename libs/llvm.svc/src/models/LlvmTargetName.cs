//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [SymSource(ApiAtomic.llvm)]
    public enum LlvmTargetName : byte
    {
        None,

        aarch64,

        amdgcn,

        arm,

        bpf,

        hexagon,

        mips,

        nvvm,

        ppc,

        r600,

        riscv,

        s390,

        ve,

        wasm,

        x86,

        xcor
    }
}