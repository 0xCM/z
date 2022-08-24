//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IRenderTemplate<T>
    {
        T Content {get;}
    }

    public interface IRenderTemplate<H,T> : IRenderTemplate<T>
        where H : struct, IRenderTemplate<H,T>
    {

    }

    public interface IRenderTemplate : IRenderTemplate<string>
    {

    }
}