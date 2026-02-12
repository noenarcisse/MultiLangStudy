# Arrays
## C#
### typage
Fortement typé de base. On peut les rendre hétérogèe au forcing (object)
  ```c#
int[] array = [1,2,3,4]; // que des int
object[] arrayBizarre = ["Salut", 'A', 2, new CompteBancaire("Titi", 90)]; 
  ```
### spread / range ..
[0..4]<br>
Permet de faire des spreads, des ranges etc. Ca crée une copie! Pour la vrai version voir > Span<T><br>
### hat
^1 : permet de se balader en sens inverse dans un array, de maniere exclusive sur le dernier.<br>
Doit toujours rester dans l'ordre. le plus petit a gauche, le plus grand a droite [1 .. ^1]<br>

  ```cs
  int[] array = {1,2,3,4};
  Console.WriteLine(array[1..3]); // array [2,3]

  string mot = "Hello";
  char[] spreadString = [..mot];
  ```
### Span<T>
Frame sans allocation un elements comme un array (ou string / char[]).<br>
C’est une struc qui permet de faire un ciblage direct des données equivalent a un .Take(5) en LinQ ou un [..array] mais extremement plus leger et sans copie en memoire
Span<T> .Slice(0,5) fait en 10x mieux un array[0 .. 5];<br>

  ```C#
        string log = "DAMAGE:150|CRIT:TRUE|SOURCE:Orc_Warrior";
        ReadOnlySpan<char> logSpan = log.AsSpan();
        
        int index1 = logSpan.IndexOf(":")+1;
        int index2 = logSpan.IndexOf("|");
        ReadOnlySpan<char> dmg = logSpan.Slice(index1, index2-index1);

        Console.WriteLine(dmg);
  ```

## Perl
Declaré avec @, on lui passe une list en valeur. Typage dynamique et mixable! Nombre d'entrée non fixes ;><br>
Peut etre parcouru dans les 2 sens.<br>
  ```Perl
my @array = (1,"deux",3,"quatre");
say($array[-1]);  #quatre
  ```

## JS
[...] <br>
Le king, remplace les autres types de collections en général<br>
  ```js
  const text = "Salut";
  const array = [1,2,"trois", ()=>"Hello", null];

  const arrayStr = [...text];
  const array2 = [...array, ...arrayStr];
  ```
