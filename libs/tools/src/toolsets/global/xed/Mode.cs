//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDomain
    {
        [SymSource(group)]
        public enum Mode : byte
        {
            None = 0,

            [Symbol("r", "REAL_16 mode, 16b addressing (20b addresses), 16b default data size")]
            Real16,

            [Symbol("r32", "REAL_32 mode, 16b addressing (20b addresses), 32b default data size")]
            Real32,

            [Symbol("16", "LEGACY_16 mode, 16b addressing, 16b default data size")]
            Bits16,

            [Symbol("32", "LEGACY_32 mode, 32b addressing, 32b default data size")]
            Bits32,

            [Symbol("64", "LONG_64 mode w/64b addressing")]
            Bits64,
        }
    }
}