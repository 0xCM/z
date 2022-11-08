//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class MultiParser : IMultiParser
    {
        ConcurrentDictionary<Type,IParser> ValueParsers {get;}

        ConcurrentDictionary<Type,IParser> EnumParsers {get;} = new();

        ConcurrentDictionary<Type,IParser> EnumValueParsers {get;} = new();

        ConcurrentDictionary<Type,IParser> RecordParsers {get;} = new();

        static bool IsRecord(Type src)
            => src.Tagged<RecordAttribute>();

        public MultiParser(ConcurrentDictionary<Type,IParser> src)
        {
            ValueParsers = src;
        }

        public SeqParser<T> SeqParser<T>(string delimiter)
            => new SeqParser<T>(ValueParser<T>(), delimiter);

        public IParser RecordParser(Type src)
            => RecordParsers.GetOrAdd(src, _ => new RecordParser(TableConvention.reflected(src), this));

        public IParser<T> RecordParser<T>()
            where T : struct
                => (IParser<T>)RecordParsers.GetOrAdd(typeof(T), _ => new RecordParser<T>(this));

        public IParser<T> EnumValueParser<E,T>()
            where E : unmanaged, Enum
            where T : unmanaged
                => (IParser<T>)EnumValueParsers.GetOrAdd(typeof(E), _ => new EnumValueParser<E,T>());

        public IParser EnumParser(Type src)
            => EnumParsers.GetOrAdd(src, t => new EnumParser(t));

        public IParser<E> EnumParser<E>()
            where E : unmanaged, Enum
                => (IParser<E>)EnumParsers.GetOrAdd(typeof(E), t => new EnumParser<E>());

        public IParser<T> ValueParser<T>()
            => (IParser<T>)ValueParser(typeof(T));

        public IParser ValueParser(Type src)
            => ValueParsers[src];

        public Outcome Parse(Type t, string src, out dynamic dst)
        {
            try
            {
                if(t.IsEnum)
                    return EnumParser(t).Parse(src, out dst);
                else if(IsRecord(t))
                    return RecordParser(t).Parse(src, out dst);
                else
                    return ValueParser(t).Parse(src, out dst);
            }
            catch (Exception e)
            {
                dst = default;
                return e;
            }
        }

        public Outcome Parse<T>(string sep, string src, out T[] dst)
            => SeqParser<T>(sep).Parse(src, out dst);

        public Outcome Parse<T>(string src, out T dst)
        {
            var result = Parse(typeof(T), src, out var data);
            if(result)
                dst = (T)data;
            else
                dst = default;
            return result;
        }
    }
}