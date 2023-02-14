//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using N = AsmOpCodeMaps.Literals;

    [SymSource(AsmOpCodeMaps.group), DataWidth(3)]
    public enum XedVexClass : byte
    {
        [Symbol("", "VEXVALID=0")]
        None = 0,

        [Symbol(N.VV1, "VEXVALID=1")]
        VV1 = 1,

        [Symbol(N.EVV, "VEXVALID=2")]
        EVV = 2,

        [Symbol(N.XOPV, "VEXVALID=3")]
        XOPV = 3,

        [Symbol(N.KVV, "VEXVALID=4, KNC EVEX")]
        KVV = 4,
    }    
}