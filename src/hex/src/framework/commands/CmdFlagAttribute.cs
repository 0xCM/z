//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
public class CmdFlagAttribute : CmdArgAttribute
{
    public CmdFlagAttribute(string expr)
        : base(expr)
    {

    }
}
