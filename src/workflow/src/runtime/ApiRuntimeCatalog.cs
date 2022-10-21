//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class ApiRuntimeCatalog : IApiCatalog
    {
        /// <summary>
        /// The parts included in the datset
        /// </summary>
        Index<IPart> _Parts;

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

        internal ApiRuntimeCatalog(Index<IPart> parts, Index<Assembly> components, ApiPartCatalogs catalogs, Index<IApiHost> hosts, Index<MethodInfo> ops)
        {
            _Parts = parts;
            _PartComponents = components;
            _Catalogs = catalogs;
            _ApiHosts = hosts;
            _ComponentNames = components.Select(x => x.GetName().Name);
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

        public bool Assembly(PartName part, out Assembly dst)
        {
            var src = _PartComponents.View;
            var count = src.Length;
            dst = default;
            for(var i=0; i<count; i++)
            {
                ref readonly var component = ref skip(src,i);
                if(component.PartName() == part)
                {
                    dst = component;
                    return true;
                }
            }
            return false;
        }

        public Index<IApiHost> PartHosts(params PartName[] parts)
        {
            if(parts.Length == 0)
                return _ApiHosts;
            else
                return  from h in _ApiHosts
                        where parts.Contains(h.PartName)
                        select h;
        }

        IPart[] IApiCatalog.Parts
            => _Parts;

        public static IApiCatalog Empty =>
            new ApiRuntimeCatalog(
                    sys.empty<IPart>(),
                    sys.empty<Assembly>(),
                    ApiPartCatalogs.Empty,
                    sys.empty<IApiHost>(),
                    sys.empty<MethodInfo>()
                    );        
    }
}