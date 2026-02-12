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
  text)<br>
  ```
  //code
  ```
### .GroupBy()
  text)<br>
  ```
  //code
  ```
### .ThenBy() / ThenByDescending()
  text)<br>
  ```
  //code
  ```
### .Contains() .Any()
  text)<br>
  ```
  //code
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
