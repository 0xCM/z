//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.DynamicModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public sealed class TrueOperator : UnaryOperator<TrueOperator>
    {
        internal TrueOperator()
            : base("true", "true")
        { }
    }
}