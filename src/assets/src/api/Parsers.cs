//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class Parsers : IMultiParser
    {
        sealed class Cache : AppData<Cache>
        {

        }

        MultiParser Mp() => Cache.get(nameof(Mp), (Func<MultiParser>)(() => new MultiParser((ConcurrentDictionary<Type, IParser>)Z0.ApiParsers.discover(ApiAssemblies.Components))));

        public IParser RecordParser(Type t)
            => Mp().RecordParser(t);

        public IParser<T> RecordParser<T>()
            where T : struct
                => Mp().RecordParser<T>();

        public IParser ValueParser(Type t)
            => Mp().ValueParser(t);

        public IParser<T> ValueParser<T>()
            => Mp().ValueParser<T>();

        public IParser EnumParser(Type src)
            => Mp().EnumParser(src);

        public IParser<E> EnumParser<E>()
            where E : unmanaged, Enum
                => Mp().EnumParser<E>();

        public IParser<T> EnumParser<E,T>()
            where E : unmanaged, Enum
                where T : unmanaged
                    => Mp().EnumValueParser<E,T>();

        public Outcome Parse(Type t, string src, out dynamic dst)
            => Mp().Parse(t, src, out dst);

        public Outcome Parse<T>(string src, out T dst)
            => Mp().Parse(src, out dst);
    }
}