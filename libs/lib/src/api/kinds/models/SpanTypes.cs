//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class SpanTypes
    {
        /// <summary>
        /// Classifies a type according to whether it is a span, a readonly span, or otherwise
        /// </summary>
        /// <param name="t">The type to examine</param>
        public static SpanKind kind(Type t)
            =>  t.GenericDefinition2() == typeof(Span<>) ? SpanKind.Mutable
              : t.GenericDefinition2() == typeof(ReadOnlySpan<>) ? SpanKind.Immutable
              : t.Tagged<CustomSpanAttribute>() ? SpanKind.Custom
              : 0;

        /// <summary>
        /// Tests whether a type defines a system-defined span
        /// </summary>
        /// <param name="t">The type to test</param>
        public static bool IsSystemSpan(Type t)
             => IsSystemSpan(kind(t));

        static bool IsSystemSpan(SpanKind kind)
            => kind == SpanKind.Mutable || kind == SpanKind.Immutable;
    }
}