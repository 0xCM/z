//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IOperatorClass<E> : IOperationClass, IOperationClass<E>
        where E : unmanaged, Enum
    {

    }

    [Free]
    public interface IOperatorClass<F,E> : IOperatorClass<E>, IOperationClassHost<F,E>
        where F : struct, IOperatorClass<F,E>
        where E : unmanaged, Enum
    {
        OperatorClass Classifier {get;}
    }

    [Free]
    public interface IOperatorClass<F,E,T> : IOperatorClass<F,E>
        where F : struct, IOperatorClass<F,E>
        where E : unmanaged, Enum
    {
        new OperatorClass<T> Classifier {get;}

        OperatorClass IOperatorClass<F,E>.Classifier
            => Classifier;
    }
}