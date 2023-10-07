//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;
using static XedModels;
using static XedModels.EASZ;
using static XedModels.EOSZ;
using static Asm.RegKind;

using F = XedRules.FieldKind;

partial class XedRules
{

    public enum RuleKind : byte
    {
        None,

        /// <summary>
        /// Classifies rules that are predicated on <see cref='F.EASZ'/> values
        /// </summary>
        EASZ,

        /// <summary>
        /// Classifies rules that are predicated on <see cref='F.REX'/> values
        /// </summary>
        REX,

        /// <summary>
        /// Classifies rules that are predicated on <see cref='F.DISP_WIDTH'/> values
        /// </summary>
        DISP_WIDTH,

        /// <summary>
        /// Classifies rules that are predicated on <see cref='F.MODE'/> values
        /// </summary>
        MODE,
    }
}
