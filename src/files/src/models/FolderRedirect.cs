//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class FolderRedirect : Redirect<FolderRedirect,RedirectKind,FolderPath,FolderPath>
    {
        public FolderRedirect()
            :base(RedirectKind.Folder)
        {

        }

        public FolderRedirect(FolderPath src, FolderPath dst)
            : base(RedirectKind.Folder, src,dst)
        {


        }

        public Redirect<RedirectKind,FolderPath,FolderPath> Record() 
            => Redirects.record(Kind,Source,Target);
    }    
}