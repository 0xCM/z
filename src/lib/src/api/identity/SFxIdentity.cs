//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Builder = ApiIdentityBuilder;

    public readonly struct SFxIdentity
    {
        [Op]
        public static string name(IFunc f)
            => text.ifempty(f.GetType().Tag<OpKindAttribute>()
                   .MapValueOrDefault(a => f.GetType().DisplayName(), f.GetType().DisplayName()),  f.GetType().DisplayName());

        [MethodImpl(Inline), Op]
        public static string name(Type host, IFunc f)
            =>$"{host.Assembly.Id().Format()}{IDI.UriPathSep}{host.Name}{IDI.UriPathSep}{SFxIdentity.name(f)}";

        [Op]
        public static string name(IFunc f, IFunc g)
            => string.Format("{0} <-> {1}", name(f), name(g));

        public static string name<W,T>(Type host, IFunc f)
            where W : unmanaged, ITypeWidth
            where T : unmanaged
                => Builder.name<W,T>(host, Builder.build<W,T>(SFxIdentity.name(f)), true);

        /// <summary>
        /// Defines an identifier of the form {opname}_WxN{u | i | f} where N := bitsize[T]
        /// </summary>
        /// <param name="opname">The base operator name</param>
        /// <param name="w">The covering bit width representative</param>
        /// <param name="t">A primal cell type representative</param>
        /// <typeparam name="W">The bit width type</typeparam>
        /// <typeparam name="T">The cell type</typeparam>
        public static _OpIdentity identity<W,T>(string opname, W w = default, T t = default, bool generic = true)
            where W : unmanaged, ITypeNat
            where T : unmanaged
                => Builder.build(opname, (NativeTypeWidth)TypeNats.value<W>(), NumericKinds.kind<T>(), generic);

        /// <summary>
        /// Defines an operand identifier of the form {opname}_N{u | i | f} that identifies an operation over a primal type of bit width N := bitsize[T]
        /// </summary>
        /// <param name="opname">The base operator name</param>
        /// <param name="t">A primal type representative</param>
        /// <typeparam name="T">The primal type</typeparam>
        [Op, Closures(Closure)]
        public static _OpIdentity identity<T>(string opname)
            => Builder.NumericOp(opname, typeof(T).NumericKind());

        /// <summary>
        /// Defines an operand identifier of the form {opname}_N{u | i | f} that identifies an operation over a primal type of bit width N := bitsize[T]
        /// </summary>
        /// <param name="opname">The base operator name</param>
        /// <param name="t">A primal type representative</param>
        /// <typeparam name="T">The primal type</typeparam>
        [Op, Closures(Closure)]
        public static _OpIdentity identity<T>(string opname, Vec128Kind<T> k)
            where T : unmanaged
                => Builder.build(opname, (NativeTypeWidth)k.Width, typeof(T).NumericKind(), true);

        /// <summary>
        /// Defines an operand identifier of the form {opname}_N{u | i | f} that identifies an operation over a primal type of bit width N := bitsize[T]
        /// </summary>
        /// <param name="opname">The base operator name</param>
        /// <param name="t">A primal type representative</param>
        /// <typeparam name="T">The primal type</typeparam>
        [Op, Closures(Closure)]
        public static _OpIdentity identity<T>(string opname, Vec256Kind<T> k)
            where T : unmanaged
                => Builder.build(opname, (NativeTypeWidth)k.Width, typeof(T).NumericKind(), true);

        /// <summary>
        /// Defines an operand identifier of the form {opname}_N{u | i | f} that identifies an operation over a primal type of bit width N := bitsize[T]
        /// </summary>
        /// <param name="opname">The base operator name</param>
        /// <param name="t">A primal type representative</param>
        /// <typeparam name="T">The primal type</typeparam>
        [Op, Closures(Closure)]
        public static _OpIdentity identity<T>(string opname, Vec512Kind<T> k)
            where T : unmanaged
                => Builder.build(opname, (NativeTypeWidth)k.Width, typeof(T).NumericKind(), true);
        const NumericKind Closure = AllNumeric;
    }
}