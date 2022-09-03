//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class IntrinsicAssets : Assets<IntrinsicAssets>
    {
        public static IntrinsicAssets AssetData = new();

        public Asset Csv() => Asset("intrinsics.csv");

        public Asset Algorithms() => Asset("intrinsics.algorithms.txt");
    }
}