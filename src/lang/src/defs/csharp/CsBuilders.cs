//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;

    public class CsBuilders
    {
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
            => compilation(name, refs).AddSyntaxTrees(syntax);

        public static EmitResult gen(ToolShimSpec spec)
        {
            var compile = compilation(spec);
            var dst = spec.ShimPath.EnsureParentExists();
            using (var exe = new FileStream(dst.Name, FileMode.Create))
            using (var resources = compile.CreateDefaultWin32Resources(true, true, null, null))
                return compile.Emit(exe, win32Resources: resources);
        }

        static CSharpCompilation compilation(ToolShimSpec config)
        {
            Require.invariant(config.TargetPath.Exists, () => $"The file {config.TargetPath}, it must exist");
            var refs = perefs(typeof(object), typeof(Enumerable), typeof(ProcessStartInfo));
            var code = new ShimCode(config.ShimPath);
            return compilation(config.ShimName.Format(), refs, parse(code.Generate()));
        }
    }
}