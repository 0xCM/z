//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IFileType : IKinded
    {
        Identifier Name {get;}

        bool INullity.IsEmpty
            => Name.IsEmpty;

        bool INullity.IsNonEmpty
            => !IsEmpty;

        string IExpr.Format()
            => Name;

        Index<FS.FileExt> DefaultExtensions {get;}

        FS.FileExt PrimaryExtension
            => DefaultExtensions.IsNonEmpty ?  DefaultExtensions.First : FS.FileExt.Empty;
    }

    public interface IFileType<K> : IFileType, IKinded<K>
        where K : unmanaged
    {


    }
}