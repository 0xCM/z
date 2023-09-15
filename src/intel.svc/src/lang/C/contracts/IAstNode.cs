//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang.C;

public interface IAstNode
{


}

public interface IAstNode<T> : IAstNode
    where T : IAstNode<T>
{

}