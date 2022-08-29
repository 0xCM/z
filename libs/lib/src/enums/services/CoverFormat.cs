//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using M = EnumFormatMode;

    public readonly struct CoverFormat
    {
        public static string format<E,T>(CoverFormat<E,T> src)
            where E : unmanaged, Enum
            where T : unmanaged
        {
            var ez = (src.Mode & M.EmptyZero) != 0;
            var dst = EmptyString;
            if(ez && sys.bw64(src.Source.Scalar) == 0)
                dst = EmptyString;
            else
            {
                var kind = (M)((byte)src.Mode & 0b111);
                switch(kind)
                {
                    case M.Expr:
                        dst = src.Source.Expr;
                    break;
                    case M.Name:
                        dst = src.Source.Name;
                    break;
                    case M.Base10:
                        dst = src.Source.Scalar.ToString();
                    break;
                    default:
                        dst = src.Source.Expr;
                    break;
                }
            }
            return dst;
        }
    }
}