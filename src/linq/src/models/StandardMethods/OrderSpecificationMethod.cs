//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.DynamicModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class OrderSpecificationMethod : StandardMethod
    {
        public OrderSpecificationMethod(string MethodName, SortDirection Direction, bool IsPrimary)
            : base(MethodName)
        {
            this.Direction = Direction;
            this.IsPrimary = IsPrimary;
        }

        public SortDirection Direction { get; }

        public bool IsPrimary { get; }
    }
}