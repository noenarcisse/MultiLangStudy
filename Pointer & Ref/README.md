# Pointers & Refs
## C#
### References
  in : entrée par adresse en “readonly”, sert surtout d’opti sur les struc (Vector3 par ex)<br>
  out : sortie uniquement<br>
  ref : reference safe (in out), se deref naturellement (Console.Write affiche la valeur)<br>
  ```
  public void MaFunc(ref int arg1, in structure, out string texte1)
  {  }
  ```
### Pointeurs
  int* : pointer à la C, avec tous les problemes classiques, ne fonctionne qu’en unsafe, n’est pas GC
  ```
unsafe
{
      int var = 42;
      int* pointer = &var;
      int** doublePointer = &pointer;

      Console.WriteLine((long)pointer); //adresse
      Console.WriteLine(*pointer); // 42
}
  ```

### Span<T> et ReadOnlySpan<T>
C'est une ref struct. Elle vit sur la stack comme n'importe quelle struct mais un ref qui garde possiblement un elements coté heap : l'adresse et la longueur de l'info. <br>
C'est tres utilisé dans les tableaux pour "framer" une zone specifique. <br>
Voir array pour son utilisation dans ce cas-là.

  ```C#
        string log = "DAMAGE:150|CRIT:TRUE|SOURCE:Orc_Warrior";
        ReadOnlySpan<char> logSpan = log.AsSpan();
        
        int index1 = logSpan.IndexOf(":")+1;
        int index2 = logSpan.IndexOf("|");
        ReadOnlySpan<char> dmg = logSpan.Slice(index1, index2-index1);

        Console.WriteLine(dmg);
  ```

## Perl
Pas de pointer :> <br>
References:<br>
  ```
\$var, \@array, \#hash
  ```
Dereferences : <br>
  ```
$$var, @$array
  ```

## C
Pointer
  ```
int variable = 42;
int *pointer = &variable;

printf("%p", pointer);
  ```
