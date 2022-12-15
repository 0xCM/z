//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IFileType : IExpr
    {
        asci16 Name {get;}

        FileExt DefaultExt {get;}
        bool INullity.IsEmpty
            => Name.IsEmpty;

        bool INullity.IsNonEmpty
            => !IsEmpty;

        string IExpr.Format()
            => Name;
    }

    public interface IFileType<T> : IFileType
        where T : IFileType<T>, new()

    {
        
    }
}