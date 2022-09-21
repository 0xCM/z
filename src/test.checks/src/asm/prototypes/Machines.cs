//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial struct AsmPrototypes
    {

        [ApiComplete(prototypes + "machine1")]
        public struct Machine1
        {
            ByteBlock32 State;

            [MethodImpl(Inline)]
            ref byte Cell(uint index)
                => ref seek(State.First, index);

            public void Run(byte opcode, byte operand)
            {
                switch(opcode)
                {
                    case 0:
                        Action0(operand);
                    break;
                    case 1:
                        Action1(operand);
                    break;
                    case 2:
                        Action2(operand);
                    break;
                    case 3:
                        Action3(operand);
                    break;
                    case 4:
                        Action4(operand);
                    break;
                    case 5:
                        Action5(operand);
                    break;
                    case 6:
                        Action6(operand);
                    break;
                    case 7:
                        Action7(operand);
                    break;
                    default:
                        Action7(operand);
                        break;
                }
            }

            [MethodImpl(NotInline)]
            void Action0(byte src)
            {
                Cell(0) = math.mul((byte)0x8, src);
            }

            [MethodImpl(NotInline)]
            void Action1(byte src)
            {
                Cell(1) = math.mul((byte)0x9, src);

            }

            [MethodImpl(NotInline)]
            void Action2(byte src)
            {
                Cell(2) = math.mul((byte)0xA, src);
            }

            [MethodImpl(NotInline)]
            void Action3(byte src)
            {
                Cell(3) = math.mul((byte)0xB, src);
            }

            [MethodImpl(NotInline)]
            void Action4(byte src)
            {
                Cell(4) = math.mul((byte)0xC, src);
            }

            [MethodImpl(NotInline)]
            void Action5(byte src)
            {
                Cell(5) = math.mul((byte)0xD, src);
            }

            [MethodImpl(NotInline)]
            void Action6(byte src)
            {
                Cell(6) = math.mul((byte)0xE, src);
            }

            [MethodImpl(NotInline)]
            void Action7(byte src)
            {
                Cell(7) = math.mul((byte)0xF, src);
            }
        }
    }
}