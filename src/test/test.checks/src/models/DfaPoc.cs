//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static AsciLetterLoSym;

    using A = AsciLetterLoSym;

    public class DfaPoc
    {
        public enum DfaToken : byte
        {
            None = 0,

            Dog,

            Cat,

            Fox,

            Hound,

            Chicken,
        }

        [ApiHost]
        public struct Dfa
        {
            byte Depth;

            DfaToken Token;

            bool Accepted;

            // dog
            // cat
            // fox
            // hound
            // chicken

            public static Dfa create()
                => default;

            // (0,'d'), (1,'o'), (2,'g')
            // (0,'c'), (1,'a'), (2,'t')
            // (0,'f'), (1,'o'), (2,'x')
            // (0,'h'), (1,'o'), (2,'u), (3, 'n'), (4, 'd')
            // (0,'c'), (1,'h'), (2,'i'), (3,'c'), (4,'k'), (5,'e'), (6,'n')

            [Op]
            public DfaToken Match(ReadOnlySpan<char> src)
            {
                Depth = 0;
                Token = 0;
                Accepted = false;
                var count = src.Length;
                var accepted = false;
                for(var i=0; i<count; i++)
                {
                    Match((A)skip(src,i));
                    if(!Accepted)
                        break;
                }
                return Token;
            }

            [Op]
            void Match(A input)
            {
                switch(input)
                {
                    case a:
                    {
                        switch(Depth)
                        {
                            // c(a)t
                            case 1:
                                goto Next;
                            default:
                                goto Reject;
                        }
                    }
                    case b:
                    {
                        switch(Depth)
                        {
                            default:
                                goto Reject;
                        }
                    }
                    case c:
                    {
                        switch(Depth)
                        {
                            // (c)at, (c)hicken
                            case 0:
                                goto Next;
                            // chi(c)ken
                            case 3:
                                goto Next;
                            default:
                                goto Reject;
                        }
                    }
                    case d:
                    {
                        switch(Depth)
                        {
                            // (d)og
                            case 0:
                                goto Next;
                            // houn(d)
                            case 4:
                                Token = DfaToken.Hound;
                                goto Next;
                            default:
                                goto Reject;
                        }
                    }
                    case e:
                    {
                        switch(Depth)
                        {
                            // chick(e)n
                            case 5:
                                goto Next;
                            default:
                                goto Reject;
                        }
                    }
                    case f:
                    {
                        switch(Depth)
                        {
                            // (f)ox
                            case 0:
                                goto Next;
                            default:
                                goto Reject;
                        }
                    }
                    case g:
                    {
                        switch(Depth)
                        {
                            case 2:
                                Token = DfaToken.Dog;
                                goto Next;
                            default:
                                goto Reject;
                        }
                    }
                    case h:
                    {
                        switch(Depth)
                        {
                            // (h)ound
                            case 0:
                                goto Next;
                            // c(h)icken
                            case 1:
                                goto Next;
                            default:
                                goto Reject;
                        }
                    }
                    case i:
                    {
                        switch(Depth)
                        {
                            // ch(i)cken
                            case 2:
                                goto Next;
                        }
                    }
                    break;
                    case j:
                    {
                        switch(Depth)
                        {
                            default:
                                goto Reject;
                        }
                    }
                    case k:
                    {
                        switch(Depth)
                        {
                            // chic(k)en
                            case 4:
                                goto Next;
                            default:
                                goto Reject;
                        }
                    }
                    case l:
                    {
                        switch(Depth)
                        {
                            default:
                                goto Reject;
                        }
                    }
                    case m:
                    {
                        switch(Depth)
                        {
                            default:
                                goto Reject;
                        }
                    }
                    case n:
                    {
                        switch(Depth)
                        {
                            // hou(n)d
                            case 3:
                                goto Next;
                            // chicke(n)
                            case 6:
                                Token = DfaToken.Chicken;
                                goto Next;
                            default:
                                goto Reject;
                        }
                    }
                    case o:
                    {
                        switch(Depth)
                        {
                            // d(o)g, f(o)x, ho(u)nd
                            case 1:
                                goto Next;
                            default:
                                goto Reject;
                        }
                    }
                    case p:
                    {
                        switch(Depth)
                        {
                            default:
                                goto Reject;
                        }
                    }
                    case q:
                    {
                        switch(Depth)
                        {
                            default:
                                goto Reject;
                        }
                    }
                    case r:
                    {
                        switch(Depth)
                        {
                            default:
                                goto Reject;
                        }
                    }
                    case s:
                    {
                        switch(Depth)
                        {
                            default:
                                goto Reject;
                        }
                    }
                    case t:
                    {
                        switch(Depth)
                        {
                            // ca(t)
                            case 2:
                                Token = DfaToken.Cat;
                                goto Next;
                            default:
                                goto Reject;
                        }
                    }
                    case u:
                    {
                        switch(Depth)
                        {
                            // ho(u)nd
                            case 2:
                                goto Next;
                            default:
                                goto Reject;
                        }
                    }
                    case v:
                    {
                        switch(Depth)
                        {
                            default:
                                goto Reject;
                        }
                    }
                    case w:
                    {
                        switch(Depth)
                        {
                            default:
                                goto Reject;
                        }
                    }
                    case x:
                    {
                        switch(Depth)
                        {
                            // fo(x)
                            case 2:
                                Token = DfaToken.Fox;
                                goto Next;
                            default:
                                goto Reject;
                        }
                    }
                    case y:
                    {
                        switch(Depth)
                        {
                            default:
                                goto Reject;
                        }
                    }
                    case z:
                    {
                        switch(Depth)
                        {
                            default:
                                goto Reject;
                        }
                    }
                    default:
                        goto Reject;
                }

                Next:
                    Accepted = true;
                    Depth++;
                    return;
                Reject:
                    Accepted = false;
                    Depth = 0;
                return;
            }
        }
    }
}