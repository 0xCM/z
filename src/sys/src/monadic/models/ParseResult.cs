//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct ParseResult : IParseResult
    {
        /// <summary>
        /// Defines a successful parse result
        /// </summary>
        /// <param name="source">The input vaue</param>
        /// <param name="value">The parsed value</param>
        /// <typeparam name="S">The source type</typeparam>
        /// <typeparam name="T">The target type</typeparam>
        public static ParseResult<S,T> parsed<S,T>(S source, T value)
            => ParseResult<S,T>.Success(source, value);

        public static ParseResult<T> parsed<T>(char source, T value)
            => ParseResult<T>.Success(source.ToString(), value);

        /// <summary>
        /// Defines a parse success result
        /// </summary>
        /// <param name="src">The parsed thing</param>
        /// <param name="value">The value that was successfully hydrated from the source/param>
        /// <typeparam name="T">The target type</typeparam>
        public static ParseResult<T> parsed<T>(object src, T value)
            => ParseResult.win(src?.ToString() ?? EmptyString, value);

        /// <summary>
        /// Defines a parse result that signals failure
        /// </summary>
        /// <param name="source">The input value</param>
        /// <param name="target">The (invalid) target value</param>
        /// <typeparam name="S">The input type</typeparam>
        /// <typeparam name="T">The parse target type</typeparam>
        [MethodImpl(Inline)]
        public static ParseResult<S,T> unparsed<S,T>(S source, T target = default)
            => ParseResult<S,T>.Fail(source);

        /// <summary>
        /// Defines a parse result that signals failure
        /// </summary>
        /// <param name="source">The input value</param>
        /// <param name="target">The (invalid) target value</param>
        /// <param name="reason">The failure reason</param>
        /// <typeparam name="S">The input type</typeparam>
        /// <typeparam name="T">The parse target type</typeparam>
        public static ParseResult<S,T> unparsed<S,T>(S source, T target, string reason)
            => ParseResult<S,T>.Fail(source, reason);

        /// <summary>
        /// Defines a parse result that signals failure
        /// </summary>
        /// <param name="source">The input value</param>
        /// <param name="target">The (invalid) target value</param>
        /// <param name="reason">The failure reason, if available</param>
        /// <typeparam name="S">The input type</typeparam>
        /// <typeparam name="T">The parse target type</typeparam>
        public static ParseResult<string,T> unparsed<T>(string source, T target = default)
            => ParseResult<string,T>.Fail(string.IsNullOrEmpty(source) ? EmptyString : source, string.IsNullOrWhiteSpace(source) ? $"There was no source text to parse" : EmptyString);

        /// <summary>
        /// Defines a parse result that signals failure
        /// </summary>
        /// <param name="source">The input value</param>
        /// <param name="error">The excaption that occurred</param>
        /// <param name="target">The default (and invalid) target value</param>
        /// <typeparam name="T">The parse target type</typeparam>
        public static ParseResult<string,T> unparsed<T>(string source, Exception error, T target = default)
            => ParseResult<string,T>.Fail(string.IsNullOrEmpty(source) ? EmptyString : source, error?.ToString() ?? EmptyString);

        /// <summary>
        /// Defines a parse result that signals failure
        /// </summary>
        /// <param name="source">The input value</param>
        /// <param name="reason">The failure reason</param>
        /// <typeparam name="T">The parse target type</typeparam>
        public static ParseResult<string,T> unparsed<T>(string source, string reason)
            => ParseResult<string,T>.Fail(string.IsNullOrEmpty(source) ? EmptyString : source, reason);

        /// <summary>
        /// Defines a parse result that signals failure
        /// </summary>
        /// <param name="source">The input value</param>
        /// <param name="reason">The failure reason, if available</param>
        /// <typeparam name="T">The parse target type</typeparam>
        public static ParseResult<T> unparsed<T>(char source, object reason = null)
            => ParseResult<T>.Fail(source.ToString(), reason);

        /// <summary>
        /// The content that was parsed...or not
        /// </summary>
        public object Source {get;}

        /// <summary>
        /// The target value type
        /// </summary>
        public Type TargetType {get;}

        /// <summary>
        /// The source type
        /// </summary>
        public Type SourceType {get;}

        /// <summary>
        /// Specifies whether the parse attempt succeed, and thus the Value field is meaningful
        /// </summary>
        public bool Succeeded {get;}

        /// <summary>
        /// The parsed value, if the parse operaion succeeded; otherwise best not look there
        /// </summary>
        public object Value {get;}

        /// <summary>
        /// If the parse attempt failed, the reason for the failure, if available
        /// </summary>
        public Option<object> Reason {get;}

        public bool Failed
        {
            [MethodImpl(Inline)]
            get => !Succeeded;
        }

        [MethodImpl(Inline)]
        public object Require()
        {
            if(Succeeded)
                return Value;
            else
                return Throw();
        }

        object Throw()
            => throw new Exception(Reason.MapValueOrElse(r => r.ToString(), () => "Parser failed"));

        /// <summary>
        /// Defines a successful parse result
        /// </summary>
        /// <param name="source">The input text</param>
        /// <param name="value">The parsed value</param>
        /// <typeparam name="T">The parsed value type</typeparam>
        [MethodImpl(Inline)]
        public static ParseResult<T> win<T>(string source, T value)
            => ParseResult<T>.Success(source, value);

        [MethodImpl(Inline)]
        public static ParseResult<T> fail<T>(string source, object reason = null)
            => ParseResult<T>.Fail(source, reason);

        /// <summary>
        /// Defines a successful parse result
        /// </summary>
        /// <param name="source">The input value</param>
        /// <param name="value">The parsed value</param>
        /// <typeparam name="S">The source type</typeparam>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline)]
        public static ParseResult<S,T> win<S,T>(S source, T value)
            => ParseResult<S,T>.Success(source, value);

        /// <summary>
        /// Defines a parse result that signals failure
        /// </summary>
        /// <param name="source">The input value</param>
        /// <param name="reason">The failure reason, if available</param>
        /// <typeparam name="S">The source type</typeparam>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline)]
        public static ParseResult<S,T> fail<S,T>(S source, object reason = null)
            => ParseResult<S,T>.Fail(source, reason);

        [MethodImpl(Inline)]
        public static ParseResult win(string source, Type target, object value)
            => new ParseResult(source, target, true, value);

        [MethodImpl(Inline)]
        public static ParseResult fail(string source, Type target, object reason = null)
            => new ParseResult(source, target, false, null, reason);

        [MethodImpl(Inline)]
        public static ParseResult define(string source, Type target, bool succeeded, object value, object reason = null)
            => new ParseResult(source, target, succeeded, value, reason);

        [MethodImpl(Inline)]
        public static ParseResult win(object src, Type srcType, Type dstType, object dst, object reason = null)
            => new ParseResult(src, srcType, dstType, true, dst, reason);

        [MethodImpl(Inline)]
        public static ParseResult fail(object src, Type srcType, Type dstType, object reason = null)
            => new ParseResult(src, srcType, dstType, false, DBNull.Value, reason);

        [MethodImpl(Inline)]
        public static bool operator true(ParseResult src)
            => src.Succeeded;

        [MethodImpl(Inline)]
        public static bool operator false(ParseResult src)
            => src.Failed;

        [MethodImpl(Inline)]
        internal ParseResult(object source, Type sourceType, Type targetType, bool succeeded, object value, object reason = null)
        {
            Source = source;
            SourceType = sourceType;
            TargetType = targetType;
            Succeeded = succeeded;
            Value = value;
            Reason = reason != null ? Option.some(reason) : Option.none<object>();
        }

        [MethodImpl(Inline)]
        internal ParseResult(object source, Type targetType, bool succeeded, object value, object reason = null)
        {
            Source = source;
            SourceType = source?.GetType() ?? typeof(void);
            TargetType = targetType;
            Succeeded = succeeded;
            Value = value;
            Reason = reason != null ? Option.some(reason) : Option.none<object>();
        }

        public static string Format(ParseResult src)
        {
            if(src.Succeeded)
                return src.Value?.ToString() ?? "Parse result indicates sucess but no value present!";
            else
                return src.Reason.MapValueOrDefault(reason => reason.ToString(), "FAIL");
        }

        public string Format()
            => Format(this);

        public override string ToString()
             => Format();
    }
}