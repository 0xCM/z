//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XFs
    {
        public static void Overwrite(this FilePath dst, string src)
        {
            using var writer = new StreamWriter(dst.EnsureParentExists().Name, false);
            writer.WriteLine(src);
        }

        public static void Overwrite(this FilePath dst, string src, TextEncodingKind encoding)
        {
            using var writer = new StreamWriter(dst.EnsureParentExists().Name, false, encoding.ToSystemEncoding());
            writer.WriteLine(src);
        }
    }
}