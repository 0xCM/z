//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaTables
    {
        [EcmaRow(TableIndex.ExportedType), StructLayout(LayoutKind.Sequential, Pack =1)]
        public struct TypeExportRow : IEcmaRow<TypeExportRow>
        {
            [Render(12)]
            public EcmaRowKey TypeDefId;

            [Render(16)]
            public EcmaStringKey TypeName;

            [Render(16)]
            public EcmaStringKey TypeNamespace;

            [Render(16)]
            public EcmaRowKey Implementation;

            [Render(1)]
            public TypeAttributes Flags;
        }       
    }
}