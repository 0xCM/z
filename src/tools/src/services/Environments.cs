//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class Environments
    {
        public readonly struct Win64 : IEnv<Win64>
        {
            public const string Name = "win-x64";

            public bool IsEmpty => false;

            public bool Equals(Win64 src)
                => true;

            public int CompareTo(Win64 src)
                => 0;

            public Hash32 Hash
            {
                [MethodImpl(Inline)]
                get => sys.hash(Name);
            }

            Win64 IEnv<Win64>.Name 
                => default;

            public string Format()
                => Name;

            public override string ToString()
                => Format();

        }
    }
}