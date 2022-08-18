//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [AttributeUsage(AttributeTargets.Struct)]
    public class SpanBlockAttribute : WidthAttribute
    {
        public SpanBlockAttribute(NativeTypeWidth width, SpanBlockKind kind)
            : base(width)
        {

        }

    }
}