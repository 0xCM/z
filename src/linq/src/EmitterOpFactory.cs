//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;

    public interface IOpFactoryProvider
    {
       IEmitterOpFactory<T> Factory<T>(EmitterClass<T> k)
            where T : unmanaged;

        IUnaryOpFactory<T> Factory<T>(UnaryOperatorClass<T> op)
            where T :  unmanaged;

        IBinaryOpFactory<T> Factory<T>(BinaryOperatorClass<T> op)
            where T :  unmanaged;

        ITernaryOpFactory<T> Factory<T>(TernaryOperatorClass<T> op)
            where T :  unmanaged;
    }

    public struct OpFactoryProvider : IOpFactoryProvider
    {
        public IEmitterOpFactory<T> Factory<T>(EmitterClass<T> k)
            where T :  unmanaged
                => EmitterFactory<T>.Service;

        public IUnaryOpFactory<T> Factory<T>(UnaryOperatorClass<T> k)
            where T :  unmanaged
            => UnaryOpFactory<T>.Service;

        public IBinaryOpFactory<T> Factory<T>(BinaryOperatorClass<T> k)
            where T :  unmanaged
            => BinaryOpFactory<T>.Service;

        public ITernaryOpFactory<T> Factory<T>(TernaryOperatorClass<T> k)
            where T :  unmanaged
                => TernaryOpFactory<T>.Service;
    }


    public readonly struct EmitterFactory<T> : IEmitterOpFactory<T>
    {
        public static IEmitterOpFactory<T> Service => default(EmitterFactory<T>);

        public Func<T> Create(MethodInfo method, object host = null)
        {
            var xCall = LinqXPress.call(host, method);
            var xConvert = LinqXPress.convert<T>(xCall);
            var f = LinqXPress.emitter<T>(xConvert);
            return f.Compile();
        }
    }
}