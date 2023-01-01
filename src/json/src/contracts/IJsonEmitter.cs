//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2023
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IJsonEmitter
    {
        void OpenArray();

        void CloseArray();

        void Delimit();

        void Object<T>(T src);

        string Emit();

        void Array<T>(JsonArray<T> src)
            where T : IJsonValue, new()
                => JsonEmitter.render(src,this);

        void Prop<T>(string name, T value);
    }
}