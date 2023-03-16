//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class BasedParser<B>
        where B : unmanaged, INumericBase
    {
        public B Base => default;
    }
}