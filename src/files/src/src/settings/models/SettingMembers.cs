//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class SettingMembers : ReadOnlySeq<SettingMembers,FieldInfo>
    {
        public static string format(SettingMembers src, char sep)
        {
            var dst = text.emitter();
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var member = ref src[i];
                dst.AppendLine($"{member.Name}{sep}{member.FieldType.DisplayName()}");
            }

            return dst.Emit();
        }

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
            => format(this, Chars.Eq);
    }
}