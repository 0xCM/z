//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed record class LocatedTool : IDataType<LocatedTool>, ISequential<LocatedTool>
    {
        public uint Seq;
    
        public ToolKey Key;
    
        public FileUri Path;
        
        public LocatedTool(uint seq, ToolKey key, FileUri path)
        {
            Seq = seq;
            Key = key;
            Path = path;
        }

        public string Name
        {
            [MethodImpl(Inline)]
            get => Path.FileName().WithoutExtension.Format();
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Key.Hash | Path.Hash;
        }

        public override int GetHashCode()
            => Hash;

        public int CompareTo(LocatedTool src)
            => Key.CompareTo(src.Key);
        
        public bool Equals(LocatedTool src)
            => Key == src.Key && Path == src.Path;

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Key.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Key.IsNonEmpty;
        }

        uint ISequential.Seq
        {
            get => Seq;
            set => Seq = value;
        }

        public static LocatedTool Empty => new LocatedTool(0,ToolKey.Empty,FileUri.Empty);
    }

}