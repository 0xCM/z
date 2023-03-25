//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static sys;
    using static XedDisasm;
    using static XedRules;

    public partial class XedCmd : WfAppCmd<XedCmd>
    {
        CsLang CsLang => Channel.Channeled<CsLang>();

        AsmObjects AsmObjects => Wf.AsmObjects();

        SdmCodeGen SdmCodeGen => Wf.SdmCodeGen();

        XedPaths XedPaths => Xed.Paths;

        XedDb XedDb => Xed.XedDb;

        IntelSdm Sdm => Wf.IntelSdm();

        XedProject XedProject => Wf.XedProject();

        public IProjectWorkspace LlvmModels(string scope)
            => Projects.load(AppDb.Dev($"llvm.models/{scope}"));

        [CmdOp("xed/headers")]
        void XedHeaders()
        {
            var src = XedProject.KitHeaders();
            iter(src, file => Channel.Row(file));
        }
        
        [CmdOp("asm/gen/specs")]
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
                var dst = LlvmModels("mc.models").SrcDir("asm") + FS.file(file.Name, FileKind.Asm);
                Channel.FileEmit(file.Format(), dst);
            }

            return true;
        }

        [CmdOp("asm/gen/sigmatch")]
        void Matcher()
        {
            var forms = Sdm.LoadSigs();
            StringMatcher.tables(Channel,forms.Select(x => x.Format()), AppDb.ApiTargets("codgen"));
        }

        [CmdOp("asm/gen/vex")]
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
        [CmdOp("asm/gen/code")]
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
                var dst = file.Path(LlvmModels("mc.models.g").SrcDir("asm"));
                EmittedFile(EmittingFile(dst), file.Save(dst));
            }

            return true;
        }

        [CmdOp("gen/sdm/code")]
        void GenAmsCode()
            => SdmCodeGen.Emit(AppDb.CgStage(CgTarget.Intel.ToString()));

        ref readonly Index<InstPattern> Patterns
            => ref Xed.Views.Patterns;

        XedRuntime Xed => GlobalServices.Instance.Injected<XedRuntime>();

        [CmdOp("project/xed/etl")]
        void XedCollect()
            => Xed.Disasm.Collect(ProjectContext());

        [CmdOp("xed/start")]
        void StartRuntime()
        {
            if(!Xed.Running)
                Xed.Start();
        }

        [CmdOp("xed/emit/types")]
        Outcome CheckXedDb(CmdArgs args)
        {
            var rows = Xed.Views.TypeTables.SelectMany(x => x.Rows).Sort().Resequence();
            Channel.TableEmit(rows, XedPaths.DbTable<TypeTableRow>());
            return true;
        }

        [CmdOp("xed/emit/sigs")]
        void EmitInstSig()
            => Xed.Rules.EmitInstSigs(Xed.Views.Patterns);

        [CmdOp("xed/import")]
        void RunImport()
            => Xed.Import.Run();

        [CmdOp("xed/import/check")]
        void CheckXedImports()
        {
            var blocks = Xed.Views.InstImports;
            ref readonly var lines = ref blocks.BlockLines;
            var forms = lines.Keys.Index().Sort();
            ref readonly var source = ref blocks.DataSource;
        }

        [CmdOp("xed/disasm/flow")]
        void RunDisasmFlow()
        {
            var context = ProjectContext();
            var flow = XedDisasm.flow(context);
            var targets = sys.bag<ITarget>();
            var sources = XedDisasm.sources(context);
            iter(XedDisasm.sources(context), src => {
                var dst = Wf.DisasmAnalyser();
                flow.Run(src,dst);
                targets.Add(dst);
            }, true);
        }

        [CmdOp("xed/emit/seq")]
        void EmitSeq()
            => Xed.Rules.EmitSeq();

        [CmdOp("xed/emit/patterns")]
        void EmitPatterns()
            => Xed.Rules.EmitPatternData(Xed.Views.Patterns);

        [CmdOp("xed/emit/expr")]
        void EmitRuleExpr()
            => Xed.Rules.Emit(Xed.Views.RuleExpr);

        [CmdOp("xed/db/emit")]
        void DbEmit()
            => Xed.XedDb.EmitArtifacts();

        [CmdOp("xed/emit/rules/tables")]
        void EmitRuleTables()
            => Xed.Rules.EmitRuleData(Xed.Views.RuleTables);

        [CmdOp("xed/emit/rules/pages")]
        void EmitTableDefs()
            => Xed.Rules.EmitRulePages(Xed.Views.RuleTables);

        [CmdOp("xed/emit/rules/specs")]
        void EmitTableCells()
            => Xed.Rules.EmitTableSpecs(Xed.Views.RuleTables);

        [CmdOp("xed/emit/docs")]
        void EmitDocs()
            => Xed.Docs.Emit();

        [CmdOp("xed/emit/attribs")]
        void EmitInstAttribs()
            => Xed.Rules.EmitInstAttribs(Xed.Views.Patterns);

        [CmdOp("xed/emit/groups")]
        void EmitInstGroups()
            => Xed.Rules.EmitInstGroups(Xed.Rules.CalcInstGroups(Xed.Views.Patterns));

        [CmdOp("xed/etl")]
        void EmitXedCat()
        {
            Xed.Start();
            Xed.RunEtl();
        }

        void GenRuleNames(FilePath path)
        {
            var assets = IntrinsicAssets.create();
            var header = assets.XedFileHeader().Utf8();

            var rules = Xed.Views.RuleTables;
            ref readonly var specs = ref rules.Specs();
            var rulenames = specs.Keys.Select(x => x.TableName.ToString()).ToHashSet();
            var names = rulenames.Index().Sort();

            var dst = text.emitter();
            dst.WriteLine(header);
            dst.WriteLine("namespace Z0");
            dst.WriteLine("{");
            var indent = 4u;

            dst.IndentLine(indent,"partial class XedRules");
            dst.IndentLine(indent,"{");
            indent+=4;
            dst.IndentLine(indent,"public enum RuleName : ushort");
            dst.IndentLine(indent,"{");
            var k=0u;
            indent += 4;
            dst.IndentLineFormat(indent, "{0} = {1},", "None", k++);
            dst.WriteLine();
            for(var i=0; i<names.Count; i++, k++)
            {
                ref readonly var name = ref names[i];
                dst.IndentLineFormat(indent, "{0} = {1},", name, k);
                if(i != names.Count-1)
                    dst.WriteLine();
            }
            indent -= 4;
            dst.IndentLine(indent,"}");
            indent -=4;
            dst.IndentLine(indent,"}");
            indent -=4;
            dst.Indent(indent,"}");
            using var writer = path.Utf8Emitter();
            writer.Write(dst.Emit());
        }

        [CmdOp("xed/gen/rulenames")]
        void GenRuleNames()
        {
            var path = FS.path(@"J:\z0\apps\asm.core\intel.xed\rules\models\RuleName.cs");
            GenRuleNames(path);
        }
    }
}