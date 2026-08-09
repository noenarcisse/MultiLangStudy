# Transpiling
## F#
Fable
Transpile dans beaucoup de lang. Nécéssite de l'interop et une bonne connaissance des language cible, c'est pas du tout indépendant
| Language | Descr | CMD |
|---|---|---|
| Javascript | desc | `cmd` |
| Typescript | non testé | `cmd` |
| Python | desc | `cmd` |
| Erlang | non testé | `cmd` |

## Nim
| Language | Descr | CMD |
|---|---|---|
| Nim c | Transpile en C puis compile en bin | `nim c file.nim` |
| Nim js | Transpile en js indépendant | `nim js file.nim` |

## Gleam
| Language | Descr | CMD |
|---|---|---|
| Erlang | Transpile erlang par defaut | `gleam build -t erlang` |
| JS | Transpile en js indépendant, reste lisible | `gleam build -t javascript` |
