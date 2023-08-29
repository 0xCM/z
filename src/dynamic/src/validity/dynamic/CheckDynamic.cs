//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly struct CheckDynamic : ICheckDynamic
    {
        public static ICheckDynamic Checker => default(CheckDynamic);
    }
}