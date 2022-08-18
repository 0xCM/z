//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class math
    {
        [MethodImpl(Inline), Op]
        public static ushort adc(byte a, byte b, bit cin, out bit cout)
        {
            var x = (byte)(b + (uint)cin);
            var y = (byte)(a + x);
            cout = x < b || y < a;
            return y;
        }

        [MethodImpl(Inline), Op]
        public static ushort adc(ushort a, ushort b, bit cin, out bit cout)
        {
            var x = (ushort)(b + (uint)cin);
            var y = (ushort)(a + x);
            cout = x < b || y < a;
            return y;
        }

        [MethodImpl(Inline), Op]
        public static uint adc(uint a, uint b, bit cin, out bit cout)
        {
            var x = b + (uint)cin;
            var y = a + x;
            cout = x < b || y < a;
            return y;
        }

        [MethodImpl(Inline), Op]
        public static ulong adc(ulong a, ulong b, bit cin, out bit cout)
        {
            var x = b + (uint)cin;
            var y = a + x;
            cout = x < b || y < a;
            return y;
        }
    }
}