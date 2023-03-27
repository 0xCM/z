//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Tables
    {
        [Op]
        public static ClrTable reflected(Type src)
        {
            var layout = src.Tag<StructLayoutAttribute>();
            LayoutKind? kind = null;
            CharSet? charset = null;
            byte? pack = null;
            uint? size = null;
            if(layout)
            {
                var value = layout.Value;
                kind = value.Value;
                charset = value.CharSet;
                pack = (byte)value.Pack;
                size = (uint)value.Size;
            }
            return new ClrTable(src, TableId.identify(src), columns(src), kind, charset, pack, size);
        }
    }
}