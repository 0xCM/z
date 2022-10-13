import { Locatable,Named,Literal,Kinded } from "./literals"

export interface Artifact<K,N extends Literal,L extends Literal> extends Kinded<K> , Named<N>, Locatable<L> {

}

export function artifact<N extends Literal,L extends Literal,K extends Literal>(kind:K,name:N,location:L) : Artifact<K,N,L> {
    return {
        kind,
        name,
        location,
    }
}