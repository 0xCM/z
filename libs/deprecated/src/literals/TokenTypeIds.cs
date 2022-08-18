//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft/.NET Foundation
// License     :  MIT
// Source      : https://github.com/dotnet/runtime/src/libraries/System.Reflection.Metadata
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class SRM
    {
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
                => (vToken & TypeMask) <= UserString;

            public static bool IsEntityToken(uint vToken)
                => (vToken & TypeMask) < UserString;

            public static bool IsValidRowId(uint rowId)
                => (rowId & ~RIDMask) == 0;

            public static bool IsValidRowId(int rowId)
                => (rowId & ~RIDMask) == 0;
        }
    }
}