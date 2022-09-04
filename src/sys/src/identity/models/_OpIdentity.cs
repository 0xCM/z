//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Specifies host-independent api member identity
    /// </summary>
    public class _OpIdentity : IMethodIdentity<_OpIdentity>
    {
        /// <summary>
        /// Determines whether a type is classified as an intrinsic vector
        /// </summary>
        /// <param name="t">The type to test</param>
        [Op]
        public static bool IsVector(Type t)
        {
            var eff = t.EffectiveType();
            var def = eff.IsGenericType ? eff.GetGenericTypeDefinition() : (eff.IsGenericTypeDefinition ? eff : null);
            if(def == null)
                return false;

            return def == typeof(Vector128<>) || def == typeof(Vector256<>) || def.Tagged<VectorAttribute>();
        }

        public static string safe(string src)
            => (src ?? EmptyString).Replace(Chars.Lt, IDI.TypeArgsOpen).Replace(Chars.Gt, IDI.TypeArgsClose).Replace(Chars.Pipe, Chars.Caret);

        public static _OpIdentity define(string src)
            => new _OpIdentity(safe(src));

        /// <summary>
        /// The operation identifier
        /// </summary>
        public string IdentityText {get;}

        /// <summary>
        /// The unqualified operation name
        /// </summary>
        public string Name {get;}

        /// <summary>
        /// The identifier suffix, if any
        /// </summary>
        public string Suffix {get;}

        /// <summary>
        /// Specifies whether the operation was reified from a generic definition
        /// </summary>
        public bool IsGeneric {get;}

        /// <summary>
        /// Specifies whether the operation is specialized for an immediate value
        /// </summary>
        public bool HasImm {get;}

        /// <summary>
        /// The moniker parts, as determined by part delimiters
        /// </summary>
        public string[] Components {get;}

        public _OpIdentity(string data, string name, string suffix, bool generic, bool imm, string[] components)
        {
            IdentityText = data;
            Name = name;
            Suffix = suffix;
            IsGeneric = generic;
            HasImm = imm;
            Components = components;
        }

        [MethodImpl(Inline)]
        public _OpIdentity(string data)
        {
            IdentityText = data;
            Name = EmptyString;
            Suffix = EmptyString;
            IsGeneric = false;
            HasImm = false;
            Components = Array.Empty<string>();
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => string.IsNullOrEmpty(IdentityText);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !string.IsNullOrEmpty(IdentityText);
        }

        public override int GetHashCode()
            => IdentityText.GetHashCode();

        public bool Equals(_OpIdentity src)
            => string.Equals(IdentityText, src.IdentityText, StringComparison.InvariantCultureIgnoreCase);

        public override bool Equals(object src)
            => src is _OpIdentity x && Equals(x);

        public string Format()
            => IdentityText;

        public override string ToString()
            => IdentityText;

        [MethodImpl(Inline)]
        public static implicit operator string(_OpIdentity src)
            => src.IdentityText;

        [MethodImpl(Inline)]
        public static bool operator==(_OpIdentity a, _OpIdentity b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator!=(_OpIdentity a, _OpIdentity b)
            => !a.Equals(b);

        public static _OpIdentity Empty
            => new _OpIdentity(EmptyString);
    }
}