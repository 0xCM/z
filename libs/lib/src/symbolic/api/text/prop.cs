//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class text
    {
        [MethodImpl(Inline), Op]
        public static TextProp prop<T>(NameOld name, T value)
            => new TextProp(name, string.Format("{0}", value));
    }
}