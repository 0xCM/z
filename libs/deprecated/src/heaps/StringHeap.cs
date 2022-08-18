//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft/.NET Foundation
// License     :  MIT
// Source      : https://github.com/dotnet/runtime/src/libraries/System.Reflection.Metadata
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Reflection.Metadata;
    using System.Runtime.InteropServices;
    using System.Text;

    using static Root;

    partial class SRM
    {
        public struct StringHeap
        {
            internal readonly MemoryBlock Block;

            internal enum VirtualIndex
            {
                System_Runtime_WindowsRuntime,
                System_Runtime,
                System_ObjectModel,
                System_Runtime_WindowsRuntime_UI_Xaml,
                System_Runtime_InteropServices_WindowsRuntime,
                System_Numerics_Vectors,

                Dispose,

                AttributeTargets,
                AttributeUsageAttribute,
                Color,
                CornerRadius,
                DateTimeOffset,
                Duration,
                DurationType,
                EventHandler1,
                EventRegistrationToken,
                Exception,
                GeneratorPosition,
                GridLength,
                GridUnitType,
                ICommand,
                IDictionary2,
                IDisposable,
                IEnumerable,
                IEnumerable1,
                IList,
                IList1,
                INotifyCollectionChanged,
                INotifyPropertyChanged,
                IReadOnlyDictionary2,
                IReadOnlyList1,
                KeyTime,
                KeyValuePair2,
                Matrix,
                Matrix3D,
                Matrix3x2,
                Matrix4x4,
                NotifyCollectionChangedAction,
                NotifyCollectionChangedEventArgs,
                NotifyCollectionChangedEventHandler,
                Nullable1,
                Plane,
                Point,
                PropertyChangedEventArgs,
                PropertyChangedEventHandler,
                Quaternion,
                Rect,
                RepeatBehavior,
                RepeatBehaviorType,
                Size,
                System,
                System_Collections,
                System_Collections_Generic,
                System_Collections_Specialized,
                System_ComponentModel,
                System_Numerics,
                System_Windows_Input,
                Thickness,
                TimeSpan,
                Type,
                Uri,
                Vector2,
                Vector3,
                Vector4,
                Windows_Foundation,
                Windows_UI,
                Windows_UI_Xaml,
                Windows_UI_Xaml_Controls_Primitives,
                Windows_UI_Xaml_Media,
                Windows_UI_Xaml_Media_Animation,
                Windows_UI_Xaml_Media_Media3D,

                Count
            }


            static string[]? s_virtualValues;


            VirtualHeap? _lazyVirtualHeap;


            internal StringHeap(MemoryBlock block, MetadataKind metadataKind)
            {
                _lazyVirtualHeap = null;

                if (s_virtualValues == null && metadataKind != MetadataKind.Ecma335)
                {
                    // Note:
                    // Virtual values shall not contain surrogates, otherwise StartsWith might be inconsistent
                    // when comparing to a text that ends with a high surrogate.

                    var values = new string[(int)VirtualIndex.Count];
                    values[(int)VirtualIndex.System_Runtime_WindowsRuntime] = "System.Runtime.WindowsRuntime";
                    values[(int)VirtualIndex.System_Runtime] = "System.Runtime";
                    values[(int)VirtualIndex.System_ObjectModel] = "System.ObjectModel";
                    values[(int)VirtualIndex.System_Runtime_WindowsRuntime_UI_Xaml] = "System.Runtime.WindowsRuntime.UI.Xaml";
                    values[(int)VirtualIndex.System_Runtime_InteropServices_WindowsRuntime] = "System.Runtime.InteropServices.WindowsRuntime";
                    values[(int)VirtualIndex.System_Numerics_Vectors] = "System.Numerics.Vectors";

                    values[(int)VirtualIndex.Dispose] = "Dispose";

                    values[(int)VirtualIndex.AttributeTargets] = "AttributeTargets";
                    values[(int)VirtualIndex.AttributeUsageAttribute] = "AttributeUsageAttribute";
                    values[(int)VirtualIndex.Color] = "Color";
                    values[(int)VirtualIndex.CornerRadius] = "CornerRadius";
                    values[(int)VirtualIndex.DateTimeOffset] = "DateTimeOffset";
                    values[(int)VirtualIndex.Duration] = "Duration";
                    values[(int)VirtualIndex.DurationType] = "DurationType";
                    values[(int)VirtualIndex.EventHandler1] = "EventHandler`1";
                    values[(int)VirtualIndex.EventRegistrationToken] = "EventRegistrationToken";
                    values[(int)VirtualIndex.Exception] = "Exception";
                    values[(int)VirtualIndex.GeneratorPosition] = "GeneratorPosition";
                    values[(int)VirtualIndex.GridLength] = "GridLength";
                    values[(int)VirtualIndex.GridUnitType] = "GridUnitType";
                    values[(int)VirtualIndex.ICommand] = "ICommand";
                    values[(int)VirtualIndex.IDictionary2] = "IDictionary`2";
                    values[(int)VirtualIndex.IDisposable] = "IDisposable";
                    values[(int)VirtualIndex.IEnumerable] = "IEnumerable";
                    values[(int)VirtualIndex.IEnumerable1] = "IEnumerable`1";
                    values[(int)VirtualIndex.IList] = "IList";
                    values[(int)VirtualIndex.IList1] = "IList`1";
                    values[(int)VirtualIndex.INotifyCollectionChanged] = "INotifyCollectionChanged";
                    values[(int)VirtualIndex.INotifyPropertyChanged] = "INotifyPropertyChanged";
                    values[(int)VirtualIndex.IReadOnlyDictionary2] = "IReadOnlyDictionary`2";
                    values[(int)VirtualIndex.IReadOnlyList1] = "IReadOnlyList`1";
                    values[(int)VirtualIndex.KeyTime] = "KeyTime";
                    values[(int)VirtualIndex.KeyValuePair2] = "KeyValuePair`2";
                    values[(int)VirtualIndex.Matrix] = "Matrix";
                    values[(int)VirtualIndex.Matrix3D] = "Matrix3D";
                    values[(int)VirtualIndex.Matrix3x2] = "Matrix3x2";
                    values[(int)VirtualIndex.Matrix4x4] = "Matrix4x4";
                    values[(int)VirtualIndex.NotifyCollectionChangedAction] = "NotifyCollectionChangedAction";
                    values[(int)VirtualIndex.NotifyCollectionChangedEventArgs] = "NotifyCollectionChangedEventArgs";
                    values[(int)VirtualIndex.NotifyCollectionChangedEventHandler] = "NotifyCollectionChangedEventHandler";
                    values[(int)VirtualIndex.Nullable1] = "Nullable`1";
                    values[(int)VirtualIndex.Plane] = "Plane";
                    values[(int)VirtualIndex.Point] = "Point";
                    values[(int)VirtualIndex.PropertyChangedEventArgs] = "PropertyChangedEventArgs";
                    values[(int)VirtualIndex.PropertyChangedEventHandler] = "PropertyChangedEventHandler";
                    values[(int)VirtualIndex.Quaternion] = "Quaternion";
                    values[(int)VirtualIndex.Rect] = "Rect";
                    values[(int)VirtualIndex.RepeatBehavior] = "RepeatBehavior";
                    values[(int)VirtualIndex.RepeatBehaviorType] = "RepeatBehaviorType";
                    values[(int)VirtualIndex.Size] = "Size";
                    values[(int)VirtualIndex.System] = "System";
                    values[(int)VirtualIndex.System_Collections] = "System.Collections";
                    values[(int)VirtualIndex.System_Collections_Generic] = "System.Collections.Generic";
                    values[(int)VirtualIndex.System_Collections_Specialized] = "System.Collections.Specialized";
                    values[(int)VirtualIndex.System_ComponentModel] = "System.ComponentModel";
                    values[(int)VirtualIndex.System_Numerics] = "System.Numerics";
                    values[(int)VirtualIndex.System_Windows_Input] = "System.Windows.Input";
                    values[(int)VirtualIndex.Thickness] = "Thickness";
                    values[(int)VirtualIndex.TimeSpan] = "TimeSpan";
                    values[(int)VirtualIndex.Type] = "Type";
                    values[(int)VirtualIndex.Uri] = "Uri";
                    values[(int)VirtualIndex.Vector2] = "Vector2";
                    values[(int)VirtualIndex.Vector3] = "Vector3";
                    values[(int)VirtualIndex.Vector4] = "Vector4";
                    values[(int)VirtualIndex.Windows_Foundation] = "Windows.Foundation";
                    values[(int)VirtualIndex.Windows_UI] = "Windows.UI";
                    values[(int)VirtualIndex.Windows_UI_Xaml] = "Windows.UI.Xaml";
                    values[(int)VirtualIndex.Windows_UI_Xaml_Controls_Primitives] = "Windows.UI.Xaml.Controls.Primitives";
                    values[(int)VirtualIndex.Windows_UI_Xaml_Media] = "Windows.UI.Xaml.Media";
                    values[(int)VirtualIndex.Windows_UI_Xaml_Media_Animation] = "Windows.UI.Xaml.Media.Animation";
                    values[(int)VirtualIndex.Windows_UI_Xaml_Media_Media3D] = "Windows.UI.Xaml.Media.Media3D";

                    s_virtualValues = values;
                    AssertFilled();
                }

                Block = TrimEnd(block);
            }

            [Conditional("DEBUG")]
            static void AssertFilled()
            {
                for (int i = 0; i < s_virtualValues!.Length; i++)
                {
                    Debug.Assert(s_virtualValues[i] != null, "Missing virtual value for VirtualIndex." + (VirtualIndex)i);
                }
            }

            // Trims the alignment padding of the heap.
            // See StgStringPool::InitOnMem in ndp\clr\src\Utilcode\StgPool.cpp.

            // This is especially important for EnC.
            static MemoryBlock TrimEnd(MemoryBlock block)
            {
                if (block.Length == 0)
                    return block;

                int i = block.Length - 1;
                while (i >= 0 && block.PeekByte(i) == 0)
                    i--;

                // this shouldn't happen in valid metadata:
                if (i == block.Length - 1)
                    return block;

                // +1 for terminating \0
                return block.GetMemoryBlockAt(0, i + 2);
            }

            public string GetString(StringHandle handle, MetadataStringDecoder utf8Decoder)
                => handle.IsVirtual() ? GetVirtualHandleString(handle, utf8Decoder) : GetNonVirtualString(handle, utf8Decoder, prefixOpt: null);


            internal static string GetVirtualString(VirtualIndex index)
                => s_virtualValues![(int)index];

            string GetNonVirtualString(StringHandle handle, MetadataStringDecoder utf8Decoder, byte[]? prefixOpt)
            {
                Debug.Assert(handle.StringKind() != StringKind.Virtual);

                int bytesRead;
                char otherTerminator = handle.StringKind() == StringKind.DotTerminated ? '.' : '\0';
                return Block.PeekUtf8NullTerminated(handle.GetHeapOffset(), prefixOpt, utf8Decoder, out bytesRead, otherTerminator);
            }

            unsafe MemoryBlock GetNonVirtualStringMemoryBlock(StringHandle handle)
            {
                Debug.Assert(handle.StringKind() != StringKind.Virtual);

                int bytesRead;
                char otherTerminator = handle.StringKind() == StringKind.DotTerminated ? '.' : '\0';
                int offset = handle.GetHeapOffset();
                int length = Block.GetUtf8NullTerminatedLength(offset, out bytesRead, otherTerminator);
                return new MemoryBlock(Block.Pointer + offset, length);
            }

            unsafe byte[] GetNonVirtualStringBytes(StringHandle handle, byte[] prefix)
            {
                Debug.Assert(handle.StringKind() != StringKind.Virtual);

                var block = GetNonVirtualStringMemoryBlock(handle);
                var bytes = new byte[prefix.Length + block.Length];
                Buffer.BlockCopy(prefix, 0, bytes, 0, prefix.Length);
                Marshal.Copy((IntPtr)block.Pointer, bytes, prefix.Length, block.Length);
                return bytes;
            }

            string GetVirtualHandleString(StringHandle handle, MetadataStringDecoder utf8Decoder)
            {
                Debug.Assert(handle.IsVirtual());

                return handle.StringKind() switch
                {
                    StringKind.Virtual => GetVirtualString(handle.GetVirtualIndex()),
                    StringKind.WinRTPrefixed => GetNonVirtualString(handle, utf8Decoder, BlobReader.WinRTPrefix),
                    _ => throw ExceptionUtilities.UnexpectedValue(handle.StringKind()),
                };
            }

            MemoryBlock GetVirtualHandleMemoryBlock(StringHandle handle)
            {
                Debug.Assert(handle.IsVirtual());
                var heap = VirtualHeap.GetOrCreateVirtualHeap(ref _lazyVirtualHeap);

                lock (heap)
                {
                    if (!heap.TryGetMemoryBlock(handle.Raw(), out var block))
                    {
                        byte[] bytes = handle.StringKind() switch
                        {
                            StringKind.Virtual => Encoding.UTF8.GetBytes(GetVirtualString(handle.GetVirtualIndex())),
                            StringKind.WinRTPrefixed => GetNonVirtualStringBytes(handle, BlobReader.WinRTPrefix),
                            _ => throw ExceptionUtilities.UnexpectedValue(handle.StringKind()),
                        };
                        block = heap.AddBlob(handle.Raw(), bytes);
                    }

                    return block;
                }
            }

            internal bool Equals(StringHandle handle, string value, MetadataStringDecoder utf8Decoder, bool ignoreCase)
            {
                Debug.Assert(value != null);

                if (handle.IsVirtual())
                {
                    // TODO: This can allocate unnecessarily for <WinRT> prefixed handles.
                    return string.Equals(GetString(handle, utf8Decoder), value, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
                }

                if (handle.IsNil)
                {
                    return value.Length == 0;
                }

                char otherTerminator = handle.StringKind() == StringKind.DotTerminated ? '.' : '\0';
                return this.Block.Utf8NullTerminatedEquals(handle.GetHeapOffset(), value, utf8Decoder, otherTerminator, ignoreCase);
            }

            internal bool StartsWith(StringHandle handle, string value, MetadataStringDecoder utf8Decoder, bool ignoreCase)
            {
                Debug.Assert(value != null);

                if (handle.IsVirtual())
                {
                    // TODO: This can allocate unnecessarily for <WinRT> prefixed handles.
                    return GetString(handle, utf8Decoder).StartsWith(value, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
                }

                if (handle.IsNil)
                {
                    return value.Length == 0;
                }

                char otherTerminator = handle.StringKind() == StringKind.DotTerminated ? '.' : '\0';
                return this.Block.Utf8NullTerminatedStartsWith(handle.GetHeapOffset(), value, utf8Decoder, otherTerminator, ignoreCase);
            }

            /// <summary>
            /// Returns true if the given raw (non-virtual) handle represents the same string as given ASCII string.
            /// </summary>
            public bool EqualsRaw(StringHandle rawHandle, string asciiString)
            {
                // Debug.Assert(!rawHandle.IsVirtual);
                // Debug.Assert(rawHandle.StringKind != StringKind.DotTerminated, "Not supported");
                return Block.CompareUtf8NullTerminatedStringWithAsciiString(rawHandle.GetHeapOffset(), asciiString) == 0;
            }

            /// <summary>
            /// Returns the heap index of the given ASCII character or -1 if not found prior null terminator or end of heap.
            /// </summary>
            internal int IndexOfRaw(int startIndex, char asciiChar)
            {
                Debug.Assert(asciiChar != 0 && asciiChar <= 0x7f);
                return Block.Utf8NullTerminatedOffsetOfAsciiChar(startIndex, asciiChar);
            }

            /// <summary>
            /// Returns true if the given raw (non-virtual) handle represents a string that starts with given ASCII prefix.
            /// </summary>
            public bool StartsWithRaw(StringHandle rawHandle, string asciiPrefix)
            {
                // Debug.Assert(!rawHandle.IsVirtual);
                // Debug.Assert(rawHandle.StringKind != StringKind.DotTerminated, "Not supported");
                return Block.Utf8NullTerminatedStringStartsWithAsciiPrefix(rawHandle.GetHeapOffset(), asciiPrefix);
            }

            /// <summary>
            /// Equivalent to Array.BinarySearch, searches for given raw (non-virtual) handle in given array of ASCII strings.
            /// </summary>
            public int BinarySearchRaw(string[] asciiKeys, StringHandle rawHandle)
            {
                // Debug.Assert(!rawHandle.IsVirtual);
                // Debug.Assert(rawHandle.StringKind != StringKind.DotTerminated, "Not supported");
                return Block.BinarySearch(asciiKeys, rawHandle.GetHeapOffset());
            }
        }
    }
}