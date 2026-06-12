# titre1
## C#
### titre
  text)<br>
  ```
  //code
  ```
## Go
### Go routines
  Green threads, fait du parallelism risqué (comparé a C#). Y'a beaucoup d'erreurs possibles qui peuvent entrainer des deadlocks<br>
  ```
  //code
  ```
### chan
  Equivalent de channel de C#<br>
  Beaucoup de dealocks possibles (lire un chan eternellement vide, mal le vider etc)
  ```
  //code
  ```
### Mutex
  permet de lock des zones pour eviter les races de goroutines, c'est le ConcurrentBag et autres de C#<br>
  ```go
var (
    links []string
    mu    sync.Mutex
)
mu.Lock()
links = append(links, "url")
mu.Unlock()
  ```
