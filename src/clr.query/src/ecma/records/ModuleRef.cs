//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaTables
    {
        [EcmaRow(TableIndex.ModuleRef), StructLayout(LayoutKind.Sequential, Pack =1)]
        public struct ModuleRef
        {
            public EcmaToken Token;

            public EcmaStringKey Name;

            public ModuleRef(EcmaToken token, EcmaStringKey name)
            {
                Token = token;
                Name = name;
            }
        }
    }
}