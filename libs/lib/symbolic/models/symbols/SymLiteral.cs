//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct SymLiteral : IComparableRecord<SymLiteral>
    {
        public const string TableId = "symbolic.literals";

        /// <summary>
        /// The component that defines the literal
        /// </summary>
        [Render(24)]
        public NameOld Component;

        /// <summary>
        /// A literal classifier
        /// </summary>
        [Render(16)]
        public @string Group;

        /// <summary>
        /// The literal's declaring type
        /// </summary>
        [Render(32)]
        public Identifier Type;

        /// <summary>
        /// The token size
        /// </summary>
        [Render(12)]
        public DataSize Size;

        /// <summary>
        /// The container-relative declaration order of the literal
        /// </summary>
        [Render(10)]
        public ushort Index;

        /// <summary>
        /// The literal name
        /// </summary>
        [Render(64)]
        public @string Name;

        /// <summary>
        /// The symbol, if so attributed, otherwise, the identifier
        /// </summary>
        [Render(64)]
        public SymExpr Symbol;

        /// <summary>
        /// The literal's primitive classifier
        /// </summary>
        [Render(12)]
        public PrimalKind DataType;

        /// <summary>
        /// The encoded literal, possibly an invariant address to a string resource
        /// </summary>
        [Render(22)]
        public SymVal Value;

        /// <summary>
        /// The numeric base interpretation given to the literal
        /// </summary>
        [Render(8)]
        public NumericBaseKind Base;

        /// <summary>
        /// Indicates whether the literal is occluded
        /// </summary>
        public bool Hidden;

        /// <summary>
        /// The meaning of the literal, if available; otherwise empty
        /// </summary>
        public TextBlock Description;

        /// <summary>
        /// A unique identifier
        /// </summary>
        public SymIdentity Identity;

        public object FieldValue;

        [MethodImpl(Inline)]
        public int CompareTo(SymLiteral src)
            => Identity.CompareTo(src.Identity);
    }
}