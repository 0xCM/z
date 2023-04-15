//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    
    public sealed class EnvPath : Seq<EnvPath,FolderPath>, IEquatable<EnvPath>
    {
        public EnvPath()
        {

        }

        [MethodImpl(Inline)]
        public EnvPath(FolderPath[] src)
            : base(src)
        {

        }

        public EnvPath Prepend(params FolderPath[] src)
        {
            var count = Count + src.Length;
            var dst = sys.alloc<FolderPath>(count);
            var j=0;
            for(var i=0; i<src.Length; i++)
                seek(dst,j++) = skip(src,i);
            for(var i=0; i<src.Length; i++)
                seek(dst,j++) = this[i];
            return new EnvPath(dst);
        }

        public EnvPath Concat(params FolderPath[] src)
        {
            var count = Count + src.Length;
            var dst = sys.alloc<FolderPath>(count);
            var j=0;
            for(var i=0; i<Count; i++)
                seek(dst,j++) = this[i];
            for(var i=0; i<src.Length; i++)
                seek(dst,j++) = skip(src,i);
            return new EnvPath(dst);
        }

        public bool Equals(EnvPath src)
        {
            var a = Storage.Sort();
            var b = src.Storage.Sort();
            var result = a.Length == b.Length;
            if(result)
            {
                for(var i=0; i<a.Length; i++)
                {
                    result = sys.skip(a,i) == sys.skip(b,i);
                    if(!result)
                        break;
                }
            }
            return result;
        }

        public override string ToString()
            => Format();
        public override string Format()
            => FS.format(this);
        
        [MethodImpl(Inline)]
        public static implicit operator EnvPath(FolderPath[] src)
            => new EnvPath(src);

        [MethodImpl(Inline)]
        public static implicit operator FolderPath[](EnvPath src)
            => src.Storage;
    }
}