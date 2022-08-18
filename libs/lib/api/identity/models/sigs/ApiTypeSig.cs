//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
   using api = ApiSigs;

    public class ApiTypeSig : IExpr
    {
        public readonly @string TypeName;

        public readonly Index<ApiSigMod> Modifiers;

        public readonly Index<ISigTypeParam> Parameters;

        [MethodImpl(Inline)]
        public ApiTypeSig(string name, params ISigTypeParam[] parameters)
        {
            Modifiers = Index<ApiSigMod>.Empty;
            TypeName = name;
            Parameters = parameters;
        }

        [MethodImpl(Inline)]
        public ApiTypeSig(string name, ApiSigMod mod, params ISigTypeParam[] parameters)
        {
            Modifiers = core.array(mod);
            TypeName = name;
            Parameters = parameters;
        }

        [MethodImpl(Inline)]
        public ApiTypeSig(string name, Index<ApiSigMod> modifiers, params ISigTypeParam[] parameters)
        {
            Modifiers = modifiers;
            TypeName = name;
            Parameters = parameters;
        }

        public uint ParameterCount
        {
            [MethodImpl(Inline)]
            get => Parameters.Count;
        }

        public bool IsParametric
        {
            [MethodImpl(Inline)]
            get => ParameterCount != 0;
        }

        public bool IsVoid
        {
            [MethodImpl(Inline)]
            get => TypeName == "void";
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => TypeName.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => TypeName.IsNonEmpty;
        }

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        public static ApiTypeSig Empty
        {
            [MethodImpl(Inline)]
            get => new ApiTypeSig(EmptyString);
        }
    }
}