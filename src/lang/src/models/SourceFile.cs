//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    public record class SourceFile
    {
        public @string Language;

        public FilePath Location;

        public TextBlock Content;

        public SourceFile()
        {
            Location = FilePath.Empty;
            Content = TextBlock.Empty;
            Language = @string.Empty;
        }

        public SourceFile(@string lang, FilePath location, string content)
        {
            Language = lang;
            Location = location;
            Content = content;
        }
    }
}