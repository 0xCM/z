//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class text
    {
        [MethodImpl(Inline), Op]
        public static JsonText jtext(string src)
            => new JsonText(src);

        [MethodImpl(Inline), Op]
        public static JsonProp jprop(string name, string value)
            => new JsonProp(name,value);
    }
}