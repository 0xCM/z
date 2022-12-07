//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public unsafe readonly partial struct AsmLoops
    {
        [Op]
        public static void loop1(Action<uint> f)
        {
            for(var i=0u; i<0xFF; i++)
                f(i);
        }

        [Op]
        public static void loop2(Action<uint,uint> f)
        {
            for(var i=0u; i<0xFF; i++)
                for(var j=0u; j<0xFF; j++)
                    f(i,j);
        }

        [Op]
        public static void loop3(Action<uint,uint,uint> f)
        {
            for(var c0=0u; c0<0xFF; c0++)
                for(var c1=0u; c1<0xFF; c1++)
                    for(var c2=0u; c2<0xFF; c2++)
                        f(c0,c1,c2);
        }

        [Op]
        public static void loop4(Action<uint,uint,uint,uint> f)
        {
            for(var c0=0u; c0<0xFF; c0++)
                for(var c1=0u; c1<0xFF; c1++)
                    for(var c2=0u; c2<0xFF; c2++)
                        for(var c3=0u; c3<0xFF; c3++)
                            f(c0,c1,c2,c3);
        }

        [Op]
        public static void loop5(uint a0, uint a1, uint a2, uint a3, Action<uint,uint,uint,uint> f)
        {
            for(var c0=0u; c0<a0; c0++)
                for(var c1=0u; c1<a1; c1++)
                    for(var c2=0u; c2<a2; c2++)
                        for(var c3=0u; c3<a3; c3++)
                            f(c0,c1,c2,c3);
        }

        [Op]
        public static void loop6(ulong a0, ulong a1, ulong a2, ulong a3, Action<ulong,ulong,ulong,ulong> f)
        {
            for(var c0=0ul; c0<a0; c0++)
                for(var c1=0ul; c1<a1; c1++)
                    for(var c2=0ul; c2<a2; c2++)
                        for(var c3=0ul; c3<a3; c3++)
                            f(c0,c1,c2,c3);
        }

        [Op]
        public static void loop5x64u_f(ulong a0, ulong a1, ulong a2, ulong a3,ulong a4, Action<ulong,ulong,ulong,ulong,ulong> f)
        {
            for(var c0=0ul; c0<a0; c0++)
            for(var c1=0ul; c1<a1; c1++)
            for(var c2=0ul; c2<a2; c2++)
            for(var c3=0ul; c3<a3; c3++)
            for(var c4=0ul; c4<a4; c4++)
                f(c0,c1,c2,c3,c4);
        }


        [Op]
        public static void loop7(ulong a0, ulong a1, ulong a2, ulong a3, Func<ulong,ulong,ulong,ulong,ulong> f, Action<ulong> g)
        {
            for(var c0=0ul; c0<a0; c0++)
                for(var c1=0ul; c1<a1; c1++)
                    for(var c2=0ul; c2<a2; c2++)
                        for(var c3=0ul; c3<a3; c3++)
                            g(f(c0,c1,c2,c3));
        }

        [Op]
        public static void loop8(byte a0, byte a1, byte a2, byte a3, Func<byte,byte,byte,byte,byte> f, Action<byte, byte, byte, byte, byte> g)
        {
            for(var c0=z8; c0<a0; c0++)
                for(var c1=z8; c1<a1; c1++)
                    for(var c2=z8; c2<a2; c2++)
                        for(var c3=z8; c3<a3; c3++)
                            g(c0, c1, c2, c3, f(c0,c1,c2,c3));
        }

        [Op]
        public static void loop9(Pair<uint> limits, Func<uint,uint> f, Action<uint> g)
        {
            for(var i=limits.Left; i<limits.Right; i++)
                g(f(i));
        }
    }
}