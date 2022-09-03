//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.Intrinsics;

    using AES = System.Runtime.Intrinsics.X86.Aes;

    using static Root;

    /// <summary>
    /// Surfaces AES intrinsics
    /// </summary>
    partial struct cpu
    {
        /// <summary>
        /// __m128i _mm_aesenc_si128 (__m128i a, __m128i RoundKey) AESENC xmm, xmm/m128
        /// Performs one round of an AES encryption flow on the source data using the round key
        /// </summary>
        /// <param name="src">The data to be encrypted</param>
        /// <param name="key">The round key</param>
        [MethodImpl(Inline), Op]
        public static Vector128<byte> aesEncode(Vector128<byte> src, Vector128<byte> key)
            => AES.Encrypt(src,key);

        /// <summary>
        /// __m128i _mm_aesenclast_si128 (__m128i a, __m128i RoundKey) AESENCLAST xmm, xmm/m128
        /// AES Encrypt (last)
        /// </summary>
        /// <param name="src">The last block of data to be encrypted</param>
        /// <param name="key">The round key</param>
        [MethodImpl(Inline), Op]
        public static Vector128<byte> aesEncodeLast(Vector128<byte> src, Vector128<byte> key)
            => AES.EncryptLast(src,key);

        /// <summary>
        /// __m128i _mm_aesdec_si128 (__m128i a, __m128i RoundKey) AESDEC xmm, xmm/m128
        /// Performs one round of an AES decryption flow on the source data using the round key
        /// </summary>
        /// <param name="src">The data to be decrypted</param>
        /// <param name="key">The round key</param>
        [MethodImpl(Inline), Op]
        public static Vector128<byte> aesDecode(Vector128<byte> src, Vector128<byte> key)
            => AES.Decrypt(src,key);

        /// <summary>
        /// __m128i _mm_aesdeclast_si128 (__m128i a, __m128i RoundKey) AESDECLAST xmm, xmm/m128
        /// Performs the last round of an AES decryption flow on the source data using the round key
        /// </summary>
        /// <param name="src">The data to be decrypted</param>
        /// <param name="key">The round key</param>
        [MethodImpl(Inline), Op]
        public static Vector128<byte> aesDecodeLast(Vector128<byte> src, Vector128<byte> key)
            => AES.DecryptLast(src,key);

        /// <summary>
        /// __m128i _mm_aesimc_si128 (__m128i a) AESIMC xmm, xmm/m128
        /// Applies the InvMixColumns transformation to the source
        /// </summary>
        /// <param name="src">The source vector</param>
        [MethodImpl(Inline), Op]
        public static Vector128<byte> aesInvMix(Vector128<byte> src)
            => AES.InverseMixColumns(src);

        /// <summary>
        /// _m128i _mm_aeskeygenassist_si128 (__m128i a, const int imm8) AESKEYGENASSIST xmm, xmm/m128, imm8
        /// Assist in expanding the AES cipher key by computing steps towards generating a round key for
        /// encryption cipher using data from a and an 8-bit round constant specified in imm8
        /// </summary>
        /// <param name="src"></param>
        /// <param name="imm8"></param>
        [MethodImpl(Inline), Op]
        public static Vector128<byte> aesKeyGen(Vector128<byte> src,byte imm8)
            => AES.KeygenAssist(src,imm8);

        [MethodImpl(Inline), Op]
        public static void aesEncode(SpanBlock128<byte> src, Vector128<byte> key, SpanBlock128<byte> dst)
        {
            for(var block = 0; block < src.BlockCount; block++)
                 cpu.vstore(aesEncode(src.LoadVector(block),key), ref dst.BlockLead(block));
        }

        [MethodImpl(Inline), Op]
        public static void aesdec(SpanBlock128<byte> src, Vector128<byte> key, SpanBlock128<byte> dst)
        {
            for(var block = 0; block < src.BlockCount; block++)
                 cpu.vstore(aesDecode(src.LoadVector(block),key), ref dst.BlockLead(block));
        }
    }
}