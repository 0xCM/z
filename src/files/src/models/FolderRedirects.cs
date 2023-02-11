//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class FolderRedirects : Seq<FolderRedirects,FolderRedirect>
    {
        public FolderRedirects()
        {

        }   

        public FolderRedirects(params FolderRedirect[] src)
            : base(src)
        {

        }

        public static implicit operator FolderRedirects(FolderRedirect[] src)
            => new FolderRedirects(src);
    }   
}