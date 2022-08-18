//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct LegalIdentityBuilder : IIdentityBuilder<string,OpIdentity>
    {
        [MethodImpl(Inline)]
        public static LegalIdentityBuilder service(LegalIdentityOptions options)
            => new LegalIdentityBuilder(options);

        [Op]
        public static string legalize(in OpIdentity src, in LegalIdentityOptions options)
        {
            var length = src.IdentityText.Length;
            Span<char> dst = stackalloc char[length];
            for(var i=0; i< length; i++)
            {
                var c = src.IdentityText[i];
                switch(c)
                {
                    case IDI.TypeArgsOpen:
                        dst[i] = options.TypeArgsOpen;
                    break;

                    case IDI.TypeArgsClose:
                        dst[i] = options.TypeArgsClose;
                    break;

                    case IDI.ArgsOpen:
                        dst[i] = options.ArgsOpen;
                    break;

                    case IDI.ArgsClose:
                        dst[i] = options.ArgsClose;
                    break;

                    case IDI.ArgSep:
                        dst[i] = options.ArgSep;
                    break;

                    case IDI.ModSep:
                        dst[i] = options.ModSep;
                    break;

                    case IDI.Refines:
                        dst[i] = (char)SymNotKind.Pipe;
                    break;

                    case Chars.Dot:
                        dst[i] = (char)SymNotKind.Dot;
                        break;

                    case Chars.Gt:
                        dst[i] = (char)SymNotKind.Gt;
                        break;

                    case Chars.Lt:
                        dst[i] = (char)SymNotKind.Lt;
                        break;

                    default:
                        dst[i] = c;
                    break;
                }
            }
            return new string(dst.Trim());
        }

        LegalIdentityOptions Options;

        [MethodImpl(Inline)]
        public static string code(OpIdentity src)
            => new LegalIdentityBuilder(CreateCodeOptions()).Build(src);

        [MethodImpl(Inline)]
        public static string file(OpIdentity src)
            => new LegalIdentityBuilder(CreateFileOptions()).Build(src);

        [MethodImpl(Inline)]
        internal LegalIdentityBuilder(LegalIdentityOptions options)
            => Options = options;

        public string Build(OpIdentity src)
            => LegalIdentityBuilder.legalize(src,Options);

        [MethodImpl(Inline)]
        static LegalIdentityOptions CreateFileOptions()
            => new LegalIdentityOptions(
                TypeArgsOpen: Chars.LBracket,
                TypeArgsClose: Chars.RBracket,
                ArgsOpen: Chars.LParen,
                ArgsClose: Chars.RParen,
                ArgSep: Chars.Comma,
                ModSep: IDI.ModSep);

        [MethodImpl(Inline)]
        static LegalIdentityOptions CreateCodeOptions()
            => new LegalIdentityOptions(
            TypeArgsOpen: SymNotKind.Lt.ToChar(),
            TypeArgsClose: SymNotKind.Gt.ToChar(),
            ArgsOpen: SymNotKind.Circle.ToChar(),
            ArgsClose: SymNotKind.Circle.ToChar(),
            ArgSep: SymNotKind.Dot.ToChar(),
            ModSep: (char)SymNotKind.Plus
            );
    }
}