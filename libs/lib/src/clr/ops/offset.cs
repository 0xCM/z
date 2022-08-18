//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Clr
    {
        [Op]
        public static ushort offset(Type host, FieldInfo field)
            => (ushort)Marshal.OffsetOf(host, field.Name);
    }
}