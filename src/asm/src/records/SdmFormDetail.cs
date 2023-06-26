//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct SdmFormDetail : IComparable<SdmFormDetail>
    {
        const string TableId = "sdm.forms.detail";

        public const byte FieldCount = 11;

        [Render(8)]
        public uint Seq;

        [Render(12)]
        public Hex32 Id;

        [Render(38)]
        public asci64 Name;

        [Render(48)]
        public AsmSig Sig;

        [Render(42)]
        public AsmOpCodeSpec OpCode;

        [Render(8)]
        public bit Mode64;

        [Render(8)]
        public bit Mode32;

        [Render(8)]
        public bit IsRex;

        [Render(8)]
        public bit IsVex;

        [Render(8)]
        public bit IsEvex;

        [Render(1)]
        public TextBlock Description;

        public int CompareTo(SdmFormDetail src)
        {
            var result = Sig.Format().CompareTo(src.Sig.Format());
            if(result == 0)
                result = OpCode.Format().CompareTo(src.OpCode.Format());
            return result;
        }
    }
}