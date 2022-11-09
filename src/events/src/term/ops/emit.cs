//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct term
    {
        public static void emit(IEvent e)
            => T.WriteLine(e.Format(), e.Flair);
    }
}