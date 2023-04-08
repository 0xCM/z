//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class CmdExpr : IExpr, IHashed, INullity
    {
        public static CmdExpr cwd() => "%~dp0";
        
        public static CmdExpr cwd(CmdExpr e) => $"{cwd()}{e}";

        public static CmdExpr call(CmdExpr script) => $"call {script}";

        public static CmdExpr set<V>(string name, V value) 
            where V : IEquatable<V>, INullity, new()
                => new CmdSetting<V>(name,value);

        public static CmdExpr script(string name) => $"{name}.cmd";

        public static CmdExpr var(string name) => $"%{name}%";

        public readonly @string Content;

        public CmdExpr()
        {
            Content = EmptyString;
        }

        [MethodImpl(Inline)]
        public CmdExpr(string content)
        {
            Content = content;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Content.Hash;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Content.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Content.IsEmpty;
        }

        public virtual bool Equals(CmdExpr src)
            => Content == src.Content;
        public string Format()
            => Content;

        public override int GetHashCode()
            => Hash;

        public override string ToString()
            => Format();

        public static CmdExpr operator +(CmdExpr a, CmdExpr b)
            => new CmdExpr($"{a.Content}{b.Content}");
    
        public static implicit operator CmdExpr(string src)
            => new CmdExpr(src);

        public static CmdExpr Empty => new (EmptyString);
    }
}