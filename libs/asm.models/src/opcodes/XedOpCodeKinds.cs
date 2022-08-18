//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class XedOpCodeKinds
    {
        public static XedOpCodeKinds Instance => _Instance;

        static XedOpCodeKinds _Instance = new();

        Index<XedMapKind> Data;

        XedOpCodeKinds()
        {
            Data = derive();
        }

        public ReadOnlySpan<XedMapKind> Records
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        static Index<XedMapKind> derive()
        {
            var counter = z8;
            var count = 0u;
            var legacy = Symbols.index<AsmBaseMapKind>();
            var xop = Symbols.index<XopMapKind>();
            var vex = Symbols.index<VexMapKind>();
            var evex = Symbols.index<EvexMapKind>();

            var counts = legacy.Count + xop.Count + vex.Count + evex.Count;
            var buffer = alloc<XedMapKind>(counts);

            count = legacy.Count;
            for(var i=0u; i<count; i++)
            {
                ref readonly var sym = ref legacy[i];
                ref var dst = ref seek(buffer, counter);
                dst.Index = counter++;
                dst.Class = AsmOpCodeClass.Base;
                dst.Code = sym.Expr.Format();
                dst.Number = (byte)sym.Kind;
                dst.Kind = (XedOpCodeKind)((ushort)dst.Class | ((ushort)sym.Kind << 8));
            }

            count = xop.Count;
            for(var i=0u; i<count; i++)
            {
                ref readonly var sym = ref xop[i];
                ref var dst = ref seek(buffer,counter);
                dst.Index = counter++;
                dst.Class = AsmOpCodeClass.Xop;
                dst.Code = sym.Expr.Format();
                dst.Number = (byte)sym.Kind;
                dst.Kind = (XedOpCodeKind)((ushort)dst.Class | ((ushort)sym.Kind << 8));
            }

            count = vex.Count;
            for(var i=0u; i<count; i++)
            {
                ref readonly var sym = ref vex[i];
                ref var dst = ref seek(buffer,counter);
                dst.Index = counter++;
                dst.Class = AsmOpCodeClass.Vex;
                dst.Code = sym.Expr.Format();
                dst.Number = (byte)sym.Kind;
                dst.Kind = (XedOpCodeKind)((ushort)dst.Class | ((ushort)sym.Kind << 8));
            }

            count = evex.Count;
            for(var i=0u; i<count; i++)
            {
                ref readonly var sym = ref evex[i];
                ref var dst = ref seek(buffer,counter);
                dst.Index = counter++;
                dst.Class = AsmOpCodeClass.Evex;
                dst.Code = sym.Expr.Format();
                dst.Number = (byte)sym.Kind;
                dst.Kind = (XedOpCodeKind)((ushort)dst.Class | ((ushort)sym.Kind << 8));
            }

            return buffer;
        }
    }
}