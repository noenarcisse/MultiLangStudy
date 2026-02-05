# Pointers & Refs
## C#
  in : entrée par adresse en “readonly”, sert surtout d’opti sur les struc (Vector3 par ex)<br>
  out : sortie uniquement<br>
  ref : reference safe (in out), se deref naturellement (Console.Write affiche la valeur)<br>
  ```
  public void MaFunc(ref int arg1, in structure, out string texte1)
  {  }
  ```
  int* : pointer a la C, avec tous les problemes classiques, ne fonctionne qu’en unsafe, n’est pas GC
  ```
unsafe
{
      int var = 42;
      int* pointer = &var;
      int** doublePointer = &pointer;
}
  ```

## Perl
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
