//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class t_logix<X> : UnitTest<X,CheckVectorBits,ICheckVectorBits>
        where X : t_logix<X>
    {
        protected BitLogix bitlogix => BitLogix.Service;
     }
}