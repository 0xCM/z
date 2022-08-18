//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct ApiIdentity
    {
        /// <summary>
        /// Assigns identity a nongeneric value parameter
        /// </summary>
        /// <param name="src">The source parameter</param>
        public static string parameter(ParameterInfo src)
        {
            if(!src.IsParametric())
            {
                var id = src.ParameterType.IsEnum
                    ? identify(src.ParameterType)
                    : identify(src.ParameterType.EffectiveType());

                if(!id.IsEmpty)
                    return text.concat(id.IdentityText, src.RefKind().Format());
            }

            return EmptyString;
        }
    }
}