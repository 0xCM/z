//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class InitAttribute : OpKindAttribute
    {
        public InitAttribute()
        : base(ApiSystemClass.Init)
        {}
    }
}