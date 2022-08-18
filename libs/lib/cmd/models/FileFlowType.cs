//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct FileFlowType : IFileFlowType
    {
        public static string format(IFileFlowType flow)
            => string.Format("{0}:*.{1} -> *.{2}", flow.Actor, flow.SourceKind.Ext(), flow.TargetKind.Ext());

        public readonly Actor Actor {get;}

        public readonly FileKind SourceKind {get;}

        public readonly FileKind TargetKind {get;}

        public FileFlowType(string actor, FileKind src, FileKind dst)
        {
            Actor = new Actor(actor);
            SourceKind = src;
            TargetKind = dst;
        }

        dynamic IArrow.Source
            => SourceKind;

        dynamic IArrow.Target
            => TargetKind;

        FS.FileExt SourceExt
            => SourceKind.Ext();

        FS.FileExt TargetExt
            => TargetKind.Ext();

        IActor IFlowType.Actor
            => Actor;

        public string Format()
            => format(this);

        public override string ToString()
            => Format();
    }
}