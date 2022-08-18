//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using LK = ClrLiteralKind;
    using EK = ClrEnumKind;

    partial struct ClrLiterals
    {
        [Op]
        public static ulong serialize(object src, LK dst)
        {
            switch(dst)
            {
                case LK.U1:
                    return u8((bool)src);
                case LK.I8:
                    return (ulong)(sbyte)src;
                case LK.U8:
                    return (ulong)(byte)src;
                case LK.I16:
                    return (ulong)(short)src;
                case LK.U16:
                    return (ulong)(ushort)src;
                case LK.C16:
                    return (ulong)(char)src;
                case LK.I32:
                    return (ulong)(int)src;
                case LK.U32:
                    return (ulong)(uint)src;
                case LK.F32:
                    return (ulong)(float)src;
                case LK.I64:
                    return (ulong)(long)src;
                case LK.U64:
                    return (ulong)(ulong)src;
                case LK.F64:
                    return (ulong)(double)src;
                case LK.String:
                    return core.address((string)src);
                default:
                    return 0;
            }
        }

        [Op]
        public static ulong serialize(object src, EK dst)
        {
            switch(dst)
            {
                case EK.I8:
                    return (ulong)(sbyte)src;
                case EK.U8:
                    return (ulong)(byte)src;
                case EK.I16:
                    return (ulong)(short)src;
                case EK.U16:
                    return (ulong)(ushort)src;
                case EK.I32:
                    return (ulong)(int)src;
                case EK.U32:
                    return (ulong)(uint)src;
                case EK.I64:
                    return (ulong)(long)src;
                case EK.U64:
                    return (ulong)src;
                default:
                    return 0;
            }
        }
    }
}