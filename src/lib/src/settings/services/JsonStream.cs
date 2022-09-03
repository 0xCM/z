//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;
    using System.Text;
    using System.Text.Json;

    using static core;

    using J = System.Text.Json.JsonTokenType;

    public ref struct JsonStream
    {
        public static JsonStream create(FilePath src)
            => new JsonStream(src.Utf8Reader());

        readonly JsonReaderState State;

        readonly StreamReader Stream;

        readonly BinaryReader BinaryStream;

        readonly Span<byte> Buffer;

        [MethodImpl(Inline)]
        internal JsonStream(StreamReader stream)
        {
            Stream = stream;
            BinaryStream = Stream.BinaryReader(Encoding.UTF8);
            State = new JsonReaderState(new JsonReaderOptions{AllowTrailingCommas = true, CommentHandling = JsonCommentHandling.Skip});
            Buffer = alloc<byte>(Pow2.T14);
        }

        [MethodImpl(Inline)]
        Utf8JsonReader Reader(bool last)
            => new Utf8JsonReader(Buffer,last,State);

        public void Dispose()
        {
            Stream.Dispose();
        }

        public void Read(IJsonSink dst)
        {
            var count = BinaryStream.Read(Buffer);
            while(count > 0)
            {
                var reader = Reader(count < Buffer.Length);
                var success = true;
                try
                {
                    reader.Read();
                }
                catch(Exception)
                {
                    success = false;
                }

                if(success)
                {
                    switch(reader.TokenType)
                    {
                        case J.Comment:
                            dst.Comment(reader);
                        break;
                        case J.StartArray:
                            dst.ArrayBegin(reader);
                        break;
                        case J.EndArray:
                            dst.ArrayEnd(reader);
                        break;
                        case J.StartObject:
                            dst.ObjectBegin(reader);
                        break;
                        case J.EndObject:
                            dst.ObjectEnd(reader);
                        break;
                        case J.Null:
                            dst.Null(reader);
                        break;
                        case J.Number:
                            dst.Number(reader);
                        break;
                        case J.PropertyName:
                            dst.PropertyName(reader);
                        break;
                        case J.String:
                            dst.String(reader);
                        break;
                        case J.True:
                        case J.False:
                            dst.Bool(reader);
                        break;
                        default:
                            break;
                    }
                }

                Buffer.Clear();
                count = BinaryStream.Read(Buffer);
            }
        }
    }
}