//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Text;

    using K = TextEncodingKind;

    partial class XText
    {
        [Op]
        public static Encoding ToSystemEncoding(this K kind)
            =>  kind switch {
                K.Asci => Encoding.ASCII,
                K.Utf8 => Encoding.UTF8,
                K.Unicode => Encoding.Unicode,
                K.Utf32 => Encoding.UTF32,
              _ => Encoding.Unicode
            };
    }
}