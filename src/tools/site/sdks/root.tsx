import * as T from "../core/tokens"
import {EnvRoot} from "../pkg"

export type SdkRoot = `${EnvRoot}/${T.Sdks}`
export function SdkRoot() : SdkRoot {
    return `${EnvRoot()}/sdks`
}
