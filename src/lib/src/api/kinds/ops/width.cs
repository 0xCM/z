//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using TW = NativeTypeWidth;

    partial class VK
    {
        [Op]
        public static TW width(Type t)
        {
            var eff = t.EffectiveType();
            var def = eff.IsGenericType
                    ? eff.GetGenericTypeDefinition()
                    : (eff.IsGenericTypeDefinition ? eff : null);

            if(def != null)
            {
                if(def == typeof(Vector128<>))
                    return TW.W128;
                else if(def == typeof(Vector256<>))
                    return TW.W256;
                else if(def == typeof(Vector512<>))
                    return TW.W512;
            }

            return TW.None;
        }
    }
}