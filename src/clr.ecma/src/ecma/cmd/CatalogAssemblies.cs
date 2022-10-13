//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{    
    [Cmd(Name)]
    public record class CatalogAssemblies : ICmd<CatalogAssemblies>
    {
        const string Name = "catalog-assemblies";

        public FolderPath Source;

        public FolderPath Target;
    }
}
