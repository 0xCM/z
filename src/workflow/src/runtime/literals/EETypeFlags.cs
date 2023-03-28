// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Internal.Runtime
{
    /// <summary>
    /// Represents the flags stored in the <c>_usFlags</c> field of a <c>System.Runtime.MethodTable</c>.
    /// </summary>
    [Flags]
    public enum EETypeFlags : uint
    {
        /// <summary>
        /// There are four kinds of EETypes, defined in <c>Kinds</c>.
        /// </summary>
        EETypeKindMask = 0x00030000,

        /// <summary>
        /// This flag is set when m_RelatedType is in a different module.  In that case, _pRelatedType
        /// actually points to an IAT slot in this module, which then points to the desired MethodTable in the
        /// other module.  In other words, there is an extra indirection through m_RelatedType to get to
        /// the related type in the other module.  When this flag is set, it is expected that you use the
        /// "_ppXxxxViaIAT" member of the RelatedTypeUnion for the particular related type you're
        /// accessing.
        /// </summary>
        RelatedTypeViaIATFlag = 0x00040000,

        /// <summary>
        /// This type was dynamically allocated at runtime.
        /// </summary>
        IsDynamicTypeFlag = 0x00080000,

        /// <summary>
        /// This MethodTable represents a type which requires finalization.
        /// </summary>
        HasFinalizerFlag = 0x00100000,

        /// <summary>
        /// This type contain GC pointers.
        /// </summary>
        HasPointersFlag = 0x00200000,

        /// <summary>
        /// This type implements IDynamicInterfaceCastable to allow dynamic resolution of interface casts.
        /// </summary>
        IDynamicInterfaceCastableFlag = 0x00400000,

        /// <summary>
        /// This type is generic and one or more of its type parameters is co- or contra-variant. This
        /// only applies to interface and delegate types.
        /// </summary>
        GenericVarianceFlag = 0x00800000,

        /// <summary>
        /// This type has optional fields present.
        /// </summary>
        OptionalFieldsFlag = 0x01000000,

        /// <summary>
        /// This type is generic.
        /// </summary>
        IsGenericFlag = 0x02000000,

        /// <summary>
        /// We are storing a EETypeElementType in the upper bits for unboxing enums.
        /// </summary>
        ElementTypeMask = 0x7C000000,

        ElementTypeShift = 26,

        /// <summary>
        /// Single mark to check TypeKind and two flags. When non-zero, casting is more complicated.
        /// </summary>
        ComplexCastingMask = EETypeKindMask | RelatedTypeViaIATFlag | GenericVarianceFlag,

        /// <summary>
        /// The _usComponentSize is a number (not holding FlagsEx).
        /// </summary>
        HasComponentSizeFlag = 0x80000000,
    };
}
