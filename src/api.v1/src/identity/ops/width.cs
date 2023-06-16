//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = NumericWidth;

    partial struct ApiIdentity
    {
        static K numeric(Type t)
        {
            var k = NumericKinds.kind(t);
            if(k != 0)
                return (K)(uint)k;
            else
                return K.None;
        }

        /// <summary>
        /// Divines the bit-width of a specified type, if possible
        /// </summary>
        /// <param name="t">The type to examine</param>
        [Op]
        public static NativeTypeWidth width(Type t)
        {
            if(t.IsVector())
                return Widths.vector(t);
            else if(t.IsSpanBlock())
                return Widths.segmented(t);
            if(NumericKinds.test(t))
                return (NativeTypeWidth)numeric(t);
            else
                return t.Tag<WidthAttribute>().MapValueOrDefault(a => a.TypeWidth, NativeTypeWidth.None);
        }
    }
}