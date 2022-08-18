//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static Hex4Kind;

    partial struct AsmPrototypes
    {
        [ApiHost(prototypes + @switch)]
        public struct NestedSwitch
        {
            [Op]
            static Hex4Kind calc00(Hex4Kind src, Hex4Kind dst)
            {
                var result = Hex4Kind.x00;
                switch(dst)
                {
                    case x00:
                        result = 0;
                        goto Exit;
                    case x01:
                        result = x01 & x01;
                        goto Exit;
                    case x02:
                        result = x02 | x01;
                        goto Exit;
                    case x03:
                        result = x03 ^ x01;
                        goto Exit;
                    case x04:
                        result = ~(x04 & x01);
                        goto Exit;
                    case x05:
                        result = ~(x05 | x01);
                        goto Exit;
                    case x06:
                        result = ~(x06 ^ x01);
                        goto Exit;
                    case x07:
                        result = x07 & ~x01;
                        goto Exit;
                    case x08:
                        result = x08 | ~x01;
                        goto Exit;
                    case x09:
                        result = x09 ^ ~x01;
                        goto Exit;
                    case x0A:
                        result = ~x0A & x01;
                        goto Exit;
                    case x0B:
                        result = ~x0B | x01;
                        goto Exit;
                    case x0C:
                        result = ~x0C ^ x01;
                        goto Exit;
                    case x0D:
                        result = ~x0D & ~x01;
                        goto Exit;
                    case x0E:
                        result = ~x0E | ~x01;
                        goto Exit;
                    case x0F:
                        result = ~x0F ^ ~x01;
                        goto Exit;
                    default:
                        goto Exit;
                }

                Exit:
                    result += 5;
                return result;
            }

            [Op]
            static Hex4Kind calc01(Hex4Kind src, Hex4Kind dst)
            {
                var result = Hex4Kind.x00;
                switch(dst)
                {
                    case x00:
                        result = 0;
                        goto Exit;
                    case x01:
                        result = x01 & x02;
                        goto Exit;
                    case x02:
                        result = x02 | x02;
                        goto Exit;
                    case x03:
                        result = x03 ^ x02;
                        goto Exit;
                    case x04:
                        result = ~(x04 & x02);
                        goto Exit;
                    case x05:
                        result = ~(x05 | x02);
                        goto Exit;
                    case x06:
                        result = ~(x06 ^ x02);
                        goto Exit;
                    case x07:
                        result = x07 & ~x02;
                        goto Exit;
                    case x08:
                        result = x08 | ~x02;
                        goto Exit;
                    case x09:
                        result = x09 ^ ~x02;
                        goto Exit;
                    case x0A:
                        result = ~x0A & x02;
                        goto Exit;
                    case x0B:
                        result = ~x0B | x02;
                        goto Exit;
                    case x0C:
                        result = ~x0C ^ x02;
                        goto Exit;
                    case x0D:
                        result = ~x0D & ~x02;
                        goto Exit;
                    case x0E:
                        result = ~x0E | ~x02;
                        goto Exit;
                    case x0F:
                        result = ~x0F ^ ~x02;
                        goto Exit;
                    default:
                        result = 0;
                        goto Exit;
                }

                Exit:
                    result += 13;
                return result;
            }

            [Op]
            static Hex4Kind calc02(Hex4Kind src, Hex4Kind dst)
            {
                var result = Hex4Kind.x00;
                switch(dst)
                {
                    case x00:
                        result = 0;
                        goto Exit;
                    case x01:
                        result = x01 & x03;
                        goto Exit;
                    case x02:
                        result = x02 | x03;
                        goto Exit;
                    case x03:
                        result = x03 ^ x03;
                        goto Exit;
                    case x04:
                        result = ~(x04 & x03);
                        goto Exit;
                    case x05:
                        result = ~(x05 | x03);
                        goto Exit;
                    case x06:
                        result = ~(x06 ^ x03);
                        goto Exit;
                    case x07:
                        result = x07 & ~x03;
                        goto Exit;
                    case x08:
                        result = x08 | ~x03;
                        goto Exit;
                    case x09:
                        result = x09 ^ ~x03;
                        goto Exit;
                    case x0A:
                        result = ~x0A & x03;
                        goto Exit;
                    case x0B:
                        result = ~x0B | x03;
                        goto Exit;
                    case x0C:
                        result = ~x0C ^ x03;
                        goto Exit;
                    case x0D:
                        result = ~x0D & ~x03;
                        goto Exit;
                    case x0E:
                        result = ~x0E | ~x03;
                        goto Exit;
                    case x0F:
                        result = ~x0F ^ ~x03;
                        goto Exit;
                    default:
                        result = 0;
                        goto Exit;
                }

                Exit:
                    result += 2;
                return result;
            }

            [Op]
            static Hex4Kind calc03(Hex4Kind src, Hex4Kind dst)
            {
                switch(dst)
                {
                    case x00:
                        return 0;
                    case x01:
                        return x01 & dst;
                    case x02:
                        return x02 | dst;
                    case x03:
                        return x03 ^ dst;
                    case x04:
                        return ~(x04 & dst);
                    case x05:
                        return ~(x05 | dst);
                    case x06:
                        return ~(x06 ^ dst);
                    case x07:
                        return x07 & ~dst;
                    case x08:
                        return x08 | ~dst;
                    case x09:
                        return x09 ^ ~dst;
                    case x0A:
                        return ~x0A & dst;
                    case x0B:
                        return ~x0B | dst;
                    case x0C:
                        return ~x0C ^ dst;
                    case x0D:
                        return ~x0D & ~dst;
                    case x0E:
                        return ~x0E | ~dst;
                    case x0F:
                        return ~x0F ^ ~dst;
                    default:
                        return 0;
                }
            }

            [Op]
            public static Hex4Kind calc(Hex4Kind src, Hex4Kind dst)
            {
                switch(src)
                {
                    case x00:
                        return calc00(src,dst);
                    case x01:
                        return calc01(src,dst);
                    case x02:
                        return calc02(src,dst);
                    case x03:
                        return calc03(src,dst);
                }

                return x0F;
            }
        }
    }
}