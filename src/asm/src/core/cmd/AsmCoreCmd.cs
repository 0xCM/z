//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using static sys;

    public partial class AsmCoreCmd : WfAppCmd<AsmCoreCmd>
    {
        OmniScript OmniScript => Wf.OmniScript();
        
        StanfordAsmCatalog StanfordCatalog => Wf.StanfordCatalog();

        Outcome AsmExe(CmdArgs args)
        {
            var result = Outcome.Success;
            var id = arg(args,0).Value;
            var script = FilePath.Empty;
            result = ExecVarScript(id, script);
            if(result.Fail)
                return result;
            //var exe = AsmWs.ExePath(id);
            var exe = FilePath.Empty;
            var clock = Time.counter(true);
            var process = Process.Start(exe.Format());
            process.WaitForExit();
            var duration = clock.Elapsed();
            Write(string.Format("runtime:{0}", duration));
            return result;
        }

        Outcome ExecVarScript(string SrcId, FilePath script)
        {
            var result = Outcome.Success;
            var vars = CmdScripts.vars(("SrcId", SrcId));
            var cmd = new CmdLine(script.Format(PathSeparator.BS));
            return OmniScript.Run(cmd, vars, out var response);
        }

        // Outcome AsmConfig(CmdArgs args)
        // {
        //     var result = OmniScript.Run(FolderPath.Empty + FS.file("log-config",FileKind.Cmd), out var response);
        //     if(result.Fail)
        //         return result;

        //     var src = Settings.parse(response, Chars.Colon);
        //     var count = src.Length;
        //     var vars = new CmdVar[count];
        //     for(var i=0; i<count; i++)
        //     {
        //         ref readonly var facet = ref src[i];
        //         seek(vars,i) = new (facet.Name, facet.Value);
        //     }

        //     iter(vars, v => Write(v.VarName,
        //         if(v.Value(out var _value))
        //         v.Evaluated ? string.Format("{0} (Evaluated)", v.Value) : string.Format("{0} (Symbolic)", v.Value))
        //         );

        //     return result;
        // }


        [CmdOp("hexify")]
        void Hexify(CmdArgs args)
        {
            var src = arg(args,0).Value;
            var pattern = arg(args,1).Value;
            var files = FS.files(FS.dir(src), pattern, true);
            var dst = AppDb.DbTargets("hexify");
            ApiCode.hexify(Channel, files, dst);
        }

        Outcome LoadStanfordForms()
        {
            var rows = StanfordCatalog.LoadSource();
            var count = rows.Length;
            var forms = alloc<AsmFormInfo>(count);
            var dst = list<string>();
            for(var i=0; i<count; i++)
            {
                ref readonly var row = ref skip(rows,i);
                AsmSigInfo.parse(row.Instruction, out var sig);
                var form = new AsmFormInfo(new (row.OpCode), sig);
                seek(forms,i) = form;
                var spec = string.Format("{0,-32} | {1,-42} | {2,-42}", form.Sig.Mnemonic, form.OpCode, form.Sig);
                dst.Add(spec);
            }

            dst.Sort();
            iter(dst.ViewDeposited(), x => Wf.Data(x));

            return true;
        }
    }
}