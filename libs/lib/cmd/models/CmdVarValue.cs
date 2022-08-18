//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct CmdVarValue : ICmdVarValue<string>
    {
        [Op]
        public static string format(CmdVarValue src)
            => src.Content ?? EmptyString;

        public string Content {get;}

        [MethodImpl(Inline)]
        public CmdVarValue(string name)
            => Content = name;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => blank(Content);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => nonempty(Content);
        }

        [MethodImpl(Inline)]
        public string Format()
            => format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator CmdVarValue(string content)
            => new CmdVarValue(content);

        [MethodImpl(Inline)]
        public static implicit operator string(CmdVarValue src)
            => src.Content;

        public static CmdVarValue Empty
            => new CmdVarValue(EmptyString);
    }
}