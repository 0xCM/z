//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly partial struct CsModels
    {
        public struct EnumReplicantSpec
        {
            public string Namespace;

            public string DeclaringType;

            public FolderPath Target;

            [MethodImpl(Inline)]
            public EnumReplicantSpec WithNamespace(string ns)
            {
                Namespace = ns;
                return this;
            }

            public EnumReplicantSpec WithDeclaringType(string name)
            {
                DeclaringType = name;
                return this;
            }
        }


        [Op]
        public static SummaryComment comment(string content)
            => new SummaryComment(content);
    }
}