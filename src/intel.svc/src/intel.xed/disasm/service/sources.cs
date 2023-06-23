//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDisasm
    {
        public static Index<FileRef> sources(ProjectContext context)
            => context.Docs(FileKind.XedRawDisasm);
    }
}