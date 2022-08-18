//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Clr
    {
        [Parser]
        public static Outcome token(string src, out CliToken dst)
        {
            var i = text.index(src, Chars.Colon);
            var outcome = Outcome.Empty;
            dst = CliToken.Empty;
            if(i != NotFound)
            {
                outcome = Hex.parse8u(src.LeftOfIndex(i), out var table);
                if(!outcome)
                    return outcome;

                outcome = Hex.parse32u(text.right(src,i), out var row);
                if(!outcome)
                    return outcome;

                dst = Clr.token((TableIndex)table, row);
                return true;
            }
            else
            {
                outcome = Hex.parse32u(src, out var token);
                if(!outcome)
                    return outcome;
                dst = token;
                return true;
            }
        }

        [MethodImpl(Inline), Op]
        public static CliToken token(Handle handle)
            => MetadataTokens.GetToken(handle);

        [MethodImpl(Inline), Op]
        public static CliToken token(EntityHandle handle)
            => MetadataTokens.GetToken(handle);

        [MethodImpl(Inline), Op]
        public static CliToken token(TableIndex table, uint row)
            => new CliToken(((uint)table << 24) | (0xFFFFFF &  row));

        [MethodImpl(Inline), Op, Closures(AllNumeric)]
        public static CliToken token<T>()
            => new CliToken(typeof(T));

        [MethodImpl(Inline), Op]
        public static CliToken token(Type src)
            => new CliToken(src);

        [MethodImpl(Inline), Op]
        public static CliToken token(FieldInfo src)
            => new CliToken(src);

        [MethodImpl(Inline), Op]
        public static CliToken token(PropertyInfo src)
            => new CliToken(src);

        [MethodImpl(Inline), Op]
        public static CliToken token(MethodInfo src)
            => new CliToken(src);

        [MethodImpl(Inline), Op]
        public static CliToken token(ParameterInfo src)
            => new CliToken(src);

        [MethodImpl(Inline), Op]
        public static CliToken token(Assembly src)
            => new CliToken(src);
    }
}