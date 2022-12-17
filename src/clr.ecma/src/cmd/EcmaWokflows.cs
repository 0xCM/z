//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class EcmaWokflows
    {
        public static ReadOnlySeq<FolderPath> sources()
            => sources(AppDb.Service.Catalogs("ecma").Path("sources", FS.ext("ts")));

        public static ReadOnlySeq<FolderPath> sources(FilePath src)
        {
            var content = src.ReadText();
            var locations = text.split(text.unfence(content, Fenced.Bracketed),Chars.Comma).ToSeq();
            return locations.Select(x => FS.dir(text.unfence(x, Fenced.SQuote)));
        }
    }
}