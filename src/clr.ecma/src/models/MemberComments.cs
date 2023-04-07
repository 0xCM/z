//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableName)]
    public record class MemberComments : IComparable<MemberComments>
    {
        const string TableName = "api.comments";
        
        [Render(64)]
        public readonly VersionedName AssemblyName;

        [Render(16)]
        public readonly ApiCommentTarget MemberKind;

        [Render(128)]
        public readonly @string MemberName;

        [Render(1)]
        public readonly @string Data;

        public MemberComments(AssemblyFile file, ApiCommentTarget kind, @string name, @string data)
        {
            AssemblyName = file.Identifier;
            MemberKind = kind;
            MemberName = name;
            Data = data;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => AssemblyName.Hash | MemberName.Hash;
        }

        public int CompareTo(MemberComments src)
        {
            var result = AssemblyName.CompareTo(src.AssemblyName);
            if(result == 0)
            {
                result = MemberName.CompareTo(src.MemberName);
            }
            return result;
        }

        public override int GetHashCode()
            => Hash;
    }
}