//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using NK = NumericKind;

    partial struct NumericBox
    {
        /// <summary>
        /// Converts a numeric source value to a boxed numeric value of specified kind
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The target kind</param>
        [Op]
        public static object box(float src, NK dst)
        {
            switch(dst)
            {
                case NK.U8:
                    return (byte)src;
                case NK.I8:
                    return (sbyte)src;
                case NK.I16:
                    return (short)src;
                case NK.U16:
                    return (ushort)src;
                case NK.I32:
                    return (int)src;
                case NK.U32:
                    return (uint)src;
                case NK.I64:
                    return (long)src;
                case NK.U64:
                    return (ulong)src;
                case NK.F32:
                    return (float)src;
                case NK.F64:
                    return (double)src;
            }
            return src;
        }
    }
}