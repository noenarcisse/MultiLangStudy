# Algorithm patterns

## Two pointers classic
  Deux curseurs parcourrent les donnée en même temps.
  Cas d'usage : interversion/reverse, comparer <br>
  ```go
// O(n/2)
func rev4(s string) string {
	runes := []rune(s)
	for i, j := 0, len(runes)-1; i < j; i, j = i+1, j-1 {
		runes[i], runes[j] = runes[j], runes[i]
	}
	return string(runes)
}
  ```
## Sliding window
  Permet de focus une zone dans l'array avec des données valides / limitées <br>
  Le Span<T> en C# et les slices en Go exploitent cette mécanique.
  Cas d'usages : validation de X valeurs qui se suivent en "subarray", verification de suite, etc.
  ```py
  //code
  ```
## fast and slow pointers
  Un pointer avance de 1, l'autre de 2<br>
  Cas d'usage : test de boucle dans une linked list, test de circuits fermés, etc
  ```cs
  //code
  ```
## Backtracking
  Arbre décisionnel, on parcourt les possibilités avec du recurring et on remonte pour rententer les solutions suivantes<br>
  Cas d'usage : Walk (Recusive)
  ```cs
    public static IList<string> Solve(int number)
    {
        List<string> results = [];
        string result = "";
        Generator(number, number, result, results);

        return results;
    }

    static void Generator(int open, int close, string result, List<string> results)
    {
        if(open > 0)
            Generator(open-1, close, result+'(', results);
        
        if(close > open)
            Generator(open, close-1, result+')', results);
        
        if(open == 0 && close == 0)
            results.Add(result);
    }
  ```
## Dynamic Programming
  Principe de Hashtable<br>
  Construction d'une data recursive ou on connait deja les réponses precedentes<br>
  On brute force a l'aide d'une table par ex dans laquelle on peut chercher les valeurs calculées précédemment en acces direct <br>
  ```cs
  foreach (int c in coins)
    {
        for (int i = 1; i <= amount; i++)
        {
            if(i-c >= 0)
            {
                if(hashtable[i-c] != int.MaxValue)
                    hashtable[i] = Math.Min(hashtable[i] , hashtable[i - c] + 1);
            }
        }
    }
  ```

## Bit manipulations
### XOR not found filter
  Cas d'usage : trouver l'intrus<br>
  ```cs
  //code
  ```
