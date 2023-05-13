//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.CommandLine.Parsing;

    using static sys;

    [ApiHost]
    public class Cmd 
    {   
        [Op, Closures(UInt64k)]
        public static CmdArgs reflect<T>(in T src)
        {
            var t = typeof(T);
            var fields = t.PublicInstanceFields();
            var count = fields.Length;
            var reflected = sys.alloc<ClrFieldValue>(count);
            ClrFields.values(src, fields, reflected);
            var dst = sys.alloc<CmdArg>(count);
            for(var i=0u; i<count; i++)
            {
                ref readonly var fv = ref skip(reflected,i);
                seek(dst,i) = new CmdArg(fv.Field.Name, fv.Value?.ToString() ?? EmptyString);
            }
            return dst;
        }        

        public static bool parse(string src, out CmdLine dst)
        {
            dst = CmdLine.Empty;
            dst = new (CliParser.SplitCommandLine(src).Map(x => new CmdArg(x)));
            return true;
        }

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