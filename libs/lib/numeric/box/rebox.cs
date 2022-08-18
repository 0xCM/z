//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using NK = NumericKind;
    using TC = System.TypeCode;

    partial struct NumericBox
    {
        /// <summary>
        /// Determines the numeric kind of a system type
        /// </summary>
        /// <param name="src">The source type</param>
        [Op]
        static NumericKind kind(Type src)
        {
            var k = src.IsEnum
                ? NumericKind.None
                : Type.GetTypeCode(src.TEffective())
                switch
                {
                    TC.SByte => NK.I8,
                    TC.Byte => NK.U8,
                    TC.Int16 => NK.I16,
                    TC.UInt16 => NK.U16,
                    TC.Int32 => NK.I32,
                    TC.UInt32 => NK.U32,
                    TC.Int64 => NK.I64,
                    TC.UInt64 => NK.U64,
                    TC.Single => NK.F32,
                    TC.Double => NK.F64,
                    _ => NK.None
                };
            return k;
        }

        /// <summary>
        /// Converts a boxed numeric value of one kind to a boxed numeric value of specified kind, if possible.
        /// If not possible, returns the original value
        /// </summary>
        /// <param name="src">The source value</param>
        /// <param name="dst">The target kind</param>
        [Op]
        public static object rebox(object src, NK dst)
        {
            var type = src?.GetType() ?? typeof(void);
            var _nk = kind(type);
            switch(_nk)
            {
                case NK.I8:
                    return box((sbyte)src, dst);
                case NK.U8:
                    return box((byte)src, dst);
                case NK.I16:
                    return box((short)src, dst);
                case NK.U16:
                    return box((ushort)src, dst);
                case NK.I32:
                    return box((int)src, dst);
                case NK.U32:
                    return box((uint)src, dst);
                case NK.I64:
                    return box((long)src, dst);
                case NK.U64:
                    return box((ulong)src, dst);
                case NK.F32:
                    return box((float)src, dst);
                case NK.F64:
                    return box((double)src, dst);
            }
            return Errors.Throw<object>($"The type {type} is not supported");
        }
    }
}