// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// Reference: D:\env\dev\dotnet\vendor\runtime\src\libraries\System.Reflection.Metadata\tests\Metadata\Decoding\DisassemblingTypeProvider.cs
namespace Z0;

partial class EcmaReader
{
    public class DisassemblingGenericContext
    {
        public DisassemblingGenericContext(ImmutableArray<string> typeParameters, ImmutableArray<string> methodParameters)
        {
            MethodParameters = methodParameters;
            TypeParameters = typeParameters;
        }

        public ImmutableArray<string> MethodParameters { get; }
        
        public ImmutableArray<string> TypeParameters { get; }
    }
}