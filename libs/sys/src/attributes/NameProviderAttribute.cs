//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static Root;

    public enum NameKind : uint
    {
        None = 0,

        Env = 1,
    }

    [AttributeUsage(AttributeTargets.All)]
    public class NameProviderAttribute : Attribute
    {
        public NameKind Kind {get;}

        public NameProviderAttribute(NameKind kind)
        {
            Kind = kind;
        }
    }
}