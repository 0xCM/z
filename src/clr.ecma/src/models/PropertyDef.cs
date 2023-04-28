//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Ecma
    {     
        [EcmaRow(TableIndex.Property), StructLayout(LayoutKind.Sequential, Pack =1)]
        public struct PropertyDef
        {
            [Render(12)]
            public EcmaToken Index;

            [Render(12)]
            public EcmaStringKey Name;

            [Render(12)]
            public EcmaToken DeclaringType;

            [Render(12)]
            public EcmaStringKey Namespace;

            [Render(12)]
            public PropertyAttributes Attributes;
        }
    }
}