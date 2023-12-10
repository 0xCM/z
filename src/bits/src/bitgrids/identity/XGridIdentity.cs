// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    
    using static sys;
    using static ApiGridKind;

    [ApiHost]
    public static class XGridIdentity
    {
        [MethodImpl(Inline), Op]
        public static bool IsPrimalGeneric(this ApiGridKind k)
            => (k & NumericGeneric) != 0;

        [MethodImpl(Inline), Op]
        public static bool IsFixedNatural(this ApiGridKind k)
            => (k & FixedNatural) != 0;

        [MethodImpl(Inline), Op]
        public static bool IsSubGrid(this ApiGridKind k)
            => (k & FixedSubgrid) != 0;

        [MethodImpl(Inline), Op]
        public static CpuCellWidth Width(this ApiGridKind k)
            => (CpuCellWidth)((ushort)k);

        [MethodImpl(Inline), Op]
        public static ApiGridClass Category(this ApiGridKind k)
            => (ApiGridClass)(((uint)k >> 16) << 16);

        [MethodImpl(Inline), Op]
        public static bool IsSome(this ApiGridKind k)
            => k != Z0.ApiGridKind.None;

        [Op]
        public static string Indicator(this ApiGridKind k)
            => k.IsPrimalGeneric() ? GridIndicators.PrimalGeneric
             : k.IsSubGrid() ? GridIndicators.FixedSubgrid
             : k.IsFixedNatural() ? GridIndicators.FixedNatural
             : (k & Z0.ApiGridKind.Generic) != 0 ? GridIndicators.Generic
             : (k & Z0.ApiGridKind.GenericUnfixed) != 0 ? GridIndicators.Generic
             : (k & Z0.ApiGridKind.Natural) != 0 ? GridIndicators.Natural
             : (k & Z0.ApiGridKind.NaturalUnfixed) != 0 ? GridIndicators.Natural
             :  k.ToString();

        [Op]
        public static GridIdentity GridClosures(this Type src)
        {
            var args = src.GridKind().MapValueOrDefault(k => src.SuppliedTypeArgs().ToArray(), array<Type>());
            if(args.Length == 1)
                return (0, 0, args[0].NumericKind());
            else if(args.Length == 3)
                return (args[0].TypeNatural().NatValue, args[1].TypeNatural().NatValue, args[2].NumericKind());
            else
                return (0, 0, NumericKind.None);
        }

        [MethodImpl(Inline), Op]
        public static bool IsSome(this GridIdentity src)
            => !src.IsEmpty;

        [MethodImpl(Inline), Op]
        public static int NonEmptyCount(this GridIdentity src)
            => (src.M != 0 ? 1 : 0) + (src.N != 0 ? 1 : 0)  + (src.T.IsSome() ? 1 : 0);

        [Op]
        public static Option<ApiGridKind> GridKind(this Type src)
        {
            var def =  src.GenericDefinition2();
            if(def == typeof(void))
                return Option.none<ApiGridKind>();

            if(def == typeof(BitSpanBlocks256<>))
                return Z0.ApiGridKind.NumericGeneric;
            else if(def == typeof(BitGrid<,,>))
                return Z0.ApiGridKind.NaturalUnfixed;
            if(def == typeof(BitGrid16<>))
                return Z0.ApiGridKind.Numeric16;
            else if(def == typeof(BitGrid32<>))
                return Z0.ApiGridKind.Numeric32;
            else if(def == typeof(BitGrid64<>))
                return Z0.ApiGridKind.Numeric64;
            else if(def == typeof(BitGrid16<,,>))
                return Z0.ApiGridKind.Natural16;
            else if(def == typeof(BitGrid32<,,>))
                return Z0.ApiGridKind.Natural32;
            else if(def == typeof(BitGrid64<,,>))
                return Z0.ApiGridKind.Natural64;
            else if(def == typeof(BitGrid128<,,>))
                return Z0.ApiGridKind.Natural128;
            else if(def == typeof(BitGrid256<,,>))
                return Z0.ApiGridKind.Natural256;
            else if(def == typeof(SubGrid16<,,>))
                return Z0.ApiGridKind.Subgrid16;
            else if(def == typeof(SubGrid32<,,>))
                return Z0.ApiGridKind.Subgrid32;
            else if(def == typeof(SubGrid64<,,>))
                return Z0.ApiGridKind.Subgrid64;
            else if(def == typeof(SubGrid128<,,>))
                return Z0.ApiGridKind.Subgrid128;
            else if(def == typeof(SubGrid256<,,>))
                return Z0.ApiGridKind.Subgrid256;
            else
                return Option.none<ApiGridKind>();
        }

        // [MethodImpl(Inline), Op]
        // public static Option<CpuCellWidth> GridWidth(this Type src)
        //     => src.GridKind().TryMap(k => k.Width());
    }
}