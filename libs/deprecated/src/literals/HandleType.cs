//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft/.NET Foundation
// License     :  MIT
// Source      : https://github.com/dotnet/runtime/src/libraries/System.Reflection.Metadata
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Reflection.Metadata;
    using System.Reflection.Metadata.Ecma335;

    partial class SRM
    {
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
    }
}