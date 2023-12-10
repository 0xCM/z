//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

partial class TypeNats
{
    public readonly struct Dim<I,J>
        where I : unmanaged, ITypeNat
        where J : unmanaged, ITypeNat
    {
        public static I i => default;

        public static J j => default;

        public static byte Order = 2;

        public static Dim<I,J> Value => default;
    }

    public readonly struct Dim<I,J,K>
        where I : unmanaged, ITypeNat
        where J : unmanaged, ITypeNat
        where K : unmanaged, ITypeNat
    {
        public static I i => default;

        public static J j => default;

        public static K k => default;

        public static byte Order = 3;

        public static Dim<I,J,K> Value => default;
    }
}
