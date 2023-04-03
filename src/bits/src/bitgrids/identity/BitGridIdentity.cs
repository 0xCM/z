// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    readonly struct BitGridIdentityProvider : ITypeIdentityProvider
    {
        public TypeIdentity Identify(Type src)
        {
            var kind = src.GridKind().ValueOrDefault();
            if(!kind.IsSome())
                return TypeIdentity.Empty;

            if(src.IsOpenGeneric())
                return TypeIdentity.define(kind.Indicator());

            var closures = src.GridClosures();
            if(!closures.IsSome())
                return TypeIdentity.Empty;

            var sep = IDI.SegSep.ToString();
            var args = closures.NonEmptyCount();

            if(args == 1)
                return TypeIdentity.define(text.concat(kind.Indicator(), closures.T.Format()));
            else if(args == 3)
                return TypeIdentity.define(text.concat(
                        kind.Indicator(), sep,
                        kind.Width().FormatValue(), sep,
                        closures.M.ToString(), sep,
                        closures.N.ToString(), sep,
                        closures.T.Format()
                        ));
            else
                return TypeIdentity.Empty;
        }
    }
}