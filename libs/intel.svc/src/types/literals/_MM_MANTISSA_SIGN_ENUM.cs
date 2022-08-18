//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class intel
    {
        [SymSource(group)]
        public enum _MM_MANTISSA_SIGN_ENUM : byte
        {
            /// <summary>
            /// sign = sign(SRC)
            /// </summary>
            _MM_MANT_SIGN_src,

            /// <summary>
            /// sign = 0
            /// </summary>
            _MM_MANT_SIGN_zero,

            /// <summary>
            /// DEST = NaN if sign(SRC) = 1
            /// </summary>
            _MM_MANT_SIGN_nan
        }
    }
}