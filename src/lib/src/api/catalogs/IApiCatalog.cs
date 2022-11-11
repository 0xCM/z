//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IApiCatalog
    {
        ApiPartCatalogs PartCatalogs {get;}
        
        Index<IApiHost> PartHosts(params PartName[] parts);

        IPart[] Parts {get;}

        Index<Assembly> Assemblies {get;}

        bool Assembly(PartName id, out Assembly dst);
    }
}