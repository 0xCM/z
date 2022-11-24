//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaReader
    {
        [MethodImpl(Inline), Op]
        public AttributeRow ReadAttributeRow(CustomAttribute src)
        {
            var dst = default(AttributeRow);
            dst.Parent = src.Parent;
            dst.Constructor = src.Constructor;
            dst.Value = src.Value;
            dst.ValueOffset = HeapOffset(src.Value);
            return dst;
        }

    }
}