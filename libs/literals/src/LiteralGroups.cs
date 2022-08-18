//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [LiteralProvider]
    public class LiteralGroups
    {
        const string sep = ".";

        public const string digits = nameof(digits);

        public const string @decimal = nameof(@decimal);

        public const string decimal_digits = @decimal + sep + digits;

        public const string hex = nameof(hex);

        public const string hex_digits = digits + sep + hex;

        public const string binary = nameof(binary);

        public const string binary_digits = digits + sep + binary;

        public const string octal = nameof(octal);

        public const string octal_digits =  octal + sep + digits;

        public const string api = nameof(api);

        public const string clr = nameof(clr);

        public const string files = nameof(files);

        public const string pow2 = nameof(pow2);

        public const string chars = nameof(chars);

        public const string numeric = nameof(numeric);

        public const string bitmasks = nameof(bitmasks);

        public const string perms =  nameof(perms);

        public const string blends = nameof(blends);

        public const string arrangements = nameof(arrangements);

    }
}