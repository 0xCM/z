//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    public class CgAssets : Assets<CgAssets>
    {        
        static CgAssets Instance = new();

        public static ref readonly CgAssets Service => ref Instance;

        public Asset DataStoreTemplate() => Asset("DataStore.template");

        public Asset DataStoresTemplate() => Asset("DataStores.template");
    }
}