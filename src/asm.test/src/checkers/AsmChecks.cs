//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static AsmPrefixCodes;
    using static sys;

    using gp32 = AsmRegTokens.Gp32Reg;

    [ApiHost]
    public partial class AsmCheckCmd_X : CheckCmd<AsmCheckCmd_X>
    {    

        [CmdOp("asm/check/tokens")]
        void CheckAsmTokens()
        {
            AsmSigs.parse("adc r16, r16", out var sig);
            SdmOpCodes.parse("11 /r", out var oc1);
            SdmOpCodes.parse("13 /r", out var oc2);
            // var count = min(oc1.TokenCount, oc2.TokenCount);
            // var token = AsmOcToken.Empty;
            // for(var i=0; i<count; i++)
            // {
            //     ref readonly var ta = ref oc1[i];
            //     ref readonly var tb = ref oc2[i];
            //     if(ta.Kind == AsmOcTokenKind.Sep && tb.Kind == AsmOcTokenKind.Sep)
            //         continue;

            //     if(ta != tb)
            //     {
            //         token = tb;
            //         break;
            //     }
            // }

            // if(SdmOpCodes.diff(oc1, oc2, out token))
            //     Write(token.Format());

            var sigs = AsmSigTokens.create();
            var src = sigs;
            var types = src.TokenTypes;
            for(var i=0; i<types.Length; i++)
            {
                var sigTokens = src.TokensByType(skip(types,i));
                for(var j=0;j<sigTokens.Count; j++)
                {
                    Write(sigTokens[j].Format());
                }
            }
        }

        [CmdOp("asm/check/res")]
        void CheckStringRes()
        {
            var resources = TextAssets.strings(typeof(AsciText)).View;
            iter(resources, r => Write(r.Format()));
        }

    }
}