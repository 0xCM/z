//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaTables
    {
        [Record(TableId), StructLayout(LayoutKind.Sequential, Pack =1)]
        public struct TypeExport
        {
            public const string TableId= "ecma.types.exports";

            [Render(12)]
            public EcmaRowKey TypeDefId;

            [Render(16)]
            public EcmaStringIndex TypeName;

            [Render(16)]
            public EcmaStringIndex TypeNamespace;

            [Render(16)]
            public EcmaRowKey Implementation;

            [Render(1)]
            public TypeAttributes Flags;
        }       
    }
}