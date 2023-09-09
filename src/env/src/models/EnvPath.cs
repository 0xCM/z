﻿//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;
    
    public sealed class EnvPath : Seq<EnvPath,FolderPath>, IEquatable<EnvPath>
    {
        public static string format(EnvPath src, char sep = Chars.Semicolon)
        {
            var dst = text.emitter();
            var count = src.Count;
            for(var i=0; i<count; i++)
            {
                dst.Append(src[i].Format(PathSeparator.BS));
                if(i != count - 1)
                    dst.Append(sep);
            }
            return dst.Emit();
        }

        public readonly EnvPathKind Kind;

        public EnvPath()
        {
            Kind = 0;
        }

        public EnvPath(EnvPathKind kind)
        {
            Kind = kind;
        }

        [MethodImpl(Inline)]
        public EnvPath(FolderPath[] src)
            : base(src)
        {
            Kind = 0;

        }

        [MethodImpl(Inline)]
        public EnvPath(EnvPathKind kind, FolderPath[] src)
            : base(src)
        {
            Kind = kind;
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
            return new EnvPath(Kind, dst);
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
            return new EnvPath(Kind, dst);
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
            => format(this);
        
        // [MethodImpl(Inline)]
        // public static implicit operator EnvPath(FolderPath[] src)
        //     => new (src);

        // [MethodImpl(Inline)]
        // public static implicit operator FolderPath[](EnvPath src)
        //     => src.Storage;
    }
}