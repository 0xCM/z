//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft/.NET Foundation
// License     :  MIT
// Source      : https://github.com/dotnet/runtime/src/libraries/System.Reflection.Metadata
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    
    using System.Diagnostics.CodeAnalysis;

    public partial class ClrEcma
    {
        [Flags]
        public enum TypeDefTreatment : byte
        {
            None = 0,

            KindMask = 0x0f,
            NormalNonAttribute = 1,
            NormalAttribute = 2,
            UnmangleWinRTName = 3,
            PrefixWinRTName = 4,
            RedirectedToClrType = 5,
            RedirectedToClrAttribute = 6,

            MarkAbstractFlag = 0x10,
            MarkInternalFlag = 0x20
        }

        public enum TypeRefTreatment : byte
        {
            None = 0,
            SystemDelegate = 1,
            SystemAttribute = 2,

            // RowId is an index to the projection info table.
            UseProjectionInfo = 3,
        }

        public enum TypeRefSignatureTreatment : byte
        {
            None = 0,
            ProjectedToClass = 1,
            ProjectedToValueType = 2,
        }

        [Flags]
        public enum MethodDefTreatment : byte
        {
            None = 0,

            KindMask = 0x0f,
            Other = 1,
            DelegateMethod = 2,
            AttributeMethod = 3,
            InterfaceMethod = 4,
            Implementation = 5,
            HiddenInterfaceImplementation = 6,
            DisposeMethod = 7,

            MarkAbstractFlag = 0x10,
            MarkPublicFlag = 0x20,
            // TODO: In the latest Adapter.cpp sources this seems to be no longer applicable (confirm?)
            // MarkSpecialName = 0x40
        }

        [Flags]
        public enum FieldDefTreatment : byte
        {
            None = 0,
            EnumValue = 1,
        }

        [Flags]
        public enum MemberRefTreatment : byte
        {
            None = 0,
            Dispose = 1,
        }

        [Flags]
        public enum CustomAttributeTreatment : byte
        {
            None = 0,
            WinMD = 1,
        }

        [Flags]
        public enum CustomAttributeValueTreatment : byte
        {
            None = 0,
            AttributeUsageAllowSingle = 1,
            AttributeUsageAllowMultiple = 2,
            AttributeUsageVersionAttribute = 3,
            AttributeUsageDeprecatedAttribute = 4,
        }

        public enum StringKind : byte
        {
            Plain = (byte)(StringHandleType.String >> HeapHandleType.OffsetBitCount),
            Virtual = (byte)(StringHandleType.VirtualString >> HeapHandleType.OffsetBitCount),
            WinRTPrefixed = (byte)(StringHandleType.WinRTPrefixedString >> HeapHandleType.OffsetBitCount),
            DotTerminated = (byte)(StringHandleType.DotTerminatedString >> HeapHandleType.OffsetBitCount),
        }

        public static class StringHandleType
        {
            // The 3 high bits above the offset that specify the full string type (including virtual bit)
            public const uint TypeMask = ~(HeapHandleType.OffsetMask);

            // The string type bits excluding the virtual bit.
            public const uint NonVirtualTypeMask = TypeMask & ~(HeapHandleType.VirtualBit);

            // NUL-terminated UTF8 string on a #String heap.
            public const uint String = (0 << HeapHandleType.OffsetBitCount);

            // String on #String heap whose terminator is NUL and '.', whichever comes first.
            public const uint DotTerminatedString = (1 << HeapHandleType.OffsetBitCount);

            // Reserved values that can be used for future strings:
            public const uint ReservedString1 = (2 << HeapHandleType.OffsetBitCount);
            public const uint ReservedString2 = (3 << HeapHandleType.OffsetBitCount);

            // Virtual string identified by a virtual index
            public const uint VirtualString = HeapHandleType.VirtualBit | (0 << HeapHandleType.OffsetBitCount);

            // Virtual string whose value is a "<WinRT>" prefixed string found at the specified heap offset.
            public const uint WinRTPrefixedString = HeapHandleType.VirtualBit | (1 << HeapHandleType.OffsetBitCount);

            // Reserved virtual strings that can be used in future:
            public const uint ReservedVirtualString1 = HeapHandleType.VirtualBit | (2 << HeapHandleType.OffsetBitCount);
            public const uint ReservedVirtualString2 = HeapHandleType.VirtualBit | (3 << HeapHandleType.OffsetBitCount);
        }

        public static class HeapHandleType
        {
            // Heap offset values are limited to 29 bits (max compressed integer)
            public const int OffsetBitCount = 29;
            public const uint OffsetMask = (1 << OffsetBitCount) - 1;
            public const uint VirtualBit = 0x80000000;

            public static bool IsValidHeapOffset(uint offset)
            {
                return (offset & ~OffsetMask) == 0;
            }
        }


        /// <summary>
        /// These constants are all in the byte range and apply to the interpretation of <see cref="Handle.VType"/>,
        /// </summary>
        public static class HandleType
        {
            public const uint Module = (uint)TableIndex.Module;
            public const uint TypeRef = (uint)TableIndex.TypeRef;
            public const uint TypeDef = (uint)TableIndex.TypeDef;
            public const uint FieldDef = (uint)TableIndex.Field;
            public const uint MethodDef = (uint)TableIndex.MethodDef;
            public const uint ParamDef = (uint)TableIndex.Param;
            public const uint InterfaceImpl = (uint)TableIndex.InterfaceImpl;
            public const uint MemberRef = (uint)TableIndex.MemberRef;
            public const uint Constant = (uint)TableIndex.Constant;
            public const uint CustomAttribute = (uint)TableIndex.CustomAttribute;
            public const uint DeclSecurity = (uint)TableIndex.DeclSecurity;
            public const uint Signature = (uint)TableIndex.StandAloneSig;
            public const uint EventMap = (uint)TableIndex.EventMap;
            public const uint Event = (uint)TableIndex.Event;
            public const uint PropertyMap = (uint)TableIndex.PropertyMap;
            public const uint Property = (uint)TableIndex.Property;
            public const uint MethodSemantics = (uint)TableIndex.MethodSemantics;
            public const uint MethodImpl = (uint)TableIndex.MethodImpl;
            public const uint ModuleRef = (uint)TableIndex.ModuleRef;
            public const uint TypeSpec = (uint)TableIndex.TypeSpec;
            public const uint Assembly = (uint)TableIndex.Assembly;
            public const uint AssemblyRef = (uint)TableIndex.AssemblyRef;
            public const uint File = (uint)TableIndex.File;
            public const uint ExportedType = (uint)TableIndex.ExportedType;
            public const uint ManifestResource = (uint)TableIndex.ManifestResource;
            public const uint NestedClass = (uint)TableIndex.NestedClass;
            public const uint GenericParam = (uint)TableIndex.GenericParam;
            public const uint MethodSpec = (uint)TableIndex.MethodSpec;
            public const uint GenericParamConstraint = (uint)TableIndex.GenericParamConstraint;

            // debug tables:
            public const uint Document = (uint)TableIndex.Document;
            public const uint MethodDebugInformation = (uint)TableIndex.MethodDebugInformation;
            public const uint LocalScope = (uint)TableIndex.LocalScope;
            public const uint LocalVariable = (uint)TableIndex.LocalVariable;
            public const uint LocalConstant = (uint)TableIndex.LocalConstant;
            public const uint ImportScope = (uint)TableIndex.ImportScope;
            public const uint AsyncMethod = (uint)TableIndex.StateMachineMethod;
            public const uint CustomDebugInformation = (uint)TableIndex.CustomDebugInformation;

            public const uint UserString = 0x70;     // #UserString heap

            // The following values never appear in a token stored in metadata,
            // they are just helper values to identify the type of a handle.
            // Note, however, that even though they do not come from the spec,
            // they are surfaced as public constants via HandleKind enum and
            // therefore cannot change!

            public const uint Blob = 0x71;        // #Blob heap
            public const uint Guid = 0x72;        // #Guid heap

            // #String heap and its modifications
            //
            // Multiple values are reserved for string handles so that we can encode special
            // handling with more than just the virtual bit. See StringHandleType for how
            // the two extra bits are actually interpreted. The extra String1,2,3 values here are
            // not used directly, but serve as a reminder that they are not available for use
            // by another handle type.
            public const uint String  = 0x78;
            public const uint String1 = 0x79;
            public const uint String2 = 0x7a;
            public const uint String3 = 0x7b;

            // Namespace handles also have offsets into the #String heap (when non-virtual)
            // to their full name. However, this is an implementation detail and they are
            // surfaced with first-class HandleKind.Namespace and strongly-typed NamespaceHandle.
            public const uint Namespace = 0x7c;

            public const uint HeapMask = 0x70;
            public const uint TypeMask = 0x7F;

            /// <summary>
            /// Use the highest bit to mark tokens that are virtual (synthesized).
            /// We create virtual tokens to represent projected WinMD entities.
            /// </summary>
            public const uint VirtualBit = 0x80;

            /// <summary>
            /// In the case of string handles, the two lower bits that (in addition to the
            /// virtual bit not included in this mask) encode how to obtain the string value.
            /// </summary>
            public const uint NonVirtualStringTypeMask = 0x03;
        }

        public static class TokenTypeIds
        {
            public const uint Module = HandleType.Module << RowIdBitCount;
            public const uint TypeRef = HandleType.TypeRef << RowIdBitCount;
            public const uint TypeDef = HandleType.TypeDef << RowIdBitCount;
            public const uint FieldDef = HandleType.FieldDef << RowIdBitCount;
            public const uint MethodDef = HandleType.MethodDef << RowIdBitCount;
            public const uint ParamDef = HandleType.ParamDef << RowIdBitCount;
            public const uint InterfaceImpl = HandleType.InterfaceImpl << RowIdBitCount;
            public const uint MemberRef = HandleType.MemberRef << RowIdBitCount;
            public const uint Constant = HandleType.Constant << RowIdBitCount;
            public const uint CustomAttribute = HandleType.CustomAttribute << RowIdBitCount;
            public const uint DeclSecurity = HandleType.DeclSecurity << RowIdBitCount;
            public const uint Signature = HandleType.Signature << RowIdBitCount;
            public const uint EventMap = HandleType.EventMap << RowIdBitCount;
            public const uint Event = HandleType.Event << RowIdBitCount;
            public const uint PropertyMap = HandleType.PropertyMap << RowIdBitCount;
            public const uint Property = HandleType.Property << RowIdBitCount;
            public const uint MethodSemantics = HandleType.MethodSemantics << RowIdBitCount;
            public const uint MethodImpl = HandleType.MethodImpl << RowIdBitCount;
            public const uint ModuleRef = HandleType.ModuleRef << RowIdBitCount;
            public const uint TypeSpec = HandleType.TypeSpec << RowIdBitCount;
            public const uint Assembly = HandleType.Assembly << RowIdBitCount;
            public const uint AssemblyRef = HandleType.AssemblyRef << RowIdBitCount;
            public const uint File = HandleType.File << RowIdBitCount;
            public const uint ExportedType = HandleType.ExportedType << RowIdBitCount;
            public const uint ManifestResource = HandleType.ManifestResource << RowIdBitCount;
            public const uint NestedClass = HandleType.NestedClass << RowIdBitCount;
            public const uint GenericParam = HandleType.GenericParam << RowIdBitCount;
            public const uint MethodSpec = HandleType.MethodSpec << RowIdBitCount;
            public const uint GenericParamConstraint = HandleType.GenericParamConstraint << RowIdBitCount;

            // debug tables:
            public const uint Document = HandleType.Document << RowIdBitCount;
            public const uint MethodDebugInformation = HandleType.MethodDebugInformation << RowIdBitCount;
            public const uint LocalScope = HandleType.LocalScope << RowIdBitCount;
            public const uint LocalVariable = HandleType.LocalVariable << RowIdBitCount;
            public const uint LocalConstant = HandleType.LocalConstant << RowIdBitCount;
            public const uint ImportScope = HandleType.ImportScope << RowIdBitCount;
            public const uint AsyncMethod = HandleType.AsyncMethod << RowIdBitCount;
            public const uint CustomDebugInformation = HandleType.CustomDebugInformation << RowIdBitCount;

            public const uint UserString = HandleType.UserString << RowIdBitCount;

            public const int RowIdBitCount = 24;
            public const uint RIDMask = (1 << RowIdBitCount) - 1;
            public const uint TypeMask = HandleType.TypeMask << RowIdBitCount;

            /// <summary>
            /// Use the highest bit to mark tokens that are virtual (synthesized).
            /// We create virtual tokens to represent projected WinMD entities.
            /// </summary>
            public const uint VirtualBit = 0x80000000;

            /// <summary>
            /// Returns true if the token value can escape the metadata reader.
            /// We don't allow virtual tokens and heap tokens other than UserString to escape
            /// since the token type ids are public to the reader and not specified by ECMA spec.
            ///
            /// Spec (Partition III, 1.9 Metadata tokens):
            /// Many CIL instructions are followed by a "metadata token". This is a 4-byte value, that specifies a row in a
            /// metadata table, or a starting byte offset in the User String heap.
            ///
            /// For example, a value of 0x02 specifies the TypeDef table; a value of 0x70 specifies the User
            /// String heap.The value corresponds to the number assigned to that metadata table (see Partition II for the full
            /// list of tables) or to 0x70 for the User String heap.The least-significant 3 bytes specify the target row within that
            /// metadata table, or starting byte offset within the User String heap.
            /// </summary>
            public static bool IsEntityOrUserStringToken(uint vToken)
            {
                return (vToken & TypeMask) <= UserString;
            }

            public static bool IsEntityToken(uint vToken)
            {
                return (vToken & TypeMask) < UserString;
            }

            public static bool IsValidRowId(uint rowId)
            {
                return (rowId & ~RIDMask) == 0;
            }

            public static bool IsValidRowId(int rowId)
            {
                return (rowId & ~RIDMask) == 0;
            }
        }

        public readonly struct ModuleDefinitionHandle : IEquatable<ModuleDefinitionHandle>
        {
            private const uint tokenType = TokenTypeIds.Module;
            private const byte tokenTypeSmall = (byte)HandleType.Module;
            private readonly int _rowId;

            public ModuleDefinitionHandle(int rowId)
            {
                Debug.Assert(TokenTypeIds.IsValidRowId(rowId));
                _rowId = rowId;
            }

            public static ModuleDefinitionHandle FromRowId(int rowId)
            {
                return new ModuleDefinitionHandle(rowId);
            }

        
            public bool IsNil
            {
                get
                {
                    return RowId == 0;
                }
            }

            public int RowId { get { return _rowId; } }

            public static bool operator ==(ModuleDefinitionHandle left, ModuleDefinitionHandle right)
            {
                return left._rowId == right._rowId;
            }

            public override bool Equals(object? obj)
            {
                return obj is ModuleDefinitionHandle moduleDefinition && moduleDefinition._rowId == _rowId;
            }

            public bool Equals(ModuleDefinitionHandle other)
            {
                return _rowId == other._rowId;
            }

            public override int GetHashCode()
            {
                return _rowId.GetHashCode();
            }

            public static bool operator !=(ModuleDefinitionHandle left, ModuleDefinitionHandle right)
            {
                return left._rowId != right._rowId;
            }
        }

        public readonly struct AssemblyDefinitionHandle : IEquatable<AssemblyDefinitionHandle>
        {
            private const uint tokenType = TokenTypeIds.Assembly;
            private const byte tokenTypeSmall = (byte)HandleType.Assembly;
            private readonly int _rowId;

            public AssemblyDefinitionHandle(int rowId)
            {
                Debug.Assert(TokenTypeIds.IsValidRowId(rowId));
                _rowId = rowId;
            }

            public static AssemblyDefinitionHandle FromRowId(int rowId)
            {
                return new AssemblyDefinitionHandle(rowId);
            }

            public bool IsNil
            {
                get
                {
                    return RowId == 0;
                }
            }

            public int RowId { get { return _rowId; } }

            public static bool operator ==(AssemblyDefinitionHandle left, AssemblyDefinitionHandle right)
            {
                return left._rowId == right._rowId;
            }

            public override bool Equals(object? obj)
            {
                return obj is AssemblyDefinitionHandle && ((AssemblyDefinitionHandle)obj)._rowId == _rowId;
            }

            public bool Equals(AssemblyDefinitionHandle other)
            {
                return _rowId == other._rowId;
            }

            public override int GetHashCode()
            {
                return _rowId.GetHashCode();
            }

            public static bool operator !=(AssemblyDefinitionHandle left, AssemblyDefinitionHandle right)
            {
                return left._rowId != right._rowId;
            }
        }

        public readonly struct InterfaceImplementationHandle : IEquatable<InterfaceImplementationHandle>
        {
            private const uint tokenType = TokenTypeIds.InterfaceImpl;
            private const byte tokenTypeSmall = (byte)HandleType.InterfaceImpl;

            private readonly int _rowId;

            public InterfaceImplementationHandle(int rowId)
            {
                Debug.Assert(TokenTypeIds.IsValidRowId(rowId));
                _rowId = rowId;
            }

            public static InterfaceImplementationHandle FromRowId(int rowId)
            {
                return new InterfaceImplementationHandle(rowId);
            }


            public bool IsNil
            {
                get
                {
                    return RowId == 0;
                }
            }

            public int RowId { get { return _rowId; } }

            public static bool operator ==(InterfaceImplementationHandle left, InterfaceImplementationHandle right)
            {
                return left._rowId == right._rowId;
            }

            public override bool Equals(object? obj)
            {
                return obj is InterfaceImplementationHandle && ((InterfaceImplementationHandle)obj)._rowId == _rowId;
            }

            public bool Equals(InterfaceImplementationHandle other)
            {
                return _rowId == other._rowId;
            }

            public override int GetHashCode()
            {
                return _rowId.GetHashCode();
            }

            public static bool operator !=(InterfaceImplementationHandle left, InterfaceImplementationHandle right)
            {
                return left._rowId != right._rowId;
            }
        }

        public readonly struct MethodDefinitionHandle : IEquatable<MethodDefinitionHandle>
        {
            const uint tokenType = TokenTypeIds.MethodDef;
            
            const byte tokenTypeSmall = (byte)HandleType.MethodDef;
            
            readonly int _rowId;

            private MethodDefinitionHandle(int rowId)
            {
                Debug.Assert(TokenTypeIds.IsValidRowId(rowId));
                _rowId = rowId;
            }

            public static MethodDefinitionHandle FromRowId(int rowId)
            {
                return new MethodDefinitionHandle(rowId);
            }


            public bool IsNil
            {
                get
                {
                    return RowId == 0;
                }
            }

            public int RowId { get { return _rowId; } }

            public static bool operator ==(MethodDefinitionHandle left, MethodDefinitionHandle right)
            {
                return left._rowId == right._rowId;
            }

            public override bool Equals(object? obj)
            {
                return obj is MethodDefinitionHandle && ((MethodDefinitionHandle)obj)._rowId == _rowId;
            }

            public bool Equals(MethodDefinitionHandle other)
            {
                return _rowId == other._rowId;
            }

            public override int GetHashCode()
            {
                return _rowId.GetHashCode();
            }

            public static bool operator !=(MethodDefinitionHandle left, MethodDefinitionHandle right)
            {
                return left._rowId != right._rowId;
            }

        }

        public readonly struct MethodImplementationHandle : IEquatable<MethodImplementationHandle>
        {
            private const uint tokenType = TokenTypeIds.MethodImpl;
            private const byte tokenTypeSmall = (byte)HandleType.MethodImpl;
            private readonly int _rowId;

            private MethodImplementationHandle(int rowId)
            {
                Debug.Assert(TokenTypeIds.IsValidRowId(rowId));
                _rowId = rowId;
            }

            public static MethodImplementationHandle FromRowId(int rowId)
            {
                return new MethodImplementationHandle(rowId);
            }

            public bool IsNil
            {
                get
                {
                    return RowId == 0;
                }
            }

            public int RowId { get { return _rowId; } }

            public static bool operator ==(MethodImplementationHandle left, MethodImplementationHandle right)
            {
                return left._rowId == right._rowId;
            }

            public override bool Equals(object? obj)
            {
                return obj is MethodImplementationHandle && ((MethodImplementationHandle)obj)._rowId == _rowId;
            }

            public bool Equals(MethodImplementationHandle other)
            {
                return _rowId == other._rowId;
            }

            public override int GetHashCode()
            {
                return _rowId.GetHashCode();
            }

            public static bool operator !=(MethodImplementationHandle left, MethodImplementationHandle right)
            {
                return left._rowId != right._rowId;
            }
        }

        public readonly struct MethodSpecificationHandle : IEquatable<MethodSpecificationHandle>
        {
            private const uint tokenType = TokenTypeIds.MethodSpec;
            private const byte tokenTypeSmall = (byte)HandleType.MethodSpec;
            private readonly int _rowId;

            private MethodSpecificationHandle(int rowId)
            {
                Debug.Assert(TokenTypeIds.IsValidRowId(rowId));
                _rowId = rowId;
            }

            public static MethodSpecificationHandle FromRowId(int rowId)
            {
                return new MethodSpecificationHandle(rowId);
            }


            public bool IsNil
            {
                get
                {
                    return RowId == 0;
                }
            }

            public int RowId { get { return _rowId; } }

            public static bool operator ==(MethodSpecificationHandle left, MethodSpecificationHandle right)
            {
                return left._rowId == right._rowId;
            }

            public override bool Equals(object? obj)
            {
                return obj is MethodSpecificationHandle && ((MethodSpecificationHandle)obj)._rowId == _rowId;
            }

            public bool Equals(MethodSpecificationHandle other)
            {
                return _rowId == other._rowId;
            }

            public override int GetHashCode()
            {
                return _rowId.GetHashCode();
            }

            public static bool operator !=(MethodSpecificationHandle left, MethodSpecificationHandle right)
            {
                return left._rowId != right._rowId;
            }
        }

        public readonly struct TypeDefinitionHandle : IEquatable<TypeDefinitionHandle>
        {
            private const uint tokenType = TokenTypeIds.TypeDef;
            private const byte tokenTypeSmall = (byte)HandleType.TypeDef;
            private readonly int _rowId;

            private TypeDefinitionHandle(int rowId)
            {
                Debug.Assert(TokenTypeIds.IsValidRowId(rowId));
                _rowId = rowId;
            }

            public static TypeDefinitionHandle FromRowId(int rowId)
            {
                return new TypeDefinitionHandle(rowId);
            }

            public bool IsNil
            {
                get
                {
                    return RowId == 0;
                }
            }

            public int RowId { get { return _rowId; } }

            public static bool operator ==(TypeDefinitionHandle left, TypeDefinitionHandle right)
            {
                return left._rowId == right._rowId;
            }

            public override bool Equals(object? obj)
            {
                return obj is TypeDefinitionHandle && ((TypeDefinitionHandle)obj)._rowId == _rowId;
            }

            public bool Equals(TypeDefinitionHandle other)
            {
                return _rowId == other._rowId;
            }

            public override int GetHashCode()
            {
                return _rowId.GetHashCode();
            }

            public static bool operator !=(TypeDefinitionHandle left, TypeDefinitionHandle right)
            {
                return left._rowId != right._rowId;
            }
        }

        public readonly struct ExportedTypeHandle : IEquatable<ExportedTypeHandle>
        {
            private const uint tokenType = TokenTypeIds.ExportedType;
            private const byte tokenTypeSmall = (byte)HandleType.ExportedType;
            private readonly int _rowId;

            private ExportedTypeHandle(int rowId)
            {
                Debug.Assert(TokenTypeIds.IsValidRowId(rowId));
                _rowId = rowId;
            }

            public static ExportedTypeHandle FromRowId(int rowId)
            {
                return new ExportedTypeHandle(rowId);
            }

            public bool IsNil
            {
                get
                {
                    return RowId == 0;
                }
            }

            public int RowId { get { return _rowId; } }

            public static bool operator ==(ExportedTypeHandle left, ExportedTypeHandle right)
            {
                return left._rowId == right._rowId;
            }

            public override bool Equals(object? obj)
            {
                return obj is ExportedTypeHandle && ((ExportedTypeHandle)obj)._rowId == _rowId;
            }

            public bool Equals(ExportedTypeHandle other)
            {
                return _rowId == other._rowId;
            }

            public override int GetHashCode()
            {
                return _rowId.GetHashCode();
            }

            public static bool operator !=(ExportedTypeHandle left, ExportedTypeHandle right)
            {
                return left._rowId != right._rowId;
            }
        }

        public readonly struct TypeReferenceHandle : IEquatable<TypeReferenceHandle>
        {
            private const uint tokenType = TokenTypeIds.TypeRef;
            private const byte tokenTypeSmall = (byte)HandleType.TypeRef;
            private readonly int _rowId;

            private TypeReferenceHandle(int rowId)
            {
                Debug.Assert(TokenTypeIds.IsValidRowId(rowId));
                _rowId = rowId;
            }

            public static TypeReferenceHandle FromRowId(int rowId)
            {
                return new TypeReferenceHandle(rowId);
            }

            public bool IsNil
            {
                get
                {
                    return RowId == 0;
                }
            }

            public int RowId { get { return _rowId; } }

            public static bool operator ==(TypeReferenceHandle left, TypeReferenceHandle right)
            {
                return left._rowId == right._rowId;
            }

            public override bool Equals(object? obj)
            {
                return obj is TypeReferenceHandle && ((TypeReferenceHandle)obj)._rowId == _rowId;
            }

            public bool Equals(TypeReferenceHandle other)
            {
                return _rowId == other._rowId;
            }

            public override int GetHashCode()
            {
                return _rowId.GetHashCode();
            }

            public static bool operator !=(TypeReferenceHandle left, TypeReferenceHandle right)
            {
                return left._rowId != right._rowId;
            }
        }

        public readonly struct TypeSpecificationHandle : IEquatable<TypeSpecificationHandle>
        {
            private const uint tokenType = TokenTypeIds.TypeSpec;
            private const byte tokenTypeSmall = (byte)HandleType.TypeSpec;
            private readonly int _rowId;

            private TypeSpecificationHandle(int rowId)
            {
                Debug.Assert(TokenTypeIds.IsValidRowId(rowId));
                _rowId = rowId;
            }

            public static TypeSpecificationHandle FromRowId(int rowId)
            {
                return new TypeSpecificationHandle(rowId);
            }

            public bool IsNil
            {
                get
                {
                    return RowId == 0;
                }
            }

            public int RowId { get { return _rowId; } }

            public static bool operator ==(TypeSpecificationHandle left, TypeSpecificationHandle right)
            {
                return left._rowId == right._rowId;
            }

            public override bool Equals(object? obj)
            {
                return obj is TypeSpecificationHandle && ((TypeSpecificationHandle)obj)._rowId == _rowId;
            }

            public bool Equals(TypeSpecificationHandle other)
            {
                return _rowId == other._rowId;
            }

            public override int GetHashCode()
            {
                return _rowId.GetHashCode();
            }

            public static bool operator !=(TypeSpecificationHandle left, TypeSpecificationHandle right)
            {
                return left._rowId != right._rowId;
            }
        }

        public readonly struct MemberReferenceHandle : IEquatable<MemberReferenceHandle>
        {
            private const uint tokenType = TokenTypeIds.MemberRef;
            private const byte tokenTypeSmall = (byte)HandleType.MemberRef;
            private readonly int _rowId;

            private MemberReferenceHandle(int rowId)
            {
                Debug.Assert(TokenTypeIds.IsValidRowId(rowId));
                _rowId = rowId;
            }

            public static MemberReferenceHandle FromRowId(int rowId)
            {
                return new MemberReferenceHandle(rowId);
            }


            public bool IsNil
            {
                get
                {
                    return RowId == 0;
                }
            }

            public int RowId { get { return _rowId; } }

            public static bool operator ==(MemberReferenceHandle left, MemberReferenceHandle right)
            {
                return left._rowId == right._rowId;
            }

            public override bool Equals(object? obj)
            {
                return obj is MemberReferenceHandle && ((MemberReferenceHandle)obj)._rowId == _rowId;
            }

            public bool Equals(MemberReferenceHandle other)
            {
                return _rowId == other._rowId;
            }

            public override int GetHashCode()
            {
                return _rowId.GetHashCode();
            }

            public static bool operator !=(MemberReferenceHandle left, MemberReferenceHandle right)
            {
                return left._rowId != right._rowId;
            }
        }

        public readonly struct FieldDefinitionHandle : IEquatable<FieldDefinitionHandle>
        {
            private const uint tokenType = TokenTypeIds.FieldDef;
            private const byte tokenTypeSmall = (byte)HandleType.FieldDef;
            private readonly int _rowId;

            private FieldDefinitionHandle(int rowId)
            {
                Debug.Assert(TokenTypeIds.IsValidRowId(rowId));
                _rowId = rowId;
            }

            public bool IsNil
            {
                get
                {
                    return RowId == 0;
                }
            }

            public int RowId { get { return _rowId; } }

            public static bool operator ==(FieldDefinitionHandle left, FieldDefinitionHandle right)
            {
                return left._rowId == right._rowId;
            }

            public override bool Equals(object? obj)
            {
                return obj is FieldDefinitionHandle && ((FieldDefinitionHandle)obj)._rowId == _rowId;
            }

            public bool Equals(FieldDefinitionHandle other)
            {
                return _rowId == other._rowId;
            }

            public override int GetHashCode()
            {
                return _rowId.GetHashCode();
            }

            public static bool operator !=(FieldDefinitionHandle left, FieldDefinitionHandle right)
            {
                return left._rowId != right._rowId;
            }
        }

        public readonly struct EventDefinitionHandle : IEquatable<EventDefinitionHandle>
        {
            private const uint tokenType = TokenTypeIds.Event;
            private const byte tokenTypeSmall = (byte)HandleType.Event;
            private readonly int _rowId;

            private EventDefinitionHandle(int rowId)
            {
                Debug.Assert(TokenTypeIds.IsValidRowId(rowId));
                _rowId = rowId;
            }

            public static EventDefinitionHandle FromRowId(int rowId)
            {
                return new EventDefinitionHandle(rowId);
            }

            public bool IsNil
            {
                get
                {
                    return RowId == 0;
                }
            }

            public int RowId { get { return _rowId; } }

            public static bool operator ==(EventDefinitionHandle left, EventDefinitionHandle right)
            {
                return left._rowId == right._rowId;
            }

            public override bool Equals(object? obj)
            {
                return obj is EventDefinitionHandle && ((EventDefinitionHandle)obj)._rowId == _rowId;
            }

            public bool Equals(EventDefinitionHandle other)
            {
                return _rowId == other._rowId;
            }

            public override int GetHashCode()
            {
                return _rowId.GetHashCode();
            }

            public static bool operator !=(EventDefinitionHandle left, EventDefinitionHandle right)
            {
                return left._rowId != right._rowId;
            }
        }

        public readonly struct PropertyDefinitionHandle : IEquatable<PropertyDefinitionHandle>
        {
            private const uint tokenType = TokenTypeIds.Property;
            private const byte tokenTypeSmall = (byte)HandleType.Property;
            private readonly int _rowId;

            private PropertyDefinitionHandle(int rowId)
            {
                Debug.Assert(TokenTypeIds.IsValidRowId(rowId));
                _rowId = rowId;
            }

            public static PropertyDefinitionHandle FromRowId(int rowId)
            {
                return new PropertyDefinitionHandle(rowId);
            }


            public bool IsNil
            {
                get
                {
                    return RowId == 0;
                }
            }

            public int RowId { get { return _rowId; } }

            public static bool operator ==(PropertyDefinitionHandle left, PropertyDefinitionHandle right)
            {
                return left._rowId == right._rowId;
            }

            public override bool Equals(object? obj)
            {
                return obj is PropertyDefinitionHandle && ((PropertyDefinitionHandle)obj)._rowId == _rowId;
            }

            public bool Equals(PropertyDefinitionHandle other)
            {
                return _rowId == other._rowId;
            }

            public override int GetHashCode()
            {
                return _rowId.GetHashCode();
            }

            public static bool operator !=(PropertyDefinitionHandle left, PropertyDefinitionHandle right)
            {
                return left._rowId != right._rowId;
            }
        }

        public readonly struct StandaloneSignatureHandle : IEquatable<StandaloneSignatureHandle>
        {
            private const uint tokenType = TokenTypeIds.Signature;
            private const byte tokenTypeSmall = (byte)HandleType.Signature;
            private readonly int _rowId;

            private StandaloneSignatureHandle(int rowId)
            {
                Debug.Assert(TokenTypeIds.IsValidRowId(rowId));
                _rowId = rowId;
            }

            public static StandaloneSignatureHandle FromRowId(int rowId)
            {
                return new StandaloneSignatureHandle(rowId);
            }


            public bool IsNil
            {
                get
                {
                    return RowId == 0;
                }
            }

            public int RowId { get { return _rowId; } }

            public static bool operator ==(StandaloneSignatureHandle left, StandaloneSignatureHandle right)
            {
                return left._rowId == right._rowId;
            }

            public override bool Equals(object? obj)
            {
                return obj is StandaloneSignatureHandle && ((StandaloneSignatureHandle)obj)._rowId == _rowId;
            }

            public bool Equals(StandaloneSignatureHandle other)
            {
                return _rowId == other._rowId;
            }

            public override int GetHashCode()
            {
                return _rowId.GetHashCode();
            }

            public static bool operator !=(StandaloneSignatureHandle left, StandaloneSignatureHandle right)
            {
                return left._rowId != right._rowId;
            }
        }

        public readonly struct ParameterHandle : IEquatable<ParameterHandle>
        {
            private const uint tokenType = TokenTypeIds.ParamDef;
            private const byte tokenTypeSmall = (byte)HandleType.ParamDef;
            private readonly int _rowId;

            private ParameterHandle(int rowId)
            {
                Debug.Assert(TokenTypeIds.IsValidRowId(rowId));
                _rowId = rowId;
            }

            public static ParameterHandle FromRowId(int rowId)
            {
                return new ParameterHandle(rowId);
            }

            public bool IsNil
            {
                get
                {
                    return RowId == 0;
                }
            }

            public int RowId { get { return _rowId; } }

            public static bool operator ==(ParameterHandle left, ParameterHandle right)
            {
                return left._rowId == right._rowId;
            }

            public override bool Equals(object? obj)
            {
                return obj is ParameterHandle && ((ParameterHandle)obj)._rowId == _rowId;
            }

            public bool Equals(ParameterHandle other)
            {
                return _rowId == other._rowId;
            }

            public override int GetHashCode()
            {
                return _rowId.GetHashCode();
            }

            public static bool operator !=(ParameterHandle left, ParameterHandle right)
            {
                return left._rowId != right._rowId;
            }
        }

        public readonly struct GenericParameterHandle : IEquatable<GenericParameterHandle>
        {
            private const uint tokenType = TokenTypeIds.GenericParam;
            private const byte tokenTypeSmall = (byte)HandleType.GenericParam;
            private readonly int _rowId;

            private GenericParameterHandle(int rowId)
            {
                Debug.Assert(TokenTypeIds.IsValidRowId(rowId));
                _rowId = rowId;
            }

            public static GenericParameterHandle FromRowId(int rowId)
            {
                return new GenericParameterHandle(rowId);
            }

            public bool IsNil
            {
                get
                {
                    return RowId == 0;
                }
            }

            public int RowId { get { return _rowId; } }

            public static bool operator ==(GenericParameterHandle left, GenericParameterHandle right)
            {
                return left._rowId == right._rowId;
            }

            public override bool Equals(object? obj)
            {
                return obj is GenericParameterHandle && ((GenericParameterHandle)obj)._rowId == _rowId;
            }

            public bool Equals(GenericParameterHandle other)
            {
                return _rowId == other._rowId;
            }

            public override int GetHashCode()
            {
                return _rowId.GetHashCode();
            }

            public static bool operator !=(GenericParameterHandle left, GenericParameterHandle right)
            {
                return left._rowId != right._rowId;
            }
        }

        public readonly struct GenericParameterConstraintHandle : IEquatable<GenericParameterConstraintHandle>
        {
            private const uint tokenType = TokenTypeIds.GenericParamConstraint;
            private const byte tokenTypeSmall = (byte)HandleType.GenericParamConstraint;
            private readonly int _rowId;

            private GenericParameterConstraintHandle(int rowId)
            {
                Debug.Assert(TokenTypeIds.IsValidRowId(rowId));
                _rowId = rowId;
            }

            public static GenericParameterConstraintHandle FromRowId(int rowId)
            {
                return new GenericParameterConstraintHandle(rowId);
            }

            public bool IsNil
            {
                get
                {
                    return RowId == 0;
                }
            }

            public int RowId { get { return _rowId; } }

            public static bool operator ==(GenericParameterConstraintHandle left, GenericParameterConstraintHandle right)
            {
                return left._rowId == right._rowId;
            }

            public override bool Equals(object? obj)
            {
                return obj is GenericParameterConstraintHandle && ((GenericParameterConstraintHandle)obj)._rowId == _rowId;
            }

            public bool Equals(GenericParameterConstraintHandle other)
            {
                return _rowId == other._rowId;
            }

            public override int GetHashCode()
            {
                return _rowId.GetHashCode();
            }

            public static bool operator !=(GenericParameterConstraintHandle left, GenericParameterConstraintHandle right)
            {
                return left._rowId != right._rowId;
            }
        }

        public readonly struct ModuleReferenceHandle : IEquatable<ModuleReferenceHandle>
        {
            private const uint tokenType = TokenTypeIds.ModuleRef;
            private const byte tokenTypeSmall = (byte)HandleType.ModuleRef;
            private readonly int _rowId;

            private ModuleReferenceHandle(int rowId)
            {
                Debug.Assert(TokenTypeIds.IsValidRowId(rowId));
                _rowId = rowId;
            }

            public static ModuleReferenceHandle FromRowId(int rowId)
            {
                return new ModuleReferenceHandle(rowId);
            }

            public bool IsNil
            {
                get
                {
                    return RowId == 0;
                }
            }

            public int RowId { get { return _rowId; } }

            public static bool operator ==(ModuleReferenceHandle left, ModuleReferenceHandle right)
            {
                return left._rowId == right._rowId;
            }

            public override bool Equals(object? obj)
            {
                return obj is ModuleReferenceHandle && ((ModuleReferenceHandle)obj)._rowId == _rowId;
            }

            public bool Equals(ModuleReferenceHandle other)
            {
                return _rowId == other._rowId;
            }

            public override int GetHashCode()
            {
                return _rowId.GetHashCode();
            }

            public static bool operator !=(ModuleReferenceHandle left, ModuleReferenceHandle right)
            {
                return left._rowId != right._rowId;
            }
        }

        public readonly struct AssemblyReferenceHandle : IEquatable<AssemblyReferenceHandle>
        {
            private const uint tokenType = TokenTypeIds.AssemblyRef;
            private const byte tokenTypeSmall = (byte)HandleType.AssemblyRef;

            // bits:
            //     31: IsVirtual
            // 24..30: 0
            //  0..23: Heap offset or Virtual index
            private readonly uint _value;

            public enum VirtualIndex
            {
                System_Runtime,
                System_Runtime_InteropServices_WindowsRuntime,
                System_ObjectModel,
                System_Runtime_WindowsRuntime,
                System_Runtime_WindowsRuntime_UI_Xaml,
                System_Numerics_Vectors,

                Count
            }

            private AssemblyReferenceHandle(uint value)
            {
                _value = value;
            }

            public static AssemblyReferenceHandle FromRowId(int rowId)
            {
                Debug.Assert(TokenTypeIds.IsValidRowId(rowId));
                return new AssemblyReferenceHandle((uint)rowId);
            }

            public static AssemblyReferenceHandle FromVirtualIndex(VirtualIndex virtualIndex)
            {
                Debug.Assert(virtualIndex < VirtualIndex.Count);
                return new AssemblyReferenceHandle(TokenTypeIds.VirtualBit | (uint)virtualIndex);
            }

            public uint Value
            {
                get { return _value; }
            }

            private uint VToken
            {
                get { return _value | tokenType; }
            }

            public bool IsNil
            {
                get { return _value == 0; }
            }

            public bool IsVirtual
            {
                get { return (_value & TokenTypeIds.VirtualBit) != 0; }
            }

            public int RowId { get { return (int)(_value & TokenTypeIds.RIDMask); } }

            public static bool operator ==(AssemblyReferenceHandle left, AssemblyReferenceHandle right)
            {
                return left._value == right._value;
            }

            public override bool Equals(object? obj)
            {
                return obj is AssemblyReferenceHandle && ((AssemblyReferenceHandle)obj)._value == _value;
            }

            public bool Equals(AssemblyReferenceHandle other)
            {
                return _value == other._value;
            }

            public override int GetHashCode()
            {
                return _value.GetHashCode();
            }

            public static bool operator !=(AssemblyReferenceHandle left, AssemblyReferenceHandle right)
            {
                return left._value != right._value;
            }
        }

        public readonly struct CustomAttributeHandle : IEquatable<CustomAttributeHandle>
        {
            private const uint tokenType = TokenTypeIds.CustomAttribute;
            private const byte tokenTypeSmall = (byte)HandleType.CustomAttribute;
            private readonly int _rowId;

            private CustomAttributeHandle(int rowId)
            {
                Debug.Assert(TokenTypeIds.IsValidRowId(rowId));
                _rowId = rowId;
            }

            public static CustomAttributeHandle FromRowId(int rowId)
            {
                return new CustomAttributeHandle(rowId);
            }

            public bool IsNil
            {
                get
                {
                    return _rowId == 0;
                }
            }

            public int RowId { get { return _rowId; } }

            public static bool operator ==(CustomAttributeHandle left, CustomAttributeHandle right)
            {
                return left._rowId == right._rowId;
            }

            public override bool Equals(object? obj)
            {
                return obj is CustomAttributeHandle && ((CustomAttributeHandle)obj)._rowId == _rowId;
            }

            public bool Equals(CustomAttributeHandle other)
            {
                return _rowId == other._rowId;
            }

            public override int GetHashCode()
            {
                return _rowId.GetHashCode();
            }

            public static bool operator !=(CustomAttributeHandle left, CustomAttributeHandle right)
            {
                return left._rowId != right._rowId;
            }
        }

        public readonly struct DeclarativeSecurityAttributeHandle : IEquatable<DeclarativeSecurityAttributeHandle>
        {
            private const uint tokenType = TokenTypeIds.DeclSecurity;
            private const byte tokenTypeSmall = (byte)HandleType.DeclSecurity;
            private readonly int _rowId;

            private DeclarativeSecurityAttributeHandle(int rowId)
            {
                Debug.Assert(TokenTypeIds.IsValidRowId(rowId));
                _rowId = rowId;
            }

            public static DeclarativeSecurityAttributeHandle FromRowId(int rowId)
            {
                return new DeclarativeSecurityAttributeHandle(rowId);
            }

            public bool IsNil
            {
                get
                {
                    return _rowId == 0;
                }
            }

            public int RowId { get { return _rowId; } }

            public static bool operator ==(DeclarativeSecurityAttributeHandle left, DeclarativeSecurityAttributeHandle right)
            {
                return left._rowId == right._rowId;
            }

            public override bool Equals(object? obj)
            {
                return obj is DeclarativeSecurityAttributeHandle && ((DeclarativeSecurityAttributeHandle)obj)._rowId == _rowId;
            }

            public bool Equals(DeclarativeSecurityAttributeHandle other)
            {
                return _rowId == other._rowId;
            }

            public override int GetHashCode()
            {
                return _rowId.GetHashCode();
            }

            public static bool operator !=(DeclarativeSecurityAttributeHandle left, DeclarativeSecurityAttributeHandle right)
            {
                return left._rowId != right._rowId;
            }
        }

        public readonly struct ConstantHandle : IEquatable<ConstantHandle>
        {
            private const uint tokenType = TokenTypeIds.Constant;
            private const byte tokenTypeSmall = (byte)HandleType.Constant;
            private readonly int _rowId;

            private ConstantHandle(int rowId)
            {
                Debug.Assert(TokenTypeIds.IsValidRowId(rowId));
                _rowId = rowId;
            }

            public static ConstantHandle FromRowId(int rowId)
            {
                return new ConstantHandle(rowId);
            }

            public bool IsNil
            {
                get
                {
                    return RowId == 0;
                }
            }

            public int RowId { get { return _rowId; } }

            public static bool operator ==(ConstantHandle left, ConstantHandle right)
            {
                return left._rowId == right._rowId;
            }

            public override bool Equals(object? obj)
            {
                return obj is ConstantHandle && ((ConstantHandle)obj)._rowId == _rowId;
            }

            public bool Equals(ConstantHandle other)
            {
                return _rowId == other._rowId;
            }

            public override int GetHashCode()
            {
                return _rowId.GetHashCode();
            }

            public static bool operator !=(ConstantHandle left, ConstantHandle right)
            {
                return left._rowId != right._rowId;
            }
        }

        public readonly struct ManifestResourceHandle : IEquatable<ManifestResourceHandle>
        {
            private const uint tokenType = TokenTypeIds.ManifestResource;
            private const byte tokenTypeSmall = (byte)HandleType.ManifestResource;
            private readonly int _rowId;

            private ManifestResourceHandle(int rowId)
            {
                Debug.Assert(TokenTypeIds.IsValidRowId(rowId));
                _rowId = rowId;
            }

            public static ManifestResourceHandle FromRowId(int rowId)
            {
                return new ManifestResourceHandle(rowId);
            }


            public bool IsNil
            {
                get
                {
                    return RowId == 0;
                }
            }

            public int RowId { get { return _rowId; } }

            public static bool operator ==(ManifestResourceHandle left, ManifestResourceHandle right)
            {
                return left._rowId == right._rowId;
            }

            public override bool Equals(object? obj)
            {
                return obj is ManifestResourceHandle && ((ManifestResourceHandle)obj)._rowId == _rowId;
            }

            public bool Equals(ManifestResourceHandle other)
            {
                return _rowId == other._rowId;
            }

            public override int GetHashCode()
            {
                return _rowId.GetHashCode();
            }

            public static bool operator !=(ManifestResourceHandle left, ManifestResourceHandle right)
            {
                return left._rowId != right._rowId;
            }
        }

        public readonly struct AssemblyFileHandle : IEquatable<AssemblyFileHandle>
        {
            private const uint tokenType = TokenTypeIds.File;
            private const byte tokenTypeSmall = (byte)HandleType.File;
            private readonly int _rowId;

            private AssemblyFileHandle(int rowId)
            {
                Debug.Assert(TokenTypeIds.IsValidRowId(rowId));
                _rowId = rowId;
            }

            public static AssemblyFileHandle FromRowId(int rowId)
            {
                return new AssemblyFileHandle(rowId);
            }


            public bool IsNil
            {
                get
                {
                    return RowId == 0;
                }
            }

            public int RowId { get { return _rowId; } }

            public static bool operator ==(AssemblyFileHandle left, AssemblyFileHandle right)
            {
                return left._rowId == right._rowId;
            }

            public override bool Equals(object? obj)
            {
                return obj is AssemblyFileHandle && ((AssemblyFileHandle)obj)._rowId == _rowId;
            }

            public bool Equals(AssemblyFileHandle other)
            {
                return _rowId == other._rowId;
            }

            public override int GetHashCode()
            {
                return _rowId.GetHashCode();
            }

            public static bool operator !=(AssemblyFileHandle left, AssemblyFileHandle right)
            {
                return left._rowId != right._rowId;
            }
        }

        /// <summary>
        /// #UserString heap handle.
        /// </summary>
        /// <remarks>
        /// The handle is 32-bit wide.
        /// </remarks>
        public readonly struct UserStringHandle : IEquatable<UserStringHandle>
        {
            // bits:
            //     31: 0
            // 24..30: 0
            //  0..23: index
            private readonly int _offset;

            private UserStringHandle(int offset)
            {
                // #US string indices must fit into 24bits since they are used in IL stream tokens
                Debug.Assert((offset & 0xFF000000) == 0);
                _offset = offset;
            }

            public static UserStringHandle FromOffset(int heapOffset)
            {
                return new UserStringHandle(heapOffset);
            }

            public bool IsNil
            {
                get { return _offset == 0; }
            }

            public int GetHeapOffset()
            {
                return _offset;
            }

            public static bool operator ==(UserStringHandle left, UserStringHandle right)
            {
                return left._offset == right._offset;
            }

            public override bool Equals(object? obj)
            {
                return obj is UserStringHandle && ((UserStringHandle)obj)._offset == _offset;
            }

            public bool Equals(UserStringHandle other)
            {
                return _offset == other._offset;
            }

            public override int GetHashCode()
            {
                return _offset.GetHashCode();
            }

            public static bool operator !=(UserStringHandle left, UserStringHandle right)
            {
                return left._offset != right._offset;
            }
        }

        // #String heap handle
        public readonly struct StringHandle : IEquatable<StringHandle>
        {
            // bits:
            //     31: IsVirtual
            // 29..31: type (non-virtual: String, DotTerminatedString; virtual: VirtualString, WinRTPrefixedString)
            //  0..28: Heap offset or Virtual index
            private readonly uint _value;

            public enum VirtualIndex
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

            private StringHandle(uint value)
            {
                Debug.Assert((value & StringHandleType.TypeMask) == StringHandleType.String ||
                            (value & StringHandleType.TypeMask) == StringHandleType.VirtualString ||
                            (value & StringHandleType.TypeMask) == StringHandleType.WinRTPrefixedString ||
                            (value & StringHandleType.TypeMask) == StringHandleType.DotTerminatedString);

                _value = value;
            }

            public static StringHandle FromOffset(int heapOffset)
            {
                return new StringHandle(StringHandleType.String | (uint)heapOffset);
            }

            public static StringHandle FromVirtualIndex(VirtualIndex virtualIndex)
            {
                Debug.Assert(virtualIndex < VirtualIndex.Count);
                return new StringHandle(StringHandleType.VirtualString | (uint)virtualIndex);
            }

            public static StringHandle FromWriterVirtualIndex(int virtualIndex)
            {
                return new StringHandle(StringHandleType.VirtualString | (uint)virtualIndex);
            }

            public StringHandle WithWinRTPrefix()
            {
                Debug.Assert(StringKind == StringKind.Plain);
                return new StringHandle(StringHandleType.WinRTPrefixedString | _value);
            }

            public StringHandle WithDotTermination()
            {
                Debug.Assert(StringKind == StringKind.Plain);
                return new StringHandle(StringHandleType.DotTerminatedString | _value);
            }

            public StringHandle SuffixRaw(int prefixByteLength)
            {
                Debug.Assert(StringKind == StringKind.Plain);
                Debug.Assert(prefixByteLength >= 0);
                return new StringHandle(StringHandleType.String | (_value + (uint)prefixByteLength));
            }

            public uint RawValue => _value;

            public bool IsVirtual
            {
                get { return (_value & HeapHandleType.VirtualBit) != 0; }
            }

            public bool IsNil
            {
                get
                {
                    // virtual strings are never nil, so include virtual bit
                    return (_value & (HeapHandleType.VirtualBit | HeapHandleType.OffsetMask)) == 0;
                }
            }

            public int GetHeapOffset()
            {
                // WinRT prefixed strings are virtual, the value is a heap offset
                Debug.Assert(!IsVirtual || StringKind == StringKind.WinRTPrefixed);
                return (int)(_value & HeapHandleType.OffsetMask);
            }

            public VirtualIndex GetVirtualIndex()
            {
                Debug.Assert(IsVirtual && StringKind != StringKind.WinRTPrefixed);
                return (VirtualIndex)(_value & HeapHandleType.OffsetMask);
            }

            public int GetWriterVirtualIndex()
            {
                Debug.Assert(IsNil || IsVirtual && StringKind == StringKind.Virtual);
                return (int)(_value & HeapHandleType.OffsetMask);
            }

            public StringKind StringKind
            {
                get { return (StringKind)(_value >> HeapHandleType.OffsetBitCount); }
            }

            public override bool Equals(object? obj)
            {
                return obj is StringHandle && Equals((StringHandle)obj);
            }

            public bool Equals(StringHandle other)
            {
                return _value == other._value;
            }

            public override int GetHashCode()
            {
                return unchecked((int)_value);
            }

            public static bool operator ==(StringHandle left, StringHandle right)
            {
                return left.Equals(right);
            }

            public static bool operator !=(StringHandle left, StringHandle right)
            {
                return !left.Equals(right);
            }
        }

        /// <summary>
        /// A handle that represents a namespace definition.
        /// </summary>
        public readonly struct NamespaceDefinitionHandle : IEquatable<NamespaceDefinitionHandle>
        {
            // Non-virtual (namespace having at least one type or forwarder of its own)
            // heap offset is to the null-terminated full name of the namespace in the
            // #String heap.
            //
            // Virtual (namespace having child namespaces but no types of its own)
            // the virtual index is an auto-incremented value and serves solely to
            // create unique values for indexing into the NamespaceCache.

            // bits:
            //     31: IsVirtual
            // 29..31: 0
            //  0..28: Heap offset or Virtual index
            private readonly uint _value;

            private NamespaceDefinitionHandle(uint value)
            {
                _value = value;
            }

            public static NamespaceDefinitionHandle FromFullNameOffset(int stringHeapOffset)
            {
                return new NamespaceDefinitionHandle((uint)stringHeapOffset);
            }

            public static NamespaceDefinitionHandle FromVirtualIndex(uint virtualIndex)
            {
                // we arbitrarily disallow 0 virtual index to simplify nil check.
                Debug.Assert(virtualIndex != 0);

                if (!HeapHandleType.IsValidHeapOffset(virtualIndex))
                {
                    // only a pathological assembly would hit this, but it must fit in 29 bits.
                    throw new Exception();
                }

                return new NamespaceDefinitionHandle(TokenTypeIds.VirtualBit | virtualIndex);
            }

            public bool IsNil
            {
                get
                {
                    return _value == 0;
                }
            }

            public bool IsVirtual
            {
                get { return (_value & HeapHandleType.VirtualBit) != 0; }
            }

            public int GetHeapOffset()
            {
                Debug.Assert(!IsVirtual);
                return (int)(_value & HeapHandleType.OffsetMask);
            }

            public bool HasFullName
            {
                get { return !IsVirtual; }
            }

            public StringHandle GetFullName()
            {
                Debug.Assert(HasFullName);
                return StringHandle.FromOffset(GetHeapOffset());
            }

            public override bool Equals([NotNullWhen(true)] object? obj)
            {
                return obj is NamespaceDefinitionHandle ndh && Equals(ndh);
            }

            public bool Equals(NamespaceDefinitionHandle other)
            {
                return _value == other._value;
            }

            public override int GetHashCode()
            {
                return unchecked((int)_value);
            }

            public static bool operator ==(NamespaceDefinitionHandle left, NamespaceDefinitionHandle right)
            {
                return left.Equals(right);
            }

            public static bool operator !=(NamespaceDefinitionHandle left, NamespaceDefinitionHandle right)
            {
                return !left.Equals(right);
            }
        }

        // #Blob heap handle
        public readonly struct BlobHandle : IEquatable<BlobHandle>
        {
            // bits:
            //     31: IsVirtual
            // 29..30: 0
            //  0..28: Heap offset or Virtual Value (16 bits) + Virtual Index (8 bits)
            private readonly uint _value;

            public enum VirtualIndex : byte
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

            private BlobHandle(uint value)
            {
                _value = value;
            }

            public static BlobHandle FromOffset(int heapOffset)
            {
                return new BlobHandle((uint)heapOffset);
            }

            public static BlobHandle FromVirtualIndex(VirtualIndex virtualIndex, ushort virtualValue)
            {
                Debug.Assert(virtualIndex < VirtualIndex.Count);
                return new BlobHandle(TokenTypeIds.VirtualBit | (uint)(virtualValue << 8) | (uint)virtualIndex);
            }

            public const int TemplateParameterOffset_AttributeUsageTarget = 2;

            public unsafe void SubstituteTemplateParameters(byte[] blob)
            {
                Debug.Assert(blob.Length >= TemplateParameterOffset_AttributeUsageTarget + 4);

                fixed (byte* ptr = &blob[TemplateParameterOffset_AttributeUsageTarget])
                {
                    *((uint*)ptr) = VirtualValue;
                }
            }

    
            public uint RawValue => _value;

            public bool IsNil
            {
                get { return _value == 0; }
            }

            public int GetHeapOffset()
            {
                Debug.Assert(!IsVirtual);
                return (int)_value;
            }

            public VirtualIndex GetVirtualIndex()
            {
                Debug.Assert(IsVirtual);
                return (VirtualIndex)(_value & 0xff);
            }

            public bool IsVirtual
            {
                get { return (_value & TokenTypeIds.VirtualBit) != 0; }
            }

            private ushort VirtualValue
            {
                get { return unchecked((ushort)(_value >> 8)); }
            }

            public override bool Equals([NotNullWhen(true)] object? obj)
            {
                return obj is BlobHandle bh && Equals(bh);
            }

            public bool Equals(BlobHandle other)
            {
                return _value == other._value;
            }

            public override int GetHashCode()
            {
                return unchecked((int)_value);
            }

            public static bool operator ==(BlobHandle left, BlobHandle right)
            {
                return left.Equals(right);
            }

            public static bool operator !=(BlobHandle left, BlobHandle right)
            {
                return !left.Equals(right);
            }
        }

        // #Guid heap handle
        public readonly struct GuidHandle : IEquatable<GuidHandle>
        {
            // The Guid heap is an array of GUIDs, each 16 bytes wide.
            // Its first element is numbered 1, its second 2, and so on.
            private readonly int _index;

            private GuidHandle(int index)
            {
                _index = index;
            }

            public static GuidHandle FromIndex(int heapIndex)
            {
                return new GuidHandle(heapIndex);
            }
    
            public bool IsNil
            {
                get { return _index == 0; }
            }

            public int Index
            {
                get { return _index; }
            }

            public override bool Equals([NotNullWhen(true)] object? obj)
            {
                return obj is GuidHandle gh && Equals(gh);
            }

            public bool Equals(GuidHandle other)
            {
                return _index == other._index;
            }

            public override int GetHashCode()
            {
                return _index;
            }

            public static bool operator ==(GuidHandle left, GuidHandle right)
            {
                return left.Equals(right);
            }

            public static bool operator !=(GuidHandle left, GuidHandle right)
            {
                return !left.Equals(right);
            }
        }        
    
        public readonly struct ProjectionInfo
        {
            public readonly string WinRTNamespace;
            public readonly StringHandle.VirtualIndex ClrNamespace;
            public readonly StringHandle.VirtualIndex ClrName;
            public readonly AssemblyReferenceHandle.VirtualIndex AssemblyRef;
            public readonly TypeDefTreatment Treatment;
            public readonly TypeRefSignatureTreatment SignatureTreatment;
            public readonly bool IsIDisposable;

            public ProjectionInfo(
                string winRtNamespace,
                StringHandle.VirtualIndex clrNamespace,
                StringHandle.VirtualIndex clrName,
                AssemblyReferenceHandle.VirtualIndex clrAssembly,
                TypeDefTreatment treatment = TypeDefTreatment.RedirectedToClrType,
                TypeRefSignatureTreatment signatureTreatment = TypeRefSignatureTreatment.None,
                bool isIDisposable = false)
            {
                this.WinRTNamespace = winRtNamespace;
                this.ClrNamespace = clrNamespace;
                this.ClrName = clrName;
                this.AssemblyRef = clrAssembly;
                this.Treatment = treatment;
                this.SignatureTreatment = signatureTreatment;
                this.IsIDisposable = isIDisposable;
            }
        }
    }
}