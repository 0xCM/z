//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

using Asm;
using static XedModels;
using static MachineModes;
using static XedModels.EASZ;
using static XedModels.EOSZ;
using static MachineModes.MachineModeClass;
using static XedModels.SMODE;
using static Asm.RegKind;

partial class XedRules
{
    public abstract class Production<S,T>
    {
        public abstract T Effect(S src);

    }

    public class Productions
    {
        public sealed class SrSP : Production<SMODE, RegOp>
        {
            public override RegOp Effect(SMODE src)
                => src switch {
                    SMode16 => asm.reg(SP),
                    SMode32 => asm.reg(ESP),
                    SMode64 => asm.reg(RSP),
                    _ => RegOp.Empty
                };
        }

        public sealed class SrBP : Production<SMODE, RegOp>
        {
            public override RegOp Effect(SMODE src)
                => src switch {
                    SMode16 => asm.reg(BP),
                    SMode32 => asm.reg(EBP),
                    SMode64 => asm.reg(RBP),
                    _ => RegOp.Empty
                };
        }

        public sealed class Ar8 : Production<EASZ, RegOp>
        {
            public override RegOp Effect(EASZ src)
                => src switch {
                    EASZ16 => asm.reg(R8W),
                    EASZ32 => asm.reg(R8D),
                    EASZ64 => asm.reg(R8Q),
                    _ => RegOp.Empty
                };
        }

        public sealed class Ar9 : Production<EASZ, RegOp>
        {
            public override RegOp Effect(EASZ src)
                => src switch {
                    EASZ16 => asm.reg(R9W),
                    EASZ32 => asm.reg(R9D),
                    EASZ64 => asm.reg(R9Q),
                    _ => RegOp.Empty
                };
        }

        public sealed class Ar10 : Production<EASZ, RegOp>
        {
            public override RegOp Effect(EASZ src)
                => src switch {
                    EASZ16 => asm.reg(R10W),
                    EASZ32 => asm.reg(R10D),
                    EASZ64 => asm.reg(R10Q),
                    _ => RegOp.Empty
                };
        }

        public sealed class Ar11 : Production<EASZ, RegOp>
        {
            public override RegOp Effect(EASZ src)
                => src switch {
                    EASZ16 => asm.reg(R11W),
                    EASZ32 => asm.reg(R11D),
                    EASZ64 => asm.reg(R11Q),
                    _ => RegOp.Empty
                };                
        }

        public sealed class Ar12 : Production<EASZ, RegOp>
        {
            public override RegOp Effect(EASZ src)
                => src switch {
                    EASZ16 => asm.reg(R12W),
                    EASZ32 => asm.reg(R12D),
                    EASZ64 => asm.reg(R12Q),
                    _ => RegOp.Empty
                };
        }

        public sealed class Ar13 : Production<EASZ, RegOp>
        {
            public override RegOp Effect(EASZ src)
                => src switch {
                    EASZ16 => asm.reg(R13W),
                    EASZ32 => asm.reg(R13D),
                    EASZ64 => asm.reg(R13Q),
                    _ => RegOp.Empty
                };
        }

        public sealed class Ar14 : Production<EASZ, RegOp>
        {
            public override RegOp Effect(EASZ src)
                => src switch {
                    EASZ16 => asm.reg(R14W),
                    EASZ32 => asm.reg(R14D),
                    EASZ64 => asm.reg(R14Q),
                    _ => RegOp.Empty
                };
        }

        public sealed class Ar15 : Production<EASZ, RegOp>
        {
            public override RegOp Effect(EASZ src)
                => src switch {
                    EASZ16 => asm.reg(R15W),
                    EASZ32 => asm.reg(R15D),
                    EASZ64 => asm.reg(R15Q),
                    _ => RegOp.Empty
                };
        }

        public sealed class rIP : Production<MachineModeClass, RegOp>
        {
            public override RegOp Effect(MachineModeClass src)
                => src switch {
                    Mode16 => asm.reg(EIP),
                    Mode32 => asm.reg(EIP),
                    Mode64 => asm.reg(RIP),
                    _ => RegOp.Empty
                };
        }

        public sealed class rIPa : Production<EOSZ, RegOp>
        {
            public override RegOp Effect(EOSZ src)
                => src switch {
                    EOSZ32 => asm.reg(EIP),
                    EOSZ64 => asm.reg(RIP),
                    _ => RegOp.Empty
                };
        }

    }

}