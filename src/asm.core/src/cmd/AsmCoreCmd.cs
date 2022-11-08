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
        AsmRegSets Regs => Service(AsmRegSets.create);

        StanfordAsmCatalog StanfordCatalog => Wf.StanfordCatalog();

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