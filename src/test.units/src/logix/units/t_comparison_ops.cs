//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using S = NumericLogixOps;

using static sys;

public class t_comparison_ops : t_typed_logix<t_comparison_ops>
{
    public void scalar_eq_op_check()
    {
        scalar_eq_op_check<byte>();
        scalar_eq_op_check<ushort>();
        scalar_eq_op_check<uint>();
        scalar_eq_op_check<ulong>();
    }

    public void scalar_lt_op_check()
    {
        scalar_lt_op_check<byte>();
        scalar_lt_op_check<ushort>();
        scalar_lt_op_check<uint>();
        scalar_lt_op_check<ulong>();
    }

    public void scalar_lteq_op_check()
    {
        scalar_lteq_op_check<byte>();
        scalar_lteq_op_check<ushort>();
        scalar_lteq_op_check<uint>();
        scalar_lteq_op_check<ulong>();
    }

    public void scalar_gt_op_check()
    {
        scalar_gt_op_check<byte>();
        scalar_gt_op_check<ushort>();
        scalar_gt_op_check<uint>();
        scalar_gt_op_check<ulong>();
    }

    public void scalar_gteq_op_check()
    {
        scalar_gteq_op_check<byte>();
        scalar_gteq_op_check<ushort>();
        scalar_gteq_op_check<uint>();
        scalar_gteq_op_check<ulong>();
    }

    public void cpu128_lt_op_check()
    {
        var n = n128;
        cpu_lt_op_check<byte>(n);
        cpu_lt_op_check<sbyte>(n);
        cpu_lt_op_check<short>(n);
        cpu_lt_op_check<ushort>(n);
        cpu_lt_op_check<int>(n);
        cpu_lt_op_check<uint>(n);
        cpu_lt_op_check<long>(n);
        cpu_lt_op_check<ulong>(n);
    }

    public void cpu256_lt_op_check()
    {
        var n = n256;
        cpu_lt_op_check<byte>(n);
        cpu_lt_op_check<sbyte>(n);
        cpu_lt_op_check<short>(n);
        cpu_lt_op_check<ushort>(n);
        cpu_lt_op_check<int>(n);
        cpu_lt_op_check<uint>(n);
        cpu_lt_op_check<long>(n);
        cpu_lt_op_check<ulong>(n);
    }

    public void cpu128_gt_op_check()
    {
        var n = n128;
        cpu_gt_op_check<byte>(n);
        cpu_gt_op_check<sbyte>(n);
        cpu_gt_op_check<short>(n);
        cpu_gt_op_check<ushort>(n);
        cpu_gt_op_check<int>(n);
        cpu_gt_op_check<uint>(n);
        cpu_gt_op_check<long>(n);
        cpu_gt_op_check<ulong>(n);
    }

    public void cpu256_gt_op_check()
    {
        var n = n256;
        cpu_gt_op_check<byte>(n);
        cpu_gt_op_check<sbyte>(n);
        cpu_gt_op_check<short>(n);
        cpu_gt_op_check<ushort>(n);
        cpu_gt_op_check<int>(n);
        cpu_gt_op_check<uint>(n);
        cpu_gt_op_check<long>(n);
        cpu_gt_op_check<ulong>(n);
    }
}
