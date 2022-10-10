import { Named } from "./common"
import { Kinded } from "./kinds"
import { Locatable } from "./locations"

export interface Artifact<K,N,L> extends Kinded<K> , Named<N>, Locatable<L> {

}

export function artifact<N,L,K>(kind:K,name:N,location:L) : Artifact<K,N,L> {
    return {
        kind,
        name,
        location,
    }
}