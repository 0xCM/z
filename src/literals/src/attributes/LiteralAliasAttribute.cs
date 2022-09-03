//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// When applied to a literal provider, indicates that the provided literals originate from another source
    /// </summary>
    public class LiteralAliasAttribute : Attribute
    {
        public LiteralAliasAttribute(Type src)
        {
            Source = src;
        }

        /// <summary>
        /// The literal origin
        /// </summary>
        public Type Source {get;}
    }
}