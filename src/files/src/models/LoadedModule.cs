//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public record class LoadedModule
    {
        public readonly @string Name;

        public readonly MemoryAddress Address;

        public LoadedModule(string name, MemoryAddress address)
        {
            Name = name;
            Address = address;
        }

        public bool IsValid
        {
            [MethodImpl(Inline)]
            get => Address != 0;
        }

        public string Format()
            => IsValid ? $"{Address}: {Name}" : $"{Name}: <invalid>";

        public override string ToString()
            => Format();
    }
}