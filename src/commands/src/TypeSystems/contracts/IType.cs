//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    public interface IType
    {
        @string Scope {get;}
        
        TypeName Name {get;}

        Type RuntimeType {get;}

        dynamic Value(params object[] args);

        dynamic Representative 
            => throw new NotImplementedException();
    }

    public interface IType<T> : IType
    {        
        Func<object[],T> Factory();

        new T Value(params object[] args) 
            => Factory()(args);
        
        dynamic IType.Value(params object[] args)
            => Value(args);
    }

    public interface IType<R,T> : IType<T>
        where R : IType
    {
        new ref readonly R Representative {get;}

        dynamic IType.Representative
            => Representative;
    }

    public interface IType<R,T,A> : IType<R,T>
        where R : IType
    {
        new Func<A,T> Factory();
                
        T Value(A args)
            => Factory()(args);
    }
}
