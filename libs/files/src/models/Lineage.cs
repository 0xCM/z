//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    public class Lineage
    {
        public static bool parse(string content, out Lineage dst)
        {
            var m = SQ.index(content, Chars.FSlash, Chars.FSlash);
            if(m >= 0)
            {
                var chain = text.trim(text.right(content, m + 1)).Split(Chars.Space);
                if(chain.Length > 0)
                {
                    dst = Lineage.path(chain);
                    return true;
                }
            }
            dst = Lineage.Empty;
            return false;
        }

        public static string parent(Lineage src)
            => src != null && src.IsNonEmpty ? src.Name : EmptyString;

        public static Index<string> ancestors(Lineage src)
        {
            var dst = sys.empty<string>();
            if(src != null && src.IsNonEmpty)
            {
                if(src.HasAncestor)
                    dst = Algs.concat(new string[]{src.Name}, src.Ancestors.Storage);
                else
                    dst = new string[]{src.Name};
            }
            return dst;
        }

        [MethodImpl(Inline)]
        public static Lineage root(string name)
            => new Lineage(name);

        public static Lineage parse(string src, string sep = "->")
        {
            var input = text.trim(src);
            if(empty(input))
                return Lineage.Empty;
            else if(input.Contains(sep))
            {
                var parts = @readonly(input.Split(sep).Select(x => x.Trim()));
                var count = parts.Length;
                if(count == 0)
                    return Lineage.Empty;

                if(count == 1)
                    return new Lineage(first(parts));
                else
                    return new Lineage(first(parts), slice(parts,1).ToArray());
            }
            else
                return new Lineage(input);
        }

        public static Lineage path(ReadOnlySpan<string> src)
        {
            var count = src.Length;
            if(count == 0)
                return Lineage.Empty;
            else if(count == 1)
                return new Lineage(first(src));
            else
                return new Lineage(first(src), slice(src,1).ToArray());
        }

        Lineage(string name, string[] ancestors)
        {
            Name = name;
            Ancestors = ancestors;
            IsEmpty = false;
        }

        Lineage(string name)
        {
            Name = name;
            Ancestors = Index<string>.Empty;
            IsEmpty = false;
        }

        Lineage()
        {
            Name = EmptyString;
            IsEmpty = true;
        }

        public Index<string> Ancestors {get;}

        public string Name {get;}

        public bool IsEmpty {get;}

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public bool HasAncestor
        {
            [MethodImpl(Inline)]
            get => Ancestors.IsNonEmpty;
        }

        public string Format()
            => Format(LeftToRight);

        public string Format(string sep)
        {
            var dst = text.buffer();
            if(IsNonEmpty && nonempty(Name))
            {
                dst.Append(Name);
                var count = Ancestors.Count;
                for(var i=0; i<count; i++)
                {
                    dst.Append(sep);
                    dst.Append(Ancestors[i]);
                }
            }
            return dst.Emit();

        }

        const string LeftToRight = " -> ";

        public override string ToString()
            => Format();

        public static Lineage Empty => new Lineage();
    }
}