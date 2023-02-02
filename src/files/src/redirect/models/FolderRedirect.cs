//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Redirects
    {
        public sealed class FolderRedirect : Redirect<FolderRedirect,Kind,FolderPath,FolderPath>
        {
            public FolderRedirect()
                :base(Kind.Folder)
            {

            }

            public FolderRedirect(FolderPath src, FolderPath dst)
                : base(Kind.Folder, src,dst)
            {


            }

            public Redirect<Kind,FolderPath,FolderPath> Record() 
                => record(Kind,Source,Target);
        }
    }
}