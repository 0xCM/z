//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IFile : IExpr, ILocatable
    {
        string IExpr.Format()
            => $"{Location}";
    }

    [Free]
    public interface IFile<T> : IFile, ILocatable<T>
    {

    }
}