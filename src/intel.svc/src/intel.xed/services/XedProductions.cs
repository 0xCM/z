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
using static MachineModes.MachineModeClass;
using static XedModels.SMODE;
using static Asm.RegKind;

public partial class XedProductions
{
    public interface IProduction
    {
        RuleName Name {get;}

        string Sig {get;}
    }

    public interface IUnaryProduction : IProduction
    {
        dynamic Effect(dynamic src);
    }

    public interface IBinaryProduction : IProduction
    {
        dynamic Effect(dynamic a, dynamic b);
    }

    public interface ITernaryProduction : IProduction
    {
        dynamic Effect(dynamic a, dynamic b, dynamic c);
    }

    public interface IProduction<S,T> : IUnaryProduction
    {
        string IProduction.Sig
            => $"{typeof(S).Name} -> {typeof(T).Name}";

        T Effect(S src);

        dynamic IUnaryProduction.Effect(dynamic src)
            => Effect((S)src);
    }

    public interface IProduction<S0,S1,T> : IBinaryProduction
    {
        string IProduction.Sig
            => $"({typeof(S0).Name},{typeof(S1).Name}) -> {typeof(T).Name}";

        T Effect(S0 a, S1 b);

        dynamic IBinaryProduction.Effect(dynamic a, dynamic b)
            => Effect((S0)a, (S1)b);
    }


    public interface IProduction<S0,S1,S2,T> : ITernaryProduction
    {
        string IProduction.Sig
            => $"({typeof(S0).Name},{typeof(S1).Name},{typeof(S2).Name}) -> {typeof(T).Name}";

        T Effect(S0 a, S1 b, S2 c);

        dynamic ITernaryProduction.Effect(dynamic a, dynamic b, dynamic c)
            =>Effect((S0)a, (S1)b, (S2)c);
    }

    public abstract class Production
    {
        public RuleName Name {get;}

        protected Production(RuleName name)
        {
            Name = name;
        }
    }

    public abstract class Production<S,T> : Production, IProduction<S,T>
    {
        protected Production(RuleName name)
            : base(name)
        {
        }
        
        public abstract T Effect(S src);
    }

    public abstract class Production<S0,S1,T> : Production, IProduction<S0,S1,T>
    {
        protected Production(RuleName name)
            : base(name)
        {
        }
        public abstract T Effect(S0 a, S1 b);
    }

    public abstract class Production<S0,S1,S2,T> : Production, IProduction<S0,S1,S2,T>
    {
        protected Production(RuleName name)
            : base(name)
        {
        }

        public abstract T Effect(S0 a, S1 b, S2 c);
    }

    public interface IRuleSelect<S> : IProduction<S,RuleName>
    {

    }
    
    public interface IInstructionSelect : IRuleSelect<VexValid>
    {

    }

    public interface IRegSelect<S> : IProduction<S,RegOp>
    {

    }

    public interface ISMODERule<T> : IProduction<SMODE,T>
    {

    }

    public interface IEASZRule<T> : IProduction<EASZ,T>
    {

    }

    public interface IEOSZRule<T> : IProduction<EOSZ,T>
    {

    }

    public interface IBitfieldRule<S,T> : IProduction<S,T>
        where S : unmanaged
    {

    }

    public interface IBitfieldRule<S0,S1,T> : IProduction<S0,S1,T>
        where S0: unmanaged
        where S1 : unmanaged
    {

    }

    public interface IMachineModeRule<T> : IProduction<MachineMode,T>
    {

    }

    public sealed class A_GPR_B : Production<bit, num3, RuleName>    
    {
        public A_GPR_B()
            : base(RuleName.A_GPR_B)
        {

        }

        public override RuleName Effect(bit a, num3 b)
        {
            var name = RuleName.None;
            var bits = Numbers.pack(a,b);
            switch((byte)bits)
            {
                case 0b0000:
                    name = RuleName.ArAX;
                break;
                case 0b0001:
                    name = RuleName.ArCX;
                break;
                case 0b0010:
                    name = RuleName.ArDX;
                break;
                case 0b0011:
                    name = RuleName.ArBX;
                break;
                case 0b0100:
                    name = RuleName.ArSP;
                break;
                case 0b0101:
                    name = RuleName.ArBP;
                break;
                case 0b0110:
                    name = RuleName.ArSI;
                break;
                case 0b0111:
                    name = RuleName.ArDI;
                break;
                case 0b1000:
                    name = RuleName.Ar8;
                break;
                case 0b1001:
                    name = RuleName.Ar9;
                break;
                case 0b1010:
                    name = RuleName.Ar10;
                break;
                case 0b1011:
                    name = RuleName.Ar11;
                break;
                case 0b1100:
                    name = RuleName.Ar12;
                break;
                case 0b1101:
                    name = RuleName.Ar13;
                break;
                case 0b1110:
                    name = RuleName.Ar14;
                break;
                case 0b1111:
                    name = RuleName.Ar15;
                break;
            }

            return name;
        }
    }

    public sealed class EVEX_SPLITTER : Production<VexValid, RuleName>, IInstructionSelect
    {
        public EVEX_SPLITTER()
            : base(RuleName.EVEX_SPLITTER)
        {

        }

        public override RuleName Effect(VexValid src)
            => src switch {
                VexValid.EVV => RuleName.EVEX_INSTRUCTIONS,
                VexValid.VV1 => RuleName.AVX_INSTRUCTIONS,
                VexValid.XOPV => RuleName.XOP_INSTRUCTIONS,
                _ => RuleName.INSTRUCTIONS
            };
    }

    public sealed class SrSP : Production<SMODE, RegOp>, IRegSelect<SMODE>
    {
        public SrSP()
            : base(RuleName.SrSP)
        {
            
        }

        public override RegOp Effect(SMODE src)
            => src switch {
                SMode16 => asm.reg(SP),
                SMode32 => asm.reg(ESP),
                SMode64 => asm.reg(RSP),
                _ => RegOp.Empty
            };
    }

    public sealed class SrBP : Production<SMODE, RegOp>, IRegSelect<SMODE>, ISMODERule<RegOp>
    {
        public SrBP()
            : base(RuleName.SrBP)
        {
            
        }

        public override RegOp Effect(SMODE src)
            => src switch {
                SMode16 => asm.reg(BP),
                SMode32 => asm.reg(EBP),
                SMode64 => asm.reg(RBP),
                _ => RegOp.Empty
            };
    }

    public sealed class Ar8 : Production<EASZ, RegOp>, IRegSelect<EASZ>, IEASZRule<RegOp>
    {
        public Ar8()
            : base(RuleName.Ar8)
        {

        }

        public override RegOp Effect(EASZ src)
            => src switch {
                EASZ16 => asm.reg(R8W),
                EASZ32 => asm.reg(R8D),
                EASZ64 => asm.reg(R8Q),
                _ => RegOp.Empty
            };
    }

    public sealed class Ar9 : Production<EASZ, RegOp>, IRegSelect<EASZ>, IEASZRule<RegOp>
    {
        public Ar9()
            : base(RuleName.Ar9)
        {

        }

        public override RegOp Effect(EASZ src)
            => src switch {
                EASZ16 => asm.reg(R9W),
                EASZ32 => asm.reg(R9D),
                EASZ64 => asm.reg(R9Q),
                _ => RegOp.Empty
            };
    }

    public sealed class Ar10 : Production<EASZ, RegOp>, IRegSelect<EASZ>, IEASZRule<RegOp>
    {
        public Ar10()
            : base(RuleName.Ar10)
        {

        }

        public override RegOp Effect(EASZ src)
            => src switch {
                EASZ16 => asm.reg(R10W),
                EASZ32 => asm.reg(R10D),
                EASZ64 => asm.reg(R10Q),
                _ => RegOp.Empty
            };
    }

    public sealed class Ar11 : Production<EASZ, RegOp>, IRegSelect<EASZ>, IEASZRule<RegOp>
    {
        public Ar11()
            : base(RuleName.Ar11)
        {

        }

        public override RegOp Effect(EASZ src)
            => src switch {
                EASZ16 => asm.reg(R11W),
                EASZ32 => asm.reg(R11D),
                EASZ64 => asm.reg(R11Q),
                _ => RegOp.Empty
            };                
    }

    public sealed class Ar12 : Production<EASZ, RegOp>, IRegSelect<EASZ>, IEASZRule<RegOp>
    {
        public Ar12()
            : base(RuleName.Ar12)
        {

        }

        public override RegOp Effect(EASZ src)
            => src switch {
                EASZ16 => asm.reg(R12W),
                EASZ32 => asm.reg(R12D),
                EASZ64 => asm.reg(R12Q),
                _ => RegOp.Empty
            };
    }

    public sealed class Ar13 : Production<EASZ, RegOp>, IRegSelect<EASZ>, IEASZRule<RegOp>
    {
        public Ar13()
            : base(RuleName.Ar13)
        {

        }

        public override RegOp Effect(EASZ src)
            => src switch {
                EASZ16 => asm.reg(R13W),
                EASZ32 => asm.reg(R13D),
                EASZ64 => asm.reg(R13Q),
                _ => RegOp.Empty
            };
    }

    public sealed class Ar14 : Production<EASZ, RegOp>, IRegSelect<EASZ>, IEASZRule<RegOp>
    {
        public Ar14()
            : base(RuleName.Ar14)
        {

        }

        public override RegOp Effect(EASZ src)
            => src switch {
                EASZ16 => asm.reg(R14W),
                EASZ32 => asm.reg(R14D),
                EASZ64 => asm.reg(R14Q),
                _ => RegOp.Empty
            };
    }

    public sealed class Ar15 : Production<EASZ, RegOp>, IRegSelect<EASZ>, IEASZRule<RegOp>
    {
        public Ar15()
            : base(RuleName.Ar15)
        {

        }

        public override RegOp Effect(EASZ src)
            => src switch {
                EASZ16 => asm.reg(R15W),
                EASZ32 => asm.reg(R15D),
                EASZ64 => asm.reg(R15Q),
                _ => RegOp.Empty
            };
    }

    public sealed class rIP : Production<MachineMode, RegOp>, IRegSelect<MachineMode>, IMachineModeRule<RegOp>
    {
        public rIP()
            : base(RuleName.rIP)
        {
            
        }

        public override RegOp Effect(MachineMode src)
            => src.Class switch {
                Mode16 => asm.reg(EIP),
                Mode32 => asm.reg(EIP),
                Mode64 => asm.reg(RIP),
                _ => RegOp.Empty
            };
    }

    public sealed class rIPa : Production<EOSZ, RegOp>, IRegSelect<EOSZ>, IEOSZRule<RegOp>
    {
        public rIPa()
            : base(RuleName.rIPa)
        {

        }

        public override RegOp Effect(EOSZ src)
            => src switch {
                EOSZ32 => asm.reg(EIP),
                EOSZ64 => asm.reg(RIP),
                _ => RegOp.Empty
            };
    }
}
