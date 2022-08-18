//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    /// <summary>
    /// Specifies a documentation reference
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class DocRefAttribute : Attribute
    {
        public string Reference {get;}

        public DocRefAttribute(string name)
            => Reference = name;
    }
}