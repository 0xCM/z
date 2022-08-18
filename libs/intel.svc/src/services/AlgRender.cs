//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static IntrinsicsDoc;

    partial class IntelInx
    {
        public class AlgRender
        {
            public static void render(ReadOnlySpan<IntrinsicDef> src, ITextEmitter dst)
            {
                for(var i=0; i<src.Length; i++)
                {
                    if(i!=0)
                        dst.AppendLine();

                    ref readonly var def = ref skip(src,i);
                    overview(def,dst);
                    dst.AppendLine(def.Sig());
                    body(def,dst);
                }
            }

            static void body(IntrinsicDef src, ITextEmitter dst)
            {
                dst.AppendLine("{");
                emit(src.operation, dst);
                dst.AppendLine("}");
            }

            static void emit(Operation src, ITextEmitter dst)
            {
                if(src.IsNonEmpty)
                    iter(src.Content, x => dst.AppendLine("  " + x.Content));
            }

            static void overview(IntrinsicDef src, ITextEmitter dst)
            {
                dst.AppendLine(string.Format("# Intrinsic: {0}", src.Sig()));

                if(nonempty(src.tech))
                    dst.AppendLineFormat("# Tech: {0}", src.tech);

                if(src.CPUID.IsNonEmpty)
                    dst.AppendLineFormat("# CpuId: {0}", src.CPUID);

                if(src.category.IsNonEmpty)
                    dst.AppendLineFormat("# Category: {0}", src.category);

                iter(src.instructions, x => {
                    dst.AppendLineFormat("# Instruction: {0}", x);
                    dst.AppendLineFormat("# IForm: {0}", x.xed);
                });

                dst.AppendLineFormat("# Description: {0}", src.description);
            }
         }
    }
}