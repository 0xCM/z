//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.DynamicModels
{
    using System;
    public sealed class NotNullOperator : UnaryOperator<NotNullOperator>, INullityOperator<NotNullOperator>
    {
        internal NotNullOperator()
            : base("not_null", "not_null")
        { }
    }
}