//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public class Cmd 
    {   
        public static CmdArgs args<T>(params T[] src)
            where T : new()
        {
            var dst = alloc<CmdArg>(src.Length);
            for(ushort i=0; i<src.Length; i++)
                seek(dst,i) = new CmdArg<T>(skip(src,i));
            return new (dst);
        }

        public static string join(CmdArgs args)
        {
            var dst = text.emitter();
            for(var i=0; i<args.Count; i++)
            {
                if(i != 0)
                    dst.Append(Chars.Space);
                dst.Append(args[i].Value);
            }

            return dst.Emit();
        }

        public static CmdArg arg(object src)
            => new CmdArg(src?.ToString() ?? EmptyString);

        public static CmdArgs args(params object[] src)
        {
            var dst = alloc<CmdArg>(src.Length);
            for(ushort i=0; i<src.Length; i++)
                seek(dst,i) = arg(skip(src,i));
            return new (dst);
        }

        public static CmdArgs args(params CmdArg[] src)
        {
            var dst = alloc<CmdArg>(src.Length);
            for(ushort i=0; i<src.Length; i++)
                seek(dst,i) = skip(src,i);
            return new (dst);
        }   
   }
}