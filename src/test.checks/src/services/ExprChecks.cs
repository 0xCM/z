//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    using static TmpTables;

    using C = AsciLetterUpCode;
    using K = Asm.AsmOcTokenKind;
    using P = Pow2x32;

    [ApiHost]
    public class ExprChecks : Checker<ExprChecks>
    {
        static ICheckNumeric Claim = NumericClaims.Checker;


        public static Index<ushort> serialize(PointMapper<K,P> src)
        {
            var dst = alloc<ushort>(src.PointCount);
            serialize(src,dst);
            return dst;
        }

        [Op]
        public static uint serialize(PointMapper<K,P> src, Span<ushort> dst)
        {
            var points = src.Points;
            var count = points.Length;
            var j=0;
            for(var i=0; i<count; i++)
            {
                ref readonly var point = ref seek(points,i);
                ref var t0 = ref @as<byte>(seek(dst,i));
                ref var t1 = ref @as<Log2x32>(seek(t0,1));
                t0 = u8(point.Left);
                t1 = Pow2.log(point.Right);
            }

            return 0;
        }

        [CmdOp("check/points/fx")]
        unsafe Outcome FT(CmdArgs args)
        {
            var src = recover<C,byte>(Source);
            PointFunctions.fx<AsciCode>(n8, src, Target, out var f);
            byte x = 0;
            x = skip(src,0);
            Write(f.Map(x));

            x = skip(src,1);
            Write(f.Map(x));

            x = skip(src,2);
            Write(f.Map(x));

            x = skip(src,3);
            Write(f.Map(x));

            x = skip(src,4);
            Write(f.Map(x));

            return true;
        }
    }

    readonly struct TmpTables
    {
        const byte PointCount = 5;

        public static ReadOnlySpan<C> Source
            => new C[PointCount]{C.Y, C.B, C.X, C.R, C.W};

        public static ReadOnlySpan<AsciCode> Target
            => new AsciCode[PointCount]{AsciCode.Y, AsciCode.B, AsciCode.X, AsciCode.R, AsciCode.W};
    }
}