//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ParseResult<S,T> : IParseResult<S,T>
    {
        /// <summary>
        /// The content that was parsed...or not
        /// </summary>
        public S Source {get;}

        /// <summary>
        /// Specifies whether the parse attempt succeed, and thus the Value field is meaningful
        /// </summary>
        public bool Succeeded {get;}

        public bool Failed
        {
            [MethodImpl(Inline)]
            get => !Succeeded;
        }

        /// <summary>
        /// Upon successful parse attempt, holds the parsed value; otherwise it may or may not hold something else
        /// </summary>
        public T Value {get;}

        public Option<object> Reason {get;}

        [MethodImpl(Inline)]
        public T Require()
        {
            if(Succeeded)
                return Value;
            else
                return Throw();
        }

        T Throw()
            => throw new Exception(Reason.MapValueOrElse(r => r.ToString(), () => $"Unable to parse {typeof(T).Name}"));


        [MethodImpl(Inline)]
        public static ParseResult<S,T> Success(S source, T value)
            => new ParseResult<S,T>(source, value);

        [MethodImpl(Inline)]
        public static ParseResult<S,T> Fail(S source, object reason = null)
            => new ParseResult<S,T>(source, default, reason);

        [MethodImpl(Inline)]
        public static bool operator true(ParseResult<S,T> src)
            => src.Succeeded;

        [MethodImpl(Inline)]
        public static bool operator false(ParseResult<S,T> src)
            => src.Failed;

        [MethodImpl(Inline)]
        internal ParseResult(S source, T value, object reason = null)
        {
            Source = source;
            Succeeded = true;
            Value = value;
            Reason = reason != null ? Option.some(reason) : Option.none<object>();
        }

        [MethodImpl(Inline)]
        public ParseResult<S,T> WithReason(object reason)
            => new ParseResult<S,T>(Source, Value, reason);

        /// <summary>
        /// Invokes an action if the value exists
        /// </summary>
        /// <param name="ifSome">The action to potentially ivoke</param>
        [MethodImpl(Inline)]
        public ParseResult<S,T> OnSuccess(Action<T> ifSome)
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
        public ParseResult<S,T> OnFailure(Action f)
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
        public ParseResult<S,T> OnFailure(Action<ParseResult<S,T>> f)
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
        public Y MapValueOrSource<Y>(Func<T,Y> success, Func<S,Y> failure)
            =>  Succeeded ? success(Value) : failure(Source);

        [MethodImpl(Inline)]
        public Y MapValueOrElse<Y>(Func<T,Y> success, Func<Y> failure)
            =>  Succeeded ? success(Value) : failure();

        [MethodImpl(Inline)]
        public Y MapValueOrDefault<Y>(Func<T,Y> success, Y @default)
            => Succeeded ? success(Value) : @default;

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
        public ParseResult<S,X> TryMap<X>(Func<T,X> f)
            => Succeeded ? ParseResult<S,X>.Success(Source, f(Value)) : ParseResult<S,X>.Fail(Source);

        /// <summary>
        /// Implements the canonical bind operation
        /// </summary>
        /// <typeparam name="X">The source domain type</typeparam>
        /// <typeparam name="Y">The target domain type</typeparam>
        /// <param name="x">The point in the monadic space over X</param>
        /// <param name="f">The function to apply to effect the bind</param>
        public ParseResult<S,Y> Bind<Y>(Func<T, ParseResult<S,Y>> f)
            => Succeeded ? f(Value) : ParseResult<S,Y>.Fail(Source);

        /// <summary>
        /// LINQ integration function
        /// </summary>
        /// <param name="apply">The application projector</param>
        /// <typeparam name="Y">The application range</typeparam>
        [MethodImpl(Inline)]
        public ParseResult<S,Y> Select<Y>(Func<T,Y> apply)
            => TryMap(_x => apply(_x));

        /// <summary>
        /// LINQ integration function
        /// </summary>
        /// <param name="eval">The evaluator</param>
        /// <param name="project">The lifting projector</param>
        /// <typeparam name="Y">The evaluator range type</typeparam>
        /// <typeparam name="Z">The projector range type</typeparam>
        [MethodImpl(Inline)]
        public ParseResult<S,Z> SelectMany<Y,Z>(Func<T, ParseResult<S,Y>> eval, Func<T,Y,Z> project)
        {
            var src = Source;
            if (Succeeded)
            {
                var v = Value;
                var y = eval(v);
                var z = y.Bind(yVal => ParseResult<S,Z>.Success(src, project(v, yVal)));
                return z;
            }
            else
                return ParseResult<S,Z>.Fail(src);
        }

        [MethodImpl(Inline)]
        public Option<T> ToOption()
            => Succeeded ? Option.some(Value) : Option.none<T>();

        [MethodImpl(Inline)]
        public ParseResult<S,X> As<X>()
            => new ParseResult<S,X>(Source, (X)(object)Value, Reason);

        public string Format()
            => ParseResult.Format(this);

        public override string ToString()
             => Format();

        [MethodImpl(Inline)]
        public static implicit operator ParseResult<S,T>((S source, T value) src)
            => Success(src.source, src.value);

        [MethodImpl(Inline)]
        public static implicit operator ParseResult(ParseResult<S,T> src)
            => ParseResult.define(src.Source.ToString(), typeof(T), src.Succeeded, src.Value);
   }
}