//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SymLiteral<K> : IComparableRecord<SymLiteral<K>>
    {
        /// <summary>
        /// The component that defines the literal
        /// </summary>
        [Render(24)]
        public ClrAssemblyName Component;

        /// <summary>
        /// The literal's declaring type
        /// </summary>
        [Render(32)]
        public string Type;

        /// <summary>
        /// A literal classifier
        /// </summary>
        [Render(16)]
        public @string Group;

        /// <summary>
        /// The token size
        /// </summary>
        [Render(12)]
        public DataSize Size;

        /// <summary>
        /// The container-relative declaration order of the literal
        /// </summary>
        [Render(10)]
        public uint Index;

        /// <summary>
        /// The literal name
        /// </summary>
        [Render(64)]
        public string Name;

        /// <summary>
        /// The symbol, if so attributed, otherwise, the identifier
        /// </summary>
        [Render(64)]
        public SymExpr<K> Symbol;

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
        /// Indicates whether the literal is occluded
        /// </summary>
        [Render(10)]
        public bool Hidden;

        /// <summary>
        /// The meaning of the literal, if available; otherwise empty
        /// </summary>
        [Render(48)]
        public TextBlock Description;

        /// <summary>
        /// A unique identifier
        /// </summary>
        [Render(1)]
        public SymIdentity Identity;

        [MethodImpl(Inline)]
        public int CompareTo(SymLiteral<K> src)
            => Identity.CompareTo(src.Identity);
    }
}