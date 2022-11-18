//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class AssetData : Assets<AssetData>
    {
        public Asset Shim() => Asset("shim.exe");
    }   
}