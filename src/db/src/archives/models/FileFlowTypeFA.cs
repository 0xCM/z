//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class FileFlow<F,A> : FileFlowType<F,A,FileKind>, IFileFlowType<F>
        where F : FileFlow<F,A>,new()
        where A : IActor
    {
        protected FileFlow(A actor, FileKind src, FileKind dst)
            : base(actor,src,dst)
        {

        }

        public FileKind SourceKind => Source;

        public FileKind TargetKind => Target;
    }
}