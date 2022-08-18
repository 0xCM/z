//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    partial struct bit
    {
        /// <summary>
        /// Presents a <see cref='byte'/> reference as a <see cref='bit'/> reference
        /// </summary>
        /// <param name="src">The source byte</param>
        [MethodImpl(Inline), Op]
        public static ref bit from(in byte src)
            => ref @as<byte,bit>(src);

        /// <summary>
        /// Presents a <see cref='sbyte'/> reference as a <see cref='bit'/> reference
        /// </summary>
        /// <param name="src">The source byte</param>
        [MethodImpl(Inline), Op]
        public static ref bit from(in sbyte src)
            => ref @as<sbyte,bit>(src);

        /// <summary>
        /// Presents a <see cref='ushort'/> reference as a <see cref='bit'/> reference
        /// </summary>
        /// <param name="src">The source byte</param>
        [MethodImpl(Inline), Op]
        public static ref bit from(in ushort src)
            => ref @as<ushort,bit>(src);

        /// <summary>
        /// Presents a <see cref='short'/> reference as a <see cref='bit'/> reference
        /// </summary>
        /// <param name="src">The source byte</param>
        [MethodImpl(Inline), Op]
        public static ref bit from(in short src)
            => ref @as<short,bit>(src);

        /// <summary>
        /// Presents a <see cref='uint'/> reference as a <see cref='bit'/> reference
        /// </summary>
        /// <param name="src">The source byte</param>
        [MethodImpl(Inline), Op]
        public static ref bit from(in uint src)
            => ref @as<uint,bit>(src);

        /// <summary>
        /// Presents a <see cref='int'/> reference as a <see cref='bit'/> reference
        /// </summary>
        /// <param name="src">The source byte</param>
        [MethodImpl(Inline), Op]
        public static ref bit from(in int src)
            => ref @as<int,bit>(src);

        /// <summary>
        /// Presents a <see cref='ulong'/> reference as a <see cref='bit'/> reference
        /// </summary>
        /// <param name="src">The source byte</param>
        [MethodImpl(Inline), Op]
        public static ref bit from(in ulong src)
            => ref @as<ulong,bit>(src);

        /// <summary>
        /// Presents a <see cref='long'/> reference as a <see cref='bit'/> reference
        /// </summary>
        /// <param name="src">The source byte</param>
        [MethodImpl(Inline), Op]
        public static ref bit from(in long src)
            => ref @as<long,bit>(src);
    }
}