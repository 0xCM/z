//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    /// <summary>
    /// Identifies a workflow host
    /// </summary>
    public class WfHostAttribute : Attribute
    {
        public WfHostAttribute()
        {
            CommandName = Root.EmptyString;
        }

        public WfHostAttribute(string name)
        {
            CommandName = name;
        }

        public string CommandName {get;}
    }
}