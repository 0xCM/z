//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    [ApiHost]
    public readonly struct ApiParsers
    {
        [Op]
        public static PartId partFromFile(string src)
            => part(Path.GetFileName(src).Replace("z0.", EmptyString).Replace(".dll", EmptyString).Replace(".exe", EmptyString));

        public static PartId part(string src)
        {
            part(src, out var dst);
            return dst;
        }

        [Parser]
        public static Outcome path(string src, out ApiPath dst)
        {
            var result = Outcome.Success;
            dst = ApiPath.Empty;
            var _part = PartId.None;
            var i = text.index(src, Chars.FSlash);
            if(i > 0)
            {
                var components = src.Split(Chars.FSlash);
                result = part(text.left(src,i), out _part);
                if(result)
                    dst = ApiPath.define(_part, text.right(src,i));
            }
            else
            {
                result = part(src, out _part);
                if(result)
                    dst = ApiPath.define(_part);
            }

            return result;
        }

        [Parser]
        public static bool part(string src, out PartId dst)
        {
            dst = PartId.None;
            var symbols = Symbols.index<PartId>();
            if(symbols.Lookup(src, out var sym))
            {
                dst = sym.Kind;
                return true;
            }
            return false;
        }

        [Parser]
        public static Outcome host(string src, out ApiHostUri dst)
        {
            var result = Outcome.Failure;
            dst = ApiHostUri.Empty;
            var i = text.index(src, Chars.FSlash);
            if(i>0)
            {
                result = part(text.left(src,i), out var p);
                if(result)
                {
                    var h = ApiIdentity.host(p, text.right(src,i));
                    return result;
                }
            }
            return result;
        }
    }
}