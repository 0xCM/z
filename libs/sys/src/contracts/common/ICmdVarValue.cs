//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ICmdVarValue : ITextual, INullity
    {

    }

    [Free]
    public interface ICmdVarValue<T> : ICmdVarValue, IContented<T>
    {

    }
}