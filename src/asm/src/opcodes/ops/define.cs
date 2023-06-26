//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class SdmOpCodes
    {
        [MethodImpl(Inline)]
        public static bool diff(AsmOpCodeSpec oc1, AsmOpCodeSpec oc2, out AsmOcToken x)
        {
            var count = sys.min(oc1.TokenCount, oc2.TokenCount);
            x = default;
            for(var i=0; i<count; i++)
            {
                ref readonly var ta = ref oc1[i];
                ref readonly var tb = ref oc2[i];
                if(ta.Kind == AsmOcTokenKind.Sep && tb.Kind == AsmOcTokenKind.Sep)
                    continue;

                if(ta != tb)
                {
                    x = tb;
                    return true;
                }
            }

            return false;
        }

        [Op]
        public static AsmOpCodeSpec define(ReadOnlySpan<AsmOcToken> src)
        {
            var storage = Cell512.Empty;
            var tokens = sys.recover<AsmOcToken>(sys.bytes(storage));
            var counter = z8;
            for(var i=0; i<AsmOpCodeSpec.TokenCapacity; i++)
            {
                if(sys.skip(tokens,i).Id != 0)
                    counter++;
                else
                    break;
            }

            //storage.Cell8(31) = counter;
            return new AsmOpCodeSpec(storage);
        }
    }
}