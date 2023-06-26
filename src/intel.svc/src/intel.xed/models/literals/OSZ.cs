//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedModels
    {
        [SymSource(xed)]
        public enum OSZ : byte
        {
            [Symbol("")]
            None = 0,

            [Symbol("o16")]
            o16 = NativeSizeCode.W16,

            [Symbol("o32")]
            o32 = NativeSizeCode.W32,

            [Symbol("o64")]
            o64 = NativeSizeCode.W64,
        }
    }
}