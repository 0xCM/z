//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential,Pack=64), Record(TableId)]
    public readonly struct FlowCmd : IWfCmd<FlowCmd>
    {
        const string TableId = "ws.cmdflows";

        [Render(16)]
        public readonly @string WsId;

        [Render(16)]
        public readonly Actor Actor;

        [Render(32)]
        public readonly @string SrcId;

        [Render(12)]
        public readonly FileKind SrcKind;

        [Render(32)]
        public readonly @string DstId;

        [Render(12)]
        public readonly FileKind DstKind;

        [MethodImpl(Inline)]
        public FlowCmd(string ws, Actor actor, string src, FileKind kSrc, string dst, FileKind kDst)
        {
            WsId = ws;
            Actor = actor;
            SrcId = src;
            SrcKind = kSrc;
            DstId = dst;
            DstKind = kDst;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => WsId.Hash | Actor.Hash | SrcId.Hash | DstId.Hash | HashCodes.hash((byte)SrcKind, (byte)(DstKind));
        }

        public FileName SrcFile 
            => FS.file(SrcId,SrcKind);

        public FileName DstFile 
            => FS.file(DstId,DstKind);

        public string Format()
            => $"{Actor}:{SrcFile} -> {DstFile}";

        public override string ToString()
            => Format();
    }
}