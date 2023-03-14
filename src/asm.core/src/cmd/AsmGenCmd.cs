//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class AsmGenCmd : WfAppCmd<AsmGenCmd>
    {
        CsLang CsLang => Wf.CsLang();

        SymbolFactories SymbolFactories => Channel.Channeled<SymbolFactories>();
     
        SymGen SymGen => Channel.Channeled<SymGen>();

        public IProjectWorkspace EtlSource(ProjectId src)
            => Projects.load(AppDb.Dev($"llvm.models/{src}"), src);


        [CmdOp("gen/limits")]
        Outcome XedCheck(CmdArgs args)
        {
            const string CommentPattern = "Specifies the maximum value of a {0}-bit number, {1:#,#}";
            const string NamePattern = "Max{0}u";
            var max = 0ul;
            var emitter = CsGen.emitter();
            var offset = 0u;
            emitter.Namespace(offset, "Z0");
            emitter.LiteralProvider(offset);
            emitter.OpenStruct(offset, "Limit");
            offset+=4;
            for(var i=1; i<=64; i++)
            {
                emitter.Comment(offset, string.Format(CommentPattern, i, max));
                max = Numbers.max((byte)i);
                if(i <= 8)
                    emitter.NumericLit(offset, string.Format(NamePattern,i), (byte)max);
                else if(i <= 16)
                    emitter.NumericLit(offset, string.Format(NamePattern,i), (ushort)max);
                else if(i <= 32)
                    emitter.NumericLit(offset, string.Format(NamePattern,i), (uint)max);
                else if(i <= 64)
                    emitter.NumericLit(offset, string.Format(NamePattern,i), (ulong)max);
                emitter.AppendLine();
            }
            offset-=4;
            emitter.CloseStruct(offset);
            offset-=4;

            Channel.FileEmit(emitter.Emit(), AppDb.CgStage().Path("limit", FileKind.Cs));

            return true;
        }

        [CmdOp("gen/syms/factories")]
        Outcome GenSymFactories(CmdArgs args)
        {
            var name = "AsmRegTokens";
            var dst = AppDb.CgStage().Path(name, FileKind.Cs);
            var src = typeof(AsmRegTokens).GetNestedTypes().Where(x => x.Tagged<SymSourceAttribute>());
            SymbolFactories.Emit("Z0.Asm", name, src, dst);
            return true;
        }

        [CmdOp("gen/enum/replicants")]
        Outcome GenEnums(CmdArgs args)
        {
            const string Name = "api.types.enums";
            var src = AppDb.ApiTargets().Path(Name, FileKind.List);
            var types = ApiMd.types(src);
            var name = "EnumDefs";
            SymGen.EmitReplicants(SymGen.replicant(AppDb.CgStage(name).Root, out var spec), types.Select(x => x.Type), AppDb.CgStage(name).Root);
            return true;
        }


    }
}