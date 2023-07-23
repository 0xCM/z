//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed record class LocatedTool : IDataType<LocatedTool>
    {    
        public ToolKey Key;

        public LocatedTool(ToolKey key)
        {
            Key = key;
        }

        public uint Seq
        {
            [MethodImpl(Inline)]
            get => Key.Seq;
        }

        public FilePath Path
        {
            [MethodImpl(Inline)]
            get => Key.Path;
        }
        
        public string Name
        {
            [MethodImpl(Inline)]
            get => Path.FileName.WithoutExtension.Format();
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Key.Hash | Path.Hash;
        }

        public override int GetHashCode()
            => Hash;

        public string Format()
            => $"{Path.FileName}={Key.Path}";

        public override string ToString()
            => Format();
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

        public static LocatedTool Empty => new (ToolKey.Empty);
    }
}