//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [SymSource(api_kinds), Flags]
    public enum FpRoundDir : byte
    {
        /// <summary>
        /// _MM_FROUND_TO_NEAREST_INT, the default mode effects rounding to the nearest integer
        /// </summary>
        Default = 0,

        /// <summary>
        /// _MM_FROUND_TO_NEG_INF, Round toward negative infinity
        /// </summary>
        NegInf = 1,

        /// <summary>
        /// _MM_FROUND_TO_POS_INF, Round toward positive infinity
        /// </summary>
        PosInf = 2,

        /// <summary>
        /// _MM_FROUND_TO_ZERO, round toward 0
        /// </summary>
        Zero = 3,

        /// <summary>
        /// _MM_FROUND_CUR_DIRECTION, round toward the current direction as specified by __MM_SET_ROUNDING_MODE
        /// </summary>
        Current = 4,

        /// <summary>
        /// _MM_FROUND_CEIL, round toward positive infinity and do not suppress exceptions
        /// </summary>
        Ceil = PosInf | FpErrorMode.Raise,

        /// <summary>
        /// _MM_FROUND_FLOOR, round toward negative infinity and do not suppress exceptions
        /// </summary>
        Floor = NegInf | FpErrorMode.Raise,

        /// <summary>
        /// _MM_FROUND_TRUNC, Round toward zero and do not supress exceptions
        /// </summary>
        Trunc = Zero | FpErrorMode.Raise,

        /// <summary>
        /// _MM_FROUND_NEARBYINT, round toward the current direction and suppress exceptions
        /// </summary>
        Nearby = Current | FpErrorMode.Suppress
    }
}