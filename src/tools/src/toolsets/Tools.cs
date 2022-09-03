//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class XedDomain
    {

    }

    [ApiHost]
    public partial class Tools : ITools
    {
        [MethodImpl(Inline)]
        public static ref readonly T tool<T>()
            where T : Tool<T>, new()
                => ref Tool<T>.Instance;

        public static ref readonly Llc llc => ref Llc.Instance;

        public static ref readonly LlvmMc llvm_mc => ref LlvmMc.Instance;

        public static ref readonly LlvmConfig llvm_config => ref LlvmConfig.Instance;

        public static ref readonly Clang clang => ref Clang.Instance;

        public static ref readonly LlvmObjDump llvm_objdump => ref LlvmObjDump.Instance;

        public static ref readonly LlvmTableGen llvm_tblgen => ref LlvmTableGen.Instance;

        public static ref readonly LlvmReadObj llvm_readobj => ref LlvmReadObj.Instance;

        public static ref readonly LlvmDis llvm_dis => ref LlvmDis.Instance;

        public static ref readonly LlvmAs llvm_as => ref LlvmAs.Instance;

        public static ref readonly LlvmLld llvm_lld => ref LlvmLld.Instance;

        public static ref readonly ZTool ztool => ref ZTool.Instance;

        public static ref readonly Xed xed => ref Xed.Instance;

        public static ref readonly BdDisasm bddisasm => ref BdDisasm.Instance;

        public static ref readonly VisualStudio msvs => ref VisualStudio.Instance;

        public sealed class ZTool : Tool<ZTool>
        {
            public ZTool()
                : base("ZTool")
            {

            }

            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();
        }

    }

    partial class XTend
    {

    }
}