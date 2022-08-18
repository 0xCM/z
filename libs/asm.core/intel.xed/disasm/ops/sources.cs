//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDisasm
    {
        public static Index<FileRef> sources(FileFlowContext context)
            => context.Docs(FileKind.XedRawDisasm);
    }
}