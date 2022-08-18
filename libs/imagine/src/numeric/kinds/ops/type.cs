//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using NK = NumericKind;

    partial class NumericKinds
    {
        /// <summary>
        /// Returns a kind-identified system type if possible; throws an exception otherwise
        /// </summary>
        /// <param name="k">The identifying kind</param>
        [Op]
        public static Type type(NumericKind k)
            => k switch {
                NK.U8 => typeof(byte),
                NK.I8 => typeof(sbyte),
                NK.U16 => typeof(ushort),
                NK.I16 => typeof(short),
                NK.U32 => typeof(uint),
                NK.I32 => typeof(int),
                NK.I64 => typeof(long),
                NK.U64 => typeof(ulong),
                NK.F32 => typeof(float),
                NK.F64 => typeof(double),
                _ => typeof(void)
            };
        }
}