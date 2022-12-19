//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Models
{
    public record class TypescriptFile<C> : TypescriptFile
        where C : IExpr, new()
    {
        public new readonly C Content;

        public TypescriptFile()
        {
            Content = new();
        }

        public TypescriptFile(FilePath location, C content)
            : base(location, content.Format())
        {
            Content = content;
        }

    }
}