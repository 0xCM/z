//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang.C;

public interface IAstFactory
{

}

public interface IAstFactory<T> : IAstFactory
{
    abstract static T create();
}

public interface IAstFactory<A,T> : IAstFactory
{
    abstract static T create(A a);
}

