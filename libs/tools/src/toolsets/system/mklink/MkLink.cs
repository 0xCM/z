//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using N = ToolNames;

    partial class Tools
    {
        public static MkLinkCmd mklink(FolderPath src, FolderPath dst)
            => new MkLinkCmd(MkLinkCmd.Flag.Directory, src.ToUri(), dst.ToUri());
                    
        public sealed class MkLink : Tool<MkLink>, ICmdRender<MkLinkCmd>
        {
            public MkLink()
                : base(N.mklink)
            {

            }

            public string Format()
                => Name.Format();

            public string Format(MkLinkCmd src)
                => $"{Name} {EnumRender.format(src.Flags)} {src.Source} {src.Target}";

            public override string ToString()
                => Format();
        }        
    }
}