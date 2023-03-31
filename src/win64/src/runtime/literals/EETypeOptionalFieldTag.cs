// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Internal.Runtime
{
    public enum EETypeOptionalFieldTag : byte
    {
        /// <summary>
        /// Extra <c>MethodTable</c> flags not commonly used such as HasClassConstructor
        /// </summary>
        RareFlags,

        /// <summary>
        /// Index of the dispatch map pointer in the DispatchMap table
        /// </summary>
        DispatchMap,

        /// <summary>
        /// Padding added to a value type when allocated on the GC heap
        /// </summary>
        ValueTypeFieldPadding,

        /// <summary>
        /// Offset in Nullable&lt;T&gt; of the value field
        /// </summary>
        NullableValueOffset,

        // Number of field types we support
        Count
    }
}
