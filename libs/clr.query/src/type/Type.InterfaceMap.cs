//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    using static Root;

    partial class ClrQuery
    {
        /// <summary>
        /// Queries the host type for the <see cref='InterfaceMapping'/> of a specified contract <see cref='Type'/>
        /// </summary>
        /// <param name="host"></param>
        /// <param name="contract"></param>
        [MethodImpl(Inline), Op]
        public static InterfaceMapping InterfaceMap(this Type host, Type contract)
            => host.GetInterfaceMap(contract);
    }
}