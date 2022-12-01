//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class IntelSdm
    {
        public void ExportTokens()
        {
            Channel.TableEmit(AsmTokens.OcTokenDefs.View, SdmPaths.TokensDst("sdm.tokens.opcodes"), UTF16);
            Channel.TableEmit(AsmTokens.SigTokenDefs.View, SdmPaths.TokensDst("sdm.tokens.sigs"), UTF16);
            Channel.TableEmit(AsmTokens.TokenDefs.View, SdmPaths.TokensDst("sdm.tokens"), UTF16);
        }
    }
}