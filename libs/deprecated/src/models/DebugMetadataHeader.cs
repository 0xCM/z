//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft/.NET Foundation
// License     :  MIT
// Source      : https://github.com/dotnet/runtime/src/libraries/System.Reflection.Metadata
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Reflection.Metadata;

    using static Root;
    using static core;

    partial class SRM
    {
        public readonly struct DebugMetadataHeader
        {
            public byte[] Id {get;}

            public MethodDefinitionHandle EntryPoint {get;}

            /// <summary>
            /// Gets the offset (in bytes) from the start of the metadata blob to the start of the <see cref="Id"/> blob.
            /// </summary>
            public int IdStartOffset {get;}

            [MethodImpl(Inline)]
            public DebugMetadataHeader(byte[] id, MethodDefinitionHandle entryPoint, int idStartOffset)
            {
                Id = id;
                EntryPoint = entryPoint;
                IdStartOffset = idStartOffset;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Id == null || Id.Length == 0;
            }

            public static DebugMetadataHeader Empty
                => new DebugMetadataHeader(sys.empty<byte>(), default, 0);
        }
    }
}