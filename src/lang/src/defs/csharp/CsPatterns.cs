//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using L = CsLiterals;

    using static CsLiterals;

    [ApiComplete, LiteralProvider]
    public readonly struct CsPatterns
    {
        [MethodImpl(Inline)]
        public static string Term()
            => L.Term;

        [MethodImpl(Inline)]
        public static string Empty()
            => Root.EmptyString;

        [MethodImpl(Inline)]
        public static string Open()
            => L.Open;

        [MethodImpl(Inline)]
        public static string Close()
            => L.Close;

        [MethodImpl(Inline)]
        public static string PublicClass()
            => L.PublicClass;

        [MethodImpl(Inline)]
        public static string Readonly()
            => @readonly;

        public static string UsingNs(string name)
            => string.Format(L.UsingNamespace, name);

        public static string UsingType(string name)
            => string.Format(L.UsingType, name);

        public static string NamespaceDecl(string name)
            => string.Format(L.NamespaceDeclPattern, name);

        [MethodImpl(Inline)]
        public static string Struct(string name)
            => @struct + Space + name;

        [MethodImpl(Inline)]
        public static string ReadonlyStruct()
            => L.ReadOnlyStruct;

        [MethodImpl(Inline)]
        public static string ReadonlyStruct(string name)
            => @readonly + Space + Struct(name);

        [MethodImpl(Inline)]
        public static string PublicReadonlyStruct(string name)
            => @public + Space + ReadonlyStruct(name);

        [MethodImpl(Inline)]
        public static string CustomAttribute(string name)
            => $"[{name}]";

        [MethodImpl(Inline)]
        public static string InlineAttrib()
            => L.InlineAttribute;

        [MethodImpl(Inline)]
        public static string InlineOpAttrib()
            => L.InlineOpAttribute;

        [MethodImpl(Inline)]
        public static string ApiCompleteAttrib()
            => L.ApiCompleteAttribute;

        [MethodImpl(Inline)]
        public static string UsingCompilerServices()
            => L.UsingCompilerServices;

        public static string Constant(string name, byte src)
            => string.Format("public const byte {0} = {1};", name, src);

        public static string Constant(string name, sbyte src)
            => string.Format("public const sbyte {0} = {1};", name, src);

        public static string Constant(string name, short src)
            => string.Format("public const short {0} = {1};", name, src);

        public static string Constant(string name, ushort src)
            => string.Format("public const ushort {0} = {1};", name, src);

        public static string Constant(string name, int src)
            => string.Format("public const int {0} = {1};", name, src);

        public static string Constant(string name, uint src)
            => string.Format("public const uint {0} = {1};", name, src);

        public static string Constant(string name, long src)
            => string.Format("public const long {0} = {1};", name, src);

        public static string Constant(string name, ulong src)
            => string.Format("public const ulong {0} = {1};", name, src);

        public static string Constant(string name, string src)
            => string.Format("public const string {0} = \"{1}\";", name, src);

        public static string Constant(string name, char src)
            => string.Format("public const char {0} = '{1}';", name, src);

        public static string Constant(string name, Enum src)
            => string.Format("public const {0} {1} = {0}.{2};", src.GetType().Name, name, src);

        public static string StaticLambdaProp(string type, string name, string expr)
            => string.Format("public static {0} {1} => {2};", type, name, expr);

        public static string EnumDecl(string name, string @base)
            => string.Format(L.EnumDeclPattern, name, @base);

        public static string PublicOneLineFunc(string ret, string name, string ops, string body)
            => string.Format(L.PublicOneLineFunc, ret, name, ops, body);

        public static string PublicStaticOneLineFunc(string ret, string name, string ops, string body)
            => string.Format(L.PublicStaticOneLineFunc, ret, name, ops, body);

        public static string Call(string method, params object[] args)
            => string.Format("{0}({1})", method, args.Delimit());

        public static RenderPattern<string> ReadOnlySpanTypePattern => "ReadOnlySpan<{0}>";

        public static RenderPattern<string,string> ExpressionBody => "{0} => {1}";
    }
}