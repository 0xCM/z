//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

using static sys;

public class SymbolDispenser : Dispenser<SymbolDispenser>, ISymbolDispenser
{
    public const uint DefaultCapacity = Pow2.T12;

    readonly Dictionary<long,LabelAllocator> Allocators;

    public SymbolDispenser(uint capacity = DefaultCapacity)
        : base(true)
    {
        Allocators = new();
        Allocators[Seq] = LabelAllocator.alloc(DefaultCapacity);
    }

    protected override void Dispose()
    {
        iter(Allocators.Values, a => a.Dispose());
    }

    Label DispenseLabel(ReadOnlySpan<char> content)
    {
        var label = Label.Empty;
        lock(Locker)
        {
            var allocator = Allocators[Seq];
            if(!allocator.Alloc(content, out label))
            {
                allocator = LabelAllocator.alloc(DefaultCapacity);
                allocator.Alloc(content, out label);
                Allocators[next()] = allocator;
            }
        }
        return label;
    }

    public LocatedSymbol Symbol(MemoryAddress location, ReadOnlySpan<char> name)
        => Symbol(new SymAddress(0,location), name);

    public LocatedSymbol Symbol(SymAddress location, ReadOnlySpan<char> name)
        => new (location, DispenseLabel(name));
}
