//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Describes a column in a table
    /// </summary>
    public readonly struct ClrTableField
    {
        /// <summary>
        /// The 0-based, declaration order of the field
        /// </summary>
        public readonly ushort FieldIndex;

        /// <summary>
        /// The defining field
        /// </summary>
        public readonly FieldInfo Definition;

        /// <summary>
        /// The external field name
        /// </summary>
        public readonly Identifier FieldName;

        /// <summary>
        /// A render specification, if any
        /// </summary>
        public readonly CellRenderSpec RenderSpec;

        /// <summary>
        /// The field width, if available
        /// </summary>
        public readonly ushort FieldWidth;

        [MethodImpl(Inline)]
        public ClrTableField(CellRenderSpec spec, FieldInfo def)
        {
            RenderSpec = spec;
            Require.invariant(spec.Width > 0);
            FieldWidth = (ushort)spec.Width;
            FieldIndex = (ushort)spec.Index;
            Definition = def;
            FieldName = Tables.name(def);
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
            => string.Format("{0:D2} {1}", FieldIndex, FieldName);

        public override string ToString()
            => Format();
    }
}