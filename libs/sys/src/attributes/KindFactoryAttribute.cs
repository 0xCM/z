//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    /// <summary>
    /// Identifies a parameter that accepts an immediate value
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class KindFactoryAttribute : OpKindAttribute
    {
        public KindFactoryAttribute()
            : base(ApiClassKind.KindFactory)
        {

        }
    }
}