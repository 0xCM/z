//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class ApiRuntimeCatalog : IApiCatalog
    {
        /// <summary>
        /// The parts included in the datset
        /// </summary>
        Index<IPart> _Parts;

        /// <summary>
        /// The dataset part identities
        /// </summary>
        Index<PartId> _PartIdentities;

        /// <summary>
        /// The part components included in the datset
        /// </summary>
        Index<Assembly> _PartComponents;

        /// <summary>
        /// The catalogs corresponding to each datset part
        /// </summary>
        ApiPartCatalogs _Catalogs;

        /// <summary>
        /// The hosts provided by the dataset parts
        /// </summary>
        Index<IApiHost> _ApiHosts;

        Index<string> _ComponentNames;

        object locker;

        public ApiRuntimeCatalog(Index<IPart> parts, Index<Assembly> components, ApiPartCatalogs catalogs, Index<IApiHost> hosts, Index<PartId> partIds, Index<MethodInfo> ops)
        {
            _Parts = parts;
            _PartComponents = components;
            _Catalogs = catalogs;
            _ApiHosts = hosts;
            _PartIdentities = partIds;
            _ComponentNames = components.Select(x => x.GetName().Name);
            locker = new();
        }

        public ApiPartCatalogs PartCatalogs
        {
            [MethodImpl(Inline)]
            get => _Catalogs;
        }

        public ReadOnlySpan<string> ComponentNames
        {
            [MethodImpl(Inline)]
            get => _ComponentNames;
        }

        public Index<Assembly> Components
        {
            [MethodImpl(Inline)]
            get => _PartComponents;
        }

        public bool PartCatalog(PartId id, out IApiPartCatalog dst)
        {
            var matched = _Catalogs.Where(x => x.PartId == id);
            if(matched.IsNonEmpty)
            {
                dst = matched.First;
            }
            else
            {
                dst = null;
            }

            return dst != null;
        }

        public bool FindPart(PartId id, out IPart dst)
        {
            var count = _Parts.Length;
            var src = _Parts.View;
            dst = default;
            for(var i=0; i<count; i++)
            {
                ref readonly var part = ref skip(src,i);
                if(part.Id == id)
                {
                    dst = part;
                    return true;
                }
            }
            return false;
        }

        public bool Assembly(PartId id, out Assembly dst)
        {
            var src = _PartComponents.View;
            var count = src.Length;
            dst = default;
            for(var i=0; i<count; i++)
            {
                ref readonly var component = ref skip(src,i);
                if(component.Id() == id)
                {
                    dst = component;
                    return true;
                }
            }
            return false;
        }

        public Index<IApiHost> PartHosts(params PartId[] parts)
        {
            if(parts.Length == 0)
                return _ApiHosts;
            else
                return  from h in _ApiHosts
                        where parts.Contains(h.PartId)
                        select h;
        }

        IPart[] IApiCatalog.Parts
            => _Parts;

        PartId[] IApiCatalog.PartIdentities
            => _PartIdentities;

        public static IApiCatalog Empty =>
            new ApiRuntimeCatalog(
                    sys.empty<IPart>(),
                    sys.empty<Assembly>(),
                    ApiPartCatalogs.Empty,
                    sys.empty<IApiHost>(),
                    sys.empty<PartId>(),
                    sys.empty<MethodInfo>()
                    );        
    }
}