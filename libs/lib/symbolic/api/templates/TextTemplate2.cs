//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Characterizes a pararametric text block bound to an arbitrary number of variables
    /// </summary>
    public interface ITextTemplate : IExpr
    {
        TextBlock Pattern {get;}

        Seq<object> Vars {get;}

        uint VarCount
            => Vars.Count;

        bool INullity.IsEmpty
            => Pattern.IsEmpty;

        bool INullity.IsNonEmpty
            => Pattern.IsNonEmpty;
    }
    
    public class TextTemplate : ITextTemplate
    {
        public readonly TextBlock Pattern;

        public readonly Seq<object> Vars;

        public readonly uint VarCount;

        public TextTemplate(string src)
        {
            Pattern = src ?? EmptyString;
            Vars = sys.empty<object>();
            VarCount = 0;
        }

        public TextTemplate(string src, object[] vars)
        {
            Pattern = src ?? EmptyString;
            Vars = vars;
            VarCount = (uint)vars.Length;
        }

        public TextTemplate(string src, uint varcount)
        {
            Pattern = src ?? EmptyString;
            Vars = sys.alloc<object>(varcount);
            VarCount = varcount;
            for(var i=0; i<VarCount; i++)
                this[i] = EmptyString;
        }

        [MethodImpl(Inline)]
        public ref T Var<T>(uint index)
            => ref sys.@as<object,T>(Vars[index]);

        [MethodImpl(Inline)]
        public ref T Var<T>(int index)
            => ref sys.@as<object,T>(Vars[index]);

        public ref object this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Vars[i];
        }

        public ref object this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Vars[i];
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Pattern.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Pattern.IsNonEmpty;
        }

        Seq<object> ITextTemplate.Vars
            => Vars;

        TextBlock ITextTemplate.Pattern
            => Pattern;

        public string Format()
            => Vars.IsNonEmpty ? string.Format(Pattern, Vars) : Pattern;

        public override string ToString()
            => Format();
    }
}