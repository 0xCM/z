//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ILiteralCover : IValueCover
    {

    }

    [Free]
    public interface ILiteralCover<T> : ILiteralCover, IValueCover<T>
    {

    }
}