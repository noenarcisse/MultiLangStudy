# Go
## Project structure
Vertical slice :
  ```
//todo
Projet
|
|  cmd/
|  |       cli/
|  |       test1/
|  |       server/
|  internal/
|  |       slice1/
|  |       slice2/
|  |       slice3/
|  pkg/
|  |      pkg1/
  ```
## Go cmd
### run
lance par le point d'entrée ciblé en path
  ```
  go run path
  ```
### build
build en exe
  ```
  go build path
  ```
### get
telecharge un pkg
  ```
  go build path
  ```
### get -u
met a jour l'ensemble des pkg du projet
  ```
  go get -u ./...
  ```

### go test
exec les tests
  ```
  go test ./...
  ```

### vuln check
verifie les vulenrabilité présente dans le projet. Sépare les packages ou zone de code utilisées vs les packages non appelé dans le code du projet
  ```
  govulncheck -show verbose ./...
  ```

### go fmt
formatte le code d'un proj avec options
https://go.dev/blog/gofix
  ```
cmd
  ```
### go fix
fix le code go d'un projet, permet aussi de remplacer facilement d'ancienne ecriture en nouvelle (genre interface{} -> any)
https://go.dev/blog/gofix
  ```
cmd
  ```

## pprof
le profiler de go
https://github.com/google/pprof

## delve
debugger
https://github.com/go-delve/delve

## deadcode
code non accessible (y'a pas de couv de branches en go test)
https://go.dev/blog/deadcode
