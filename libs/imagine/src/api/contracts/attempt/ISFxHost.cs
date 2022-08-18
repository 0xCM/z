//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Characterizes a service that exposes serviced api operations
    /// </summary>
    public interface ISFxHost
    {
        /// <summary>
        /// The known types that reify contracted operation services, potentially generic
        /// </summary>
        IEnumerable<Type> HostTypes {get;}

        /// <summary>
        /// The methods that instantiate services reified by the hosts
        /// </summary>
        IEnumerable<MethodInfo> FactoryMethods {get;}

        /// <summary>
        /// Specifies the number of service hosts described by the catalog
        /// </summary>
        int HostCount
            => HostTypes.Count();

        /// <summary>
        /// Specifies whether the catalog describes any service hosts
        /// </summary>
        bool IsNonEmpty
            => HostCount != 0;
    }
}