//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static XedRules;

partial class XedModels
{
    [Record(TableName), StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct InstLayoutRecord : IComparable<InstLayoutRecord>
    {
        public const string TableName = "xed.inst.layouts";

        public const byte CellCount = 11;

        const byte HeaderCount = 4;

        const byte TotalCount = HeaderCount + CellCount;

        public const byte CellWidth = LayoutCell.RenderWidth;

        [Render(12)]
        public ushort PatternId;

        [Render(18)]
        public XedInstClass Instruction;

        [Render(18)]
        public AsmOpCode OpCode;

        [Render(6)]
        public byte Count;

        [Render(CellWidth)]
        public LayoutCell Cell0;

        [Render(CellWidth)]
        public LayoutCell Cell1;

        [Render(CellWidth)]
        public LayoutCell Cell2;

        [Render(CellWidth)]
        public LayoutCell Cell3;

        [Render(CellWidth)]
        public LayoutCell Cell4;

        [Render(CellWidth)]
        public LayoutCell Cell5;

        [Render(CellWidth)]
        public LayoutCell Cell6;

        [Render(CellWidth)]
        public LayoutCell Cell7;

        [Render(CellWidth)]
        public LayoutCell Cell8;

        [Render(CellWidth)]
        public LayoutCell Cell9;

        [Render(CellWidth)]
        public LayoutCell Cell10;

        public LayoutCell this[byte i]
        {
            get
            {
                var dst = LayoutCell.Empty;
                switch(i)
                {
                    case 0:
                        dst = Cell0;
                    break;
                    case 1:
                        dst = Cell1;
                    break;

                    case 2:
                        dst = Cell2;
                    break;

                    case 3:
                        dst = Cell3;
                    break;

                    case 4:
                        dst = Cell4;
                    break;

                    case 5:
                        dst = Cell5;
                    break;

                    case 6:
                        dst = Cell6;
                    break;

                    case 7:
                        dst = Cell7;
                    break;

                    case 8:
                        dst = Cell8;
                    break;

                    case 9:
                        dst = Cell9;
                    break;

                    case 10:
                        dst = Cell10;
                    break;
                };

                return dst;
            }
        }

        public string Format()
        {
            var dst = text.emitter();
            cells(this, dst);
            return dst.Emit();
        }

        public override string ToString()
            => Format();

        static void cells(in InstLayoutRecord src, ITextEmitter dst)
        {
            for(var i=z8; i<src.Count; i++)
                dst.AppendFormat("{0} ", src[i]);
        }

        public int CompareTo(InstLayoutRecord src)
            => PatternId.CompareTo(src.PatternId);

        public static InstLayoutRecord Empty => default;
    }
}
