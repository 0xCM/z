//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{    
    public readonly struct PdbMethods
    {
        public static PdbMethods load(ISymUnmanagedReader5 reader, ISymUnmanagedDocument doc)
            => new PdbMethods(doc,reader.GetMethodsInDocument(doc));

        public readonly Index<ISymUnmanagedMethod> Methods {get;}

        public readonly ISymUnmanagedDocument Document {get;}

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