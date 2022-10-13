import {Edge} from "./links"

export type Step<R,S,T>  = Edge<R,S,T>

// export function step<R extends Literal,S,T>(rule:R, source:S, target:T) : Step<R,S,T> {
//     return {
//         kind:rule,
//         source,
//         target
//     }
// }

