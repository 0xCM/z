//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public sealed class ClrMethodArtifact : IClrArtifact
    {
        [Op]
        public static string format(in ClrTypeSigInfo src)
        {
            const string P0 = "{0}{1}[]";
            const string P1 = "{0}{1}*";
            const string P2 = "{0}{1}";
            var pattern = P2;
            if(src.IsArray)
                pattern = P0;
            else if(src.IsPointer)
                pattern = P1;
            return string.Format(pattern, src.Modifier, src.DisplayName);
        }

        [Op]
        public static string format(in ClrParamInfo src)
            => string.Format("{0} {1}", format(src.Type), src.Name);

        public static string format(in ClrMethodArtifact src)
        {
            var dst = text.buffer();
            dst.Append(format(src.ReturnType));
            dst.Append(Chars.Space);
            dst.Append(text.replace(src.MethodName, Chars.Pipe, Chars.Caret));
            dst.Append(Chars.LParen);
            var parameters = src.Args.View;
            var count = parameters.Length;
            for(var i=0; i<count; i++)
            {
                dst.Append(format(skip(parameters,i)));
                if(i != count - 1)
                {
                    dst.Append(Chars.Comma);
                    dst.Append(Chars.Space);
                }
            }

            dst.Append(Chars.RParen);
            return dst.Emit();
        }

        public ClrMethodArtifact()
        {
            Id = CliToken.Empty;
            MethodName = EmptyString;
            DefiningAssembly = ClrAssemblyName.Empty;
            DefiningModule = EmptyString;
            DeclaringType = ClrTypeSigInfo.Empty;
            ReturnType = ClrTypeSigInfo.Empty;
            Args = sys.empty<ClrParamInfo>();
            TypeParameters = sys.empty<string>();
        }

        public CliToken Id;

        public @string MethodName;

        public ClrAssemblyName DefiningAssembly;

        public @string DefiningModule;

        public ClrTypeSigInfo DeclaringType;

        public ClrTypeSigInfo ReturnType;

        public Index<ClrParamInfo> Args;

        public Index<string> TypeParameters;

        public MethodDisplaySig DisplaySig
            => new MethodDisplaySig(format(this));

        CliToken IClrArtifact.Token
            => Id;

        string IClrArtifact.Name
            => MethodName;

        public ClrArtifactKind Kind
            => ClrArtifactKind.Method;
        public string Format()
            => DisplaySig.Format();

        public override string ToString()
            => Format();

        public static ClrMethodArtifact Empty
            => new();
    }
}