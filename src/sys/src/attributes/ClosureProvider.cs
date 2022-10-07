//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ClosureProviderAttribute : Attribute
    {
        public ClosureProviderAttribute(Type provider)
        {
            this.ProviderType = provider;
        }

        public Type ProviderType {get;}
    }
}