//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0;

partial class XedModels
{
    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct InstPatternSpec : IComparable<InstPatternSpec>, ISequential<InstPatternSpec>
    {
        public uint Seq;

        public MachineMode Mode;

        public InstIsa Isa;

        public InstCategory Category;

        public Extension Extension;

        public XedInstClass InstClass;

        public XedInstForm InstForm;

        public InstAttribs Attributes;

        public Index<XedFlagEffect> Effects;

        public AsmOpCode OpCode;

        public TextBlock RawBody;

        public InstPatternBody Body;

        public PatternOps Ops;

        public static void FixIsa(ref InstPatternSpec src)
        {
            if(src.Isa.IsEmpty)
            {
                switch(src.Extension.Kind)
                {
                    case ExtensionKind._3DNOW:
                        src.Isa = InstIsaKind._3DNOW;
                    break;
                    case ExtensionKind.INVPCID:
                        src.Isa = InstIsaKind.INVPCID;
                    break;
                    case ExtensionKind.PCLMULQDQ:
                        src.Isa = InstIsaKind.PCLMULQDQ;
                    break;
                    case ExtensionKind.FMA4:
                        src.Isa = InstIsaKind.FMA4;
                    break;
                    case ExtensionKind.F16C:
                        src.Isa = InstIsaKind.F16C;
                    break;
                    case ExtensionKind.X87:
                        src.Isa = InstIsaKind.X87;
                    break;
                    case ExtensionKind.AES:
                        src.Isa = InstIsaKind.AES;
                    break;
                    case ExtensionKind.AVX:
                        src.Isa = InstIsaKind.AVX;
                    break;
                    case ExtensionKind.AVX2:
                        src.Isa = InstIsaKind.AVX2;
                    break;
                    case ExtensionKind.BMI1:
                        src.Isa = InstIsaKind.BMI1;
                    break;
                    case ExtensionKind.BMI2:
                        src.Isa = InstIsaKind.BMI2;
                    break;
                    case ExtensionKind.LONGMODE:
                        src.Isa = InstIsaKind.LONGMODE;
                    break;
                    case ExtensionKind.CLZERO:
                        src.Isa = InstIsaKind.CLZERO;
                    break;
                    case ExtensionKind.FMA:
                        src.Isa = InstIsaKind.FMA;
                    break;
                    case ExtensionKind.LZCNT:
                        src.Isa = InstIsaKind.LZCNT;
                        break;
                    case ExtensionKind.SSE:
                        src.Isa = InstIsaKind.SSE;
                    break;
                    case ExtensionKind.SSE2:
                        src.Isa = InstIsaKind.SSE2;
                    break;
                    case ExtensionKind.SSE3:
                        src.Isa = InstIsaKind.SSE3;
                    break;
                    case ExtensionKind.SSE4:
                        src.Isa = InstIsaKind.SSE4;
                    break;
                    case ExtensionKind.VTX:
                        src.Isa = InstIsaKind.VTX;
                    break;
                    case ExtensionKind.SSE4a:
                        src.Isa = InstIsaKind.SSE4a;
                    break;
                    case ExtensionKind.SSSE3:
                        src.Isa = InstIsaKind.SSSE3;
                    break;
                    case ExtensionKind.TBM:
                        src.Isa = InstIsaKind.TBM;
                    break;
                    case ExtensionKind.XSAVE:
                        src.Isa = InstIsaKind.XSAVE;
                    break;
                    case ExtensionKind.XSAVEC:
                        src.Isa = InstIsaKind.XSAVEC;
                    break;
                    case ExtensionKind.XSAVEOPT:
                        src.Isa = InstIsaKind.XSAVEOPT;
                    break;
                    case ExtensionKind.XSAVES:
                        src.Isa = InstIsaKind.XSAVES;
                    break;
                    default:
                    {

                    }
                    break;
                }
            }
        }

        public int CompareTo(InstPatternSpec src)
        {
            var result = InstClass.CompareTo(src.InstClass);
            if(result == 0)
                result = RawBody.CompareTo(src.RawBody);
            return result;
        }

        public static InstPatternSpec Empty => default;

        uint ISequential.Seq
        {
            get => Seq;
            set => Seq = value;
        }
    }
}
