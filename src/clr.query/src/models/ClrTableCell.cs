//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Describes a column in a table
    /// </summary>
    public readonly struct ClrTableCell
    {
        /// <summary>
        /// The 0-based, declaration order of the field
        /// </summary>
        public readonly ushort CellIndex;

        /// <summary>
        /// The defining field
        /// </summary>
        public readonly FieldInfo Definition;

        /// <summary>
        /// The external field name
        /// </summary>
        public readonly Identifier CellName;

        /// <summary>
        /// A render specification, if any
        /// </summary>
        public readonly CellRenderSpec RenderSpec;

        /// <summary>
        /// The field width, if available
        /// </summary>
        public readonly ushort CellWidth;

        public static string name(MemberInfo src)
            => src.Tag<FieldAttribute>().MapValueOrDefault(a => text.ifempty(a.FieldName, src.Name), src.Name);

        [MethodImpl(Inline)]
        public ClrTableCell(CellRenderSpec spec, FieldInfo def)
        {
            RenderSpec = spec;
            Require.invariant(spec.Width > 0);
            CellWidth = (ushort)spec.Width;
            CellIndex = (ushort)spec.Index;
            Definition = def;
            CellName = name(def);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Definition == null;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Definition != null;
        }

        /// <summary>
        /// The member field name
        /// </summary>
        public Identifier MemberName
        {
            [MethodImpl(Inline)]
            get => IsNonEmpty ? Definition.Name : Identifier.Empty;
        }

        /// <summary>
        /// The field datatype
        /// </summary>
        public Type DataType
        {
            [MethodImpl(Inline)]
            get => Definition?.FieldType ?? typeof(void);
        }

        [MethodImpl(Inline)]
        public string Format<T>(T src)
            => RenderSpec.Format(src);

        public string Format()
            => string.Format("{0:D2} {1}", CellIndex, CellName);

        public override string ToString()
            => Format();
    }
}