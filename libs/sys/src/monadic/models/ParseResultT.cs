//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ParseResult<T> : IParseResult<string,T>
    {
        /// <summary>
        /// The text that was parsed...or not
        /// </summary>
        public string Source {get;}

        /// <summary>
        /// Specifies whether the parse attempt succeed, and thus the Value field is meaningful
        /// </summary>
        public bool Succeeded {get;}

        /// <summary>
        /// Upon successful parse attempt, holds the parsed value; otherwise it may or may not hold something else
        /// </summary>
        public T Value {get;}

        public object Message {get;}

        public bool Failed
        {
            [MethodImpl(Inline)]
            get => !Succeeded;
        }

        [MethodImpl(Inline)]
        ParseResult(string source, T value, object reason)
        {
            Source = source;
            Succeeded = true;
            Value = value;
            Message = reason ?? EmptyString;
        }

        [MethodImpl(Inline)]
        public ParseResult<T> WithReason(object reason)
            => new ParseResult<T>(Source, Value, reason);

        /// <summary>
        /// Invokes an action if the value exists
        /// </summary>
        /// <param name="ifSome">The action to potentially invoke</param>
        [MethodImpl(Inline)]
        public ParseResult<T> OnSuccess(Action<T> ifSome)
        {
            if (Succeeded)
                ifSome(Value);
            return this;
        }

        /// <summary>
        /// Invokes an action if the value doesn't exist
        /// </summary>
        /// <param name="f">The action to invoke</param>
        [MethodImpl(Inline)]
        public ParseResult<T> OnFailure(Action f)
        {
            if (!Succeeded)
                f();
            return this;
        }

        /// <summary>
        /// Invokes an action if the value doesn't exist
        /// </summary>
        /// <param name="f">The action to invoke</param>
        [MethodImpl(Inline)]
        public ParseResult<T> OnFailure(Action<ParseResult> f)
        {
            if (!Succeeded)
                f(this);
            return this;
        }

        /// <summary>
        /// Maps the parsed value upon success and the source text upon failure
        /// </summary>
        /// <param name="success">The success projector</param>
        /// <param name="failure">The failure projector</param>
        /// <typeparam name="Y">The target type</typeparam>
        [MethodImpl(Inline)]
        public Y MapValueOrSource<Y>(Func<T,Y> success, Func<string,Y> failure)
            =>  Succeeded ? success(Value) : failure(Source);

        /// <summary>
        /// Extracts the encapsulated value if it exists; otherwise, returns the default value for
        /// the underlying type which is NULL for reference types
        /// </summary>
        /// <param name="default">The value to return if the option is non-valued</param>
        [MethodImpl(Inline)]
        public T ValueOrDefault(T @default = default(T))
            => Succeeded ? Value : @default;

        /// <summary>
        /// Returns the encapsulated value if it exists; otherwise, invokes the supplied fallback function
        /// </summary>
        /// <param name="fallback">The function called to produce a value when there is no value in the source</param>
        [MethodImpl(Inline)]
        public T ValueOrElse(Func<T> fallback)
            => Succeeded ? Value : fallback();

        /// <summary>
        /// Applies a function to value if present, otherwise returns None
        /// </summary>
        /// <typeparam name="S">The output type</typeparam>
        /// <param name="f">The function to apply when value exists</param>
        [MethodImpl(Inline)]
        public ParseResult<S> TryMap<S>(Func<T,S> f)
            => Succeeded ? ParseResult<S>.Success(Source, f(Value)) : ParseResult<S>.Fail(Source);

        /// <summary>
        /// Implements the canonical bind operation
        /// </summary>
        /// <typeparam name="X">The source domain type</typeparam>
        /// <typeparam name="Y">The target domain type</typeparam>
        /// <param name="x">The point in the monadic space over X</param>
        /// <param name="f">The function to apply to effect the bind</param>
        public ParseResult<Y> Bind<Y>(Func<T, ParseResult<Y>> f)
            => Succeeded ? f(Value) : ParseResult<Y>.Fail(Source);

        /// <summary>
        /// LINQ integration function
        /// </summary>
        /// <param name="apply">The application projector</param>
        /// <typeparam name="Y">The application range</typeparam>
        [MethodImpl(Inline)]
        public ParseResult<Y> Select<Y>(Func<T,Y> apply)
            => TryMap(_x => apply(_x));

        /// <summary>
        /// LINQ integration function
        /// </summary>
        /// <param name="eval">The evaluator</param>
        /// <param name="project">The lifting projector</param>
        /// <typeparam name="Y">The evaluator range type</typeparam>
        /// <typeparam name="Z">The projector range type</typeparam>
        [MethodImpl(Inline)]
        public ParseResult<Z> SelectMany<Y,Z>(Func<T, ParseResult<Y>> eval, Func<T,Y,Z> project)
        {
            var src = Source;
            if (Succeeded)
            {
                var v = Value;
                var y = eval(v);
                var z = y.Bind(yVal => ParseResult<Z>.Success(src, project(v, yVal)));
                return z;
            }
            else
                return ParseResult<Z>.Fail(src);
        }

        [MethodImpl(Inline)]
        public Y MapValueOrElse<Y>(Func<T,Y> success, Func<Y> failure)
            =>  Succeeded ? success(Value) : failure();

        [MethodImpl(Inline)]
        public Y MapValueOrDefault<Y>(Func<T,Y> success, Y @default)
            => Succeeded ? success(Value) : @default;

        [MethodImpl(Inline)]
        public T Require()
        {
            if(Succeeded)
                return Value;
            else
                return Throw();
        }

        T Throw()
            => throw new Exception(Message?.ToString() ?? $"Unable to parse {typeof(T).Name}");

        [MethodImpl(Inline)]
        public Option<T> ToOption()
            => Succeeded ? Option.some(Value) : Option.none<T>();

        [MethodImpl(Inline)]
        public ParseResult<X> As<X>()
            => new ParseResult<X>(Source, (X)(object)Value, Message);

        public string Format()
            => ParseResult.Format(this);

        public override string ToString()
             => Format();

        [MethodImpl(Inline)]
        public static implicit operator ParseResult<T>(ParseResult<string,T> src)
            => new ParseResult<T>(src.Source, src.Value, src.Reason);

        [MethodImpl(Inline)]
        public static implicit operator ParseResult<string,T>(ParseResult<T> src)
            => new ParseResult<string,T>(src.Source, src.Value, src.Message);

        [MethodImpl(Inline)]
        public static ParseResult<T> Success(string source, T value)
            => new ParseResult<T>(source, value, null);

        [MethodImpl(Inline)]
        public static ParseResult<T> Fail(string source, object reason)
            => new ParseResult<T>(source, default, reason);

        [MethodImpl(Inline)]
        public static ParseResult<T> Fail(string source)
            => new ParseResult<T>(source, default, null);

        [MethodImpl(Inline)]
        public static implicit operator ParseResult<T>((string source, T value) src)
            => Success(src.source, src.value);

        [MethodImpl(Inline)]
        public static implicit operator ParseResult(ParseResult<T> src)
            => ParseResult.define(src.Source, typeof(T), src.Succeeded, src.Value);

        [MethodImpl(Inline)]
        public static bool operator true(ParseResult<T> src)
            => src.Succeeded;

        [MethodImpl(Inline)]
        public static bool operator false(ParseResult<T> src)
            => src.Failed;

        [MethodImpl(Inline)]
        public static implicit operator bool(ParseResult<T> src)
            => src.Succeeded;
   }
}