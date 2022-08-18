//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [AttributeUsage(AttributeTargets.Field)]
    public class FieldKindAttribute : Attribute
    {
        public FieldKindAttribute(object kind)
        {
            FieldKind = kind;
        }

        public object FieldKind {get;}

    }
}