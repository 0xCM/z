//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using N = ToolNames;

    partial class Tools
    {
        public static SymLinkCmd symlink(FolderPath src, FolderPath dst)
            => new SymLinkCmd(SymLinkCmd.Flag.Directory, src.ToUri(), dst.ToUri());
                    
        public sealed class SymLink : Tool<SymLink>, ICmdRender<SymLinkCmd>
        {
            public SymLink()
                : base(N.mklink)
            {

            }

            public string Format()
                => Name.Format();            

            public string Format(SymLinkCmd src)
            {
                var result = EmptyString;
                if(src.Flags != 0)
                {
                    result = $"{Name} {EnumRender.format(src.Flags)} {src.Source} {src.Target}";
                }
                else
                {
                    result = $"{Name} {src.Source} {src.Target}";
                }
                return result;
            }

            public override string ToString()
                => Format();
        }        
    }
}