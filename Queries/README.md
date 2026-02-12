# Queries
## C# LINQ
Query sql en c# appliqué a des enumerables en général :>
Y’a 2 ecritures, en "sequence" et en chainage.
### .Select()
  Selectionne la donnée equivalent de select<br>
  ```
 IEnumerable <string> query1 = livres
                                 .Select(l => l.Titre = "Harry Potter");
  ```
### .Where()
  litteralement where, filtre<br>
  ```
 IEnumerable <string> query1 = livres
                                 .Where(p => p.Pages > 400)
                                 .Select(t => t.Titre);
  ```
### .Join()
  ```
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
### .OrderBy() / .OrderByDescending()
  ```
var deluxe = produits   .Where(p => p.Prix > 50)
                        .OrderByDescending(p=> p.Prix)
                        .Select(p=> p.Nom);
  ```
### .GroupBy()
  ```
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
### .ThenBy() / ThenByDescending()
  Ordonne secondairement<br>
  ```
IEnumerable<string> query1 = _customers
                                .OrderBy(n => n.Value)
                                .ThenByDescending(n => n.Key)
                                .Select(n => $"{n.Key} {n.Value}");
  ```
### .Contains() .Any()
Contains() verifie en acces direct si un element existe<br>
Enumerable > Any : Effectue un parcours et return true a la premiere correspondance<br>
  ```
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
  ```
  //code
  ```
### .Take(<int>)		)
  prend les x resultats (LIMIT)<br>
  ```
  //code
  ```
### ToArray() / ToList() / ToDictionary()
  text)<br>
  ```
  //code
  ```

## SQL
### SELECT
  text)<br>
  ```
  //code
  ```
## MySQL
### SELECT
  text)<br>
  ```
  //code
  ```
