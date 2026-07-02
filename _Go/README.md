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
### vuln check
verifie les vulenrabilité présente dans le projet. Sépare les packages ou zone de code utilisées vs les packages non appelé dans le code du projet
  ```
  govulncheck -show verbose ./...
  ```
