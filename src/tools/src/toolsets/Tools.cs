//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class XedDomain
    {

    }

    public partial class FileFlows
    {
        
    }

    [ApiHost]
    public partial class Tools : ITools
    {
        // public static IEnumerable<FileUri> files(FolderPath src, params FileKind[] kinds)
        // {
        //     if(kinds.Length != 0)
        //         return DbArchive.enumerate(src,true,kinds);
        //     else
        //         return DbArchive.enumerate(src,"*.*",true);
        // }

        [MethodImpl(Inline), Op]
        public static CmdTool tool(string name)
            => new CmdTool(name);
            
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

        public static ref readonly Zsh ztool => ref Zsh.Instance;

        public static ref readonly XedTool xed => ref XedTool.Instance;

        public static ref readonly BdDisasm bddisasm => ref BdDisasm.Instance;

        public static ref readonly VisualStudio msvs => ref VisualStudio.Instance;
    }

    partial class XTend
    {

    }
}