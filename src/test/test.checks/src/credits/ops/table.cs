//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static CreditModel;

    partial class CreditBits
    {
        [MethodImpl(Inline), Op]
        public static ContentRef table(ContentNumber n0, ContentNumber n1 = default, ContentNumber n2 = default)
        {
            var l0 = (ushort)n0;
            var l1 = (ushort)((byte)n1 << (byte)ContentLevel.L1);
            var l2 = (ushort)((byte)n2 << (byte)ContentLevel.L2);
            var ct = (ushort)((byte)CreditContentType.Table << (byte)ContentLevel.Type);
            return (ushort)(l0 | l1 | l2 | ct);
        }
    }
}