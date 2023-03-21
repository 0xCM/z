//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IFileType : IExpr
    {
        @string Name {get;}

        bool INullity.IsEmpty
            => Name.IsEmpty;

        bool INullity.IsNonEmpty
            => !IsEmpty;

        string IExpr.Format()
            => Name;
    }

    public interface IFileType<T> : IFileType, IDataString<T>, IDataType<T>
        where T : IFileType<T>, new()

    {
        
    }
}