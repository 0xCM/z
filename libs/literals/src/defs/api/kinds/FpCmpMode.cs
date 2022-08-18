//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using FCM = System.Runtime.Intrinsics.X86.FloatComparisonMode;

    /// <summary>
    /// Floating point comparison mode
    /// </summary>
    [SymSource(api_kinds), Flags]
    public enum FpCmpMode : byte
    {
        /// <summary>
        /// 0: ordered, equal, non-signaling
        /// </summary>
        EQ_OQ = FCM.OrderedEqualNonSignaling,

        /// <summary>
        /// Overly-verbose alias for EQ_OQ
        /// </summary>
        OrderedEqualNonSignaling = EQ_OQ,

        /// <summary>
        /// 1: ordered, less than, signaling
        /// </summary>
        LT_OS = FCM.OrderedLessThanSignaling,

        /// <summary>
        /// Overly-verbose alias for LT_OS
        /// </summary>
        OrderedLessThanSignaling = LT_OS,

        /// <summary>
        /// 2: ordered, less than or equal, signaling
        /// </summary>
        LE_OS = FCM.OrderedLessThanOrEqualSignaling,

        /// <summary>
        /// Overly-verbose alias for LE_OS
        /// </summary>
        OrderedLessThanOrEqualSignaling = LE_OS,

        /// <summary>
        /// 3: unordered, non-signaling
        /// </summary>
        UNORD_Q = FCM.UnorderedNonSignaling,

        /// <summary>
        /// Overly-verbose alias for UNORD_Q
        /// </summary>
        UnorderedNonSignaling = UNORD_Q,

        /// <summary>
        /// 4: unordered, not equal, non-signaling
        /// </summary>
        NEQ_UQ = FCM.UnorderedNotEqualNonSignaling,

        /// <summary>
        /// Overly-verbose alias for NEQ_UQ
        /// </summary>
        UnorderedNotEqualNonSignaling = NEQ_UQ,

        /// <summary>
        /// 5: unordered, not less than, signaling
        /// </summary>
        NLT_US = FCM.UnorderedNotLessThanSignaling,

        /// <summary>
        /// Overly-verbose alias for NLT_US
        /// </summary>
        UnorderedNotLessThanSignaling = NLT_US,

        /// <summary>
        /// 6: unordered, not less than or equal, signaling
        /// </summary>
        NLE_US = FCM.UnorderedNotLessThanOrEqualSignaling,

        /// <summary>
        /// Ridiculously verbose alias for NLE_US
        /// </summary>
        UnorderedNotLessThanOrEqualSignaling = NLE_US,

        /// <summary>
        /// 7: ordered, non-signaling
        /// </summary>
        ORD_Q = FCM.OrderedNonSignaling,

        /// <summary>
        /// Overly-verbose alias for ORD_Q
        /// </summary>
        OrderedNonSignaling = ORD_Q,

        /// <summary>
        /// 8: unordered, equal, non-signaling
        /// </summary>
        EQ_UQ = FCM.UnorderedEqualNonSignaling,

        /// <summary>
        /// Overly-verbose alias for EQ_UQ
        /// </summary>
        UnorderedEqualNonSignaling = EQ_UQ,

        /// <summary>
        /// 9: unordered, not greater than or equal, signaling
        /// </summary>
        NGE_US = FCM.UnorderedNotGreaterThanOrEqualSignaling,

        /// <summary>
        /// Ridiculously verbose alias for NGE_US
        /// </summary>
        UnorderedNotGreaterThanOrEqualSignaling = NGE_US,

        /// <summary>
        /// 9:unordered, not greater than, signaling
        /// </summary>
        NGT_US = FCM.UnorderedNotGreaterThanSignaling,

        /// <summary>
        /// Ridiculously verbose alias for NGT_US
        /// </summary>
        UnorderedNotGreaterThanSignaling = NGT_US,

        /// <summary>
        /// 10: ordered, false, non-signaling
        /// </summary>
        FALSE_OQ = FCM.OrderedFalseNonSignaling,

        /// <summary>
        /// Overly-verbose alias for FALSE_OQ
        /// </summary>
        OrderedFalseNonSignaling = FALSE_OQ,

        /// <summary>
        /// 12: ordered, not equal, non-signaling
        /// </summary>
        NEQ_OQ = FCM.OrderedNotEqualNonSignaling,

        /// <summary>
        /// Overly-verbose alias for NGT_US
        /// </summary>
        OrderedNotEqualNonSignaling = NEQ_OQ,

        /// <summary>
        /// 13: ordered, greater than or equal, signaling
        /// </summary>
        GE_OS = FCM.OrderedGreaterThanOrEqualSignaling,

        /// <summary>
        /// Ridiculously verbose alias for GE_OS
        /// </summary>
        OrderedGreaterThanOrEqualSignaling = GE_OS,

        /// <summary>
        /// 14: ordered, greater than, signaling
        /// </summary>
        GT_OS = FCM.OrderedGreaterThanSignaling,

        /// <summary>
        /// Overly-verbose alias for GT_OS
        /// </summary>
        OrderedGreaterThanSignaling = GT_OS,

        /// <summary>
        /// 15: unordered, true, non-signaling
        /// </summary>
        TRUE_UQ = FCM.UnorderedTrueNonSignaling,

        /// <summary>
        /// Overly-verbose alias for TRUE_UQ
        /// </summary>
        UnorderedTrueNonSignaling = TRUE_UQ,

        /// <summary>
        /// 16: ordered, equal, signaling
        /// </summary>
        EQ_OS = FCM.OrderedEqualSignaling,

        /// <summary>
        /// Overly-verbose alias for EQ_OS
        /// </summary>
        OrderedEqualSignaling = EQ_OS,

        /// <summary>
        /// 17: ordered, less than, non-signaling
        /// </summary>
        LT_OQ = FCM.OrderedLessThanNonSignaling,

        /// <summary>
        /// Overly-verbose alias for LT_OQ
        /// </summary>
        OrderedLessThanNonSignaling = LT_OQ,

        /// <summary>
        /// 18: ordered, less than or equal, non-signaling
        /// </summary>
        LE_OQ = FCM.OrderedLessThanOrEqualNonSignaling,

        /// <summary>
        /// Ridiculously verbose alias for LE_OQ
        /// </summary>
        OrderedLessThanOrEqualNonSignaling = LE_OQ,

        /// <summary>
        /// 19: unordered, signaling
        /// </summary>
        UNORD_S = FCM.UnorderedSignaling,

        /// <summary>
        /// Overly-verbose alias for LE_OQ
        /// </summary>
        UnorderedSignaling = UNORD_S,

        /// <summary>
        /// 20: unordered, not equal, signaling
        /// </summary>
        NEQ_US = FCM.UnorderedNotEqualSignaling,

        /// <summary>
        /// Overly-verbose alias for NEQ_US
        /// </summary>
        UnorderedNotEqualSignaling = NEQ_US,

        /// <summary>
        /// 21: unordered, not less, non-signaling
        /// </summary>
        NLT_UQ = FCM.UnorderedNotLessThanNonSignaling,

        /// <summary>
        /// Ridicuously verbose alias for NLT_UQ
        /// </summary>
        UnorderedNotLessThanNonSignaling = NLT_UQ,

        /// <summary>
        /// 22: unordered, not less than or equal, non-signaling
        /// </summary>
        NLE_UQ = FCM.UnorderedNotLessThanOrEqualNonSignaling,

        /// <summary>
        /// Ridiculously verbose alias for NLE_UQ
        /// </summary>
        UnorderedNotLessThanOrEqualNonSignaling = NLE_UQ,

        /// <summary>
        /// 23: ordered, signaling
        /// </summary>
        ORD_S = FCM.OrderedSignaling,

        /// <summary>
        /// Overly-verbose alias for ORD_S
        /// </summary>
        OrderedSignaling = ORD_S,

        /// <summary>
        /// 24: unordered,equal, signaling
        /// </summary>
        EQ_US = FCM.UnorderedEqualSignaling,

        /// <summary>
        /// Overly-verbose alias for EQ_US
        /// </summary>
        UnorderedEqualSignaling = EQ_US,

        /// <summary>
        /// 25: unordered, not greater than or equan, non-signaling
        /// </summary>
        NGE_UQ = FCM.UnorderedNotGreaterThanOrEqualNonSignaling,

        /// <summary>
        /// Infuriatingly verbose alias for NGE_UQ
        /// </summary>
        UnorderedNotGreaterThanOrEqualNonSignaling = NGE_UQ,

        /// <summary>
        /// 26: unordered, not greater than, non-signaling
        /// </summary>
        NGT_UQ = FCM.UnorderedNotGreaterThanNonSignaling,

        /// <summary>
        /// Infuriatingly verbose alias for NGT_UQ
        /// </summary>
        UnorderedNotGreaterThanNonSignaling = NGT_UQ,

        /// <summary>
        /// 27: ordered, false, signaling
        /// </summary>
        FALSE_OS = FCM.OrderedFalseSignaling,

        /// <summary>
        /// Overly-verbose alias for FALSE_OS
        /// </summary>
        OrderedFalseSignaling = FALSE_OS,

        /// <summary>
        /// 28: ordered, not equal, signaling
        /// </summary>
        NEQ_OS = FCM.OrderedNotEqualSignaling,

        /// <summary>
        /// Overly-verbose alias for NEQ_OS
        /// </summary>
        OrderedNotEqualSignaling = NEQ_OS,

        /// <summary>
        /// 29: ordered, greater than or equal, non-signaling
        /// </summary>
        GE_OQ = FCM.OrderedGreaterThanOrEqualNonSignaling,

        /// <summary>
        /// Infuriatingly verbose alias for LE_OQ
        /// </summary>
        OrderedGreaterThanOrEqualNonSignaling = GE_OQ,

        /// <summary>
        /// 30: ordered, greater than, non-signaling
        /// </summary>
        GT_OQ = FCM.OrderedGreaterThanNonSignaling,

        /// <summary>
        /// Overly-verbose alias for GT_OQ
        /// </summary>
        OrderedGreaterThanNonSignaling = GT_OQ,

        /// <summary>
        /// 31: ordered, true, signaling
        /// </summary>
        TRUE_US = FCM.UnorderedTrueSignaling,

        /// <summary>
        /// Overly-verbose alias for TRUE_US
        /// </summary>
        UnorderedTrueSignaling = TRUE_US
    }
}