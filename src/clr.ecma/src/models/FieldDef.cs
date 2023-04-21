//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Ecma
    {
        [Record(TableId), StructLayout(LayoutKind.Sequential)]
        public struct FieldDef
        {
            public const string TableId = "ecma.fields.defs.info";

            [Render(12)]
            public EcmaToken Token;

            [Render(48)]            
            public AssemblyKey Assembly;

            [Render(48)]
            public @string DeclaringType;

            [Render(24)]
            public @string Namespace;

            [Render(48)]
            public @string Name;

            [Render(32)]
            public EcmaSig CliSig;

            [Render(1)]
            public FieldAttributes Attributes;
        }

    }
}