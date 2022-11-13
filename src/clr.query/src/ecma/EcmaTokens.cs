//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public class EcmaTokens
    {
        [MethodImpl(Inline), Op]
        public static EcmaToken token(Handle handle)
            => MetadataTokens.GetToken(handle);

        [MethodImpl(Inline), Op]
        public static EcmaToken token(EntityHandle handle)
            => MetadataTokens.GetToken(handle);

        [MethodImpl(Inline), Op]
        public static EcmaToken token(TableIndex table, uint row)
            => new EcmaToken(((uint)table << 24) | (0xFFFFFF &  row));

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static EcmaToken token<T>()
            => new EcmaToken(typeof(T));

        [MethodImpl(Inline), Op]
        public static EcmaToken token(Type src)
            => new EcmaToken(src);

        [MethodImpl(Inline), Op]
        public static EcmaToken token(FieldInfo src)
            => new EcmaToken(src);

        [MethodImpl(Inline), Op]
        public static EcmaToken token(PropertyInfo src)
            => new EcmaToken(src);

        [MethodImpl(Inline), Op]
        public static EcmaToken token(MethodInfo src)
            => new EcmaToken(src);

        [MethodImpl(Inline), Op]
        public static EcmaToken token(ParameterInfo src)
            => new EcmaToken(src);

        [MethodImpl(Inline), Op]
        public static EcmaToken token(Assembly src)
            => new EcmaToken(src);
    }
}