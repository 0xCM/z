//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public class CmdSpecs
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline)]
        public static CmdJob<T> job<T>(string name, T spec)
            where T : struct
                => new CmdJob<T>(name, spec);

        [Parser]
        public static Outcome parse(string src, out CmdOption dst)
        {
            const char Delimiter = Chars.Colon;

            dst = CmdOption.Empty;
            if(empty(src))
                return (false,RpOps.Empty);
            var i = text.index(src, Delimiter);
            if(i>0)
                dst = new CmdOption(text.left(src,i).Trim(), text.right(src,i).Trim());
            else
                dst = new CmdOption(src.Trim());
            return true;
        }

        public static ReadOnlySpan<CmdOption> options(FS.FilePath src)
        {
            var dst = list<CmdOption>();
            using var reader = src.Utf8LineReader();
            while(reader.Next(out var line))
            {
                if(line.IsNonEmpty)
                {
                    ref readonly var content = ref line.Content;
                    if(parse(content, out var option))
                        dst.Add(option);
                }
            }
            return dst.ViewDeposited();
        }

        [MethodImpl(Inline), Op]
        public static CmdArgDef<T> arg<T>(string name, T value, ArgPrefix prefix)
            => new CmdArgDef<T>(name, value, prefix);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static CmdArgDef<T> arg<T>(ushort pos, T value, ArgPrefix prefix)
            => new CmdArgDef<T>(pos, value.ToString(), value, prefix);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static CmdArgDef<T> arg<T>(ushort pos, string name, T value, ArgPrefix prefix)
            => new CmdArgDef<T>(pos, name, value, prefix);

        /// <summary>
        /// Creates a meaningful option
        /// </summary>
        /// <param name="name">The option name</param>
        /// <param name="value">What does it do?</param>
        [MethodImpl(Inline), Op]
        public static CmdOption option(string name, string value)
            => new CmdOption(name, value);

        [MethodImpl(Inline)]
        public static Relation<K,S,T> relation<K,S,T>(K kind, S src, T dst)
            where K : unmanaged
            where S : unmanaged
            where T : unmanaged
                => new Relation<K,S,T>(FlowId.identify(kind,src,dst), kind, src, dst);
    }
}