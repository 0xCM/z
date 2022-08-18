//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Text;
    using System.IO;

    using static core;

    public class CodeGenerator
    {
        const string HeaderLine1 = "//-----------------------------------------------------------------------------";

        const string HeaderLine2 = "// Copyright   :  (c) Chris Moore, 2021";

        const string HeaderLine3 = "// License     :  MIT";

        const string HeaderLine4 = "// Generated   : {0:yyyy-MM-dd H:mm:ss zzz}";

        const string HeaderLine5 = "//-----------------------------------------------------------------------------";

        public const string Level0 = "";

        public const string Level1 = "    ";

        public const string Level2 = Level1 + Level1;

        public const string Level3 = Level2 + Level1;

        public const string InlineTag = "[MethodImpl(Inline)]";

        public const string ImplicitOp ="public static implicit operator ";

        public const int FileLevel = 0;

        public const int TypeLevel = 1;

        public const int MemberLevel = 2;

        public static string bracket(object content)
            => text.bracket(content);

        public static string args(params object[] src)
            => string.Join(Chars.Comma,src);

        public static string attrib(string name, params object[] arguments)
            => arguments.Length == 0
            ? bracket(name)
            : bracket(string.Concat(name, Chars.LParen, args(arguments), Chars.RParen));

        protected CodeGenerator()
        {

        }

        public static string level(int l, params object[] src)
            => l switch {
                1 => l1(src),
                2 => l2(src),
                3 => l3(src),
                _ => l0(src),
            };

        public static string spaced(params object[] src)
            => string.Join(Space, src);

        public static string l0(params object[] src)
            => text.concat(src);

        public static string l1(params object[] src)
            => Level1 + text.concat(src);

        public static string l2(params object[] src)
            => Level2 + text.concat(src);

        public static string l3(params object[] src)
            => Level3 + text.concat(src);

        public static string usingNs(int n, string ns)
            => level(n, text.concat("using", Space, ns, Chars.Semicolon));

        public static  string usingType(int n, string type)
            => level(n, text.concat("using static", Space, type, Chars.Semicolon));

        protected string concat(params object[] src)
            => text.concat(src);

        public static void line(string src, StringBuilder dst)
            => dst.AppendLine(src);

        public static void lines(IEnumerable<string> src, StringBuilder dst)
            => iter(src,l => line(l,dst));

        public static string assign(object dst, object src)
            => text.concat(dst, Space, Chars.Eq, Space, src);

        public virtual string Generate()
            => string.Empty;

        public static string Comment(object src, int l)
            => level(l,$"// {src}");

        public static string TypeComment(object src, int l = TypeLevel)
            => level(TypeLevel,$"// {src}");

        public static string MemberComment(object src, int l = MemberLevel)
            => level(TypeLevel,$"// {src}");

        public static string[] DefaultNamspaces {get;}
            = new string[]{
                "System",
                "System.Runtime.CompilerServices",
            };

        public static string[] DefaultTypes {get;}
            = new string[]{ };

        protected virtual string[] StaticUsings
            => DefaultTypes;

        public static string FileHeader
            => text.join(
                Eol,
                HeaderLine1,
                HeaderLine2,
                HeaderLine3,
                string.Format(HeaderLine4, now()),
                HeaderLine5);

        public static void EmitFileHeader(TextWriter dst)
        {
            dst.Write(FileHeader);
        }

        public static void OpenFileNamespace(TextWriter dst, string ns = "Z0")
        {
            dst.WriteLine(string.Concat("namespace ", ns));
            dst.WriteLine(Chars.LBrace);
        }

        public static void CloseFileNamespace(TextWriter dst)
        {
            dst.WriteLine(Chars.RBrace);
        }

        public static void OpenStructDeclaration(TextWriter dst, string name, params string[] modifiers)
        {
            dst.WriteLine(level(TypeLevel, text.concat($"{spaced(modifiers)} struct {name}")));
            dst.WriteLine(level(TypeLevel, Chars.LBrace));
        }

        public static void OpenClassDeclaration(TextWriter dst, string name, params string[] modifiers)
        {
            dst.WriteLine(level(TypeLevel, text.concat($"{spaced(modifiers)} class {name}")));
            dst.WriteLine(level(TypeLevel, Chars.LBrace));
        }

        public static void DeclareStaticClass(TextWriter dst, string name, bool @public = true)
            => OpenClassDeclaration(dst,name, @public ? "public" : EmptyString, "static");

        public static void CloseTypeDeclaration(TextWriter dst, int l = TypeLevel)
        {
            dst.WriteLine(level(l, Chars.RBrace));
        }

        public static void EmitUsingStatements(TextWriter dst, int l = TypeLevel)
        {
            for(var j=0; j<DefaultNamspaces.Length; j++)
                dst.WriteLine(usingNs(l, DefaultNamspaces[j]));

            dst.WriteLine();

            for(var j=0; j<DefaultTypes.Length; j++)
                dst.WriteLine(usingType(l, DefaultTypes[j]));

            dst.WriteLine();
        }

        public static void EmitMember(TextWriter dst, object definition, int l = MemberLevel)
        {
            dst.WriteLine(level(l, definition));
            dst.WriteLine();
        }
    }
}