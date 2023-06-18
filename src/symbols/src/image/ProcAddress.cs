//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0;

public readonly record struct ProcAddress : IDataType<ProcAddress>
{
    public readonly ProcessId ProcessId;

    public readonly MemoryAddress Address;

    [MethodImpl(Inline)]
    public ProcAddress(ProcessId id, MemoryAddress address)
    {
        ProcessId = id;
        Address = address;
    }

    public Hash32 Hash
    {
        [MethodImpl(Inline)]
        get => sys.hash(ProcessId, Address);
    }

    public bool IsEmpty
    {
        [MethodImpl(Inline)]
        get => ProcessId == 0;
    }

    public bool IsNonEmpty
    {
        [MethodImpl(Inline)]
        get => ProcessId != 0;
    }

    [MethodImpl(Inline)]
    public unsafe void* Pointer()
        => Address.Pointer();

    [MethodImpl(Inline)]
    public int CompareTo(ProcAddress src)
        => Address.CompareTo(src.Address);

    [MethodImpl(Inline)]
    public bool Equals(ProcAddress src)
        => ProcessId == src.ProcessId && Address == src.Address;

    public override int GetHashCode()
        => (int)Address.Hash;

    [MethodImpl(Inline)]
    public static implicit operator ProcAddress((ProcessId id, MemoryAddress address) src)
        => new ProcAddress(src.id, src.address);

    [MethodImpl(Inline)]
    public static implicit operator ProcAddress((int id, MemoryAddress address) src)
        => new ProcAddress((uint)src.id, src.address);

    [MethodImpl(Inline)]
    public static implicit operator ProcAddress((uint id, MemoryAddress address) src)
        => new ProcAddress((uint)src.id, src.address);
}
