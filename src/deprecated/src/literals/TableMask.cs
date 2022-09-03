//-----------------------------------------------------------------------------
// Copyright   :  (c) Microsoft/.NET Foundation
// License     :  MIT
// Source      : https://github.com/dotnet/runtime/src/libraries/System.Reflection.Metadata
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection.Metadata.Ecma335;

    partial class SRM
    {
        [Flags]
        public enum TableMask : ulong
        {
            Module = 1UL << TableIndex.Module,

            TypeRef = 1UL << TableIndex.TypeRef,

            TypeDef = 1UL << TableIndex.TypeDef,

            FieldPtr = 1UL << TableIndex.FieldPtr,

            Field = 1UL << TableIndex.Field,

            MethodPtr = 1UL << TableIndex.MethodPtr,

            MethodDef = 1UL << TableIndex.MethodDef,

            ParamPtr = 1UL << TableIndex.ParamPtr,

            Param = 1UL << TableIndex.Param,

            InterfaceImpl = 1UL << TableIndex.InterfaceImpl,

            MemberRef = 1UL << TableIndex.MemberRef,

            Constant = 1UL << TableIndex.Constant,

            CustomAttribute = 1UL << TableIndex.CustomAttribute,

            FieldMarshal = 1UL << TableIndex.FieldMarshal,

            DeclSecurity = 1UL << TableIndex.DeclSecurity,

            ClassLayout = 1UL << TableIndex.ClassLayout,

            FieldLayout = 1UL << TableIndex.FieldLayout,

            StandAloneSig = 1UL << TableIndex.StandAloneSig,

            EventMap = 1UL << TableIndex.EventMap,

            EventPtr = 1UL << TableIndex.EventPtr,

            Event = 1UL << TableIndex.Event,

            PropertyMap = 1UL << TableIndex.PropertyMap,

            PropertyPtr = 1UL << TableIndex.PropertyPtr,

            Property = 1UL << TableIndex.Property,

            MethodSemantics = 1UL << TableIndex.MethodSemantics,

            MethodImpl = 1UL << TableIndex.MethodImpl,

            ModuleRef = 1UL << TableIndex.ModuleRef,

            TypeSpec = 1UL << TableIndex.TypeSpec,

            ImplMap = 1UL << TableIndex.ImplMap,

            FieldRva = 1UL << TableIndex.FieldRva,

            EnCLog = 1UL << TableIndex.EncLog,

            EnCMap = 1UL << TableIndex.EncMap,

            Assembly = 1UL << TableIndex.Assembly,

            AssemblyRef = 1UL << TableIndex.AssemblyRef,

            File = 1UL << TableIndex.File,

            ExportedType = 1UL << TableIndex.ExportedType,

            ManifestResource = 1UL << TableIndex.ManifestResource,

            NestedClass = 1UL << TableIndex.NestedClass,

            GenericParam = 1UL << TableIndex.GenericParam,

            MethodSpec = 1UL << TableIndex.MethodSpec,

            GenericParamConstraint = 1UL << TableIndex.GenericParamConstraint,

            Document = 1UL << TableIndex.Document,

            MethodDebugInformation = 1UL << TableIndex.MethodDebugInformation,

            LocalScope = 1UL << TableIndex.LocalScope,

            LocalVariable = 1UL << TableIndex.LocalVariable,

            LocalConstant = 1UL << TableIndex.LocalConstant,

            ImportScope = 1UL << TableIndex.ImportScope,

            StateMachineMethod = 1UL << TableIndex.StateMachineMethod,

            CustomDebugInformation = 1UL << TableIndex.CustomDebugInformation,

            PtrTables =
                FieldPtr
            | MethodPtr
            | ParamPtr
            | EventPtr
            | PropertyPtr,

            EncTables =
                EnCLog
            | EnCMap,

            TypeSystemTables =
                PtrTables
            | EncTables
            | Module
            | TypeRef
            | TypeDef
            | Field
            | MethodDef
            | Param
            | InterfaceImpl
            | MemberRef
            | Constant
            | CustomAttribute
            | FieldMarshal
            | DeclSecurity
            | ClassLayout
            | FieldLayout
            | StandAloneSig
            | EventMap
            | Event
            | PropertyMap
            | Property
            | MethodSemantics
            | MethodImpl
            | ModuleRef
            | TypeSpec
            | ImplMap
            | FieldRva
            | Assembly
            | AssemblyRef
            | File
            | ExportedType
            | ManifestResource
            | NestedClass
            | GenericParam
            | MethodSpec
            | GenericParamConstraint,

            DebugTables =
                Document
            | MethodDebugInformation
            | LocalScope
            | LocalVariable
            | LocalConstant
            | ImportScope
            | StateMachineMethod
            | CustomDebugInformation,

            AllTables =
                TypeSystemTables |
                DebugTables,

            ValidPortablePdbExternalTables =
                TypeSystemTables & ~PtrTables & ~EncTables
        }
    }
}