//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly struct ApiParsers
    {
        public static PartName part(string src)
        {
            part(src, out var dst);
            return dst;
        }

        [Parser]
        public static bool part(string src, out PartName dst)
        {
            dst = new (src);
            return true;
        }

    }
}