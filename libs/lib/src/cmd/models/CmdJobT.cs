//-----------------------------------------------------------------------------
// Copyright   : (c) Chris Moore, 2020
// License     : MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CmdJob<T>
        where T : struct
    {
        public readonly Name Name;

        public readonly T Spec;

        [MethodImpl(Inline)]
        public CmdJob(string name, T spec)
        {
            Spec = spec;
            Name = name;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Spec.ToString();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator CmdJob(CmdJob<T> src)
            => new CmdJob(src.Name, src.Format());
    }
}