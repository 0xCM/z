//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class SettingMembers<T> : ReadOnlySeq<SettingMembers<T>,FieldInfo>
        where T : new()
    {
        readonly SettingMembers Members;

        public SettingMembers()
        {   
            Members = new();
        }

        public SettingMembers(SettingMembers src)
            : base(src.Storage)
        {
            Members = src;    
        }

        public bool Member(string name, out FieldInfo dst)
            => Members.Member(name, out dst);

        public override string Format()
            => Data.Format();

        [MethodImpl(Inline), Op]
        public static implicit operator SettingMembers<T>(SettingMembers src)
            => new SettingMembers<T>(src);
    }
}