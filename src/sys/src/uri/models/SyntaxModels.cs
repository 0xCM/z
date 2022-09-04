//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    [ApiHost]
    public class SyntaxModels
    {
        static string[] NodeNames = new string[]{
            EmptyString
        };

        static ConcurrentDictionary<string,ushort> NodeIndexMap = sys.mapi(NodeNames, (i,n) => (n,(ushort)i)).ToConcurrentDictionary();

        public static NodeName name(string src)
        {
            var dst = NodeName.Empty;
            if(NodeIndexMap.TryGetValue(src, out var i))
                dst = new (i);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static NodePath path(params NodeName[] src)
        {
            var storage = default(PathData);
            var count = (byte)min(src.Length,PathData.Segments);
            ref var dst = ref @as<PathData,NodeName>(storage);
            @as<NodeName,byte>(seek(dst,0)) = count;
            for(var i=1; i<count; i++)
                seek(dst,i) = skip(src,i);       
            return new (storage);
        }

        public struct NodePath
        {
            PathData Data;

            [MethodImpl(Inline)]
            internal NodePath(PathData src)
            {
                Data = src;
            }

        }

        [StructLayout(LayoutKind.Sequential,Size=Size)]
        internal struct PathData
        {
            public const byte Size = 32;

            public const byte Segments = (Size/NodeName.Size) - 1;
        }

        public readonly struct NodeName : IDataType<NodeName>, IDataString
        {
            internal const byte Size = 2;

            readonly ushort Index;

            [MethodImpl(Inline)]
            internal NodeName(ushort index)
            {
                Index = index;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Index == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Index != 0;
            }

            public Hash32 Hash
            {
                [MethodImpl(Inline)]
                get => Index;
            }

            public override int GetHashCode()
                => Hash;

            [MethodImpl(Inline)]
            public string Format()
                => skip(NodeNames,Index);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public bool Equals(NodeName src)
                => Index == src.Index;

            public int CompareTo(NodeName src)
                => Index.CompareTo(src.Index);

            public static NodeName Empty => new(0);
        }
    }

    // URI = scheme ":" ["//" authority] path ["?" query] ["#" fragment]

}