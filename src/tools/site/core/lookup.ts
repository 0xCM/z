
export type Kvp<K,V> = {
    key:K
    value:V
}

export type KeyedValues<K,V> = Array<Kvp<K,V>>

export type Lookup<K,V> = Map<K,V>

export function kvp<K,V>(key:K,value:V) {
    return {
        key,
        value
    }
}

export function lookup<K,V>(src?:KeyedValues<K,V>) : Lookup<K,V> {
    var dst = Map.prototype
    if(src != null)
    {
        src.forEach(kvp => {
            dst.set(kvp.key, kvp.value)
        });
    }
    return dst;
}
