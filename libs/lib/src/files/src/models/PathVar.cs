//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct PathVar
    {
        public @string Name {get;}

        FS.FilePath _Value;

        [MethodImpl(Inline)]
        public PathVar(@string name)
        {
            Name = name;
            _Value = FS.FilePath.Empty;
        }

        [MethodImpl(Inline)]
        public PathVar(@string name, FS.FilePath value)
        {
            Name = name;
            _Value = value;
        }

        [MethodImpl(Inline)]
        public FS.FilePath Value()
            => _Value;

        [MethodImpl(Inline)]
        public PathVar Assign(FS.FilePath src)
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