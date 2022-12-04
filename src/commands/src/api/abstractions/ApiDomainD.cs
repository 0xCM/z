
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class ApiDomain<D>
        where D : ApiDomain<D>,new()
    {
        [Cmd]

        public abstract record class DomainCmd<C> : ICmd<C>
            where C : DomainCmd<C>, new()
        {

        }
    }
}