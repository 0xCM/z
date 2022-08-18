//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CodeBlockPair
    {
        [MethodImpl(Inline), Op]
        public static CodeBlockPair create(MemoryAddress @base, byte[] raw, byte[] parsed)
            => new CodeBlockPair(@base, new CodeBlock(@base, raw), new CodeBlock(@base,parsed));

        public MemoryAddress Base {get;}

        public CodeBlock Raw {get;}

        public CodeBlock Parsed {get;}

        [MethodImpl(Inline)]
        public CodeBlockPair(MemoryAddress @base, CodeBlock raw, CodeBlock parsed)
        {
            Base = @base;
            Raw = raw;
            Parsed = parsed;
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Parsed.Length;
        }

        public ref readonly byte this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Parsed[index];
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Parsed.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Parsed.IsNonEmpty;
        }

        [MethodImpl(Inline)]
        public bool Equals(CodeBlockPair src)
            => Parsed.Equals(src.Parsed);

        public string Format()
            => Parsed.Format();

        public override string ToString()
            => Format();
    }
}