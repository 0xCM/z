//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Ecma
    {
        [EcmaRow(TableIndex.FieldLayout), StructLayout(LayoutKind.Sequential, Pack =1)]
        public struct FieldLayoutRow : IEcmaRow<FieldLayoutRow>
        {
            [Render(12)]
            public Address32 Offset;

            [Render(12)]
            public EcmaToken Field;
        }

        [EcmaRow(TableIndex.ClassLayout), StructLayout(LayoutKind.Sequential, Pack =1)]
        public struct ClassLayoutRow : IEcmaRow<ClassLayoutRow>
        {
            [Render(12)]
            public Address32 Offset;

            [Render(12)]
            public EcmaToken Field;
        }

    }
}