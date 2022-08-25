//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct PathVar
    {
        public @string Name {get;}

        FilePath _Value;

        [MethodImpl(Inline)]
        public PathVar(@string name)
        {
            Name = name;
            _Value = FilePath.Empty;
        }

        [MethodImpl(Inline)]
        public PathVar(@string name, FilePath value)
        {
            Name = name;
            _Value = value;
        }

        [MethodImpl(Inline)]
        public FilePath Value()
            => _Value;

        [MethodImpl(Inline)]
        public PathVar Assign(FilePath src)
        {
            _Value = src;
            return this;
        }

        [MethodImpl(Inline)]
        public static implicit operator PathVar(string name)
            => new PathVar(name);

        [MethodImpl(Inline)]
        public static implicit operator PathVar(@string name)
            => new PathVar(name);
    }
}