//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    public record class SourceFile
    {
        public asci8 Language;

        public FilePath Location;

        public TextBlock Content;

        public SourceFile()
        {
            Location = FilePath.Empty;
            Content = TextBlock.Empty;
            Language = asci8.Null;
        }

        public SourceFile(asci8 lang, FilePath location, string content)
        {
            Language = lang;
            Location = location;
            Content = content;
        }
    }
}