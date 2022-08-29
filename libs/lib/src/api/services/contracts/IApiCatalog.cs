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

        Index<Assembly> Components {get;}

        //bool FindPart(PartId id, out IPart dst);

        bool Assembly(PartName id, out Assembly dst);
    }
}