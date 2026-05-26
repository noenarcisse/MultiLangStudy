# Iterateurs
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
bla
  ```fs
code
  ```

## Python
### range
Ca prépare un iterateur de x -> y (exculsif) par step z
  ```py
enum = range(10, -1, -2)
for i in enum :
    print(i)
  ```
