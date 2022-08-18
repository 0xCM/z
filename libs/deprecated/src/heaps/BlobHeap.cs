//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft/.NET Foundation
// License     :  MIT
// Source      : https://github.com/dotnet/runtime/src/libraries/System.Reflection.Metadata
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection.Metadata;

    using static Root;

    partial class SRM
    {
        public struct BlobHeap
        {
            internal enum VirtualIndex : byte
            {
                Nil,

                // B0 3F 5F 7F 11 D5 0A 3A
                ContractPublicKeyToken,

                // 00, 24, 00, 00, 04, ...
                ContractPublicKey,

                // Template for projected AttributeUsage attribute blob
                AttributeUsage_AllowSingle,

                // Template for projected AttributeUsage attribute blob with AllowMultiple=true
                AttributeUsage_AllowMultiple,

                Count
            }

            [MethodImpl(Inline), Op]
            public static BlobHandle HandleFromOffset(int heapOffset)
                => core.@as<int, BlobHandle>(heapOffset);

            private static byte[][]? s_virtualValues;

            internal readonly MemoryBlock Block;

            public MemoryAddress BaseAddress
            {
                [MethodImpl(Inline), Op]
                get => Block.BaseAddress;
            }

            VirtualHeap? _lazyVirtualHeap;

            internal MemoryBlock GetMemoryBlock(BlobHandle handle)
            {
                if (handle.IsVirtual())
                {
                    return GetVirtualHandleMemoryBlock(handle);
                }

                int offset, size;
                Block.PeekHeapValueOffsetAndSize(handle.GetHeapOffset(), out offset, out size);
                return Block.GetMemoryBlockAt(offset, size);
            }

            private MemoryBlock GetVirtualHandleMemoryBlock(BlobHandle handle)
            {
                var heap = VirtualHeap.GetOrCreateVirtualHeap(ref _lazyVirtualHeap);

                lock (heap)
                {
                    if (!heap.TryGetMemoryBlock(handle.Raw(), out var block))
                    {
                        block = heap.AddBlob(handle.Raw(), GetVirtualBlobBytes(handle, unique: false));
                    }

                    return block;
                }
            }

            internal BlobReader GetBlobReader(BlobHandle handle)
            {
                return new BlobReader(GetMemoryBlock(handle));
            }

            public BlobHandle GetNextHandle(BlobHandle handle)
            {
                if (handle.IsVirtual())
                {
                    return default(BlobHandle);
                }

                int offset, size;
                if (!Block.PeekHeapValueOffsetAndSize(handle.GetHeapOffset(), out offset, out size))
                {
                    return default(BlobHandle);
                }

                int nextIndex = offset + size;
                if (nextIndex >= Block.Length)
                {
                    return default(BlobHandle);
                }

                return BlobHeap.HandleFromOffset(nextIndex);
            }

            internal byte[] GetVirtualBlobBytes(BlobHandle handle, bool unique)
            {
                VirtualIndex index = handle.GetVirtualIndex();
                byte[] result = s_virtualValues![(int)index];

                switch (index)
                {
                    case VirtualIndex.AttributeUsage_AllowMultiple:
                    case VirtualIndex.AttributeUsage_AllowSingle:
                        result = (byte[])result.Clone();
                        handle.SubstituteTemplateParameters(result);
                        break;

                    default:
                        if (unique)
                        {
                            result = (byte[])result.Clone();
                        }
                        break;
                }

                return result;
            }

            public string GetDocumentName(DocumentNameBlobHandle handle)
            {
                var blobReader = GetBlobReader(handle);

                // Spec: separator is an ASCII encoded character in range [0x01, 0x7F], or byte 0 to represent an empty separator.
                int separator = blobReader.ReadByte();
                if (separator > 0x7f)
                {
                    //throw new BadImageFormatException(SR.Format(SR.InvalidDocumentName, separator));
                }

                // var pooledBuilder = PooledStringBuilder.GetInstance();
                // var builder = pooledBuilder.Builder;
                var builder = text.build();
                bool isFirstPart = true;
                while (blobReader.RemainingBytes > 0)
                {
                    if (separator != 0 && !isFirstPart)
                    {
                        builder.Append((char)separator);
                    }

                    var partReader = GetBlobReader(blobReader.ReadBlobHandle());

                    builder.Append(partReader.ReadUTF8(partReader.Length));
                    isFirstPart = false;
                }

                return builder.ToString();
            }

            internal bool DocumentNameEquals(DocumentNameBlobHandle handle, string other, bool ignoreCase)
            {
                var blobReader = GetBlobReader(handle);

                // Spec: separator is an ASCII encoded character in range [0x01, 0x7F], or byte 0 to represent an empty separator.
                int separator = blobReader.ReadByte();
                if (separator > 0x7f)
                {
                    return false;
                }

                int ignoreCaseMask = StringUtils.IgnoreCaseMask(ignoreCase);
                int otherIndex = 0;
                bool isFirstPart = true;
                while (blobReader.RemainingBytes > 0)
                {
                    if (separator != 0 && !isFirstPart)
                    {
                        if (otherIndex == other.Length || !StringUtils.IsEqualAscii(other[otherIndex], separator, ignoreCaseMask))
                        {
                            return false;
                        }

                        otherIndex++;
                    }

                    var partBlock = GetMemoryBlock(blobReader.ReadBlobHandle());

                    int firstDifferenceIndex;
                    var result = partBlock.Utf8NullTerminatedFastCompare(0, other, otherIndex, out firstDifferenceIndex, terminator: '\0', ignoreCase: ignoreCase);
                    if (result == MemoryBlock.FastComparisonResult.Inconclusive)
                    {
                        return GetDocumentName(handle).Equals(other, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
                    }

                    if (result == MemoryBlock.FastComparisonResult.Unequal ||
                        firstDifferenceIndex - otherIndex != partBlock.Length)
                    {
                        return false;
                    }

                    otherIndex = firstDifferenceIndex;
                    isFirstPart = false;
                }

                return otherIndex == other.Length;
            }
        }
    }
}