//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System.Linq;

    public readonly struct LlvmEntitySet
    {
        readonly List<LlvmEntity> Data;

        public readonly Identifier Name;

        [MethodImpl(Inline)]
        public LlvmEntitySet(LlvmEntity[] src)
        {
            Name = RpOps.Empty;
            Data = new(src);
        }

        [MethodImpl(Inline)]
        public LlvmEntitySet(string name, LlvmEntity[] src)
        {
            Name = name;
            Data = new(src);
        }

        public LlvmEntitySet Children(string parent)
            => new LlvmEntitySet(parent, Data.Where(x => x.Def.Ancestors.Name == parent).ToArray());

        LlvmEntitySet Include(params LlvmEntity[] src)
        {
            Data.AddRange(src);
            return this;
        }

        public ReadOnlySpan<LlvmEntity> Members
        {
            [MethodImpl(Inline)]
            get => Data.ViewDeposited();
        }

        public static SortedDictionary<string,LlvmEntitySet> GroupByParent(ReadOnlySpan<LlvmEntity> src)
        {
            var name = EmptyString;
            var dst = new SortedDictionary<string,LlvmEntitySet>();
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var entity = ref src[i];
                if(dst.TryGetValue(entity.ParentName, out var es))
                    es.Include(entity);
                else
                {
                    dst[entity.ParentName] = new LlvmEntitySet(entity.ParentName, sys.empty<LlvmEntity>());
                    dst[entity.ParentName].Include(entity);
                }
            }

            return dst;
        }

        [MethodImpl(Inline)]
        public static implicit operator LlvmEntitySet(LlvmEntity[] src)
            => new LlvmEntitySet(src);

        [MethodImpl(Inline)]
        public static implicit operator LlvmEntitySet(Index<LlvmEntity> src)
            => new LlvmEntitySet(src);

        [MethodImpl(Inline)]
        public static implicit operator LlvmEntitySet((string name, Index<LlvmEntity> members) src)
            => new LlvmEntitySet(src.name, src.members);

        public static LlvmEntitySet Empty => new LlvmEntitySet(EmptyString, sys.empty<LlvmEntity>());
    }
}