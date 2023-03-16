//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Binary
{
    public record struct FixedRule : IBinaryRule
    {
        public readonly BitWidth CellWidth;

        public readonly uint CellCount;

        public FixedRule(BitWidth width, uint count)
        {
            CellWidth = width;
            CellCount = count;
        }
    }
}