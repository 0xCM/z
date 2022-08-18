//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableId)]
    public struct SdmOpCodeDetail : IComparable<SdmOpCodeDetail>
    {
        const string TableId = "sdm.opcodes.details";

        public const byte FieldCount = 11;

        [Render(12)]
        public uint OpCodeKey;

        [Render(16)]
        public AsmMnemonic Mnemonic;

        [Render(36)]
        public TextBlock OpCodeExpr;

        [Render(36)]
        public AsmOcValue OpCodeValue;

        [Render(64)]
        public TextBlock AsmSig;

        [Render(8)]
        public TextBlock EncXRef;

        [Render(8)]
        public TextBlock Mode64;

        [Render(8)]
        public TextBlock Mode32;

        [Render(12)]
        public TextBlock Mode64x32;

        [Render(16)]
        public TextBlock CpuIdExpr;

        [Render(254)]
        public TextBlock Description;

        public int CompareTo(SdmOpCodeDetail src)
        {
            var result = Mnemonic.CompareTo(src.Mnemonic);
            if(result == 0)
            {
                result = OpCodeValue.CompareTo(src.OpCodeValue);
                if(result == 0)
                    result = AsmSig.CompareTo(src.AsmSig);
            }

            return result;
        }
    }
}