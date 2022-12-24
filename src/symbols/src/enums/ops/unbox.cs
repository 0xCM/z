//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using EC = PrimalKind;

    partial struct Enums
    {
        [Op]
        public static ulong unbox(EC ec, object src)
            => ec switch {
                EC.U8 => (ulong)(byte)src,
                EC.I8 => (ulong)(sbyte)src,
                EC.U16 => (ulong)(ushort)src,
                EC.I16 => (ulong)(short)src,
                EC.U32 => (ulong)(uint)src,
                EC.I32 => (ulong)(int)src,
                EC.I64 => (ulong)(long)src,
                EC.U64 => (ulong)src,
                _ => 0ul,
            };
    }
}