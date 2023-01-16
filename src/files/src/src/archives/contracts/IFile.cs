//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IFile : IExpr
    {
        FilePath Path {get;}

        string IExpr.Format()
            => $"{Path}";

        bool INullity.IsEmpty
            => Path.IsEmpty;

        bool INullity.IsNonEmpty
            => Path.IsNonEmpty;
    }
}