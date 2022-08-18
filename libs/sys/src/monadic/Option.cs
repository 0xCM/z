//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{

    [ApiHost]
    public static class Option
    {
        const NumericKind Closure = UnsignedInts;

        /// <summary>
        /// Implements the canonical join operation that reduces the monadic depth by one level
        /// </summary>
        /// <param name="src">The optional option</param>
        /// <typeparam name="T">The encapsulated value</typeparam>
        [MethodImpl(Inline), Op, Closures(UInt64k)]
        public static Option<T> reduce<T>(Option<Option<T>> src)
            => src.ValueOrDefault(Option.none<T>());

        /// <summary>
        /// Defines the canonical option functor F:Option[A] -> Option[B] induced by a non-monadic dual f:A->B
        /// </summary>
        /// <param name="f">A non-monadic projector</param>
        /// <typeparam name="A">The source type</typeparam>
        /// <typeparam name="B">The target type</typeparam>
        [MethodImpl(Inline)]
        public static Func<Option<A>,Option<B>> fmap<A,B>(Func<A,B> f)
            => x => x.TryMap(a => f(a));

        /// <summary>
        /// Implements the canonical bind operation
        /// </summary>
        /// <typeparam name="X">The source domain type</typeparam>
        /// <typeparam name="Y">The target domain type</typeparam>
        /// <param name="x">The point in the monadic space over X</param>
        /// <param name="f">The function to apply to effect the bind</param>
        [MethodImpl(Inline)]
        public static Option<Y> bind<X,Y>(Option<X> x, Func<X,Option<Y>> f)
            => x ? f(x.ValueOrDefault()) : Option.none<Y>();

        /// <summary>
        /// Creates an option from a reference type instance, returning a valued option if the
        /// refernce is not null; otherwise, returns none
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline)]
        public static Option<T> from<T>(T src)
            where T : class
                => src != null ? some(src) : none<T>();

        /// <summary>
        /// Creates an option from a value type, returning a valued option if the
        /// refernce is not null; otherwise, returns none
        /// </summary>
        /// <param name="src">The source value</param>
        /// <typeparam name="T">The source type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Option<T> from<T>(T? src)
            where T : struct
                => src.HasValue ? some(src.Value) : none<T>();

        /// <summary>
        /// Defines a non-valued option
        /// </summary>
        /// <typeparam name="T">The value type, if the value existed</typeparam>
        [MethodImpl(Inline)]
        public static Option<T> none<T>()
            => Option<T>.None();

        /// <summary>
        /// Defines a valued option
        /// </summary>
        /// <param name="value">The value</param>
        /// <typeparam name="T">The type of the extant value</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Option<T> some<T>(T value)
            => Option<T>.Some(value);

        /// <summary>
        /// Classifies the value as some or none and manufactures the appropriate option encapsulation
        /// </summary>
        /// <typeparam name="T">The type of value</typeparam>
        /// <param name="value">The value to lift into option-space</param>
        [MethodImpl(Inline)]
        public static Option<T> eval<T>(T value)
            where T : class
                => value is null ? none<T>()  : some(value);

        /// <summary>
        /// Classifies the value as some or none and manufactures the appropriate option encapsulation
        /// </summary>
        /// <typeparam name="T">The type of value</typeparam>
        /// <param name="value">The value to lift into option-space</param>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Option<T> eval<T>(T? value)
            where T : struct
                => value.HasValue ? some(value.Value) : none<T>();

        /// <summary>
        /// Evaluates a function within a try block and returns the value of the computation if
        /// successful; otherwise, returns None and invokes an error handler if supplied
        /// </summary>
        /// <typeparam name="T">The result type</typeparam>
        /// <param name="f">The function to evaluate</param>
        [Op,Closures(Closure)]
        public static Option<T> Try<T>(Func<T> f, Action<Exception> handler = null)
        {
            try
            {
                return f();
            }
            catch (Exception e)
            {
                Handle(e, handler);
                return none<T>();
            }
        }

        /// <summary>
        /// Evaluates a function within a try block and returns the value of the computation if
        /// successful; otherwise, returns None together with the reported exception
        /// </summary>
        /// <param name="f">The function to evaluate</param>
        /// <typeparam name="T">The function result type, if successful</typeparam>
        [Op,Closures(Closure)]
        public static Option<T> Try<T>(Func<Option<T>> f, Action<Exception> handler = null)
        {
            try
            {
                return f();
            }
            catch (Exception e)
            {
                Handle(e,handler);
                return none<T>();
            }
        }

        /// <summary>
        /// Invokes an action within a try block and, upon error, calls
        /// the handler if specified. If no handler is specified, the exception
        /// message is emitted to stderr
        /// </summary>
        /// <param name="f">The action to invoke</param>
        /// <param name="onerror">The error handler to call, if specified</param>
        [Op]
        public static void Try(Action f, Action<Exception> handler = null)
        {
            try
            {
                f();
            }
            catch(Exception e)
            {
                Handle(e,handler);
            }
        }

        /// <summary>
        /// Evaluates a function within a try block and returns the value of the computation if
        /// successful; otherwise, returns None together with the reported exception
        /// </summary>
        /// <typeparam name="X">The input type</typeparam>
        /// <typeparam name="Y">The output type</typeparam>
        /// <param name="x">The input value</param>
        /// <param name="f">The function to evaluate</param>
        public static Option<Y> Try<X,Y>(X x, Func<X,Y> f, Action<X,Exception> handler = null)
        {
            try
            {
                return f(x);
            }
            catch (Exception e)
            {
                Handle(e,x,handler);
                return none<Y>();
            }
        }

        /// <summary>
        /// Casts a value if possible, otherwise returns none
        /// </summary>
        /// <typeparam name="T">The target type</typeparam>
        /// <param name="item">The object to cast</param>
        [MethodImpl(Inline)]
        public static Option<T> TryCast<T>(object item)
            => item is T ? some((T)item) : none<T>();

        static void Handle(Exception e, Action<Exception> handler)
        {
            if(handler != null)
                handler.Invoke(e);
            else
                Console.Error.WriteLine(e);
        }

        static void Handle<X>(Exception e, X x, Action<X,Exception> handler)
        {
            if(handler != null)
                handler.Invoke(x,e);
            else
            {
                var msg = $"Exeption raised during {x} evaluation: {e}";
                Console.WriteLine(msg);
            }
        }

        /// <summary>
        /// Evaluates a function over a value if the value is not null; otherwise, returns the default result value
        /// </summary>
        /// <typeparam name="X">The operand type</typeparam>
        /// <typeparam name="Y">The return type</typeparam>
        /// <param name="x">The operand</param>
        /// <param name="f1">The function to potentially evaluate</param>
        [MethodImpl(Inline)]
        public static Y ifNotNull<X,Y>(X x, Func<X,Y> f1, Y @default = default)
            => x != null ? f1(x) : @default;

        [MethodImpl(Inline)]
        public static T[] array<T>(params T[] src)
            => src;
    }
}