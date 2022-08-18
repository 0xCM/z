//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

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