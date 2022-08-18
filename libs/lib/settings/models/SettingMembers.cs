//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = Settings;

    public class SettingMembers : ReadOnlySeq<SettingMembers,FieldInfo>
    {
        public SettingMembers()
        {

        }

        [MethodImpl(Inline), Op]
        public SettingMembers(FieldInfo[] fields)
            : base(fields)
        {
        }

        public bool Member(string name, out FieldInfo dst)
        {
            var result = false;
            dst = EmptyVessels.EmptyField;
            for(var i=0; i<Count; i++)
            {
                ref readonly var member = ref this[i];
                if(member.Name == name)
                {
                    dst = member;
                    break;
                }
            }
            return result;
        }

        public override string Format()
            => api.format(this, Chars.Eq);
    }
}