# Pointers & Refs
## C#
### References
  in : entrée par adresse en “readonly”, sert surtout d’opti sur les struc (Vector3 par ex)<br>
  out : sortie uniquement<br>
  ref : reference safe (in out), se deref naturellement (Console.Write affiche la valeur)<br>
  ```cs
  public void MaFunc(ref int arg1, in structure, out string texte1)
  {  }
  ```
### Pointeurs
  int* : pointer à la C, avec tous les problemes classiques, ne fonctionne qu’en unsafe, n’est pas GC
  ```cs
unsafe
{
      int var = 42;
      int* pointer = &var;
      int** doublePointer = &pointer;

      Console.WriteLine((long)pointer); //adresse
      Console.WriteLine(*pointer); // 42
}
  ```
C'est assez infame a écrire en vrai face a des langages bas niveaux et faut parfois chipoter (si la var est externe au scope unsafe ou capturée). <br>
Y'a tous les défaut possibles des ptr de C on peut se deplacé hors d'un array notamment. <br>
On doit fixed sur la heap pour empecher de GC de deplacer les ptr qu'on regardent. En sortie de scope free, le GC recupere et nettoie si besoin. Pour le reste, on doit évidemment les nettoyer de la heap soit meme avec un free :<
  ```cs
unsafe
{
	int n = 5;
	int* pn = &n;
	Console.WriteLine($"pointer :{(IntPtr)pn}");
	Console.WriteLine($"value = {*pn}");

	int* arr = stackalloc int[3] { 3, 20, 100 };

	Console.WriteLine($"pointer :{(IntPtr)arr}");
	Console.WriteLine($"value 1 = {arr[0]}");
	Console.WriteLine($"value 2 = {*(arr + 1)}");
	Console.WriteLine($"value 2 = {*(arr + 2)}");
	Console.WriteLine($"value fausse = {*(arr - 1)}"); // <- buffer overflow, pas de segfault si on est encore dans notre zone
}
  ```

### Span<T> et ReadOnlySpan<T>
C'est une ref struct. Elle vit sur la stack comme n'importe quelle struct mais un ref qui garde possiblement un elements coté heap : l'adresse et la longueur de l'info. <br>
C'est tres utilisé dans les tableaux pour "framer" une zone specifique. <br>
Voir array pour son utilisation dans ce cas-là.

  ```cs
        string log = "DAMAGE:150|CRIT:TRUE|SOURCE:Orc_Warrior";
        ReadOnlySpan<char> logSpan = log.AsSpan();
        
        int index1 = logSpan.IndexOf(":")+1;
        int index2 = logSpan.IndexOf("|");
        ReadOnlySpan<char> dmg = logSpan.Slice(index1, index2-index1);

        Console.WriteLine(dmg);
  ```
## Go
Pointers classico classiques avec les &val, *ptr etc. <br>
Go autorise les nil ptr. Ca crée un délire assez horrible avec les struct et interface vu que ca passe en principe "d'impl duck typée". 
  ```go
package main

type Robot struct {
	Nom string
}

func (r *Robot) Saluer() string {
	if r == nil {
		return "Je suis un robot fantôme"
	}
	return "Bonjour, je suis " + r.Nom
}

func main() {
	var pr *Robot = nil
	pr.Saluer() //ooof
}
  ```
### Interfaces
En go les interfaces sont en soit des fat pointeurs deguisés. Elles tiennent la valeur de l'element et le type concret. Afficher %v ou %T donne donc deux résultats différents.
Une interface remplit la demainde d'un *Truc sans préciser la ref avec & car elles sont le ptr.

## Nim
### Pointer
Stack, pas de GC si passage en heap
  ```nim
let uneVariable = "Hop"

# unsafe
let p1 = addr(uneVariable)
let p2 = addr(p1)
echo une_variable
echo "ptr unevariable x2 = ", repr(p2)
echo "deballé -> ", p2[][]
  ```
### Ref
Heap, GC
  ```nim
# safe

let r1 = new(int) # on stocke d'abord un empl mem
r1[] = 42 # on lui donne une val
let r2 = r1 #apres on copie le ptr apres au lieu de var := 1 puis ref := &var
echo r2[] #et la on peut recup la val de r1

  ```

## C
Les strings sont des ptr, les arrays aussi
Pointer
  ```c
int variable = 42;
int *pointer = &variable;

printf("%p", pointer);
  ```

## Python
Ref
Python prend tout comme un objet. TOUT passe par une ref ! Ca inclut les int etc. <br>
Dans le cas des petits int (int8?) python les stocke en memmoire et les utilise comme références constante. <br>
Dans le cas de nombres plus grands, python crée un emplacement qu'il va tenter de référencer autant que possible. Ca ne fonctionne que pour 1 meme fichier/module.
  ```py
from numbers_mod import func3, func4

i1 =  1_000_000_000
def func2() -> int : 
    i =  1_000_000_000
    return i
i2 =  1_000_000_000
print(i1 is i2) #true

i3 = func3()
i4 = func4()
print(i1 is i3) #false
print(i3 is i4) #true, meme fichier, meme ref donc
  ```

