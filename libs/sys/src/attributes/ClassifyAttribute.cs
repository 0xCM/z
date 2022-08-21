//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ClassifyAttribute : OpKindAttribute
    {
        public ClassifyAttribute()
        : base(ApiSystemClass.Kind) {}
    }
}