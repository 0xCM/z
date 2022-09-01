//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    /// <summary>
    /// Matches a sequence of 3 8-bit values
    /// </summary>
    [ApiComplete]
    public struct Match3x8
    {
        [MethodImpl(Inline)]
        public static Match3x8 create(MachineSpec src)
            => new Match3x8(src);

        [MethodImpl(Inline)]
        public static MachineSpec specify(byte n, uint src)
        {
            var spec = new MachineSpec();
            spec.TermCount = n;
            spec.TermEncoding = Bytes.convert(slice(src.Bytes(), 0, n), w32);
            spec.Instruction = math.or(math.or(math.sll((uint)n, 24), 0u), spec.TermEncoding);
            return spec;
        }

        public struct MachineSpec
        {
            static MsgPattern<Count,HexArray,Hex32,HexArray> FormatPattern => "Matching a {0}-element subsequence {1} with instruction {2}:{3}";

            public byte TermCount;

            public Hex32 TermEncoding;

            public Hex32 Instruction;

            public ReadOnlySpan<byte> Terms
            {
                [MethodImpl(Inline)]
                get => slice(bytes(TermEncoding),0, TermCount);
            }

            public string Format()
                => FormatPattern.Format(TermCount, HexArray.from(Terms), Instruction, HexArray.from(Instruction));

            public override string ToString()
                => Format();
        }

        MachineSpec Spec;

        byte Matched;

        byte TermCount
        {
            [MethodImpl(Inline)]
            get => Spec.TermCount;
        }

        [MethodImpl(Inline)]
        ref readonly byte Term(byte index)
            => ref skip(Spec.Terms,index);

        [MethodImpl(Inline)]
        Match3x8(MachineSpec spec)
        {
            Spec = spec;
            Matched = 0;
        }

        /// <summary>
        /// If target sequence was matched, returns the index of the first element  of the match sequence; otherwise returns -1
        /// </summary>
        /// <param name="input">The sequence to search</param>
        public int Run(ReadOnlySpan<byte> input)
        {
            var j = -1;
            var count = input.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var b = ref skip(input, i);
                if(Accept(b))
                {
                    switch(Matched)
                    {
                        case 1:
                            j = i;
                        break;
                        case 2:
                            j = i - 1;
                        break;
                        case 3:
                            j = i - 2;
                        break;
                    }
                }
                if(j>0)
                    break;
            }

            return j;
        }

        bit Accept(byte input)
        {
            var result = bit.Off;
            switch(TermCount)
            {
                case 1:
                    result = Match(n1, input);
                break;
                case 2:
                    result = Match(n2, input);
                break;
                case 3:
                    result = Match(n3, input);
                break;
            }
            return result;
        }

        /// <summary>
        /// Matches a single byte
        /// </summary>
        /// <param name="n">The match count selector</param>
        /// <param name="input">The input token</param>
        bit Match(N1 n, byte input)
        {
            var result = bit.Off;
            switch(Matched)
            {
                case 0:
                    if(input == Term(Matched))
                        Matched = 1;
                        result = bit.On;
                break;
                default:
                    Matched = 0;
                    break;
            }
            return result;
        }

        /// <summary>
        /// Matches a 2-byte sequence
        /// </summary>
        /// <param name="n">The match count selector</param>
        /// <param name="input">The input token</param>
        bit Match(N2 n, byte input)
        {
            var result = bit.Off;
            switch(Matched)
            {
                case 0:
                    if(input == Term(Matched))
                        Matched = 1;
                break;
                case 1:
                    if(input == Term(Matched))
                        Matched = 1;
                        result = bit.On;
                break;
                default:
                    Matched = 0;
                    break;
            }

            return result;
        }

        /// <summary>
        /// Matches a 3-byte sequence
        /// </summary>
        /// <param name="n">The match count selector</param>
        /// <param name="input">The input token</param>
        bit Match(N3 n, byte input)
        {
            var result = bit.Off;
            switch(Matched)
            {
                case 0:
                    if(input == Term(Matched))
                        Matched = 1;
                break;
                case 1:
                    if(input == Term(Matched))
                        Matched = 2;
                break;
                case 2:
                    if(input == Term(Matched))
                        Matched = 3;
                        result = bit.On;
                break;
                default:
                    Matched = 0;
                    break;
            }
            return result;
        }

        /// <summary>
        /// Matches a 4-byte sequence
        /// </summary>
        /// <param name="n">The match count selector</param>
        /// <param name="input">The input token</param>
        bit Match(N4 n, byte input)
        {
            var result = bit.Off;
            switch(Matched)
            {
                case 0:
                    if(input == Term(Matched))
                        Matched++;
                break;
                case 1:
                    if(input == Term(Matched))
                        Matched++;
                break;
                case 2:
                    if(input == Term(Matched))
                        Matched++;
                break;
                case 3:
                    if(input == Term(Matched))
                        result = bit.On;
                        Matched++;
                break;
                default:
                    Matched = 0;
                    break;
            }
            return result;
        }

        /// <summary>
        /// Matches a 5-byte sequence
        /// </summary>
        /// <param name="n">The match count selector</param>
        /// <param name="input">The input token</param>
        bit Match(N5 n, byte input)
        {
            var result = bit.Off;
            switch(Matched)
            {
                case 0:
                    if(input == Term(Matched))
                        Matched++;
                break;
                case 1:
                    if(input == Term(Matched))
                        Matched++;
                break;
                case 2:
                    if(input == Term(Matched))
                        Matched++;
                break;
                case 3:
                    if(input == Term(Matched))
                        Matched++;
                break;
                case 4:
                    if(input == Term(Matched))
                        result = bit.On;
                        Matched++;
                break;
                default:
                    Matched = 0;
                    break;
            }
            return result;
        }

        /// <summary>
        /// Matches a 6-byte sequence
        /// </summary>
        /// <param name="n">The match count selector</param>
        /// <param name="input">The input token</param>
        bit Match(N6 n, byte input)
        {
            var result = bit.Off;
            switch(Matched)
            {
                case 0:
                    if(input == Term(Matched))
                        Matched++;
                break;
                case 1:
                    if(input == Term(Matched))
                        Matched++;
                break;
                case 2:
                    if(input == Term(Matched))
                        Matched++;
                break;
                case 3:
                    if(input == Term(Matched))
                        Matched++;
                break;
                case 4:
                    if(input == Term(Matched))
                        Matched++;
                break;
                case 5:
                    if(input == Term(Matched))
                        result = bit.On;
                        Matched++;
                break;
                default:
                    Matched = 0;
                    break;
            }
            return result;
        }
    }
}