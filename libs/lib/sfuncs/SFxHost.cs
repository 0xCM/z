//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Defines service provider implementation predicated on service factory and enclosure types
    /// </summary>
    public readonly struct SFxHost : ISFxHost
    {
        /// <summary>
        /// The types declared within the enclosure that define serviced api operations
        /// </summary>
        public readonly Type[] HostTypes;

        /// <summary>
        /// The methods defined by the factory host that intantiate services reified by the host types
        /// </summary>
        public readonly MethodInfo[] FactoryMethods;

        /// <summary>
        /// The type that defines the service factory operations
        /// </summary>
        public Type FactoryHost {get;}

        /// <summary>
        /// The type into which api service reifications are nested
        /// </summary>
        public Type HostEnclosure {get;}

        /// <summary>
        /// The types declared within the enclosure that define serviced api operations
        /// </summary>
        IEnumerable<Type> ISFxHost.HostTypes
            => HostTypes;

        /// <summary>
        /// The methods defined by the factory host that intantiate services reified by the host types
        /// </summary>
        IEnumerable<MethodInfo> ISFxHost.FactoryMethods
            => FactoryMethods;

        internal SFxHost(Type factory, Type enclosure)
        {
            FactoryHost = factory;
            HostEnclosure = enclosure;
            HostTypes = enclosure.GetNestedTypes().Realize<IFunc>().ToArray();
            FactoryMethods = (from m in factory.DeclaredStaticMethods()
               where m.ReturnType.Reifies(typeof(IFunc))
               select m).ToArray();
        }
    }
}