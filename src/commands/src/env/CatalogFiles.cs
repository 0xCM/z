
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Commands
{
    public record class CatalogFiles : Command<CatalogFiles>
    {
        public CatalogFiles()
        {
            Source = FolderPath.Empty;
            Target = FolderPath.Empty;
            Match = sys.empty<FileExt>();
        }

        public FolderPath Source;

        public FolderPath Target;

        public Seq<FileExt> Match;

        public static Outcome bind(CmdArgs src, out CatalogFiles dst)
        {
            dst = new();
            dst.Target = Env.ShellData.Root;
            var count = src.Count;
            try
            {
                if(count >= 1)
                    dst.Source = FS.dir(src[0]);
                
                if(count >= 2)
                    switch(src[1].Value)
                    {
                        case "--ext":
                        dst.Match = sys.map(text.split(src[2].Value, Chars.Semicolon), x => FS.ext(x));
                        break;
                    }
            }
            catch(Exception e)
            {
                return e;
            }
        
            return true;
        }
    
    }
}