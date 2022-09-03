//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct Ancestors
    {
        [MethodImpl(Inline)]
        public static Ancestors create(LabelDispenser dispenser)
            => new Ancestors(dispenser);

        readonly LabelDispenser Dispenser;

        [MethodImpl(Inline)]
        public Ancestors(LabelDispenser dispenser)
        {
            Dispenser = dispenser;
        }

        public bool Parse(string src, out Ancestry dst)
        {
            dst = Ancestry.Empty;
            const string sep = "->";
            var input = text.trim(src);
            if(empty(input))
                return false;

            if(input.Contains(sep))
            {
                var parts = @readonly(input.Split(sep).Select(x => x.Trim()));
                var count = parts.Length;
                if(count == 0)
                    return false;
                if(count == 1)
                    dst = new Ancestry(Dispenser.Label(first(parts)));
                else
                {
                    var names = alloc<Label>(count-1);
                    for(var i=1; i<count; i++)
                        seek(names,i-1) = Dispenser.Label(skip(parts,i));
                    dst = new Ancestry(first(parts), names);
                }
            }
            else
                dst = new Ancestry(input);

            return dst.IsNonEmpty;
        }
    }
}