//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiAtomic;

    [ApiClass, SymSource(api_classes)]
    public enum ApiOpaqueClass : ushort
    {
        None = 0,

        Root = ApiClassKind.Opaque,

        First = Root + 1,

        UnboxObject = First,

        UnboxEnum,

        CreateString,

        Alloc,

        AllocSpan,

        Equals,

        GetInstanceType,

        GetGenericType,

        GetTypeCode,

        GetGenericTypeCode,

        Write,

        Copy,

        CopyBlock,

        GetTypeHandle,

        GetGenericTypeHandle,

        StringToCharSpan,

        CharSpanToString,

        CharPointerToString,

        ClearSpan,

        SpanToArray,

        ParameterArray,

        FillCells,

        FillSpan,

        CopyCellToVoidPointer,

        CopyCellToGenericPointer,

        CopySpan,

        EmptyStringTest,

        ArrayToList,

        ListToArray,

        EnumerableToArray,

        EnumerableToSpan,

        Throw,

        GetFieldConstant,

        GetTypeFields,

        GetTypeProperties,

        GetTypeMethods,

        GetEnumerator,

       MoveNext,

       Current,

       GetEmptyArray,

       GetEnumNames,

      GetEnumValues,

      FormatCharSpan,

      GetEntryAssembly,

      GetCallingAssembly,

      GetCurrentProcess,

      GetCurrentProcessHandle,

      GetFieldValue,

      FillArray,

      CreateDelegate,

      Substring,

      PrepareMethod,

      PrepareDelegate,
    }
}