# Declarative programming
## C# LINQ
Query sql en c# appliqué a des enumerables en général :>
Y’a 2 ecritures, en "sequence" et en chainage.
### .Select()
  Selectionne la donnée equivalent de select<br>
  ```cs
 IEnumerable <string> query1 = livres
                                 .Select(l => l.Titre = "Harry Potter");
  ```
### .Where()
  litteralement where, filtre<br>
  ```cs
 IEnumerable <string> query1 = livres
                                 .Where(p => p.Pages > 400)
                                 .Select(t => t.Titre);
  ```
  ```cs
        var orders = new List<Order>
        {
            new("Alice", "TV", 800),
            new("Bob", "Phone", 400),
            new("Alice", "Laptop", 1200),
            new("Charlie", "Tablet", 600),
            new("Bob", "Headphones", 200),
            new("Charlie", "Camera", 900),
        };

        var query = orders.GroupBy(order => order.Customer)
                            .Select(group => new              // on peut aussi creer une variable "let" intermediaire
                            {                                 // a l'aide de select
                                Customer = group.Key,
                                Total = group.Sum(o => o.Amount)
                            }
                                 )
                            .OrderByDescending(group => group.Total)  // qui reste recupérable dans le scope de la suite de chainage
                            .Take(3);

        record Order(string Customer, string Product, decimal Amount);
  ```
### .Join()
  ```cs
var query5 = livres.Join(
                            auteurs,
                            a => a.AuteurId,
                            b => b.Id,
                            (a, b) => new {b.Nom, a.Titre});

foreach(var tuple in query5)
{
    Console.WriteLine($"{tuple.Nom} a écrit {tuple.Titre}");
} 
  ```
### .Order() / .OrderBy() / .OrderByDescending()
  ```css
var deluxe = produits   .Where(p => p.Prix > 50)
                        .OrderByDescending(p=> p.Prix)
                        .Select(p=> p.Nom);
  ```
### .ThenBy() / ThenByDescending()
  Ordonne secondairement<br>
  ```cs
IEnumerable<string> query1 = _customers
                                .OrderBy(n => n.Value)
                                .ThenByDescending(n => n.Key)
                                .Select(n => $"{n.Key} {n.Value}");
  ```
### .GroupBy()
  ```cs
var query6 = livres.Join(
                            auteurs,
                            a => a.AuteurId,
                            b => b.Id,
                            (a, b) => new {b.Nom, a.Note})
                            .GroupBy(auteur => auteur.Nom)
                            .Select(g => new {  
                                Auteur = g.Key, 
                                NoteMoy = g.Average(n => n.Note)
                            });
  ```
### .Contains() .Any()
Contains() verifie en acces direct si un element existe<br>
Enumerable > Any : Effectue un parcours et return true a la premiere correspondance<br>
  ```cs
if(uneListe.Any()) // = .Count() > 0 mais en plus lourd
{
  //liste qui contient des trucs
}
if(uneListe.Any(Item stuff))
{
  // une liste qui contient stuff
}
  ```
### .Skip(<int>)		
  passe les x premiers resultats	(OFFSET x)<br>
  ```cs
  //code
  ```
### .Take(<int>)
  prend les x resultats (LIMIT)<br>
  ```cs
  //code
  ```
### ToArray() / ToList() / ToDictionary(K, V)
  Transforme l'enumerable en une structure de données<br>
  ```cs
  var words = new List<string> { "apple", "banana", "cherry", "date" };
  var query = words.ToDictionary(w=> w, w=> w.Length);
  ```
### .ToLookUp()
  Cree un groupement par index, en acces direct O(1) puis O(n) (contrairement a grouby qui fait une liste O(n) de groupes O(n))<br>
  ```
    //Sépare les nombres en deux listes : pairs et impairs
    var query9 = numbers.ToLookup(n => n%2 == 0);
    var pair = query9[true];
    var impair = query9[false];
  ```
### .Distinct()
  SELECT DISTINCT du SQL<br>
  ```
    var numbers = new List<int> { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3 };
    //Retourne les nombres sans doublons, triés.
    var query = numbers.Distinct().Order();
  ```




## JS / TS
### .filter()
  Equivalent de where en linq. Ca return une copie sans modifier le preceent<br>
  ```
  articles.filter(article => article.price > 100);
  ```

## SQL
### SELECT
  text)<br>
  ```sql
SELECT filename FROM Jobs WHERE status = 'pending'
  ```
### COUNT()
  text)<br>
  ```sql
SELECT COUNT(id), status FROM Jobs GROUP BY status 
  ```
### HAVING
  text)<br>
  ```sql
SELECT user_id FROM Jobs GROUP BY user_id HAVING COUNT(id) > 10
  ```
### IN (sub query)
  Sous requete. Tres lourd.<br>
  ```sql
SELECT * FROM Jobs WHERE user_id IN (SELECT id FROM Users WHERE email='jeanluc@google.com')
  ```
### INNER JOIN
  JOINTURE interne (and gate : A & B) <br>
  ```sql
SELECT filename, Users.username FROM Jobs INNER JOIN Users ON Jobs.user_id = Users.id
  ```
### LEFT JOIN / RIGHT JOIN
  JOINTURE partielle (and + or gate)<br>
  LEFT (A & B) | A <br>
  RIGHT (A & B) | B <br>
  ```sql
code
  ```
### FULL JOIN
  JOINTURE complete (or gate : A | B) <br>
  ```sql
code
  ```

## MySQL
### SELECT
  text)<br>
  ```sql
  //code
  ```
