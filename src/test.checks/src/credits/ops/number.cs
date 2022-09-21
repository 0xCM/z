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
        public static ContentNumber number(ContentRef src, N0 level)
        {
            var isolated = (ushort)((ushort)(ContentField.L0) & (ushort)src);
            return (ContentNumber)(isolated >> (byte)ContentLevel.L0);
        }

        [MethodImpl(Inline), Op]
        public static ContentNumber number(ContentRef src, N1 level)
        {
            var isolated = (ushort)((ushort)(ContentField.L1) & (ushort)src);
            return (ContentNumber)(isolated >> (byte)ContentLevel.L1);
        }

        [MethodImpl(Inline), Op]
        public static ContentNumber number(ContentRef src, N2 level)
        {
            var isolated = (ushort)((ushort)(ContentField.L2) & (ushort)src);
            return (ContentNumber)(isolated >> (byte)ContentLevel.L2);
        }
    }
}