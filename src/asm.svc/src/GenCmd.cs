//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static sys;

    public class AsmGenCmd : WfAppCmd<AsmGenCmd>
    {
        IntelSdm Sdm => Wf.IntelSdm();

        CsLang CsLang => Wf.CsLang();

        SdmCodeGen SdmCodeGen => Wf.SdmCodeGen();

        ApiMd ApiMd => Wf.ApiMd();

        public IProjectWorkspace EtlSource(ProjectId src)
            => Projects.load(AppDb.Dev($"llvm.models/{src}").Root, src);

        /*
        | dec_m16        | dec m16  | FF /1            | Decrement r/m16 by 1.
        | dec_m32        | dec m32  | FF /1            | Decrement r/m32 by 1.
        | dec_m64        | dec m64  | REX.W + FF /1    | Decrement r/m64 by 1.
        | dec_m8         | dec m8   | FE /1            | Decrement r/m8 by 1.
        | dec_m8_rex     | dec m8   | REX + FE /1      | Decrement r/m8 by 1.
        | dec_r16_rex    | dec r16  | 48 +rw           | Decrement r16 by 1.
        | dec_r16        | dec r16  | FF /1            | Decrement r/m16 by 1.
        | dec_r32_rex    | dec r32  | 48 +rd           | Decrement r32 by 1.
        | dec_r32        | dec r32  | FF /1            | Decrement r/m32 by 1.
        | dec_r64        | dec r64  | REX.W + FF /1    | Decrement r/m64 by 1.
        | dec_r8         | dec r8   | FE /1            | Decrement r/m8 by 1.
        | dec_r8_rex     | dec r8   | REX + FE /1      | Decrement r/m8 by 1.
        */
        [CmdOp("gen/sdm/models")]
        Outcome GenAsmCode(CmdArgs args)
        {
            var forms = Sdm.CalcForms().View;
            var buffer = dict<AsmMnemonic,List<SdmForm>>();
            for(var i=0; i<forms.Length; i++)
            {
                ref readonly var form = ref skip(forms,i);
                if(buffer.TryGetValue(form.Mnemonic, out var fl))
                {
                    fl.Add(form);
                }
                else
                {
                    buffer[form.Mnemonic] = new();
                    buffer[form.Mnemonic].Add(form);
                }

            }

            var lookup = buffer.Keys.Map(x => (x,  (Index<SdmForm>)buffer[x].ToArray().Sort())).ToConstLookup();
            var mnemonics = array<AsmMnemonic>("dec");
            var sources = dict<AsmMnemonic,List<IAsmSourcePart>>();
            var g = AsmGen.generator();

            for(var i=0; i<mnemonics.Length; i++)
            {
                ref readonly var mnemonic = ref skip(mnemonics,i);
                if(lookup.Find(mnemonic, out var selected))
                {
                    sources[mnemonic] = new();
                    sources[mnemonic].Add(AsmDirectives.define(AsmDirectiveKind.DK_INTEL_SYNTAX, AsmDirectiveOp.noprefix));
                    var count = selected.Count;
                    for(var j=0; j<count; j++)
                    {
                        ref readonly var form = ref selected[j];
                        var specs = g.Concretize(form);
                        Require.invariant(specs.Count > 0);
                        sources[mnemonic].Add(asm.comment(string.Format("{0} | {1}", form.Sig, form.OpCode)));
                        sources[mnemonic].Add(asm.block(asm.label(form.Name.Format()), specs));
                    }
                }
            }

            foreach(var mnemonic in sources.Keys)
            {
                var file = AsmFileSpec.define(mnemonic.Format(), sources[mnemonic].ToArray());
                var dst = file.Path(EtlSource("mc.models.g").SrcDir("asm"));
                EmittedFile(EmittingFile(dst), file.Save(dst));
            }

            return true;
        }

        [CmdOp("gen/asci/bytes")]
        Outcome EmitAsciBytes(CmdArgs args)
        {
            var name = "Uppercase";
            var content = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var dst = text.buffer();
            var bytes = CsLang.AsciLookups().Emit(8u, name,content, dst);
            Write(dst.Emit());
            return true;
        }

        [CmdOp("gen/asm/sigmatch")]
        void Matcher()
        {
            var forms = Sdm.LoadSigs();
            StringMatcher.tables(Channel,forms.Select(x => x.Format()), AppDb.ApiTargets("codgen"));
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
                Write(dst.Emit());
            }
        }

        [CmdOp("gen/sdm/code")]
        void GenAmsCode()
            => SdmCodeGen.Emit();


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
            Write(result);
        }

        void GenEnumToIntSwitch()
        {
            var src = array<Hex3Kind>(Hex3Kind.x02, Hex3Kind.x03, Hex3Kind.x04);
            var dst = array<byte>(2,3,4);
            var spec = CgSpecs.@switch("enum_test", src, dst);
            var result = CsLang.SwitchMap().Generate(spec);
            Write(result);
        }

        [CmdOp("gen/hex/strings")]
        Outcome GenHexStrings(CmdArgs args)
        {
            var name = "HexStringArrays";
            var ns = "Z0";
            var dst = CsLang.emitter();
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

            FileEmit(dst.Emit(), AppDb.CgStage().Path(name,FileKind.Cs));

            return true;
        }

        [CmdOp("gen/bytes")]
        Outcome BytesEmit(CmdArgs args)
        {
            var dst = text.emitter();
            var offset = 8u;
            RenderByteSpans(offset,dst);
            FileEmit(dst.Emit(), 4, AppDb.CgStage().Path("UnpackedBytes", FileKind.Cs));
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

        [CmdOp("gen/vex/tokens")]
        Outcome GenTokenSpecs(CmdArgs args)
        {
            var result = Outcome.Success;
            var src = Symbols.concat(Symbols.index<AsmOcTokens.VexToken>());
            var name = "VexTokens";
            var dst = AppDb.CgStage().Path("literals", name, FileKind.Cs);
            using var writer = dst.Writer();
            writer.WriteLine(string.Format("public readonly struct {0}", name));
            writer.WriteLine("{");
            CsLang.StringLits().Emit("Data", src, writer);
            writer.WriteLine("}");
            return result;
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

        [CmdOp("gen/asm/specs")]
        Outcome GenInstData(CmdArgs args)
        {
            var g = AsmGen.generator();
            var forms = Sdm.CalcForms();
            var count = forms.Count;
            var buffer = text.buffer();
            var counter = 0u;
            var mnemonics = hashset("and", "or", "xor");
            var sources = dict<string,List<IAsmSourcePart>>();
            iter(mnemonics, name => sources[name] = new());
            iter(mnemonics, mnemonic => sources[mnemonic].Add(AsmDirectives.define(AsmDirectiveKind.DK_INTEL_SYNTAX, AsmDirectiveOp.noprefix)));

            for(var i=0; i<count; i++)
            {
                ref readonly var form = ref forms[i];
                var mnemonic = form.Mnemonic.Format();
                if(mnemonics.Contains(mnemonic))
                {
                    var specs = g.Concretize(form);
                    Require.invariant(specs.Count > 0);
                    sources[mnemonic].Add(asm.comment(string.Format("{0} | {1}", form.Sig, form.OpCode)));
                    sources[mnemonic].Add(asm.block(asm.label(form.Name.Format()), specs));
                }
            }

            foreach(var mnemonic in sources.Keys)
            {
                var file = AsmFileSpec.define(mnemonic, sources[mnemonic].ToArray());
                var dst = file.Path(EtlSource("mc.models").SrcDir("asm"));
                EmittedFile(EmittingFile(dst), file.Save(dst));
            }

            return true;
        }

        [CmdOp("gen/limits")]
        Outcome XedCheck(CmdArgs args)
        {
            const string CommentPattern = "Specifies the maximum value of a {0}-bit number, {1:#,#}";
            const string NamePattern = "Max{0}u";
            var max = 0ul;
            var emitter = CsLang.emitter();
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

            FileEmit(emitter.Emit(), AppDb.CgStage().Path("limit", FileKind.Cs));

            return true;
        }

        [CmdOp("gen/enum/replicants")]
        Outcome GenEnums(CmdArgs args)
        {
            const string Name = "api.types.enums";
            var src = AppDb.ApiTargets().Path(Name, FileKind.List);
            var types = ApiMd.types(src);
            var name = "EnumDefs";
            CsLang.EmitReplicants(CsLang.replicant(AppDb.CgStage(name).Root, out var spec), types.Select(x => x.Type), AppDb.CgStage(name).Root);
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
                Error(FS.missing(src));
            }
            else
            {
                var items = new ItemList<Constant<string>>("CsKeywordList", mapi(src.ReadLines(), (i,line) => new ListItem<Constant<string>>((uint)i,text.trim(line))));
                var dst = text.buffer();
                CsLang.EmitArrayInitializer(items,dst);
                Write(dst.Emit());

            }
            return true;
        }
    }
}