//-----------------------------------------------------------------------------
// Copyright   :  Microsoft
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EcmaReader
    {
        /// <summary>
        /// https://github.com/microsoft/win32metadata/blob/d80feccc5fe7a9f88b8cb65cb3bf75b98f369126/sources/MetadataUtils/GenericSignatureTypeProvider.cs
        /// </summary>
        public class GenericContext
        {
            public GenericContext(ImmutableArray<string> typeParameters, ImmutableArray<string> methodParameters)
            {
                MethodParameters = methodParameters;
                TypeParameters = typeParameters;
            }

            public ImmutableArray<string> MethodParameters { get; }
            
            public ImmutableArray<string> TypeParameters { get; }
        }
    }
}