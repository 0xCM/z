//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ITextFileMapper<T> : IMapper<TextFile,T>
    {
        TextFileKind SourceType {get;}
    }

}