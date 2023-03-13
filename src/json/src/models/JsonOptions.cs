//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Text.Json;

    public class JsonOptions
    {
        static JsonOptions _Default = new();

        public static ref readonly JsonOptions Default => ref _Default;

        readonly JsonSerializerOptions _Serializer;

        readonly JsonWriterOptions _Writer;

        readonly JsonReaderOptions _Reader;

        public ref readonly JsonSerializerOptions Serializer => ref _Serializer;

        public ref readonly JsonWriterOptions Writer => ref _Writer;

        public ref readonly JsonReaderOptions Reader => ref _Reader;

        public JsonOptions()
        {
            _Serializer = new JsonSerializerOptions{
                AllowTrailingCommas = true,
                IncludeFields = true,
                WriteIndented = true,
            };

            _Reader = new JsonReaderOptions{
                AllowTrailingCommas = true, 
                CommentHandling = JsonCommentHandling.Skip
                };
            _Writer = new JsonWriterOptions{
                Indented = true,                
            };
        }
    }
}