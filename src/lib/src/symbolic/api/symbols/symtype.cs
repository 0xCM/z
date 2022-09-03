//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Symbols
    {
       public static SymTypeInfo symtype<T>()
            where T : unmanaged, Enum
        {
            var t = typeof(T);
            var dst = default(SymTypeInfo);
            dst.TypeName = t.Name;
            dst.DataType = (PrimalCode)Enums.ecode(t);
            dst.SymCount = (ushort)t.GetFields().Length;
            dst.TypeNameData = text.utf16(dst.TypeName).ToArray();
            dst.TypeNameSize = (ushort)dst.TypeNameData.Length;
            return dst;
        }

        [Op]
        public static SymTypeInfo symtype(Type src)
        {
            var dst = default(SymTypeInfo);
            dst.TypeName = src.Name;
            dst.DataType = (PrimalCode)Enums.ecode(src);
            dst.SymCount = (ushort)src.GetFields().Length;
            dst.TypeNameData = text.utf16(dst.TypeName).ToArray();
            dst.TypeNameSize = (ushort)dst.TypeNameData.Length;
            return dst;
        }
    }
}