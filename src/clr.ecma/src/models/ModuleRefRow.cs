//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Ecma
    {
        [EcmaRow(TableIndex.ModuleRef), StructLayout(LayoutKind.Sequential, Pack =1)]
        public struct ModuleRefRow : IEcmaRow<ModuleRefRow>
        {
            [Render(12)]
            public EcmaToken Index;

            [Render(12)]
            public EcmaStringKey Name;

            public ModuleRefRow()
            {
                Index = default;
                Name = default;
            }

            public ModuleRefRow(EcmaToken token, EcmaStringKey name)
            {
                Index = token;
                Name = name;
            }
        }
    }
}