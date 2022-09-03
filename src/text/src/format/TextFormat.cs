//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public class TextFormat
    {
        [Op]
        public static ITextBuffer buffer()
            => new TextBuffer(new StringBuilder());

        [Op]
        public static ITextBuffer buffer(StringBuilder src)
            => new TextBuffer(src);

        [Op]
        public static ITextBuffer buffer(uint capacity)
            => new TextBuffer(capacity);

        [Op]
        public static ITextEmitter emitter(StringBuilder src)
            => new TextEmitter(new TextBuffer(src), false);

        [Op]
        public static ITextEmitter emitter()
            => new TextEmitter(new TextBuffer(new StringBuilder()), true);

        [MethodImpl(Inline)]
        public static string format<T>(T src)
            => TextFormatters.Service.Format(src);

        [MethodImpl(Inline)]
        public static string format<T,K>(T src, K selector)
            where K : unmanaged
                => TextFormatters.Service.Format(src, selector);

        [MethodImpl(Inline)]
        public static ITextFormatter formatter(Type type)
            => TextFormatters.Service.FirstOrDefault(type);

        [MethodImpl(Inline)]
        public static ITextFormatter formatter<K>(Type type, K selector)
            where K : unmanaged
                => TextFormatters.Service.RefinedOrDefault(type, selector);

        [MethodImpl(Inline)]
        public static bool RegisterFormatter<T>(ITextFormatter<T> src)
            => TextFormatters.Service.Register(z16, src);

        [MethodImpl(Inline)]
        public static bool RegisterFormatter<K,T>(ITextFormatter<T> src, K selector)
            where K : unmanaged
                => TextFormatters.Service.Register(selector, src);

        [MethodImpl(Inline)]
        public static bool RegisterFormatter(ITextFormatter<object> src)
            => TextFormatters.Service.Register(z16, src);

        [MethodImpl(Inline)]
        public static bool RegisterFormatter<K>(ITextFormatter<object> src, K selector)
            where K : unmanaged
                => TextFormatters.Service.Register(selector, src);

        [MethodImpl(Inline)]
        public static bool RegisterFormatter<T>(RenderDelegate<T> src)
            => TextFormatters.Service.Register(z16, src);

        [MethodImpl(Inline)]
        public static bool RegisterFormatter<K,T>(RenderDelegate<T> src, K selector)
            where K : unmanaged
                => TextFormatters.Service.Register(selector, src);

        [MethodImpl(Inline)]
        public static bool RegisterFormatter(Type type, RenderDelegate<object> src)
            => TextFormatters.Service.Register(type, z16, src);

        [MethodImpl(Inline)]
        public static bool RegisterFormatter<K>(Type type, K selector, RenderDelegate<object> src)
            where K : unmanaged
                => TextFormatters.Service.Register(type, selector, src);
        [Op]
        public static string adjacent(dynamic a, dynamic b)
            => string.Format(RP.Adjacent2, a, b);

        [Op]
        public static string adjacent(dynamic a, dynamic b, dynamic c)
            => string.Format(RP.Adjacent3, a, b, c);

        [Op]
        public static string adjacent(dynamic a, dynamic b, dynamic c, dynamic d)
            => string.Format(RP.Adjacent4, a, b, c, d);

        [Op]
        public static string adjacent(dynamic a, dynamic b, dynamic c, dynamic d, dynamic e)
            => string.Format(RP.Adjacent5, a, b, c, d, e);

        [Op]
        public static string adjacent(dynamic a, dynamic b, dynamic c, dynamic d, dynamic e, dynamic f)
            => string.Format(RP.Adjacent6, a, b, c, d, e, f);
    }
}