//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct ChildRelation
    {
        const string TableId = "llvm.entities.relations.child";

        [Render(8)]
        public uint Key;

        [Render(12)]
        public uint ParentKey;

        [Render(24)]
        public string ParentName;

        [Render(12)]
        public uint ChildSeq;

        [Render(1)]
        public string ChildName;
    }
}