//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Ecma
    {
        [EcmaRow(TableIndex.TypeRef), StructLayout(LayoutKind.Sequential, Pack =1)]
        public struct TypeRefRow : IEcmaRow<TypeRefRow>
        {
            [Render(12)]
            public EcmaToken Index;

            /// <summary>
            /// ResolutionScope (an index into a Module, ModuleRef, AssemblyRef or TypeRef table, or null; more precisely, a ResolutionScope
            /// </summary>
            [Render(16)]
            public EcmaToken ResolutionScope;

            [Render(16)]
            public EcmaStringKey TypeName;

            [Render(16)]
            public EcmaStringKey TypeNamespace;

            const string ResoltionScopeDescription = 
                @"ResolutionScope shall be exactly one of:
                * null - in this case, there shall be a row in the ExportedType table for this Type - its Implementation field shall contain a File token or an AssemblyRef token that says where the type is defined [ERROR]
                * a TypeRef token, if this is a nested type (which can be determined by, for example, inspecting the Flags column in its TypeDef table - the accessibility subfield is one of the tdNestedXXX set) [ERROR]
                * a ModuleRef token, if the target type is defined in another module within the same Assembly as this one [ERROR]
                * a Module token, if the target type is defined in the current module - this should not occur in a CLI (“compressed metadata”) module [WARNING] an AssemblyRef token, if the target type is defined in a different Assembly from the current module [ERROR]";

        }        


    }
}