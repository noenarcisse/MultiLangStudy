# Iterateurs / Iteratables
## C#
### yield return + Enumerable<T>
yield return un Enumerable<T> ca cree un itérateur, ca permet de parcourir des données lourdes voire infinies en ne bloquant qu’une petite adresse mémoire (stream, large file a lire ligne par ligne)<br>
  ```cs
Enumerable<int> GenererSuite()
{
      int i=0;
      while (true)
      {
      	yield return i++;
      }
}

var suiteInfinie = GenererSuite();
var resultat = suiteInfinie 
                        .Where(n => n % 2 == 0) 
                        .Select(n => $"N°{n}")
                        .Skip(5)
                        .Take(10); 
  ```

## F#
### seq{}
Ca permet de faire une liste lazy, des ranges / iterators en tout genre. Les range sont inclusives, si le step fait pas depasser l'itération suivante.
  ```fs
let test = seq{1;2;3}
let test2 = seq{1.0..1.5..10}
let test3 = seq{1..2..9}

for i in test3 do
    printfn "%i" i // 1 -> 9 inclus par step de 2

for f in test2 do
    printfn "%.1f" f // 1 -> 10 inclus par step de 1.5
  ```
### for yield
une boucle for permet de return une valeur 1 a 1 (avec yield mais il peut etre implicite) <br>
C'est pour ca qu'une expression list fonctionne : <br>
Ca permet de construire un seq qui peut a son tour etre passé et cast en list.
  ```fs
let maListe = [
    for i in 1 .. 3 do
        yield i * 2 //yield peut sauter, en F# le return implicite renvoie deja la valeur 1 a 1
]
  ```
Ca peut servir a faire des trucs qu'un simple concat @ peut pas faire si on a des opérations en plus
  ```fs
let group1, group2 = ["jean";"claude"], ["terry";"william"]

let group3 = group1 @ group2
let group4 = [yield! group1 ; for name in group2 do if name = "terry" then name]

  ```
### yield!
Permet le yield return forcé sur une seq ou list, en deballant la list en dessous en une seq 1 a 1



## Python
### range
Ca prépare un iterateur de x -> y (exculsif) par step z
  ```py
enum = range(10, -1, -2)
for i in enum :
    print(i)
  ```
