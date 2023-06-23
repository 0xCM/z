//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedModels
    {
        [Record(TableId)]
        public struct QueryResult
        {
            public const string TableId = "xed.query.result";

            public const byte FieldCount = 6;

            [Render(18)]
            public string SearchPattern;

            [Render(18)]
            public XedInstClass InstClass;

            [Render(64)]
            public XedInstForm InstForm;

            [Render(16)]
            public InstIsaKind Isa;

            [Render(16)]
            public ExtensionKind Extension;

            [Render(1)]
            public InstAttribs Attributes;

            public static QueryResult Empty => default;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{16,16,48,16,16,1};
        }
    }
}