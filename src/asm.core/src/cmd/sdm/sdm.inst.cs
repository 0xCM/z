//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    partial class AsmCoreCmd
    {
        [CmdOp("sdm/inst")]
        void ShowInstInfo(CmdArgs args)
        {
            var details = Sdm.LoadOcDetails();
            var forms  = SdmOps.forms(details);
            for(var i=0; i<forms.Count; i++)
            {
                ref readonly var form = ref forms[i];
                ref readonly var opcode = ref details[i];

                Write(string.Format("{0,-16} | {1,-64} | {2}", form.Mnemonic, form.Sig, form.OpCode));
            }
        }
    }
}