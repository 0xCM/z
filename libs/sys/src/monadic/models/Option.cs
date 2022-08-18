//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using File = System.Runtime.CompilerServices.CallerFilePathAttribute;
    using Caller = System.Runtime.CompilerServices.CallerMemberNameAttribute;
    using Line = System.Runtime.CompilerServices.CallerLineNumberAttribute;

    /// <summary>
    /// Represents a potential value
    /// </summary>
    /// <typeparam name="T">The potential value type</typeparam>
    public readonly struct Option<T> : IOption<Option<T>,T>
    {
        /// <summary>
        /// The encapsulated value, iff Exists is true
        /// </summary>
        readonly T value;

        /// <summary>
        /// Specifies whether the option has a value
        /// </summary>
        public bool Exists { get; }

        /// <summary>
        /// Exposes the underlying data, if extant; otherwise, yeilds the default potential value, which may of course be null
        /// </summary>
        public T Value
        {
            [MethodImpl(Inline)]
            get => value;
        }

        /// <summary>
        /// Defines a non-valued option
        /// </summary>
        [MethodImpl(Inline)]
        public static Option<T> None()
            => default;

        /// <summary>
        /// Defines a valued option
        /// </summary>
        /// <param name="Value">The encapsulated value</param>
        [MethodImpl(Inline)]
        public static Option<T> Some(T Value)
            => new Option<T>(Value, true);

        [MethodImpl(Inline)]
        Option(T value, bool exists)
        {
            this.value = value;
            this.Exists = exists;
        }


        /// <summary>
        /// Returns true if the value exists
        /// </summary>
        [MethodImpl(Inline)]
        public bool IsSome()
            => Exists;

        /// <summary>
        /// Returns true if the value does not exist
        /// </summary>
        [MethodImpl(Inline)]
        public bool IsNone()
            => !Exists;

        /// <summary>
        /// Applies the a function to evaluate the underlying value if it exists
        /// </summary>
        /// <param name="F">The function to apply, if possible</param>
        /// <typeparam name="X">The mapped value type</typeparam>
        [MethodImpl(Inline)]
        public Option<X> IfSome<X>(Func<T, X> F)
            => Exists ? F(value) : Option<X>.None();

        /// <summary>
        /// Invokes an action if the value exists
        /// </summary>
        /// <param name="ifSome">The action to potentially ivoke</param>
        [MethodImpl(Inline)]
        public Option<T> OnSome(Action<T> ifSome)
        {
            if (Exists)
                ifSome(value);
            return this;
        }

        /// <summary>
        /// Invokes an action if the value doesn't exist
        /// </summary>
        /// <param name="ifNone">The action to invoke</param>
        [MethodImpl(Inline)]
        public Option<T> OnNone(Action ifNone)
        {
            if (IsNone())
                ifNone();
            return this;
        }

        /// <summary>
        /// Yields the encapulated value if present; otherwise, raises an exception
        /// </summary>
        [MethodImpl(Inline)]
        public T Require([CallerName]string caller = null, [CallerFile]string file = null, [CallerLine]int? line = null)
            =>  Exists ? value : throw new Exception($"The required value doesn't exist: invoked by {caller} on {line} in {file}");

        public T Default
        {
            [MethodImpl(Inline)]
            get => default;
        }

        bool IOption.IsSome
        {
            [MethodImpl(Inline)]
            get => Exists;
        }

        bool IOption.IsNone
        {
            [MethodImpl(Inline)]
            get => !Exists;
        }

        /// <summary>
        /// The type of the encapsulated value, if present
        /// </summary>
        public Type ValueType
        {
            [MethodImpl(Inline)]
            get => typeof(T);
        }

        /// <summary>
        /// Extracts the encapulated value if it exists; otherwise, returns the default value for
        /// the underlying type which is NULL for reference types
        /// </summary>
        /// <param name="default">The value to return if the option is non-valued</param>
        [MethodImpl(Inline)]
        public T ValueOrDefault(T @default = default(T))
            => Exists ? value : @default;

        /// <summary>
        /// Returns the encapsulated value if it exists; otherwise, invokes the supplied fallback function
        /// </summary>
        /// <param name="fallback">The function called to produce a value when there is no value in the source</param>
        [MethodImpl(Inline)]
        public T ValueOrElse(Func<T> fallback)
            => Exists ? value : fallback();

        /// <summary>
        /// Returns the encapsulated value if it exists; otherwise, returns the supplied value
        /// </summary>
        /// <param name="fallback">The function called to produce a value when there is no value in the source</param>
        [MethodImpl(Inline)]
        public T ValueOrElse(T fallback)
            => Exists ? value : fallback;

        /// <summary>
        /// Applies supplied function to value if present, otherwise returns the
        /// value obtained by invoking the fallback function
        /// </summary>
        /// <typeparam name="S">The output type</typeparam>
        /// <param name="f">The function to apply when value exists</param>
        /// <param name="fallback">The function to invoke when no value exists</param>
        [MethodImpl(Inline)]
        public S Map<S>(Func<T,S> f, Func<S> fallback)
            => Exists  ? f(value)  : fallback();

        /// <summary>
        /// Applies supplied function to value if present, otherwise returns the fallback value
        /// </summary>
        /// <typeparam name="S">The output type</typeparam>
        /// <param name="f">The function to apply when value exists</param>
        /// <param name="fallback">The function to invoke when no value exists</param>
        [MethodImpl(Inline)]
        public S Map<S>(Func<T,S> f, S fallback)
            => Exists  ? f(value)  : fallback;

        /// <summary>
        /// Applies a function to value if present, otherwise returns None
        /// </summary>
        /// <typeparam name="S">The output type</typeparam>
        /// <param name="f">The function to apply when value exists</param>
        [MethodImpl(Inline)]
        public Option<S> TryMap<S>(Func<T,S> f)
            => Exists ? Option<S>.Some(f(value)) : Option<S>.None();

        /// <summary>
        /// Transforms the value, if present, otherwise invokes a function
        /// to produce an appropriate value of the target type if not
        /// </summary>
        /// <typeparam name="S">The target type</typeparam>
        /// <param name="ifSome">The transformer</param>
        /// <param name="fallback">The alternate transformer</param>
        [MethodImpl(Inline)]
        public S MapValueOrElse<S>(Func<T,S> ifSome, Func<S> fallback)
            => Exists  ? ifSome(value)  : fallback();

        /// <summary>
        /// Applies a function to the encapsulated value if it exists; otherwise, returns a default value
        /// </summary>
        /// <typeparam name="S">The projected value type</typeparam>
        /// <param name="ifSome">The function to apply when a value exists</param>
        /// <param name="default">The value to return when no value exists</param>
        [MethodImpl(Inline)]
        public S MapValueOrDefault<S>(Func<T,S> ifSome, S @default = default)
            => Exists ? ifSome(value) :  @default;

        /// <summary>
        /// Maps an optional source value to a nullable value type
        /// </summary>
        /// <param name="x">The optional source value</param>
        /// <param name="f">The transfomation function</param>
        /// <typeparam name="S">The type of the project value if value exists</typeparam>
        [MethodImpl(Inline)]
        public S? MapValueOrNull<S>(Func<T, S> f)
            where S : struct
                => value != null ? f(value) : (S?)null;

        /// <summary>
        /// Implements the canonical bind operation
        /// </summary>
        /// <typeparam name="X">The source domain type</typeparam>
        /// <typeparam name="Y">The target domain type</typeparam>
        /// <param name="x">The point in the monadic space over X</param>
        /// <param name="f">The function to apply to effect the bind</param>
        public Option<Y> Bind<Y>(Func<T,Option<Y>> f)
            => Exists ? f(value) : Option<Y>.None();

        /// <summary>
        /// LINQ integration function
        /// </summary>
        /// <param name="apply">The application projector</param>
        /// <typeparam name="Y">The application range</typeparam>
        [MethodImpl(Inline)]
        public Option<Y> Select<Y>(Func<T,Y> apply)
            => TryMap(_x => apply(_x));

        /// <summary>
        /// LINQ integration function
        /// </summary>
        /// <param name="eval">The evaluator</param>
        /// <param name="project">The lifting projector</param>
        /// <typeparam name="Y">The evaluator range type</typeparam>
        /// <typeparam name="Z">The projector range type</typeparam>
        [MethodImpl(Inline)]
        public Option<Z> SelectMany<Y,Z>(Func<T, Option<Y>> eval, Func<T,Y,Z> project)
        {
            if (Exists)
            {
                var v = value;
                var y = eval(v);
                var z = y.Bind(yVal => Option<Z>.Some(project(v, yVal)));
                return z;
            }
            else
                return Option<Z>.None();
        }

        /// <summary>
        /// LINQ integration function
        /// </summary>
        /// <param name="predicate">The predicate to evaluate</param>
        [MethodImpl(Inline)]
        public Option<T> Where(Func<T, bool> predicate)
        {
            if (Exists)
            {
                if (predicate(value))
                    return value;
                else
                    return new Option<T>();
            }
            else
                return value;
        }

        public bool Equals(Option<T> y)
        {
            var x = this;

            if (!x.Exists && !y.Exists)
                return true;

            if (x.Exists && y.Exists)
                return  Object.Equals(x.ValueOrDefault(), y.ValueOrDefault());

            return false;
        }

        public override int GetHashCode()
            => Exists ? value.GetHashCode() : typeof(T).Name.GetHashCode();

        public override string ToString()
            => this.MapValueOrElse(value => value?.ToString() ?? string.Empty, () => string.Empty);

        public override bool Equals(object obj)
            => obj is Option<T> x && Equals(x);

        [MethodImpl(Inline)]
        public static implicit operator Option<T>(T x)
            => x != null  ? Some(x) : None();

        /// <summary>
        /// Implmements value-based equality
        /// </summary>
        /// <param name="lhs">The first value</param>
        /// <param name="rhs">The second value</param>
        [MethodImpl(Inline)]
        public static bool operator == (Option<T> lhs, Option<T> rhs)
            => (lhs.IsNone() && rhs.IsNone())  ? true : (lhs.Exists && rhs.Exists && lhs.value.Equals(rhs.value));

        /// <summary>
        /// Implements value-based equality negation
        /// </summary>
        /// <param name="lhs">The first value</param>
        /// <param name="rhs">The second value</param>
        [MethodImpl(Inline)]
        public static bool operator !=(Option<T> lhs, Option<T> rhs)
            => !(lhs == rhs);

        /// <summary>
        /// Returns true if the option has a value and false otherwise
        /// </summary>
        /// <param name="x">The option to test</param>
        [MethodImpl(Inline)]
        public static bool operator true(Option<T> x)
            => x.Exists;

        /// <summary>
        /// Returns false if the option is non-valued and true otherwise
        /// </summary>
        /// <param name="x">The option to test</param>
        [MethodImpl(Inline)]
        public static bool operator false(Option<T> x)
            => !x.Exists;

        /// <summary>
        /// Returns false if the option is non-valued and true otherwise
        /// </summary>
        /// <param name="x">The option to test</param>
        [MethodImpl(Inline)]
        public static bool operator !(Option<T> x)
            => !x.Exists;
    }
}