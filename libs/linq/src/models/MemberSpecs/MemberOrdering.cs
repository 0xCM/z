//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.DynamicModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MemberOrdering
    {

        public MemberOrdering(IEnumerable<MemberItemOrder> orders)
        {
            Orders = orders.OrderBy(e => e.Precedence).ToList();
        }

        public IReadOnlyList<MemberItemOrder> Orders { get; }
    }
}