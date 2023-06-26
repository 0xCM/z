//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static Chars;
    using static sys;

    partial struct AsmPrototypes
    {
        [ApiHost]
        public struct StringSwitch
        {
            uint State;

            [MethodImpl(NotInline), Op]
            void fA(uint i)
            {
                State |= i<<1;
            }

            [MethodImpl(NotInline), Op]
            void fB(uint i)
            {
                State |= i>>2;
            }

            [MethodImpl(NotInline), Op]
            void fC(uint i)
            {
                State |= i<<2;
            }

            [MethodImpl(NotInline), Op]
            void fD(uint i)
            {
                State |= i>>2;
            }

            [MethodImpl(NotInline), Op]
            void fE(uint i)
            {
                State |= i<<3;
            }

            [MethodImpl(NotInline), Op]
            void fF(uint i)
            {
                State |= i>>3;

            }

            [MethodImpl(NotInline), Op]
            void fG(uint i)
            {
                State |= i<<4;
            }

            [MethodImpl(NotInline), Op]
            void fH(uint i)
            {
                State |= i>>4;
            }

            [MethodImpl(NotInline), Op]
            void fI(uint i)
            {
                State |= i<<5;
            }

            [MethodImpl(NotInline), Op]
            void fJ(uint i)
            {
                State |= i>>5;
            }

            [MethodImpl(NotInline), Op]
            void fK(uint i)
            {
                State |= i<<6;
            }

            [MethodImpl(NotInline), Op]
            void fL(uint i)
            {
                State |= i>>6;
            }

            [MethodImpl(NotInline), Op]
            void fM(uint i)
            {
                State |= i<<7;
            }

            [MethodImpl(NotInline), Op]
            void fN(uint i)
            {
                State |= i>>7;
            }

            [MethodImpl(NotInline), Op]
            void fO(uint i)
            {
                State |= i<<8;
            }

            [MethodImpl(NotInline), Op]
            void fP(uint i)
            {
                State |= i>>8;
            }

            [MethodImpl(NotInline), Op]
            void fQ(uint i)
            {
                State++;
            }

            [MethodImpl(NotInline), Op]
            void fR(uint i)
            {
                State--;
            }

            [MethodImpl(NotInline), Op]
            void fS(uint i)
            {
                State++;
            }

            [MethodImpl(NotInline), Op]
            void fT(uint i)
            {
                State--;
            }

            [MethodImpl(NotInline), Op]
            void fU(uint i)
            {
                State++;
            }

            [MethodImpl(NotInline), Op]
            void fV(uint i)
            {
                State--;
            }

            [MethodImpl(NotInline), Op]
            void fW(uint i)
            {
                State++;

            }

            [MethodImpl(NotInline), Op]
            void fX(uint i)
            {
                State--;
            }

            [MethodImpl(NotInline), Op]
            void fY(uint i)
            {
                State++;
            }

            [MethodImpl(NotInline), Op]
            void fZ(uint i)
            {
                State--;
            }

            [Op]
            public void Dispatch(ReadOnlySpan<char> src)
            {
                var count = src.Length;
                for(var i=0u; i<count; i++)
                {
                    switch(skip(src,i))
                    {
                        case a:
                        case A:
                            fA(i);
                        break;
                        case b:
                        case B:
                            fB(i);
                        break;
                        case c:
                        case C:
                            fC(i);
                        break;
                        case d:
                        case D:
                            fD(i);
                        break;
                        case e:
                        case E:
                            fE(i);
                        break;
                        case f:
                        case F:
                            fF(i);
                        break;
                        case g:
                        case G:
                            fG(i);
                        break;
                        case h:
                        case H:
                            fH(i);
                        break;
                        case Chars.i:
                        case I:
                            fI(i);
                        break;
                        case j:
                        case J:
                            fJ(i);
                        break;
                        case l:
                        case L:
                            fL(i);
                        break;
                        case m:
                        case M:
                            fM(i);
                        break;
                        case n:
                        case N:
                            fN(i);
                        break;
                        case o:
                        case O:
                            fO(i);
                        break;
                        case p:
                        case P:
                            fP(i);
                        break;
                        case q:
                        case Q:
                            fQ(i);
                        break;
                        case r:
                        case R:
                            fR(i);
                        break;
                        case s:
                        case S:
                            fS(i);
                        break;
                        case t:
                        case T:
                            fT(i);
                        break;
                        case u:
                        case U:
                            fU(i);
                        break;
                        case v:
                        case V:
                            fV(i);
                        break;
                        case w:
                        case W:
                            fW(i);
                        break;
                        case x:
                        case X:
                            fX(i);
                        break;
                        case y:
                        case Y:
                            fY(i);
                        break;
                        case z:
                        case Z:
                            fZ(i);
                        break;
                    }
                }
            }
        }
    }
}