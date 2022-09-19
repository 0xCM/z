//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Tools;

    public interface ITools
    {

        
    }
    public static partial class XTend
    {
        [MethodImpl(Inline)]
        public static LlcCmd Command(this Llc tool, FilePath src, FilePath dst)
        {
            var cmd = new LlcCmd();
            cmd.Source = src;
            cmd.Target = dst;
            return cmd;
        }

        [MethodImpl(Inline)]
        public static ref readonly Xed xed(this ITools tools)
            => ref Tools.xed;

        [MethodImpl(Inline)]
        public static ref readonly LlvmTableGen tablgen(this ITools tools)
            => ref Tools.llvm_tblgen;

        [MethodImpl(Inline)]
        public static ref readonly Llc llc(this ITools tools)
            => ref Tools.llc;

        [MethodImpl(Inline)]
        public static ref readonly LlvmMc llvm_mc(this ITools tools)
            => ref Tools.llvm_mc;

        [MethodImpl(Inline)]
        public static ref readonly LlvmObjDump objdump(this ITools tools)
            => ref Tools.llvm_objdump;

        [MethodImpl(Inline)]
        public static ref readonly Clang clang(this ITools tools)
            => ref Tools.clang;

        [MethodImpl(Inline)]
        public static ref readonly T Tool<T>(this ITools tools)
            where T : Tool<T>, new()
                => ref Tools.tool<T>();
    }
}