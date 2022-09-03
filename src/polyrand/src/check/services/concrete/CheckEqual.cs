//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CheckEqual : ICheckEqual
    {
        public static ICheckEqual Checker => default(CheckEqual);
    }
}