//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public class t_compare_expr : t_logix<t_compare_expr>
{
    public void scalar_lt_check()
    {
        scalar_lt_check<byte>();
        scalar_lt_check<sbyte>();
        scalar_lt_check<short>();
        scalar_lt_check<ushort>();
        scalar_lt_check<int>();
        scalar_lt_check<uint>();
        scalar_lt_check<long>();
        scalar_lt_check<ulong>();
    }

    public void scalar_lteq_check()
    {
        scalar_lteq_check<byte>();
        scalar_lteq_check<sbyte>();
        scalar_lteq_check<short>();
        scalar_lteq_check<ushort>();
        scalar_lteq_check<int>();
        scalar_lteq_check<uint>();
        scalar_lteq_check<long>();
        scalar_lteq_check<ulong>();
    }

    public void scalar_gt_expr_check()
    {
        scalar_gt_check<byte>();
        scalar_gt_check<sbyte>();
        scalar_gt_check<short>();
        scalar_gt_check<ushort>();
        scalar_gt_check<int>();
        scalar_gt_check<uint>();
        scalar_gt_check<long>();
        scalar_gt_check<ulong>();
    }

    public void scalar_gteq_expr_check()
    {
        scalar_gteq_check<byte>();
        scalar_gteq_check<sbyte>();
        scalar_gteq_check<short>();
        scalar_gteq_check<ushort>();
        scalar_gteq_check<int>();
        scalar_gteq_check<uint>();
        scalar_gteq_check<long>();
        scalar_gteq_check<ulong>();
    }
}
