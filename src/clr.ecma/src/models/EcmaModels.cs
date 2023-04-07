//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class EcmaModels
    {
        public sealed record class Method
        {
            public MemberKey Key;

            public EcmaMethodDef Def;

            public Method()
            {

            }

            public Method(MemberKey key, EcmaMethodDef def)
            {
                Key = key;
                Def = def;
            }
        }
    }
}