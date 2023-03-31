// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
namespace Internal.Runtime;

using Internal.NativeFormat;
using Internal.Runtime.TypeLoader;
using Debug = System.Diagnostics.Debug;

internal static class ArrayTypesConstants
{
    /// <summary>
    /// Maximum allowable size for array element types.
    /// </summary>
    public const int MaxSizeForValueClassInArray = 0xFFFF;
}

internal static class SpecialDispatchMapSlot
{
    public const ushort Diamond = 0xFFFE;

    public const ushort Reabstraction = 0xFFFF;
}

internal static class SpecialGVMInterfaceEntry
{
    public const uint Diamond = 0xFFFFFFFF;
    public const uint Reabstraction = 0xFFFFFFFE;
}

/// <summary>
/// Constants that describe the bits of the Flags field of MethodFixupCell.
/// </summary>
internal static class MethodFixupCellFlagsConstants
{
    public const int CharSetMask = 0x7;
    public const int IsObjectiveCMessageSendMask = 0x8;
    public const int ObjectiveCMessageSendFunctionMask = 0x70;
    public const int ObjectiveCMessageSendFunctionShift = 4;
}    

internal static class ParameterizedTypeShapeConstants
{
    // NOTE: Parameterized type kind is stored in the BaseSize field of the MethodTable.
    // Array types use their actual base size. Pointer and ByRef types are never boxed,
    // so we can reuse the MethodTable BaseSize field to indicate the kind.
    // It's important that these values always stay lower than any valid value of a base
    // size for an actual array.
    public const int Pointer = 0;

    public const int ByRef = 1;
}

internal static class StringComponentSize
{
    public const int Value = sizeof(char);
}

internal static class WritableData
{
    public static int GetSize(int pointerSize) => pointerSize;

    public static int GetAlignment(int pointerSize) => pointerSize;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct MethodTable
{
    // upper ushort is used for Flags
    // lower ushort is used for
    // - component size for strings and arrays,
    // - type arg count for generic type definitions MethodTables,
    // - otherwise holds ExtendedFlags bits
    uint _uFlags;

    uint _uBaseSize;

    RelatedTypeUnion _relatedType;

    ushort _usNumVtableSlots;

    ushort _usNumInterfaces;
    
    uint _uHashCode;

    // vtable follows

    const int POINTER_SIZE = 8;
    
    const int PADDING = 1; // _numComponents is padded by one Int32 to make the first element pointer-aligned
    
    public const int SZARRAY_BASE_SIZE = POINTER_SIZE + POINTER_SIZE + (1 + PADDING) * 4;

    // These masks and paddings have been chosen so that the ValueTypePadding field can always fit in a byte of data.
    // if the alignment is 8 bytes or less. If the alignment is higher then there may be a need for more bits to hold
    // the rest of the padding data.
    // If paddings of greater than 7 bytes are necessary, then the high bits of the field represent that padding
    const uint ValueTypePaddingLowMask = 0x7;

    const uint ValueTypePaddingHighMask = 0xFFFFFF00;

    const uint ValueTypePaddingMax = 0x07FFFFFF;

    const int ValueTypePaddingHighShift = 8;

    const uint ValueTypePaddingAlignmentMask = 0xF8;

    const int ValueTypePaddingAlignmentShift = 3;

    static unsafe MethodTable* GetArrayEEType()
        => typeof(Array).TypeHandle.ToEETypePtr();

    public unsafe RuntimeTypeHandle ToRuntimeTypeHandle()
    {
        fixed (MethodTable* pThis = &this)
        {
            IntPtr result = (IntPtr)pThis;
            return *(RuntimeTypeHandle*)&result;
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    unsafe struct RelatedTypeUnion
    {
        // Kinds.CanonicalEEType
        [FieldOffset(0)]
        public MethodTable* _pBaseType;

        [FieldOffset(0)]
        public MethodTable** _ppBaseTypeViaIAT;

        // Kinds.ClonedEEType
        [FieldOffset(0)]
        public MethodTable* _pCanonicalType;

        [FieldOffset(0)]
        public MethodTable** _ppCanonicalTypeViaIAT;

        // Kinds.ArrayEEType
        [FieldOffset(0)]
        public MethodTable* _pRelatedParameterType;

        [FieldOffset(0)]
        public MethodTable** _ppRelatedParameterTypeViaIAT;
    }

    [StructLayout(LayoutKind.Sequential)]
    readonly struct GenericComposition
    {
        public readonly ushort Arity;

        readonly EETypeRef _genericArgument1;

        public EETypeRef* GenericArguments
        {
            get
            {
                return (EETypeRef*)Unsafe.AsPointer(ref Unsafe.AsRef(in _genericArgument1));
            }
        }

        public GenericVariance* GenericVariance
        {
            get
            {
                // Generic variance directly follows the last generic argument
                return (GenericVariance*)(GenericArguments + Arity);
            }
        }
    }

    static unsafe class OptionalFieldsReader
    {
        public static uint GetInlineField(byte* pFields, EETypeOptionalFieldTag eTag, uint uiDefaultValue)
        {
            if (pFields == null)
                return uiDefaultValue;

            bool isLastField = false;
            while (!isLastField)
            {
                byte fieldHeader = NativePrimitiveDecoder.ReadUInt8(ref pFields);
                isLastField = (fieldHeader & 0x80) != 0;
                EETypeOptionalFieldTag eCurrentTag = (EETypeOptionalFieldTag)(fieldHeader & 0x7f);
                uint uiCurrentValue = NativePrimitiveDecoder.DecodeUnsigned(ref pFields);

                // If we found a tag match return the current value.
                if (eCurrentTag == eTag)
                    return uiCurrentValue;
            }

            // Reached end of stream without getting a match. Field is not present so return default value.
            return uiDefaultValue;
        }
    }

    /// <summary>
    /// Gets a value indicating whether the statically generated data structures use relative pointers.
    /// </summary>
    public static bool SupportsRelativePointers
    {
        get
        {
            return true;
        }
    }

    /// <summary>
    /// Gets a value indicating whether writable data is supported.
    /// </summary>
    public static bool SupportsWritableData
    {
        get
        {
            // For now just key this off of SupportsRelativePointer to avoid this on both CppCodegen and WASM.
            return SupportsRelativePointers;
        }
    }

    public bool HasComponentSize
    {
        get
        {
            // return (_uFlags & (uint)EETypeFlags.HasComponentSizeFlag) != 0;
            return (int)_uFlags < 0;
        }
        set
        {
            if (value)
            {
                Debug.Assert(ExtendedFlags == 0);
                _uFlags |= (uint)EETypeFlags.HasComponentSizeFlag;
            }
            else
            {
                // we should not be un-setting this bit.
                Debug.Assert(!HasComponentSize);
            }
        }
    }

    public ushort ComponentSize
    {
        get
        {
            return HasComponentSize ? (ushort)_uFlags : (ushort)0;
        }
        set
        {
            Debug.Assert(HasComponentSize);
            _uFlags |= (uint)value;
        }
    }

    public ushort GenericArgumentCount
    {
        get
        {
            Debug.Assert(IsGenericTypeDefinition);
            return ComponentSize;
        }
        set
        {
            Debug.Assert(IsGenericTypeDefinition);
            ComponentSize = value;
        }
    }

    public uint Flags
    {
        get
        {
            return _uFlags;
        }
        set
        {
            _uFlags = value;
        }
    }

    public ushort ExtendedFlags
    {
        get
        {
            return HasComponentSize ? (ushort)0 : (ushort)_uFlags;
        }
        set
        {
            Debug.Assert(!HasComponentSize);
            Debug.Assert(ExtendedFlags == 0);
            _uFlags |= (uint)value;
        }
    }

    public uint BaseSize
    {
        get
        {
            return _uBaseSize;
        }
        set
        {
            _uBaseSize = value;
        }
    }

    public ushort NumVtableSlots
    {
        get
        {
            return _usNumVtableSlots;
        }
        set
        {
            _usNumVtableSlots = value;
        }
    }

    public ushort NumInterfaces
    {
        get
        {
            return _usNumInterfaces;
        }
        set
        {
            _usNumInterfaces = value;
        }
    }

    public uint HashCode
    {
        get
        {
            return _uHashCode;
        }
        set
        {
            _uHashCode = value;
        }
    }

    EETypeKind Kind
    {
        [MethodImpl(Inline)]
        get => (EETypeKind)(_uFlags & (uint)EETypeFlags.EETypeKindMask);
    }

    public bool HasOptionalFields
    {
        [MethodImpl(Inline)]
        get
        {
            return (_uFlags & (uint)EETypeFlags.OptionalFieldsFlag) != 0;
        }
    }

    // Mark or determine that a type is generic and one or more of it's type parameters is co- or
    // contra-variant. This only applies to interface and delegate types.
    public bool HasGenericVariance
    {
        [MethodImpl(Inline)]
        get
        {
            return (_uFlags & (uint)EETypeFlags.GenericVarianceFlag) != 0;
        }
    }

    public bool IsFinalizable
    {
        [MethodImpl(Inline)]
        get
        {
            return (_uFlags & (uint)EETypeFlags.HasFinalizerFlag) != 0;
        }
    }

    public bool IsNullable
    {
        [MethodImpl(Inline)]
        get
        {
            return ElementType == EETypeElementType.Nullable;
        }
    }

    public bool IsCloned
    {
        [MethodImpl(Inline)]
        get
        {
            return Kind == EETypeKind.ClonedEEType;
        }
    }

    public bool IsCanonical
    {
        [MethodImpl(Inline)]
        get
        {
            return Kind == EETypeKind.CanonicalEEType;
        }
    }

    public bool IsString
    {
        [MethodImpl(Inline)]
        get
        {
            // String is currently the only non-array type with a non-zero component size.
            return ComponentSize == StringComponentSize.Value && !IsArray && !IsGenericTypeDefinition;
        }
    }

    public bool IsArray
    {
        [MethodImpl(Inline)]
        get
        {
            EETypeElementType elementType = ElementType;
            return elementType == EETypeElementType.Array || elementType == EETypeElementType.SzArray;
        }
    }


    public int ArrayRank
    {
        [MethodImpl(Inline)]
        get
        {
            Debug.Assert(this.IsArray);

            int boundsSize = (int)this.ParameterizedTypeShape - SZARRAY_BASE_SIZE;
            if (boundsSize > 0)
            {
                // Multidim array case: Base size includes space for two Int32s
                // (upper and lower bound) per each dimension of the array.
                return boundsSize / (2 * sizeof(int));
            }
            return 1;
        }
    }

    public bool IsSzArray
    {
        [MethodImpl(Inline)]
        get
        {
            return ElementType == EETypeElementType.SzArray;
        }
    }

    public bool IsMultiDimensionalArray
    {
        [MethodImpl(Inline)]
        get
        {
            Debug.Assert(HasComponentSize);
            // See comment on RawArrayData for details
            return BaseSize > (uint)(3 * sizeof(IntPtr));
        }
    }

    public bool IsGeneric
    {
        [MethodImpl(Inline)]
        get
        {
            return (_uFlags & (uint)EETypeFlags.IsGenericFlag) != 0;
        }
    }

    public bool IsGenericTypeDefinition
    {
        [MethodImpl(Inline)]
        get
        {
            return Kind == EETypeKind.GenericTypeDefEEType;
        }
    }

    public MethodTable* GenericDefinition
    {
        [MethodImpl(Inline)]
        get
        {
            Debug.Assert(IsGeneric);
            if (IsDynamicType || !SupportsRelativePointers)
                return GetField<IatAwarePointer<MethodTable>>(EETypeField.ETF_GenericDefinition).Value;

            return GetField<IatAwareRelativePointer<MethodTable>>(EETypeField.ETF_GenericDefinition).Value;
        }
        set
        {
            Debug.Assert(IsGeneric && IsDynamicType);
            uint cbOffset = GetFieldOffset(EETypeField.ETF_GenericDefinition);
            fixed (MethodTable* pThis = &this)
            {
                *((MethodTable**)((byte*)pThis + cbOffset)) = value;
            }
        }
    }

    public static int GetGenericCompositionSize(int numArguments, bool hasVariance)
    {
        return IntPtr.Size
            + numArguments * IntPtr.Size
            + (hasVariance ? numArguments * sizeof(GenericVariance) : 0);
    }

    public void SetGenericComposition(IntPtr data)
    {
        Debug.Assert(IsGeneric && IsDynamicType);
        uint cbOffset = GetFieldOffset(EETypeField.ETF_GenericComposition);
        fixed (MethodTable* pThis = &this)
        {
            *((IntPtr*)((byte*)pThis + cbOffset)) = data;
        }
    }

    public uint GenericArity
    {
        get
        {
            Debug.Assert(IsGeneric);
            if (IsDynamicType || !SupportsRelativePointers)
                return GetField<Pointer<GenericComposition>>(EETypeField.ETF_GenericComposition).Value->Arity;

            return GetField<RelativePointer<GenericComposition>>(EETypeField.ETF_GenericComposition).Value->Arity;
        }
        set
        {
            Debug.Assert(IsDynamicType);
            // GenericComposition is a readonly struct, so we just blit the bytes over. Asserts guard changes to the layout.
            *((ushort*)GetField<Pointer<GenericComposition>>(EETypeField.ETF_GenericComposition).Value) = checked((ushort)value);
            Debug.Assert(GenericArity == (ushort)value);
        }
    }

    public EETypeRef* GenericArguments
    {
        get
        {
            Debug.Assert(IsGeneric);
            if (IsDynamicType || !SupportsRelativePointers)
                return GetField<Pointer<GenericComposition>>(EETypeField.ETF_GenericComposition).Value->GenericArguments;

            return GetField<RelativePointer<GenericComposition>>(EETypeField.ETF_GenericComposition).Value->GenericArguments;
        }
    }

    public GenericVariance* GenericVariance
    {
        get
        {
            Debug.Assert(IsGeneric || IsGenericTypeDefinition);

            if (!HasGenericVariance)
                return null;

            if (IsDynamicType || !SupportsRelativePointers)
                return GetField<Pointer<GenericComposition>>(EETypeField.ETF_GenericComposition).Value->GenericVariance;

            return GetField<RelativePointer<GenericComposition>>(EETypeField.ETF_GenericComposition).Value->GenericVariance;
        }
    }

    public bool IsPointerType
    {
        get
        {
            return ElementType == EETypeElementType.Pointer;
        }
    }

    public bool IsByRefType
    {
        get
        {
            return ElementType == EETypeElementType.ByRef;
        }
    }

    public bool IsInterface
    {
        get
        {
            return ElementType == EETypeElementType.Interface;
        }
    }

    public bool IsAbstract
    {
        get
        {
            return IsInterface || (RareFlags & EETypeRareFlags.IsAbstractClassFlag) != 0;
        }
    }

    public bool IsByRefLike
    {
        get
        {
            return (RareFlags & EETypeRareFlags.IsByRefLikeFlag) != 0;
        }
    }

    public bool IsDynamicType
    {
        get
        {
            return (_uFlags & (uint)EETypeFlags.IsDynamicTypeFlag) != 0;
        }
    }

    public bool IsParameterizedType
    {
        get
        {
            return Kind == EETypeKind.ParameterizedEEType;
        }
    }

    // The parameterized type shape defines the particular form of parameterized type that
    // is being represented.
    // Currently, the meaning is a shape of 0 indicates that this is a Pointer,
    // shape of 1 indicates a ByRef, and >=SZARRAY_BASE_SIZE indicates that this is an array.
    // Two types are not equivalent if their shapes do not exactly match.
    public uint ParameterizedTypeShape
    {
        get
        {
            return _uBaseSize;
        }
        set
        {
            _uBaseSize = value;
        }
    }

    public bool IsRelatedTypeViaIAT
    {
        get
        {
            return ((_uFlags & (uint)EETypeFlags.RelatedTypeViaIATFlag) != 0);
        }
    }

    public bool RequiresAlign8
    {
        get
        {
            return (RareFlags & EETypeRareFlags.RequiresAlign8Flag) != 0;
        }
    }

    public bool IsIDynamicInterfaceCastable
    {
        get
        {
            return ((_uFlags & (uint)EETypeFlags.IDynamicInterfaceCastableFlag) != 0);
        }
    }

    public bool IsValueType
    {
        get
        {
            return ElementType < EETypeElementType.Class;
        }
    }

    // Warning! UNLIKE the similarly named Reflection api, this method also returns "true" for Enums.
    public bool IsPrimitive
    {
        get
        {
            return ElementType < EETypeElementType.ValueType;
        }
    }

    public bool ContainsGCPointers
    {
        get
        {
            return ((_uFlags & (uint)EETypeFlags.HasPointersFlag) != 0);
        }
        set
        {
            if (value)
            {
                _uFlags |= (uint)EETypeFlags.HasPointersFlag;
            }
            else
            {
                _uFlags &= (uint)~EETypeFlags.HasPointersFlag;
            }
        }
    }

    public bool IsHFA
    {
        get
        {
            return (RareFlags & EETypeRareFlags.IsHFAFlag) != 0;
        }
    }

    public bool IsTrackedReferenceWithFinalizer
    {
        get
        {
            return (ExtendedFlags & (ushort)EETypeFlagsEx.IsTrackedReferenceWithFinalizerFlag) != 0;
        }
    }

    public uint ValueTypeFieldPadding
    {
        get
        {
            byte* optionalFields = OptionalFieldsPtr;

            // If there are no optional fields then the padding must have been the default, 0.
            if (optionalFields == null)
                return 0;

            // Get the value from the optional fields. The default is zero if that particular field was not included.
            // The low bits of this field is the ValueType field padding, the rest of the byte is the alignment if present
            uint ValueTypeFieldPaddingData = OptionalFieldsReader.GetInlineField(optionalFields, EETypeOptionalFieldTag.ValueTypeFieldPadding, 0);
            uint padding = ValueTypeFieldPaddingData & ValueTypePaddingLowMask;
            // If there is additional padding, the other bits have that data
            padding |= (ValueTypeFieldPaddingData & ValueTypePaddingHighMask) >> (ValueTypePaddingHighShift - ValueTypePaddingAlignmentShift);
            return padding;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    struct ObjHeader
    {
        // Contents of the object header
        IntPtr _objHeaderContents;
    }
    
    public uint ValueTypeSize
    {
        get
        {
            Debug.Assert(IsValueType);
            // get_BaseSize returns the GC size including space for the sync block index field, the MethodTable* and
            // padding for GC heap alignment. Must subtract all of these to get the size used for locals, array
            // elements or fields of another type.
            return BaseSize - ((uint)sizeof(ObjHeader) + (uint)sizeof(MethodTable*) + ValueTypeFieldPadding);
        }
    }

    public uint FieldByteCountNonGCAligned
    {
        get
        {
            // This api is designed to return correct results for EETypes which can be derived from
            // And results indistinguishable from correct for DefTypes which cannot be derived from (sealed classes)
            // (For sealed classes, this should always return BaseSize-((uint)sizeof(ObjHeader));
            Debug.Assert(!IsInterface && !IsParameterizedType);

            // get_BaseSize returns the GC size including space for the sync block index field, the MethodTable* and
            // padding for GC heap alignment. Must subtract all of these to get the size used for the fields of
            // the type (where the fields of the type includes the MethodTable*)
            return BaseSize - ((uint)sizeof(ObjHeader) + ValueTypeFieldPadding);
        }
    }

    public EEInterfaceInfo* InterfaceMap
    {
        get
        {
            fixed (MethodTable* start = &this)
            {
                // interface info table starts after the vtable and has _usNumInterfaces entries
                return (EEInterfaceInfo*)((byte*)start + sizeof(MethodTable) + sizeof(void*) * _usNumVtableSlots);
            }
        }
    }

    public bool HasDispatchMap
    {
        get
        {
            if (NumInterfaces == 0)
                return false;
            byte* optionalFields = OptionalFieldsPtr;

            const uint NoDispatchMap = 0xffffffff;
            uint idxDispatchMap = NoDispatchMap;
            if (optionalFields != null)
                idxDispatchMap = OptionalFieldsReader.GetInlineField(optionalFields, EETypeOptionalFieldTag.DispatchMap, NoDispatchMap);

            if (idxDispatchMap == NoDispatchMap)
            {
                if (IsDynamicType)
                    return DynamicTemplateType->HasDispatchMap;
                return false;
            }
            return true;
        }
    }

    public DispatchMap* DispatchMap
    {
        get
        {
            if (NumInterfaces == 0)
                return null;
            byte* optionalFields = OptionalFieldsPtr;
            const uint NoDispatchMap = 0xffffffff;
            uint idxDispatchMap = NoDispatchMap;
            if (optionalFields != null)
                idxDispatchMap = OptionalFieldsReader.GetInlineField(optionalFields, EETypeOptionalFieldTag.DispatchMap, NoDispatchMap);
            if (idxDispatchMap == NoDispatchMap)
            {
                if (IsDynamicType)
                    return DynamicTemplateType->DispatchMap;
                return null;
            }

            if (SupportsRelativePointers)
                return (DispatchMap*)FollowRelativePointer((int*)TypeManager.DispatchMap + idxDispatchMap);
            else
                return ((DispatchMap**)TypeManager.DispatchMap)[idxDispatchMap];
        }
    }

    // Get the address of the finalizer method for finalizable types.
    public IntPtr FinalizerCode
    {
        get
        {
            Debug.Assert(IsFinalizable);

            if (IsDynamicType || !SupportsRelativePointers)
                return GetField<Pointer>(EETypeField.ETF_Finalizer).Value;

            return GetField<RelativePointer>(EETypeField.ETF_Finalizer).Value;
        }
        set
        {
            Debug.Assert(IsDynamicType && IsFinalizable);

            fixed (MethodTable* pThis = &this)
                *(IntPtr*)((byte*)pThis + GetFieldOffset(EETypeField.ETF_Finalizer)) = value;
        }
    }

    public MethodTable* BaseType
    {
        get
        {
            if (IsCloned)
            {
                return CanonicalEEType->BaseType;
            }

            if (IsParameterizedType)
            {
                if (IsArray)
                    return GetArrayEEType();
                else
                    return null;
            }

            Debug.Assert(IsCanonical);

            if (IsRelatedTypeViaIAT)
                return *_relatedType._ppBaseTypeViaIAT;
            else
                return _relatedType._pBaseType;
        }
        set
        {
            Debug.Assert(IsDynamicType);
            Debug.Assert(!IsParameterizedType);
            Debug.Assert(!IsCloned);
            Debug.Assert(IsCanonical);
            _uFlags &= (uint)~EETypeFlags.RelatedTypeViaIATFlag;
            _relatedType._pBaseType = value;
        }
    }

    public MethodTable* NonArrayBaseType
    {
        get
        {
            Debug.Assert(!IsArray, "array type not supported in BaseType");

            if (IsCloned)
            {
                // Assuming that since this is not an Array, the CanonicalEEType is also not an array
                return CanonicalEEType->NonArrayBaseType;
            }

            Debug.Assert(IsCanonical, "we expect canonical types here");

            if (IsRelatedTypeViaIAT)
            {
                return *_relatedType._ppBaseTypeViaIAT;
            }

            return _relatedType._pBaseType;
        }
    }

    public MethodTable* NonClonedNonArrayBaseType
    {
        get
        {
            Debug.Assert(!IsArray, "array type not supported in NonArrayBaseType");
            Debug.Assert(!IsCloned, "cloned type not supported in NonClonedNonArrayBaseType");
            Debug.Assert(IsCanonical || IsGenericTypeDefinition, "we expect canonical types here");

            if (IsRelatedTypeViaIAT)
            {
                return *_relatedType._ppBaseTypeViaIAT;
            }

            return _relatedType._pBaseType;
        }
    }

    public MethodTable* RawBaseType
    {
        get
        {
            Debug.Assert(!IsParameterizedType, "array type not supported in NonArrayBaseType");
            Debug.Assert(!IsCloned, "cloned type not supported in NonClonedNonArrayBaseType");
            Debug.Assert(IsCanonical, "we expect canonical types here");
            Debug.Assert(!IsRelatedTypeViaIAT, "Non IAT");

            return _relatedType._pBaseType;
        }
    }

    public MethodTable* CanonicalEEType
    {
        get
        {
            // cloned EETypes must always refer to types in other modules
            Debug.Assert(IsCloned);
            if (IsRelatedTypeViaIAT)
                return *_relatedType._ppCanonicalTypeViaIAT;
            else
                return _relatedType._pCanonicalType;
        }
    }

    public MethodTable* NullableType
    {
        get
        {
            Debug.Assert(IsNullable);
            Debug.Assert(GenericArity == 1);
            return GenericArguments[0].Value;
        }
    }

    /// <summary>
    /// Gets the offset of the value embedded in a Nullable&lt;T&gt;.
    /// </summary>
    public byte NullableValueOffset
    {
        get
        {
            Debug.Assert(IsNullable);

            // Grab optional fields. If there aren't any then the offset was the default of 1 (immediately after the
            // Nullable's boolean flag).
            byte* optionalFields = OptionalFieldsPtr;
            if (optionalFields == null)
                return 1;

            // The offset is never zero (Nullable has a boolean there indicating whether the value is valid). So the
            // offset is encoded - 1 to save space. The zero below is the default value if the field wasn't encoded at
            // all.
            return (byte)(OptionalFieldsReader.GetInlineField(optionalFields, EETypeOptionalFieldTag.NullableValueOffset, 0) + 1);
        }
    }

    public MethodTable* RelatedParameterType
    {
        get
        {
            Debug.Assert(IsParameterizedType);

            if (IsRelatedTypeViaIAT)
                return *_relatedType._ppRelatedParameterTypeViaIAT;
            else
                return _relatedType._pRelatedParameterType;
        }
        set
        {
            Debug.Assert(IsDynamicType && IsParameterizedType);
            _uFlags &= ((uint)~EETypeFlags.RelatedTypeViaIATFlag);
            _relatedType._pRelatedParameterType = value;
        }
    }

    static IntPtr FollowRelativePointer(int* pDist)
    {
        int dist = *pDist;
        IntPtr result = (IntPtr)((byte*)pDist + dist);
        return result;
    }

    public void* GetSealedVirtualTable()
    {
        Debug.Assert((RareFlags & EETypeRareFlags.HasSealedVTableEntriesFlag) != 0);

        uint cbSealedVirtualSlotsTypeOffset = GetFieldOffset(EETypeField.ETF_SealedVirtualSlots);
        byte* pThis = (byte*)Unsafe.AsPointer(ref this);
        if (IsDynamicType || !SupportsRelativePointers)
        {
            return *(void**)(pThis + cbSealedVirtualSlotsTypeOffset);
        }
        else
        {
            return (void*)FollowRelativePointer((int*)(pThis + cbSealedVirtualSlotsTypeOffset));
        }
    }

    public IntPtr GetSealedVirtualSlot(ushort slotNumber)
    {
        void* pSealedVtable = GetSealedVirtualTable();
        if (!SupportsRelativePointers)
        {
            return ((IntPtr*)pSealedVtable)[slotNumber];
        }
        else
        {
            return FollowRelativePointer(&((int*)pSealedVtable)[slotNumber]);
        }
    }

    public byte* OptionalFieldsPtr
    {
        get
        {
            if (!HasOptionalFields)
                return null;

            if (IsDynamicType || !SupportsRelativePointers)
                return GetField<Pointer<byte>>(EETypeField.ETF_OptionalFieldsPtr).Value;

            return GetField<RelativePointer<byte>>(EETypeField.ETF_OptionalFieldsPtr).Value;
        }
        set
        {
            Debug.Assert(IsDynamicType);

            _uFlags |= (uint)EETypeFlags.OptionalFieldsFlag;

            uint cbOptionalFieldsOffset = GetFieldOffset(EETypeField.ETF_OptionalFieldsPtr);
            fixed (MethodTable* pThis = &this)
            {
                *(byte**)((byte*)pThis + cbOptionalFieldsOffset) = value;
            }
        }
    }

    public MethodTable* DynamicTemplateType
    {
        get
        {
            Debug.Assert(IsDynamicType);
            uint cbOffset = GetFieldOffset(EETypeField.ETF_DynamicTemplateType);
            fixed (MethodTable* pThis = &this)
            {
                return *(MethodTable**)((byte*)pThis + cbOffset);
            }
        }
        set
        {
            Debug.Assert(IsDynamicType);
            uint cbOffset = GetFieldOffset(EETypeField.ETF_DynamicTemplateType);
            fixed (MethodTable* pThis = &this)
            {
                *(MethodTable**)((byte*)pThis + cbOffset) = value;
            }
        }
    }

    public IntPtr DynamicGcStaticsData
    {
        get
        {
            Debug.Assert((RareFlags & EETypeRareFlags.IsDynamicTypeWithGcStatics) != 0);
            uint cbOffset = GetFieldOffset(EETypeField.ETF_DynamicGcStatics);
            fixed (MethodTable* pThis = &this)
            {
                return *(IntPtr*)((byte*)pThis + cbOffset);
            }
        }
        set
        {
            Debug.Assert((RareFlags & EETypeRareFlags.IsDynamicTypeWithGcStatics) != 0);
            uint cbOffset = GetFieldOffset(EETypeField.ETF_DynamicGcStatics);
            fixed (MethodTable* pThis = &this)
            {
                *(IntPtr*)((byte*)pThis + cbOffset) = value;
            }
        }
    }

    public IntPtr DynamicNonGcStaticsData
    {
        get
        {
            Debug.Assert((RareFlags & EETypeRareFlags.IsDynamicTypeWithNonGcStatics) != 0);
            uint cbOffset = GetFieldOffset(EETypeField.ETF_DynamicNonGcStatics);
            fixed (MethodTable* pThis = &this)
            {
                return *(IntPtr*)((byte*)pThis + cbOffset);
            }
        }
        set
        {
            Debug.Assert((RareFlags & EETypeRareFlags.IsDynamicTypeWithNonGcStatics) != 0);
            uint cbOffset = GetFieldOffset(EETypeField.ETF_DynamicNonGcStatics);
            fixed (MethodTable* pThis = &this)
            {
                *(IntPtr*)((byte*)pThis + cbOffset) = value;
            }
        }
    }

    public IntPtr DynamicThreadStaticsIndex
    {
        get
        {
            Debug.Assert((RareFlags & EETypeRareFlags.IsDynamicTypeWithThreadStatics) != 0);
            uint cbOffset = GetFieldOffset(EETypeField.ETF_DynamicThreadStaticOffset);
            fixed (MethodTable* pThis = &this)
            {
                return *(IntPtr*)((byte*)pThis + cbOffset);
            }
        }
        set
        {
            Debug.Assert((RareFlags & EETypeRareFlags.IsDynamicTypeWithThreadStatics) != 0);
            uint cbOffset = GetFieldOffset(EETypeField.ETF_DynamicThreadStaticOffset);
            fixed (MethodTable* pThis = &this)
            {
                *(IntPtr*)((byte*)pThis + cbOffset) = value;
            }
        }
    }

    public TypeManagerHandle TypeManager
    {
        get
        {
            IntPtr typeManagerIndirection;
            if (IsDynamicType || !SupportsRelativePointers)
                typeManagerIndirection = GetField<Pointer>(EETypeField.ETF_TypeManagerIndirection).Value;
            else
                typeManagerIndirection = GetField<RelativePointer>(EETypeField.ETF_TypeManagerIndirection).Value;

            return *(TypeManagerHandle*)typeManagerIndirection;
        }
    }
    public IntPtr PointerToTypeManager
    {
        get
        {
            if (IsDynamicType || !SupportsRelativePointers)
                return GetField<Pointer>(EETypeField.ETF_TypeManagerIndirection).Value;

            return GetField<RelativePointer>(EETypeField.ETF_TypeManagerIndirection).Value;
        }
        set
        {
            Debug.Assert(IsDynamicType);
            uint cbOffset = GetFieldOffset(EETypeField.ETF_TypeManagerIndirection);
            // This is always a pointer to a pointer to a type manager
            *(TypeManagerHandle**)((byte*)Unsafe.AsPointer(ref this) + cbOffset) = (TypeManagerHandle*)value;
        }
    }

    /// <summary>
    /// Gets a pointer to a segment of writable memory associated with this MethodTable.
    /// The purpose of the segment is controlled by the class library. The runtime doesn't
    /// use this memory for any purpose.
    /// </summary>
    public IntPtr WritableData
    {
        get
        {
            Debug.Assert(SupportsWritableData);

            uint offset = GetFieldOffset(EETypeField.ETF_WritableData);

            if (!IsDynamicType)
                return GetField<RelativePointer>(offset).Value;
            else
                return GetField<Pointer>(offset).Value;
        }
        set
        {
            Debug.Assert(IsDynamicType && SupportsWritableData);

            uint cbOffset = GetFieldOffset(EETypeField.ETF_WritableData);
            *(IntPtr*)((byte*)Unsafe.AsPointer(ref this) + cbOffset) = value;
        }
    }

    public unsafe EETypeRareFlags RareFlags
    {
        get
        {
            // If there are no optional fields then none of the rare flags have been set.
            // Get the flags from the optional fields. The default is zero if that particular field was not included.
            return HasOptionalFields ? (EETypeRareFlags)OptionalFieldsReader.GetInlineField(OptionalFieldsPtr, EETypeOptionalFieldTag.RareFlags, 0) : 0;
        }
    }

    public int FieldAlignmentRequirement
    {
        get
        {
            byte* optionalFields = OptionalFieldsPtr;

            // If there are no optional fields then the alignment must have been the default, IntPtr.Size.
            // (This happens for all reference types, and for valuetypes with default alignment and no padding)
            if (optionalFields == null)
                return IntPtr.Size;

            // Get the value from the optional fields. The default is zero if that particular field was not included.
            // The low bits of this field is the ValueType field padding, the rest of the value is the alignment if present
            uint alignmentValue = (OptionalFieldsReader.GetInlineField(optionalFields, EETypeOptionalFieldTag.ValueTypeFieldPadding, 0) & ValueTypePaddingAlignmentMask) >> ValueTypePaddingAlignmentShift;

            // Alignment is stored as 1 + the log base 2 of the alignment, except a 0 indicates standard pointer alignment.
            if (alignmentValue == 0)
                return IntPtr.Size;
            else
                return 1 << ((int)alignmentValue - 1);
        }
    }

    public EETypeElementType ElementType
    {
        get
        {
            return (EETypeElementType)((_uFlags & (uint)EETypeFlags.ElementTypeMask) >> (byte)EETypeFlags.ElementTypeShift);
        }
        set
        {
            _uFlags = (_uFlags & ~(uint)EETypeFlags.ElementTypeMask) | ((uint)value << (byte)EETypeFlags.ElementTypeShift);
        }
    }

    public bool HasCctor
    {
        get
        {
            return (RareFlags & EETypeRareFlags.HasCctorFlag) != 0;
        }
    }

    public unsafe IntPtr* GetVTableStartAddress()
    {
        byte* pResult;

        // EETypes are always in unmanaged memory, so 'leaking' the 'fixed pointer' is safe.
        fixed (MethodTable* pThis = &this)
            pResult = (byte*)pThis;

        pResult += sizeof(MethodTable);
        return (IntPtr*)pResult;
    }

    public uint GetFieldOffset(EETypeField eField)
    {
        // First part of MethodTable consists of the fixed portion followed by the vtable.
        uint cbOffset = (uint)(sizeof(MethodTable) + (IntPtr.Size * _usNumVtableSlots));

        // Then we have the interface map.
        if (eField == EETypeField.ETF_InterfaceMap)
        {
            Debug.Assert(NumInterfaces > 0);
            return cbOffset;
        }
        cbOffset += (uint)(sizeof(EEInterfaceInfo) * NumInterfaces);

        uint relativeOrFullPointerOffset = (IsDynamicType || !SupportsRelativePointers ? (uint)IntPtr.Size : 4);

        // Followed by the type manager indirection cell.
        if (eField == EETypeField.ETF_TypeManagerIndirection)
        {
            return cbOffset;
        }
        cbOffset += relativeOrFullPointerOffset;

        // Followed by writable data.
        if (SupportsWritableData)
        {
            if (eField == EETypeField.ETF_WritableData)
            {
                return cbOffset;
            }
            cbOffset += relativeOrFullPointerOffset;
        }

        // Followed by the pointer to the finalizer method.
        if (eField == EETypeField.ETF_Finalizer)
        {
            Debug.Assert(IsFinalizable);
            return cbOffset;
        }
        if (IsFinalizable)
            cbOffset += relativeOrFullPointerOffset;

        // Followed by the pointer to the optional fields.
        if (eField == EETypeField.ETF_OptionalFieldsPtr)
        {
            Debug.Assert(HasOptionalFields);
            return cbOffset;
        }
        if (HasOptionalFields)
            cbOffset += relativeOrFullPointerOffset;

        // Followed by the pointer to the sealed virtual slots
        if (eField == EETypeField.ETF_SealedVirtualSlots)
            return cbOffset;

        EETypeRareFlags rareFlags = RareFlags;

        // in the case of sealed vtable entries on static types, we have a UInt sized relative pointer
        if ((rareFlags & EETypeRareFlags.HasSealedVTableEntriesFlag) != 0)
            cbOffset += relativeOrFullPointerOffset;

        if (eField == EETypeField.ETF_GenericDefinition)
        {
            Debug.Assert(IsGeneric);
            return cbOffset;
        }
        if (IsGeneric)
        {
            cbOffset += relativeOrFullPointerOffset;
        }

        if (eField == EETypeField.ETF_GenericComposition)
        {
            Debug.Assert(IsGeneric || (IsGenericTypeDefinition && HasGenericVariance));
            return cbOffset;
        }
        if (IsGeneric || (IsGenericTypeDefinition && HasGenericVariance))
        {
            cbOffset += relativeOrFullPointerOffset;
        }

        if (eField == EETypeField.ETF_DynamicTemplateType)
        {
            Debug.Assert(IsDynamicType);
            return cbOffset;
        }
        if (IsDynamicType)
            cbOffset += (uint)IntPtr.Size;

        if (eField == EETypeField.ETF_DynamicGcStatics)
        {
            Debug.Assert((rareFlags & EETypeRareFlags.IsDynamicTypeWithGcStatics) != 0);
            return cbOffset;
        }
        if ((rareFlags & EETypeRareFlags.IsDynamicTypeWithGcStatics) != 0)
            cbOffset += (uint)IntPtr.Size;

        if (eField == EETypeField.ETF_DynamicNonGcStatics)
        {
            Debug.Assert((rareFlags & EETypeRareFlags.IsDynamicTypeWithNonGcStatics) != 0);
            return cbOffset;
        }
        if ((rareFlags & EETypeRareFlags.IsDynamicTypeWithNonGcStatics) != 0)
            cbOffset += (uint)IntPtr.Size;

        if (eField == EETypeField.ETF_DynamicThreadStaticOffset)
        {
            Debug.Assert((rareFlags & EETypeRareFlags.IsDynamicTypeWithThreadStatics) != 0);
            return cbOffset;
        }

        Debug.Assert(false, "Unknown MethodTable field type");
        return 0;
    }

    public ref T GetField<T>(EETypeField eField)
        => ref Unsafe.As<byte, T>(ref *((byte*)Unsafe.AsPointer(ref this) + GetFieldOffset(eField)));

    public ref T GetField<T>(uint offset)
        => ref Unsafe.As<byte, T>(ref *((byte*)Unsafe.AsPointer(ref this) + offset));

    public static uint GetSizeofEEType(
        ushort cVirtuals,
        ushort cInterfaces,
        bool fHasFinalizer,
        bool fRequiresOptionalFields,
        bool fHasSealedVirtuals,
        bool fHasGenericInfo,
        bool fHasNonGcStatics,
        bool fHasGcStatics,
        bool fHasThreadStatics)
    {
        return (uint)(sizeof(MethodTable) +
            (IntPtr.Size * cVirtuals) +
            (sizeof(EEInterfaceInfo) * cInterfaces) +
            sizeof(IntPtr) + // TypeManager
            (SupportsWritableData ? sizeof(IntPtr) : 0) + // WritableData
            (fHasFinalizer ? sizeof(UIntPtr) : 0) +
            (fRequiresOptionalFields ? sizeof(IntPtr) : 0) +
            (fHasSealedVirtuals ? sizeof(IntPtr) : 0) +
            (fHasGenericInfo ? sizeof(IntPtr)*2 : 0) + // pointers to GenericDefinition and GenericComposition
            (fHasNonGcStatics ? sizeof(IntPtr) : 0) + // pointer to data
            (fHasGcStatics ? sizeof(IntPtr) : 0) +  // pointer to data
            (fHasThreadStatics ? sizeof(IntPtr) : 0)); // threadstatic index cell
    }
}

