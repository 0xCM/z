//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public enum RuleExprKind : uint
    {
        None = 0,

        Choice,

        Option,

        List,

        Literal,

        Production
    }
}