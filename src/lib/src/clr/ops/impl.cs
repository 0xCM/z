//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Clr
    {
        /// <summary>
        /// Queries the host type for a <see cref='ClrImplMap'/>
        /// </summary>
        /// <param name="host">The reifying type</param>
        /// <param name="contract">The contract type</param>
        [MethodImpl(Inline), Op]
        public static ClrImplMap impl(Type host, Type contract)
        {
            var src = host.InterfaceMap(contract);
            var dst = new ClrImplMap();
            dst.Specs = src.InterfaceMethods;
            dst.SpecType = src.InterfaceType;
            dst.Impl = src.TargetMethods;
            dst.ImplType = src.TargetType;
            return dst;
        }

        public static ClrImplMap impl<H,C>()
            where C : class
                => impl(typeof(H), typeof(C));

        public static ReadOnlySeq<ClrImplMap> impls(Assembly defs, Assembly hosts)
        {
            var contrats = defs.Interfaces().ToHashSet();
            var maps = from host in hosts.Types().Concrete()
                    from i in host.Interfaces()
                    where contrats.Contains(i)
                    select impl(host,i);
            return maps.ToArray();
        }
    }
}