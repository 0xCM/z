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

        Assembly[] Assemblies {get;}

        IApiHost[] PartHosts(params PartName[] parts);

        IPart[] Parts {get;}

        bool Assembly(PartName part, out Assembly dst);
    }
}