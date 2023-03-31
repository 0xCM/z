// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Internal.Runtime
{
    /// <summary>
    /// These are flag values that are rarely set for types. If any of them are set then an optional field will
    /// be associated with the MethodTable to represent them.
    /// </summary>
    [Flags]
    public enum EETypeRareFlags : int
    {
        /// <summary>
        /// This type requires 8-byte alignment for its fields on certain platforms (only ARM currently).
        /// </summary>
        RequiresAlign8Flag = 0x00000001,

        // UNUSED1 = 0x00000002,

        // UNUSED = 0x00000004,

        // UNUSED = 0x00000008,

        // UNUSED = 0x00000010,

        /// <summary>
        /// This MethodTable has a Class Constructor
        /// </summary>
        HasCctorFlag = 0x0000020,

        // UNUSED2 = 0x00000040,

        // UNUSED = 0x00000080,

        /// <summary>
        /// This MethodTable represents a structure that is an HFA
        /// </summary>
        IsHFAFlag = 0x00000100,

        /// <summary>
        /// This MethodTable has sealed vtable entries
        /// </summary>
        HasSealedVTableEntriesFlag = 0x00000200,

        /// <summary>
        /// This dynamically created types has gc statics
        /// </summary>
        IsDynamicTypeWithGcStatics = 0x00000400,

        /// <summary>
        /// This dynamically created types has non gc statics
        /// </summary>
        IsDynamicTypeWithNonGcStatics = 0x00000800,

        /// <summary>
        /// This dynamically created types has thread statics
        /// </summary>
        IsDynamicTypeWithThreadStatics = 0x00001000,

        // UNUSED = 0x00002000,

        /// <summary>
        /// This MethodTable is an abstract class (but not an interface).
        /// </summary>
        IsAbstractClassFlag = 0x00004000,

        /// <summary>
        /// This MethodTable is for a Byref-like class (TypedReference, Span&lt;T&gt;,...)
        /// </summary>
        IsByRefLikeFlag = 0x00008000,
    }
}
