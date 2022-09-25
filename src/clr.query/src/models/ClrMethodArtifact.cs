//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public sealed class ClrMethodArtifact : IClrArtifact
    {
        [Op]
        public static ClrTypeSigInfo siginfo(ParameterInfo src)
        {
            var dst = new ClrTypeSigInfo();
            var type = src.ParameterType;
            dst.DisplayName = type.HasElementType ? type.ElementType().DisplayName() : type.EffectiveType().DisplayName();
            dst.IsOpenGeneric = type.IsGenericType && !type.IsConstructedGenericType;
            dst.IsClosedGeneric = type.IsConstructedGenericType;
            dst.IsByRef = type.IsRef();
            dst.IsIn = src.IsIn;
            dst.IsOut = src.IsOut;
            dst.IsPointer = type.IsPointer;
            dst.Modifier = dst.IsIn ? "in " : dst.IsOut ? "out " : dst.IsByRef ? "ref " : EmptyString;
            dst.IsArray = type.IsArray;
            return dst;
        }

        [Op]
        public static ClrTypeSigInfo siginfo(Type type)
        {
            var dst = new ClrTypeSigInfo();
            dst.DisplayName = type.HasElementType ? type.ElementType().DisplayName() : type.EffectiveType().DisplayName();
            dst.IsOpenGeneric = type.IsGenericType && !type.IsConstructedGenericType;
            dst.IsClosedGeneric = type.IsConstructedGenericType;
            dst.IsByRef = type.IsRef();
            dst.IsIn = false;
            dst.IsOut = false;
            dst.IsPointer = type.IsPointer;
            dst.Modifier = dst.IsIn ? "in " : dst.IsOut ? "out " : dst.IsByRef ? "ref " : EmptyString;
            dst.IsArray = type.IsArray;
            return dst;
        }

        /// <summary>
        /// Derives a signature from reflected method metadata
        /// </summary>
        /// <param name="src">The source method</param>
        [Op]
        public static ClrMethodArtifact from(MethodInfo src)
        {
            var dst = new ClrMethodArtifact();
            dst.Id = src.MetadataToken;
            dst.MethodName = src.DisplayName();
            dst.DefiningAssembly = src.Module.Assembly;
            dst.DefiningModule = src.Module.Name;
            dst.DeclaringType = siginfo(src.DeclaringType);
            dst.ReturnType = siginfo(src.ReturnType);
            dst.Args = src.GetParameters().Select(p => new ClrParamInfo(siginfo(p), p.RefKind(), p.Name, (ushort)p.Position));
            dst.TypeParameters = src.GenericParameters(false).Mapi((i,t) => t.DisplayName());
            return dst;
        }

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
            Id = EcmaToken.Empty;
            MethodName = EmptyString;
            DefiningAssembly = ClrAssemblyName.Empty;
            DefiningModule = EmptyString;
            DeclaringType = ClrTypeSigInfo.Empty;
            ReturnType = ClrTypeSigInfo.Empty;
            Args = sys.empty<ClrParamInfo>();
            TypeParameters = sys.empty<string>();
        }

        public EcmaToken Id;

        public @string MethodName;

        public ClrAssemblyName DefiningAssembly;

        public @string DefiningModule;

        public ClrTypeSigInfo DeclaringType;

        public ClrTypeSigInfo ReturnType;

        public Index<ClrParamInfo> Args;

        public Index<string> TypeParameters;

        public MethodDisplaySig DisplaySig
            => new MethodDisplaySig(format(this));

        EcmaToken IClrArtifact.Token
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