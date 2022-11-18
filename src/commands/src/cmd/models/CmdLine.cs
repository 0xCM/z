//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Captures the content of a command-line
    /// </summary>
    public readonly record struct CmdLine
    {
        readonly Index<string> Data;

        [MethodImpl(Inline)]
        public CmdLine(params string[] content)
        {
            Data = content;
        }

        public ReadOnlySpan<CmdLinePart> Parts
        {
            [MethodImpl(Inline)]
            get => sys.recover<string,CmdLinePart>(Data.Edit);
        }

        [MethodImpl(Inline)]
        public string Format()
            => text.delimit(Data.View, Chars.Space, 0);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator CmdLine(string src)
            => new CmdLine(src);

        [MethodImpl(Inline)]
        public static implicit operator CmdLine(string[] src)
            => new CmdLine(src);

        [MethodImpl(Inline)]
        public static implicit operator string(CmdLine src)
            => src.Format();

        public static CmdLine Empty
        {
            [MethodImpl(Inline)]
            get => new CmdLine(sys.empty<string>());
        }
    }
}