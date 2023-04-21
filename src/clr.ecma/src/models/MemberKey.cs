//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Ecma
    {
        [StructLayout(LayoutKind.Sequential,Pack=1), Record(TableName)]
        public record class MemberKey : IComparable<MemberKey>
        {
            const string TableName = "members.keys";

            [Render(48)]
            public readonly VersionedName Assembly;

            [Render(12)]
            public readonly EcmaToken MemberToken;

            [Render(48)]
            public readonly StringRef Namespace;

            [Render(48)]
            public readonly StringRef DeclaringType;
            
            [Render(1)]

            public readonly StringRef MemberName;

            public MemberKey(VersionedName assembly, EcmaToken token, StringRef ns, StringRef decl, StringRef member)
            {
                Assembly = assembly;
                MemberToken = token;
                Namespace = ns;
                DeclaringType = decl;
                MemberName = member;
            }

            public string Format()
            {
                var dst = EmptyString;
                if(Namespace.IsNonEmpty && DeclaringType.IsNonEmpty)
                    dst =$"{Assembly}/{Namespace}/{DeclaringType}/{MemberName}";
                else if(Namespace.IsNonEmpty)
                    dst = $"{Assembly}/{Namespace}/{MemberName}";
                else
                    dst = $"{Assembly}/{MemberName}";
                return dst;

            }

            public override string ToString()
                => Format();
            
            public int CompareTo(MemberKey src)
            {
                var result = Assembly.CompareTo(src.Assembly);
                if(result == 0)
                {
                    result = Namespace.CompareTo(src.Namespace);
                    if(result == 0)
                    {
                        result = DeclaringType.CompareTo(src.DeclaringType);
                        if(result == 0)
                        {
                            result = MemberName.CompareTo(src.MemberName);
                        }
                    }
                }
                return result;
            }
        }
    }
}