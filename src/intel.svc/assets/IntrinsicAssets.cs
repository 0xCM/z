//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class IntrinsicAssets : Assets<IntrinsicAssets>
    {
        public Asset Csv() => Asset("intrinsics.csv");

        public Asset Algorithms() => Asset("intrinsics.algorithms.txt");

        public Asset XedFileHeader() => Asset("xedheader.cs");

        public Asset TypeDeclarations() => Asset("intel.intrinsics.types.h");
    }
}