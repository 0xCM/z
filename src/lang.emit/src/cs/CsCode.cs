//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CsCode : WfSvc<CsCode>
    {
        public static PortableExecutableReference peref<T>()
            => PortableExecutableReference.CreateFromFile(typeof(T).Assembly.Location);

        public static PortableExecutableReference peref(Type src)
            => PortableExecutableReference.CreateFromFile(src.Assembly.Location);

        public static PortableExecutableReference[] perefs(params Type[] src)
            => src.Select(peref);

        public static SyntaxTree parse(string src)
            => CSharpSyntaxTree.ParseText(src);

        public static CSharpCompilation compilation(string name)
            => CSharpCompilation.Create(name);

        [Op]
        public static CSharpCompilation compilation(Identifier name, MetadataReference[] refs)
            => compilation(name).AddReferences(refs);

        [Op]
        public static CSharpCompilation compilation(Identifier name, MetadataReference[] refs, params SyntaxTree[] syntax)
            => compilation(name,refs).AddSyntaxTrees(syntax);
    }
}