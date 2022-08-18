//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct ApiIdentity
    {
        /// <summary>
        /// Assigns identity to a delegate
        /// </summary>
        /// <param name="src">The source delegate</param>
        [Op]
        public static OpIdentity identify(Delegate src)
            => identify(src.Method);

        /// <summary>
        /// Assigns identity to a type
        /// </summary>
        /// <param name="src">The source type</param>
        [Op]
        public static TypeIdentity identify(Type src)
            => TypeIdentityDiviner.IdentityProvider(src).Identify(src);

        /// <summary>
        /// Assigns host-independent identity to an api member
        /// </summary>
        /// <param name="src">The source method</param>
        [Op]
        public static OpIdentity identify(MethodInfo src)
        {
            if(src.IsOpenGeneric())
                return generic(src).Generalize();
            else if(src.IsConversionOperator())
                return conversion(src);
            else if(src.IsConstructedGenericMethod)
                return constructed(src);
            else
                return nongeneric(src);
        }

        [Op]
        static OpIdentity identify(MethodInfo src, NumericKind k)
        {
            var t = k.ToSystemType();
            if(src.IsOpenGeneric() && t.IsNonEmpty())
                return identify(src.MakeGenericMethod(t));
            else
                return identify(src);
        }
    }
}