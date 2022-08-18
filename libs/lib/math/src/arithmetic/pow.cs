//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
        
    partial class math
    {
        // See https://stackoverflow.com/questions/101439/the-most-efficient-way-to-implement-an-integer-based-power-function-powint-int
        [MethodImpl(Inline), Op]
        public static sbyte pow(sbyte b, uint exp)
        {
            if(exp == 0)
                return 1;

            var result = (sbyte)1;
            while(true)
            {
                if((exp & 1) != 0)
                    result *= b;
                exp >>= 1;                
                if(exp == 0)
                    break;
                b *= b;
            }
            return result;
        }

        [MethodImpl(Inline), Op]
        public static byte pow(byte b, uint exp)
        {
            if(exp == 0)
                return 1;
            
            var result = (byte)1;
            while(true)
            {
                if((exp & 1) != 0)
                    result *= b;
                exp >>= 1;
                if(exp == 0)
                    break;
                b *= b;
            }
            return result;
        }

        [MethodImpl(Inline), Op]
        public static short pow(short b, uint exp)
        {
            if(exp == 0)
                return 1;

            var result = (short)1;
            while(true)
            {
                if((exp & 1) != 0)
                    result *= b;
                exp >>= 1;                
                if(exp == 0)
                    break;
                b *= b;
            }
            return result;
        }

        [MethodImpl(Inline), Op]
        public static ushort pow(ushort b, uint exp)
        {
            if(exp == 0)
                return 1;

            var result = (ushort)1;
            while(true)
            {
                if((exp & 1) != 0)
                    result *= b;
                exp >>= 1;                
                if(exp == 0)
                    break;
                b *= b;
            }
            return result;
        }

        [MethodImpl(Inline), Op]
        public static int pow(int b, uint exp)
        {
            if(exp == 0)
                return 1;

            var result = 1;
            while(true)
            {
                if((exp & 1) != 0)
                    result *= b;
                exp >>= 1;                
                if(exp == 0)
                    break;
                b *= b;
            }
            return result;
        }

        [MethodImpl(Inline), Op]
        public static uint pow(uint b, uint exp)
        {
            if(exp == 0)
                return 1;

            var result = 1u;
            while(true)
            {
                if((exp & 1) != 0)
                    result *= b;
                exp >>= 1;
                if(exp == 0)
                    break;
                b *= b;
            }
            return result;
        }

        [MethodImpl(Inline), Op]
        public static long pow(long b, uint exp)
        {
            if(exp == 0)
                return 1;
            
            var result = 1L;
            while(true)
            {
                if((exp & 1) != 0)
                    result *= b;
                exp >>= 1;
                if(exp == 0)
                    break;
                b *= b;
            }
            return result;
        }

        [MethodImpl(Inline), Op]
        public static ulong pow(ulong b, uint exp)
        {
            if(exp == 0)
                return 1;
            
            var result = 1ul;
            while(true)
            {
                if((exp & 1) != 0)
                    result *= b;
                exp >>= 1;
                if(exp == 0)
                    break;
                b *= b;
            }
            return result;
        }
    }
}