//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CellDispenser<T> : Dispenser<CellDispenser<T>>    
        where T : unmanaged
    {
        readonly uint CellCount;
        
        readonly ByteSize CellSize;

        readonly MemoryDispenser Dispenser;

        public CellDispenser(uint count)
            : base(true)
        {
            CellSize = sys.size<T>();
            CellCount = count;
            Dispenser = Dispense.memory(CellCount*CellSize);
        }

        [MethodImpl(Inline)]
        public ref T Cell()
            => ref sys.@as<T>(Dispenser.Memory(CellSize).Cell(0));

        protected override void Dispose()
            => (Dispenser as IDisposable).Dispose();
    }
}