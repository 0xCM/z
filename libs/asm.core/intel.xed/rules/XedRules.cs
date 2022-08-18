//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static core;

    [ApiHost]
    public partial class XedRules : WfSvc<XedRules>
    {
        const string xed = "xed";

        const NumericKind Closure = UnsignedInts;

        Index<PointerWidth> PointerWidths;

        Symbols<VisibilityKind> Visibilities;

        Symbols<XedFieldType> FieldTypes;

        XedRuntime Xed;

        public XedRules With(XedRuntime xed)
        {
            Xed = xed ;
            return this;
        }

        [MethodImpl(Inline)]
        StringRef String(string src)
            => Xed.Alloc.String(src);

        public XedRules()
        {
            PointerWidths = map(PointerWidthKinds.View, s => (PointerWidth)s.Kind);
            Visibilities = Symbols.index<VisibilityKind>();
            FieldTypes = Symbols.index<XedFieldType>();
        }

        XedPaths XedPaths => Xed.Paths;

        static Symbols<PointerWidthKind> PointerWidthKinds;

        static XedRules()
        {
            PointerWidthKinds = Symbols.index<PointerWidthKind>();
        }

        static MsgPattern<string> StepParseFailed => "Failed to parse step from '{0}'";
    }
}