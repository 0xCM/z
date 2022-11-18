//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{    
    public class PdbMethods
    {
        public readonly Index<ISymUnmanagedMethod> Methods;

        public readonly ISymUnmanagedDocument Document;

        public PdbMethods(ISymUnmanagedDocument doc, ISymUnmanagedMethod[] methods)
        {
            Document = doc;
            Methods = methods;
        }

        public uint MethodCount
        {
            [MethodImpl(Inline)]
            get => Methods.Count;
        }
    }
}