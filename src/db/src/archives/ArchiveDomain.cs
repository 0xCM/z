
//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ArchiveDomain : ApiDomain<ArchiveDomain>
    {
        public class CommandNames 
        {
            public const string FilesCopy = "files/copy";

            public const string FilesPack = "files/pack";
        }

        public static Outcome cmd(CmdArgs src, out CatalogFiles dst)
        {
            dst = new();
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

        public record class CatalogFiles : DomainCmd<CatalogFiles>
        {
            public CatalogFiles()
            {
                Source = FolderPath.Empty;
                Target = FolderPath.Empty;
                Match = sys.empty<FileExt>();
            }

            public CatalogFiles(FolderPath src, FolderPath dst, params FileExt[] match)
            {
                Source = src;
                Target = dst;
                Match = match;
            }

            public FolderPath Source;

            public FolderPath Target;

            public Seq<FileExt> Match;
        }
    }
}