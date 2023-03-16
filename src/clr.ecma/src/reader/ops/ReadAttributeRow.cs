//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static EcmaTables;

    partial class EcmaReader
    {
        [MethodImpl(Inline), Op]
        public CustomAttribRow ReadAttributeRow(System.Reflection.Metadata.CustomAttribute src)
        {
            var dst = default(CustomAttribRow);
            dst.Parent = src.Parent;
            dst.Constructor = src.Constructor;
            dst.Value = src.Value;
            dst.ValueOffset = EcmaHeaps.offset(MD, src.Value);
            return dst;
        }
    }
}