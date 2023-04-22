//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId)]
    public struct BitMaskInfo
    {
        const string TableId = "api.bitmasks";

        [Render(32)]
        public string Name;

        [Render(8)]
        public NumericBaseKind Base;

        [Render(12)]
        public @string DataType;

        [Render(82)]
        public BitMaskData MaskData;

        [Render(1)]
        public string Text;
    }
}