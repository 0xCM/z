//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    
    public class CsBuilders
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


        public static ToolShimSpec bind(CmdArgs args, out ToolShimSpec dst)
        {
            dst.ShimName = CmdArgs.arg(args,0).Value;
            dst.ShimPath = FS.dir(CmdArgs.arg(args,1)) + FS.file(dst.ShimName,FileKind.Exe);
            dst.TargetPath = FS.path(CmdArgs.arg(args,2));
            return dst;
        }

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
            var refs = CsBuilders.perefs(typeof(object), typeof(Enumerable), typeof(ProcessStartInfo));
            var code = new ShimCode(config.ShimPath);
            return CsBuilders.compilation(config.ShimName.Format(), refs, CsBuilders.parse(code.Generate()));
        }
    }
}