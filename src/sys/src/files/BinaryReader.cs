//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;
    using System.Text;

    partial class XTend
    {
        public static BinaryReader BinaryReader(this Stream src)
            => new BinaryReader(src);

        public static BinaryReader BinaryReader(this StreamReader src)
            => new BinaryReader(src.BaseStream);

        public static BinaryReader BinaryReader(this StreamReader src, Encoding encoding)
            => new BinaryReader(src.BaseStream, encoding);
    }
}