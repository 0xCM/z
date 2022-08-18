//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [LiteralProvider]
    public readonly struct CsLiterals
    {
        public const string @struct = "struct";

        public const string @public = "public";

        public const string @static = "static";

        public const string @readonly = "readonly";

        public const string @using = "using";

        public const string @namespace = "namespace";

        public const string @class = "class";

        public const string @enum = "enum";

        public const string @short = "short";

        public const string @ushort = "ushort";

        public const string @byte = "byte";

        public const string @sbyte = "sbyte";

        public const string @string = "string";

        public const string Open = "{";

        public const string Close = "}";

        public const string Term = ";";

        public const string Space = " ";

        public const string NamespaceDeclPattern = @namespace + Space + "{0}";

        public const string UsingStatic = @using + Space + @static;

        public const string UsingNamespace = @using + Space + "{0}" + Term;

        public const string UsingType = UsingStatic + Space + "{0}" + Term;

        public const string InlineAttribute = "[MethodImpl(Inline)]";

        public const string InlineOpAttribute = "[MethodImpl(Inline), Op]";

        public const string ApiCompleteAttribute = "[ApiComplete]";

        public const string PublicClass = @public + Space + @class;

        public const string ReadOnlyStruct = @readonly + Space + @struct;

        public const string UsingCompilerServices = "using System.Runtime.CompilerServices;";

        public const string OneLineFunc = "{0} {1}({2}) => {3}" + Term;

        public const string StaticOneLineFunc = @static + Space + OneLineFunc;

        public const string PublicStaticOneLineFunc = @public + Space + StaticOneLineFunc;

        public const string PublicOneLineFunc = @public + Space + OneLineFunc;

        public const string EnumDeclPattern = "public enum {0} : {1}";
    }
}