# titre1
## C#
### yield return + Enumerable<T>
yield return un Enumerable<T> ca cree un itérateur, ca permet de parcourir des données lourdes voire infinies en ne bloquant qu’une petite adresse mémoire (stream, large file a lire ligne par ligne)<br>
  ```
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
