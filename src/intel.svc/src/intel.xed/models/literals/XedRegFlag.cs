//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedModels
    {
        [SymSource(xed)]
        public enum XedRegFlag : byte
        {
            INVALID,

            [Symbol("of", "overflow flag")]
            of,

            [Symbol("sf", "sign flag")]
            sf,

            [Symbol("zf", "zero flag")]
            zf,

            [Symbol("af", "auxiliary flag")]
            af,

            [Symbol("pf", "parity flag")]
            pf,

            [Symbol("cf", "carry flag")]
            cf,

            [Symbol("df", "direction flag")]
            df,

            [Symbol("vif", "virtual interrupt flag")]
            vif,

            [Symbol("iopl", "I/O privilege level")]
            iopl,

            [Symbol("if", "interrupt flag")]
            _if,

            [Symbol("ac", "alignment check")]
            ac,

            [Symbol("vm", "virtual-8086 mode")]
            vm,

            [Symbol("rf", "resume flag")]
            rf,

            [Symbol("nt", "nested task")]
            nt,

            [Symbol("tf", "trap flag")]
            tf,

            [Symbol("id", "id flag")]
            id,

            [Symbol("vip", "virtual interrupt pending")]
            vip,

            [Symbol("fc0", "x87 FC0 flag")]
            fc0,

            [Symbol("fc1", "x87 FC1 flag")]
            fc1,

            [Symbol("fc2", "x87 FC2 flag")]
            fc2,

            [Symbol("fc3", "x87 FC3 flag")]
            fc3,
        }
    }
}