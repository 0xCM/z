//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public class ClosureProviderAttribute : Attribute
    {
        public ClosureProviderAttribute(Type provider)
        {
            this.ProviderType = provider;
        }

        public Type ProviderType {get;}
    }
}