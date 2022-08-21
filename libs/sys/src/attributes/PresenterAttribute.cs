//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
    public class PresenterAttribute : Attribute
    {
        public PresenterAttribute(Type src)
        {
            Presentable = src;
        }

        public Type Presentable {get;}
    }

    public class TextPresenterAttribute : PresenterAttribute
    {
        public TextPresenterAttribute()
            : base(typeof(string))
        {

        }
    }
}