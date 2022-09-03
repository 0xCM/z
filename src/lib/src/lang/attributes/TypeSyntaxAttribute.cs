//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [AttributeUsage(AttributeTargets.Method)]
    public class TypeSyntaxAttribute : OpAttribute
    {
        public TypeSyntaxAttribute(string spec)
        {
            Specifier = spec;
        }

        public TypeSpec Specifier {get;}
    }
}