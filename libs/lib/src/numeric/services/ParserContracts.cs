//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ParserContracts
    {
        [Free]
        public delegate Outcome DynamicOutcome(string src, out dynamic dst);

        [Free]
        public delegate Outcome GenericOutcome<T>(string src, out T dst);

        [Free]
        public delegate bool DynamicBool(string src, out dynamic dst);

        [Free]
        public delegate bool GenericBool<T>(string src, out T dst);

        [Free]
        public interface IParserO
        {
            Outcome Parse(string src, out dynamic dst);
        }

        [Free]
        public interface IParserB
        {
            bool Parse(string src, out dynamic dst);
        }

        [Free]
        public interface IParser : IParserO, IParserB
        {
            Type TargetType {get;}
        }

        [Free]
        public interface IParserO<T> : IParserO
        {
            Outcome Parse(string src, out T dst);

            Outcome IParserO.Parse(string src, out dynamic dst)
            {
                var result = Parse(src, out var x);
                if(result)
                {
                    dst = x;
                }
                else
                {
                    dst = default(T);
                }
                return result;
            }
        }

        [Free]
        public interface IParserB<T> : IParserB
        {
            bool Parse(string src, out T dst);

            bool IParserB.Parse(string src, out dynamic dst)
            {
                var result = Parse(src, out var x);
                if(result)
                {
                    dst = x;
                }
                else
                {
                    dst = default(T);
                }
                return result;
            }
        }

        [Free]
        public interface IParser<T> : IParserO<T>, IParserB<T>, IParser
        {
            Type IParser.TargetType
                => typeof(T);
        }

        [Free]
        public class ParseFunction<T> : IParser<T>
        {
            Either<GenericBool<T>,GenericOutcome<T>> Delegate;

            public ParseFunction(GenericBool<T> f)
            {
                Delegate = f;
            }

            public ParseFunction(GenericOutcome<T> f)
            {
                Delegate = f;
            }

            Outcome IParserO<T>.Parse(string src, out T dst)
            {
                var value = default(T);
                var result = Outcome.Failure;
                Delegate
                    .OnLeft(f => result = f(src, out value))
                    .OnRight(f => result = f(src, out value));
                dst = value;
                return result;
            }

            bool IParserB<T>.Parse(string src, out T dst)
            {
                var value = default(T);
                var result = false;
                Delegate
                    .OnLeft(f => result = f(src, out value))
                    .OnRight(f => result = f(src, out value));
                dst = value;
                return result;
            }
        }
    }
}