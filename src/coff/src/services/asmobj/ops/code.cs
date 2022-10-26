//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial class AsmObjects
    {
        public static AsmCode code(CompositeDispenser dispenser, in AsmEncodingInfo src)
        {
            ref readonly var code = ref src.Encoded;
            var size = code.Size;
            var hex = dispenser.Reserve(size);
            var hexsrc = code.View;
            var hexdst = hex.Edit;
            for(var j=0; j<size; j++)
                seek(hexdst,j) = skip(hexsrc,j);
            return new AsmCode(EncodingId.from(src.IP, code), src.Seq, src.DocSeq, src.OriginId, dispenser.Source(src.Asm.Format()), src.IP, hex);
        }
    }
}