# Parallelisme et concurrence
## C#
### Parrallel
  Multithreading, pareil à 100% que go func(a) {print(a)}. Ca résout dans un ordre au pif en fonction de la vitesse des threads.<br>
  ```cs
Action<string> f = a => Console.WriteLine(a);
List<string> arr = ["Salut", "moi", "c'est", "Caillou"];
Parallel.ForEach(arr, f);
  ```
### PLINQ
  Parallel LINQ :><br>
  ```cs
List<string> arr = ["Salut", "moi", "c'est", "Caillou", "moi", "moi aussi"];
var query = arr.AsParallel().Where(x => x.Length >= 5);
foreach(var res in query) {
	Console.WriteLine(res);
}
  ```
### ConcurrentBag / Dict etc
  text)<br>
  ```cs
  //code
  ```
### CT
  text)<br>
  ```cs
  //code
  ```
### Channel
  En C# on a le choix entre des chan buffé ou pas<br>
  Il y a des possibilités de deadlocks mais c'est un peu plus calme que Go.
  ```cs
Channel<string> c = Channel.CreateBounded<string>(1); // le ticket de Charlie et la chocolaterie
Channel<string> c = Channel.CreateUnbounded<string>(); // ici c'est 
  ```
### lock{}
  Similaire au mutex de Go, on l'active / desactive quand on en a besoin autour ses zones sensibles. Possiblement on peut l'eviter quand on travaille avec des Concurrent Collections<br>
  ```cs
  //code
  ```
## Go
### Go routines
  Green threads, fait du parallelism risqué (comparé a C#). Y'a beaucoup d'erreurs possibles qui peuvent entrainer des deadlocks (lecture d'un chan vide, ecriture d'un chan fermé etc)<br>
  Les WaitGroups ont ajouté un emballage plus simple plutot que le go func d'avant.
  ```
	wg := sync.WaitGroup{}
		wg.Go(func() {
			gimme1(i, c)
		})
  ```
### chan
  Equivalent de channel de C#<br>
  Beaucoup de dealocks possibles (lire un chan eternellement vide, mal le vider etc) <br>
  Ca a plein de cas d'usage cool (rate limiting, file d'attente, producteur + filtre/entonnoir). C'est plus facile a cadrer qu'en C# en général.
  ```
func main() {

	wg := sync.WaitGroup{}

	c := make(chan int, 4)
	for i := range 10 {
		fmt.Println("Boucle", i)

		wg.Go(func() {
			gimme1(i, c)
		})
	}

	wg.Wait()
	close(c)
	for e := range c {
		fmt.Println(e)
	}

}

func gimme1(n int, c chan int) {
	select {
	case c <- n:
		fmt.Println("YES")
	default:
		fmt.Println("Drop")
	}
}
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
	ctx2 := context.WithValue(ctx1, "truc", "lavaleurdetruc")
	ctx3, cancel3 := context.WithDeadline(ctx2, delay)
	defer cancel3()
	ctx4, cancel4 := context.WithCancel(ctx3)
	defer cancel4()

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
