//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static XedModels;

    partial class XedRules
    {
        public void EmitInstAttribs(Index<InstPattern> src)
        {
            const byte BaseCount = 4;
            const byte AttribCount = 8;
            const sbyte AttribPad = -32;
            const string Sep = " | ";
            const byte CellCount = BaseCount + AttribCount;

            var j=z8;
            var k=z8;
            var slots = new string[CellCount];
            seek(slots,j++) = "{0,-10}";
            seek(slots,j++) = "{1,-18}";
            seek(slots,j++) = "{2,-26}";
            seek(slots,j++) = "{3,-12}";

            var headers = new string[CellCount];
            seek(headers,k++) = "PatternId";
            seek(headers,k++) = "InstClass";
            seek(headers,k++) = "OpCode";
            seek(headers,k++) = "AttribCount";

            var cells = new object[CellCount];

            for(byte i=0; i<AttribCount; i++,j++,k++)
            {
                seek(slots,j) = RpOps.slot(j, AttribPad);
                seek(headers,k) = string.Format("Attrib{0:D2}", i);
            }

            var render = slots.Intersperse(" | ").Concat();
            var header = string.Format(render, headers);
            var dst = text.buffer();
            dst.AppendLine(header);
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var pattern = ref src[i];
                ref readonly var attribs = ref pattern.Attributes;
                var set = attribs.Bitset();
                if(pattern.Scalable)
                    set.Include(InstAttribKind.SCALABLE);

                var acount = set.Count();
                Demand.lteq(acount, AttribCount);

                var m=0;
                seek(cells,m++) = pattern.PatternId;
                seek(cells,m++) = pattern.InstClass;
                seek(cells,m++) = pattern.OpCode;
                seek(cells,m++) = acount;
                if(set.IsNonEmpty)
                {
                    var _attribs = set.Format("|").Split(Chars.Pipe);
                    for(var q=z8; q < _attribs.Length && m<CellCount; q++,m++)
                        seek(cells,m) = skip(_attribs,q);

                    for(var q=m; q<CellCount; q++,m++)
                        seek(cells,m) = EmptyString;

                }
                else
                {
                    for(var q=m; q<CellCount; q++)
                        seek(cells,q) = EmptyString;
                }

                dst.AppendLineFormat(render, cells);

            }

            Channel.FileEmit(dst.Emit(), src.Count, XedPaths.Output() + FS.file("xed.inst.attributes", FS.Csv));
        }
    }
}