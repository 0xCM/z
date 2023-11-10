//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    // D:\env\sdks\intel\xed\kit\include\xed\xed-chip-enum.h
    [SymSource(xed), DataWidth(7)]
    public enum ChipCode : byte
    {
        INVALID,

        I86,
        I86FP,
        I186,
        I186FP,
        I286REAL,
        I286,
        I2186FP,
        I386REAL,
        I386,
        I386FP,
        I486REAL,
        I486,
        PENTIUMREAL,
        PENTIUM,
        QUARK,
        PENTIUMMMXREAL,
        PENTIUMMMX,
        ALLREAL,
        PENTIUMPRO,
        PENTIUM2,
        PENTIUM3,
        PENTIUM4,
        P4PRESCOTT,
        P4PRESCOTT_NOLAHF,
        P4PRESCOTT_VTX,
        MEROM,
        PENRYN,
        PENRYN_E,
        NEHALEM,
        WESTMERE,
        BONNELL,
        SALTWELL,
        SILVERMONT,
        VIA,
        AMD_K10,
        AMD_BULLDOZER,
        AMD_PILEDRIVER,
        AMD_ZEN,
        AMD_ZENPLUS,
        AMD_ZEN2,
        AMD_FUTURE,
        GOLDMONT,
        GOLDMONT_PLUS,
        TREMONT,
        SNOW_RIDGE,
        LAKEFIELD,
        SANDYBRIDGE,
        IVYBRIDGE,
        HASWELL,
        BROADWELL,
        SKYLAKE,
        COMET_LAKE,
        SKYLAKE_SERVER,
        CASCADE_LAKE,
        COOPER_LAKE,
        KNL,
        KNM,
        CANNONLAKE,
        ICE_LAKE,
        ICE_LAKE_SERVER,
        TIGER_LAKE,
        ALDER_LAKE,
        SAPPHIRE_RAPIDS,
        GRANITE_RAPIDS,
        SIERRA_FOREST,
        GRAND_RIDGE,
        FUTURE,
    }
}
