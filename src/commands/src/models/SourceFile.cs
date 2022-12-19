//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Models
{
    public record class SourceFile : IModel<SourceFile>
    {
        public FilePath Location;


        public IExpr Content;

        public SourceFile()
        {
            Location = FilePath.Empty;
            Content = @string.Empty;
        }

        public SourceFile(FilePath location, IExpr content)
        {
            Location = location;
            Content = content;
        }
    }
}