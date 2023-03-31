//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack = 16)]
    public struct FLOAT_REGISTERS
    {
        public Vector128<double> F0;

        public Vector128<double> F1;

        public Vector128<double> F2;

        public Vector128<double> F3;

        public Vector128<double> F4;

        public Vector128<double> F5;

        public Vector128<double> F6;

        public Vector128<double> F7;
    }
}