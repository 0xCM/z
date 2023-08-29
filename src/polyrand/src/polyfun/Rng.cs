//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public readonly struct Rng
    {
        /// <summary>
        /// Produces a non-deterministic seed
        /// </summary>
        /// <typeparam name="T">The seed type</typeparam>
        public static T entropy<T>()
            where T : unmanaged
                => Entropy.value<T>();
        [Op]
        public static Index<byte> entropy(ByteSize size)
            => Entropy.bytes(size);

        [MethodImpl(Inline), Op]
        public static void entropy(Span<byte> dst)
            => Entropy.fill(dst);

        [MethodImpl(Inline), Op]
        public static IPolyrand @default()
            => pcg64(PolySeed64.Seed05);

        [MethodImpl(Inline), Op]
        public static IPolyrand @default(ulong seed)
            => pcg64(seed);

        /// <summary>
        /// Creates a 32-bit Pcg RNG
        /// </summary>
        /// <param name="seed">The initial rng state</param>
        /// <param name="index">The stream index, if any</param>
        [MethodImpl(Inline), Op]
        public static IPolyrand pcg32(ulong seed, ulong index)
            => create(Pcg.pcg32(seed, index));

        /// <summary>
        /// Creates a 64-bit Pcg RNG
        /// </summary>
        /// <param name="seed">The initial rng state</param>
        /// <param name="index">The stream index, if any</param>
        [MethodImpl(Inline), Op]
        public static IPolyrand pcg64()
            => create(Pcg.pcg64(PolySeed64.Seed00));

        /// <summary>
        /// Creates a 64-bit Pcg RNG
        /// </summary>
        /// <param name="seed">The initial rng state</param>
        /// <param name="index">The stream index, if any</param>
        [MethodImpl(Inline), Op]
        public static IPolyrand pcg64(ulong seed, ulong? index = null)
            => create(Pcg.pcg64(seed, index));

        /// <summary>
        /// Creates a wyhash 16-bit rng
        /// </summary>
        /// <param name="state">The initial state</param>
        /// <param name="index">The stream index</param>
        [MethodImpl(Inline), Op]
        public static WyHash16 wyhash16(ushort state, ushort? index = null)
            => new (state,index);

        /// <summary>
        /// Creates a new WyHash16 generator
        /// </summary>
        /// <param name="seed">An optional seed; if unspecified, seed is taken from the system entropy source</param>
        [MethodImpl(Inline), Op]
        public static IPolyrand wyhash64(ulong? seed = null)
            => create(new WyHash64(seed ?? PolySeed64.Seed00));

        /// <summary>
        /// Creates a splitmix 64-bit generator
        /// </summary>
        /// <param name="seed">The initial state of the generator, if specified;
        /// otherwise, the seed is obtained from an entropy source</param>
        [MethodImpl(Inline), Op]
        public static IPolyrand splitmix(ulong? seed = null)
            => create(new SplitMix64(seed ?? PolySeed64.Seed00));

        /// <summary>
        /// Creates an XOrShift 1024 rng
        /// </summary>
        /// <param name="seed">The initial state</param>
        [MethodImpl(Inline), Op]
        public static IPolyrand xorStars256(ulong[] seed = null)
            => create(XorShift256.create(seed ?? PolySeed256.Default));

        /// <summary>
        /// Creates an XOrShift 1024 rng
        /// </summary>
        /// <param name="seed">The initial state</param>
        [MethodImpl(Inline), Op]
        public static IPolyrand xorShift1024(ulong[] seed = null)
            => create(new XorShift1024(seed ?? PolySeed1024.Default));

        [MethodImpl(Inline), Op]
        public static IPolyrand create(IRandomSource<ulong> src)
            => new Polyrand(src);

        [MethodImpl(Inline), Op]
        public static IPolyrand create(IRandomNav<ulong> src)
            => new Polyrand(src);
    }
}