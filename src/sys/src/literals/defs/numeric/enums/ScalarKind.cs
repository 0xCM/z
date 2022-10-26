//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines identifiers for primal numeric types
    /// </summary>
    [SymSource(numeric)]
    public enum ScalarKind : uint
    {
        None = 0,

        U8 = 1 << 16,

        I8 = 2 << 16,

        U16 = 4 << 16,

        I16 = 8 << 16,

        U32 = 16 << 16,

        I32 = 32 << 16,

        U64 = 64 << 16,

        I64 = 128 << 16,

        F32 = 512 << 16,

        F64 = 1024 << 16,
    }
}