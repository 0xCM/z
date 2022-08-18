//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class intel
    {
        [SymSource(group)]
        public enum TypeSuffix : byte
        {
            [Symbol("i8", "signed 8-bit integer")]
            i8,

            [Symbol("u8", "unsigned 8-bit integer")]
            u8,

            [Symbol("i16", "signed 16-bit integer")]
            i16,

            [Symbol("u16", "unsigned 16-bit integer")]
            u16,

            [Symbol("i32", "signed 32-bit integer")]
            i32,

            [Symbol("u32", "unsigned 32-bit integer")]
            u32,

            [Symbol("i64", "signed 64-bit integer")]
            i64,

            [Symbol("u64", "unsigned 64-bit integer")]
            u64,

            [Symbol("i128", "signed 128-bit integer")]
            i128,

            [Symbol("i256", "signed 256-bit integer")]
            i256,

            [Symbol("i512", "signed 512-bit integer")]
            i512,

            [Symbol("p", "packed")]
            p,

            [Symbol("ep", "extended packed")]
            ep,

            [Symbol("s", "single-precision floating point")]
            s,

            [Symbol("d", "double-precision floating point")]
            d,
        }
    }
}