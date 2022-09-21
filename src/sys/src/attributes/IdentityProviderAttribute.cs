//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class IdentityProviderAttribute : Attribute
    {
        /// <summary>
        /// Use of this constructor implies that the attribution target provides identies
        /// for what are likely unattributable types, such as framework-defined types, for example
        /// </summary>
        public IdentityProviderAttribute()
        {
            Host = typeof(void);
        }
        
        public IdentityProviderAttribute(Type host)
        {
            this.Host = host;
        }

        public Type Host;
    }           
}