//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Defines a file emission payload
    /// </summary>
    public readonly struct FileEmission
    {
        [Op]
        public static Outcome<FileEmission> emissions(Files src, bool uri, FilePath dst)
        {
            var counter  = 0;
            try
            {
                using var writer = dst.Writer();
                for(var i=0; i<src.Count; i++)
                {
                    ref readonly var file = ref src[i];
                    writer.WriteLine(uri ? file.ToUri().Format() : file.Format());
                    counter++;
                }

                return new FileEmission(dst, (int)counter);
            }
            catch(Exception e)
            {
                return e;
            }
        }
                
        /// <summary>
        /// The emission target
        /// </summary>
        public readonly FilePath Target;

        public readonly uint Count;

        [MethodImpl(Inline)]
        public FileEmission(FilePath target, Count count)
        {
            Target = target;
            Count = count;
        }

        public bool Succeeded
        {
            [MethodImpl(Inline)]
            get => Count >= 0;
        }
    }
}