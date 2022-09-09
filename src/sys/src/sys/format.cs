//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class sys
    {
        public static string format<P>(P pattern, params object[] args)
        {
            var result = EmptyString;
            try
            {
                result = string.Format($"{pattern}", args);
            }
            catch(FormatException)
            {
                var msg = $"A useless {nameof(FormatException)} trapped; Useful(pattern:={pattern}, operands:={args})";
                @throw(msg);
            }
            catch(Exception)
            {
                throw;
            }
            return result;
        }
    }
}