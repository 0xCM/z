//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost,Free]
    public partial class Redirects
    {
        [MethodImpl(Inline)]
        public static Redirect<K,S,T> record<K,S,T>(K kind, S src, T dst)
            where K : unmanaged
            where S : IDataType<S>, IExpr, new()
            where T : IDataType<T>, IExpr, new()
                => new (kind,src,dst);

        [Op]
        public static ReadOnlySeq<Redirect<Kind,FolderPath,FolderPath>> records(FolderRedirects src)
            => src.Map(x => record(x.Kind, x.Source, x.Target));

        [Op]
        public static FolderRedirect folder(FolderPath src, FolderPath dst)
            => new FolderRedirect(src,dst);

        [Op]
        public static FolderRedirects folders(params FolderRedirect[] src)
            => new FolderRedirects(src);
    }
}