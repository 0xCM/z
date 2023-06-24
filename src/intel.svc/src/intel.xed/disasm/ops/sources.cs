//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDisasm
    {
        public static IEnumerable<FilePath> sources(IDbArchive src)
            => src.Files(FileKind.XedRawDisasm);        
    }
}