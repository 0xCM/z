//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Windows;

    [StructLayout(LayoutKind.Sequential,Pack = 16)]
    public unsafe struct XSAVE_FORMAT 
    {
        public Hex16 ControlWord;

        public Hex16 StatusWord;

        public Hex8 TagWord;

        public Hex8 Reserved1;

        public Hex16 ErrorOpcode;

        public DWORD ErrorOffset;

        public Hex16 ErrorSelector;

        public Hex16 Reserved2;

        public Hex32 DataOffset;

        public Hex16 DataSelector;

        public Hex16 Reserved3;

        public Hex32 MxCsr;

        public Hex32 MxCsr_Mask;

        public FLOAT_REGISTERS FloatRegisters;

        public XMM_REGISTERS XmmRegisters;

        fixed byte Reserved4[96];
    }
}