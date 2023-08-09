//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;
using System.Linq;
partial class XedDisasm
{
    public static ParallelQuery<FilePath> sources(IDbArchive src)
        => src.Files(FileKind.XedRawDisasm).AsParallel();        
}
