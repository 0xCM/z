//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class JsonDeps
    {
        public record struct Options
        {
            public Seq<string> Defines;

            public string LanguageVersion;

            public string Platform;

            public bool? AllowUnsafe;

            public bool? WarningsAsErrors;

            public bool? Optimize;

            public string KeyFile;

            public bool? DelaySign;

            public bool? PublicSign;

            public string DebugType;

            public bool? EmitEntryPoint;

            public bool? GenerateXmlDocumentation;

            public static Options Empty
            {
                get
                {
                    var dst = default(Options);
                    dst.Defines = sys.empty<string>();
                    return dst;
                }
            }
        }
    }
}