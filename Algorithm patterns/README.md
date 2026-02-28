# Algorithm patterns

## Two pointers classic
  text)<br>
  ```cs
  //code
  ```
## Sliding window
  text)<br>
  ```cs
  //code
  ```
## fast and slow pointers
  text)<br>
  ```cs
  //code
  ```
## Backtracking
  Arbre décisionnel, on parcourt les possibilités avec du recurring et on remonte pour rententer les solutions suivantes<br>
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
  text)<br>
  ```cs
  //code
  ```
