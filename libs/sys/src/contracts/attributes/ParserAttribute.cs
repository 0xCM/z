//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [AttributeUsage(AttributeTargets.Method)]
    public class ParserAttribute : OpAttribute
    {
        public ParserAttribute()
        {
            TypeProvider = typeof(void);
        }

        public ParserAttribute(Type provider)
        {
            TypeProvider = provider;
        }

        public Type TypeProvider {get;}
    }
}