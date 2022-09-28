//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract record class Url<U,S> : Uri<U,S>
        where U : Url<U,S>, new()
        where S : unmanaged, IUriScheme        
    {
        protected Url(System.Uri data)
            : base(data)
        {
        }

        protected Url(string data)
            : base(data)
        {
        }

        protected Url()
        {
               
        }
    }
}