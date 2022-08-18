//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IFileFlowType : IFlowType
    {
        FileKind SourceKind {get;}

        FileKind TargetKind {get;}
    }

    public interface IFileFlowType<F> : IFileFlowType
        where F : IFileFlowType<F>
    {

    }
}