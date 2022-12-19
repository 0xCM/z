//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Models
{
    public record class TypescriptFile : SourceFile<TypescriptFile,@string>
    {
        public TypescriptFile()
            : base(FilePath.Empty, @string.Empty)
        {

        }

        public TypescriptFile(FilePath location, @string content)
            : base(location,content)
        {


        }
    }
}