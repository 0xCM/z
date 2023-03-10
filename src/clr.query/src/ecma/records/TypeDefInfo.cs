//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaModels
    {
        [Record(TableId), StructLayout(LayoutKind.Sequential, Pack = 1)]
        public record struct TypeDefInfo
        {
            const string TableId = "ecma.typedefs";
            
            [Render(16)]            
            public EcmaToken Token;

            [Render(48)]
            public @string Name;

            [Render(48)]
            public @string BaseName;

            [Render(1)]
            public TypeAttributes Attributes;
        }
    }
}