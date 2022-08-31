//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
[assembly: PartId(PartId.CgShell)]
namespace Z0.Parts
{
    public sealed class GenApp : Part<GenApp>
    {
        public static AssetData.DataSources Assets
        {
            [MethodImpl(Inline)]
            get => AssetData.Assets;
        }

        public readonly struct AssetData
        {
            public static DataSources Assets = new ();

            public static AssetData.DataSources AssetSet
                => Assets;

            public sealed class DataSources : Assets<DataSources>
            {
                public Asset DataStoreTemplate() => Asset("DataStore.template");

                public Asset DataStoresTemplate() => Asset("DataStores.template");

            }
        }
    }
}