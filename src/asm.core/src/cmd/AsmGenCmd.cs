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

        public IProjectWorkspace EtlSource(ProjectId src)
            => Projects.load(AppDb.Dev($"llvm.models/{src}"), src);

        [CmdOp("gen/asci/bytes")]
        Outcome EmitAsciBytes(CmdArgs args)
        {
            var name = "Uppercase";
            var content = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var dst = text.buffer();
            var bytes = CsLang.AsciLookups().Emit(8u, name,content, dst);
            Channel.Write(dst.Emit());
            return true;
        }

        [CmdOp("gen/cs/keywords")]
        void GenCsKeywords()
        {
            var src = AppDb.AppData().Path("ms.cs.keywords", FileKind.List);
            const string FieldName = "CsKeywordList";
            if(!src.Exists)
            {
                Error(FS.missing(src));
            }
            else
            {
                var list = ItemLists.constants(FieldName, src.ReadLines(skipBlank:true).Storage);
                var dst = text.buffer();
                dst.Append("public static string[] ");
                CsLang.EmitArrayInitializer(list,dst);
                Channel.Write(dst.Emit());
            }
        }

        [CmdOp("gen/switchmaps")]
        Outcome GenSwitchMap(CmdArgs args)
        {
            GenIntSwitch();
            GenEnumToIntSwitch();
            return true;
        }

        void GenIntSwitch()
        {
            var src = array<uint>(34, 51, 98, 101, 264, 888, 911, 902, 3828, 13, 19);
            var dst = array<uint>(3000, 201, 197, 313145, 264801, 911122, 4, 7, 11, 54, 99);
            var spec = CgSpecs.@switch("test", src, dst);
            var result = CsLang.SwitchMap().Generate(spec);
            Channel.Write(result);
        }

        void GenEnumToIntSwitch()
        {
            var src = array<Hex3Kind>(Hex3Kind.x02, Hex3Kind.x03, Hex3Kind.x04);
            var dst = array<byte>(2,3,4);
            var spec = CgSpecs.@switch("enum_test", src, dst);
            var result = CsLang.SwitchMap().Generate(spec);
            Channel.Write(result);
        }

        [CmdOp("gen/hex/strings")]
        Outcome GenHexStrings(CmdArgs args)
        {
            var name = "HexStringArrays";
            var ns = "Z0";
            var dst = Z0.CsLang.emitter();
            var offset = 0u;
            dst.OpenNamespace(offset, ns);
            offset += 4;
            dst.OpenStruct(offset, name);
            offset +=4;

            var content = CsLang.HexStrings().GenArray("Hex8Strings", byte.MinValue, byte.MaxValue, LetterCaseKind.Upper);
            dst.IndentLine(offset,content);
            offset -= 4;
            dst.CloseStruct(offset);
            offset -= 4;
            dst.CloseNamespace(offset);

            Channel.FileEmit(dst.Emit(), AppDb.CgStage().Path(name,FileKind.Cs));

            return true;
        }

        [CmdOp("gen/bytes")]
        Outcome BytesEmit(CmdArgs args)
        {
            var dst = text.emitter();
            var offset = 8u;
            RenderByteSpans(offset,dst);
            Channel.FileEmit(dst.Emit(), 4, AppDb.CgStage().Path("UnpackedBytes", FileKind.Cs));
            return true;
        }

        public static void RenderByteSpans(uint offset, ITextEmitter dst)
        {
            Bytes.bytespan<byte>(0,255,offset,dst);
            Bytes.bytespan<ushort>(0,255,offset,dst);
            Bytes.bytespan<uint>(0,255,offset,dst);
            Bytes.bytespan<ulong>(0,255,offset,dst);
            Bytes.bytespan<ushort>(0, 511, offset, dst);
            Bytes.bytespan<ushort>(0, Pow2.T11m1, offset, dst);
        }

        SymbolFactories SymbolFactories => Wf.SymbolFactories();
     
        [CmdOp("gen/syms/factories")]
        Outcome GenSymFactories(CmdArgs args)
        {
            var name = "AsmRegTokens";
            var dst = AppDb.CgStage().Path(name, FileKind.Cs);
            var src = typeof(AsmRegTokens).GetNestedTypes().Where(x => x.Tagged<SymSourceAttribute>());
            SymbolFactories.Emit("Z0.Asm", name, src, dst);
            return true;
        }
        
        [CmdOp("gen/strings/ints")]
        Outcome GenIntStrings(CmdArgs args)
        {
            var result = Outcome.Success;
            result = DataParser.parse(arg(args,0).Value, out uint min);
            result = DataParser.parse(arg(args,1).Value, out uint max);
            var values = list<string>();
            var name = string.Format("Range{0}To{1}", min, max);
            var n = max.ToString().Length;
            for(var i=min; i<=max; i++)
                values.Add(i.ToString().PadLeft(n));

            var dst = AppDb.CgStage().Path("literals", name, FileKind.Cs);
            CsLang.StringLits().Emit(name,values.ViewDeposited(), dst);
            return result;
        }

        [CmdOp("gen/limits")]
        Outcome XedCheck(CmdArgs args)
        {
            const string CommentPattern = "Specifies the maximum value of a {0}-bit number, {1:#,#}";
            const string NamePattern = "Max{0}u";
            var max = 0ul;
            var emitter = Z0.CsLang.emitter();
            var offset = 0u;
            emitter.OpenNamespace(offset, "Z0");
            offset+=4;
            emitter.LiteralProvider(offset);
            emitter.OpenStruct(offset, "Limit");
            offset+=4;
            for(var i=1; i<=64; i++)
            {
                emitter.SummaryComment(offset, string.Format(CommentPattern, i, max));
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
            emitter.CloseNamespace(offset);

            Channel.FileEmit(emitter.Emit(), AppDb.CgStage().Path("limit", FileKind.Cs));

            return true;
        }

        [CmdOp("gen/enum/replicants")]
        Outcome GenEnums(CmdArgs args)
        {
            const string Name = "api.types.enums";
            var src = AppDb.ApiTargets().Path(Name, FileKind.List);
            var types = ApiMd.types(src);
            var name = "EnumDefs";
            CsLang.EmitReplicants(CsLang.Enums.replicant(AppDb.CgStage(name).Root, out var spec), types.Select(x => x.Type), AppDb.CgStage(name).Root);
            return true;
        }

        [CmdOp("gen/symspan")]
        void GenSymSpan()
            => CsLang.EmitSymSpan<AsciLetterLoSym>(AppDb.CgStage().Path("symspan", FileKind.Cs));

        [CmdOp("gen/enum/cs/keywords")]
        Outcome CsKeywords(CmdArgs args)
        {
            var src = AppDb.CgStage().Path("ms","ms.cs.keywords", FileKind.List);
            if(!src.Exists)
            {
                Channel.Error(FS.missing(src));
            }
            else
            {
                var items = new ItemList<Constant<string>>("CsKeywordList", mapi(src.ReadLines(), (i,line) => new ListItem<Constant<string>>((uint)i,text.trim(line))));
                var dst = text.buffer();
                CsLang.EmitArrayInitializer(items,dst);
                Channel.Write(dst.Emit());

            }
            return true;
        }
    }
}