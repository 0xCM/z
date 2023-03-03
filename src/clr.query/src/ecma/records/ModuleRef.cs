//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaModels
    {
        public struct ModuleRef
        {
            public EcmaToken Token;

            public string Name;

            public ModuleRef(EcmaToken token, string name)
            {
                Token = token;
                Name = name;
            }
        }
    }
}