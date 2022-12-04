//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class EnvTools 
    {
        public sealed record class EnvTool : IDataType<EnvTool>, ISequential<EnvTool>
        {
            public uint Seq;
        
            public Key Key;
        
            public FileUri Path;
            
            public EnvTool(uint seq, Key key, FileUri path)
            {
                Seq = seq;
                Key = key;
                Path = path;
            }

            public FileName Name
            {
                [MethodImpl(Inline)]
                get => Path.FileName();
            }

            public Hash32 Hash
            {
                [MethodImpl(Inline)]
                get => Key.Hash | Path.Hash;
            }

            public override int GetHashCode()
                => Hash;

            public int CompareTo(EnvTool src)
                => Key.CompareTo(src.Key);
            
            public bool Equals(EnvTool src)
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

            public static EnvTool Empty => new EnvTool(0,Key.Empty,FileUri.Empty);
        }
    }
}