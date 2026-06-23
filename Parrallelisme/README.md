# titre1
## C#
### Parrallel
  text)<br>
  ```
  //code
  ```
### ConcurrentBag / Dict etc
  text)<br>
  ```
  //code
  ```
### CT
  text)<br>
  ```
  //code
  ```
## Go
### Go routines
  Green threads, fait du parallelism risqué (comparé a C#). Y'a beaucoup d'erreurs possibles qui peuvent entrainer des deadlocks (lecture d'un chan vide, ecriture d'un chan fermé etc)<br>
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
### context
  Ca sert a plusieur objectifs pour aider la concurrences et le parallélisme<br>
  contexte permet de chainer un arbre de contexte parents-enfants qui sert a faire remonter les infos ou les sortie d'exec (comme un CT) <br>
  Il permet de donner des infos qui passent pas en params et doivent être garantie comme imut pour les différentes goroutines
  ```go
func main() {

	delay := time.Now().Add(time.Second * 5)
	ctx1 := context.Background()
	ctx2 := context.WithValue(ctx1, "truc", "lavaleurdetruc") //value qui peut etre recup par tous les enfants aussi
	ctx3, cancel := context.WithDeadline(ctx2, delay)
	ctx4, cancel := context.WithCancel(ctx3)
	defer cancel()

	context.AfterFunc(ctx3, func() {
		fmt.Println("Je dois vraiment afficher ce message")
		fmt.Println(ctx3.Err())
	})

	wg := sync.WaitGroup{}
	wg.Go(func() {
		test(ctx3)
	})
	wg.Go(func() {
		test2(ctx4)
	})
	wg.Wait()

}

func test(ctx context.Context) {

	fmt.Println("test value:", ctx.Value("truc"))

	for i := 0; i < 10; i++ {

		select {
		case <-ctx.Done():
			fmt.Println("test annulé")
			return
		default:
		}

		fmt.Println("Sleep n", i)
		time.Sleep(time.Second * 1)
	}
}
func test2(ctx context.Context) {

	fmt.Println("test2 value:", ctx.Value("truc"))
	done := make(chan struct{})

	go func() {
		fmt.Println("Du traitement en cours")
		time.Sleep(time.Second * 2)
		fmt.Println("Traitement terminé")
		close(done)
	}()

	select {
	case <-ctx.Done():
		fmt.Println("test2 annulé")
		return
	case <-done:
		fmt.Println("test2 terminé sans souci")
	}
}
  ```
