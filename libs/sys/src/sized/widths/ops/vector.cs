//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = NativeVectorWidth;

    partial class Widths
    {
        [MethodImpl(Inline)]
        public static NativeVectorWidth vector<W>(W w = default)
            where W : struct, IVectorWidth
        {
            if(typeof(W) == typeof(W128))
                return K.W128;
            else if(typeof(W) == typeof(W256))
                return K.W256;
            else if(typeof(W) == typeof(W512))
                return K.W512;
            else
                return 0;
        }

        /// <summary>
        /// Determines the width of a system-defined or custom intrinsic vector type
        /// </summary>
        /// <param name="t">The source type</param>
        [Op]
        public static NativeTypeWidth vector(Type t)
        {
            var eff = t.TEffective();
            var def = eff.IsGenericType
                ? eff.GetGenericTypeDefinition()
                : (eff.IsGenericTypeDefinition ? eff : null);

            if(def == null)
                return NativeTypeWidth.None;
            else if(def == typeof(Vector128<>))
                return NativeTypeWidth.W128;
            else if(def == typeof(Vector256<>))
                return NativeTypeWidth.W256;
            else
                return t.Tag<VectorAttribute>().MapValueOrDefault(a => a.TypeWidth, NativeTypeWidth.None);
        }
    }
}