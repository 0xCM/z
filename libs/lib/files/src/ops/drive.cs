//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct FS
    {
        [MethodImpl(Inline), Op]
        public static Drive drive(DriveLetter letter)
            => new Drive(letter);
            
        [Op]
        public static Outcome drive(FS.FolderPath src, out Drive dst)
            => drive(src.Format(), out dst);

        [Op]
        public static Outcome drive(FS.FilePath src, out Drive dst)
            => drive(src.Format(), out dst);

         /// <summary>
        /// Attempts to parse a drive letter from a path
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        [Op]
        public static Outcome drive(string src, out Drive dst)
        {
            var i = text.index(src, Chars.Colon);
            var result = Outcome.Failure;
            dst = default;
            if(i>=0)
            {
                var spec = text.left(src,i);
                if(spec.Length == 1)
                {
                    var c = spec[0].ToUpper();
                    if(c >= (char)DriveLetter.A && c<= (char)DriveLetter.B)
                    {
                        dst = (DriveLetter)c;
                        result = true;
                    }
                }
            }
            return result;
        }
    }
}