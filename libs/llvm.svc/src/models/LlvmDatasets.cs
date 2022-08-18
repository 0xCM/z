//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static LlvmTargetName;

    public abstract class LlvmDatasets<D> : LlvmDatasets
        where D : LlvmDatasets<D>,new()
    {
        public static readonly D Instance = new();
    }

    [LiteralProvider("llvm.datasets")]
    public abstract class LlvmDatasets
    {
        // aarch64, amdgcn, arm, bpf, hexagon, mips, nvvm, ppc, r600, riscv, s390, ve, wasm, x86, xcor
        public sealed class X86Datasets : LlvmDatasets<X86Datasets>
        {
            public override LlvmTargetName Target
                => LlvmTargetName.x86;
        }

        public static LlvmDatasets dataset(LlvmTargetName target)
            => target switch
            {
                x86 => X86Datasets.Instance,
                _ => null
            };

        public abstract LlvmTargetName Target {get;}

        public string Records => $"{Target}.records";

        public string Classes => $"{Target}.records.classes";

        public string ClassFields => $"{Target}.records.classes.fields";

        public string Defs => $"{Target}.records.defs";

        public string DefFields => $"{Target}.records.defs.fields";

        public const string X86Defs = "X86.records.defs";

        public const string X86DefFields = "X86.records.defs.fields";

        public const string X86Classes = "X86.records.classes";

    }
}