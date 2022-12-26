//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public sealed class EnvVars : Seq<EnvVars,EnvVar>
    {
        public EnvVars()
        {

        }
        
        [MethodImpl(Inline)]
        public EnvVars(EnvVar[] src)
            : base(src)
        {
        }

        public EnvVars Replace(EnvVar src)
        {
            for(var i=0; i<Count; i++)
            {
                if(this[i].Name == src.Name)
                {
                    this[i] = src;
                    break;
                }
            }
            return this;
        }

        public bool Find(@string name, out @string value)
        {
            for(var i=0; i<Count; i++)
            {
                if(this[i].Name == name)
                {
                    value = this[i].Value;
                    return true;
                }
            }
            value = @string.Empty;
            return false;
        }

        public override string Format()
        {
            var dst = text.emitter();
            var src = View;
            var count = src.Length;
            for(var i=0; i<count; i++)
                dst.AppendLine(skip(src,i));
            return dst.Emit();
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator EnvVars(EnvVar[] src)
            => new EnvVars(src);

        [MethodImpl(Inline)]
        public static implicit operator EnvVars(List<EnvVar> src)
            => new EnvVars(src.ToArray());

        [MethodImpl(Inline)]
        public static implicit operator EnvVar[](EnvVars src)
            => src.Storage;
    }
}