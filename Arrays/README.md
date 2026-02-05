# Arrays
## C#
### spread / range
[0..4]<br>
Permet de faire des spreads, des ranges etc.<br>
### hat
^1 : permet de se balader en sens inverse dans un array, de maniere exclusive sur le dernier.<br>
Doit toujours rester dans l'ordre. le plus petit a gauche, le plus grand a droite [1 .. ^1]<br>

  ```
  int[] array = {1,2,3,4};
  Console.WriteLine(array[1..3]); // array [2,3]

  string mot = "Hello";
  char[] spreadString = [..mot];
  ```

## Perl
Declaré avec @, on lui passe une list en valeur. Typage dynamique et mixable! Nombre d'entrée non fixes ;><br>
Peut etre parcouru dans les 2 sens.<br>
  ```
my @array = (1,"deux",3,"quatre");

say(@array[-1]);  #affchie le dernier elem
  ```

## JS
[...] <br>
Le king, remplace les autres types de collections en général<br>
  ```
  const text = "Salut";
  const array = [1,2,3,4];

  const arrayStr = [...text];
  const array2 = [...array, ...arrayStr];
  
  ```
