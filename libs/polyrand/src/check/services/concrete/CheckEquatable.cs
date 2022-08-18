//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CheckEquatable : ICheckEquatable
    {
        public static ICheckEquatable Checker => default(CheckEquatable);
    }
}