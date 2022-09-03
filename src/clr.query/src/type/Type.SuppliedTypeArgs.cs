//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    partial class ClrQuery
    {
        public static Type[] SuppliedTypeArgs(this Type t)
        {
            var tE = t.TEffective();
            if(tE.IsConstructedGenericType)
                return tE.GetGenericArguments();
            else
                return Array.Empty<Type>();
        }
    }
}