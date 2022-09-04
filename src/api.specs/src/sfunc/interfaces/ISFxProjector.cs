//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a structural transformation function
    /// </summary>
    public interface ISFxProjector : IFunc
    {
        dynamic Invoke(dynamic src);
    }

    /// <summary>
    /// Characterizes a structural transformation function
    /// </summary>
    /// <typeparam name="A">The source domain type</typeparam>
    /// <typeparam name="B">The target domain type</typeparam>
    [Free, SFx]
    public interface ISFxProjector<A,B> : ISFxProjector, IFunc<A,B>
    {
        _OpIdentity IFunc.Id
            => _OpIdentity.define(string.Format("map<{0},{1}>", typeof(A).Name, typeof(B).Name));

        dynamic ISFxProjector.Invoke(dynamic src)
            => Invoke((A)src);
    }

    /// <summary>
    /// Characterizes a projector that is also a unary operator
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Free, SFx]
    public interface ISFxProjector<T> : ISFxProjector<T,T>, IUnaryOp<T>
    {

    }
}