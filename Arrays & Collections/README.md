# Arrays & Collections
## C#
Il y a de tout: arrays, list, arraylist, hashset, ienum/seq, dictionnary, orderedlist/dict, etc.
### typage
Fortement typé de base. On peut les rendre hétérogènes au forcing (object)
  ```cs
int[] array = [1,2,3,4]; // que des int
object[] arrayBizarre = ["Salut", 'A', 2, new CompteBancaire("Titi", 90)]; 
  ```
### spread / range ..
[0..4]<br>
Permet de faire des spreads, des ranges etc. <br>
Ca crée une copie! Pour la version sans copie voir > Span<T><br>
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
struct <br>
Frame sans allocation d'un element comme un array (ou string / char[]).<br>
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

## Go
typé, longueur fixe, tres proche du C dans son fonctionnement<br>
Go file len() et cap() pour connaitre les tailles d'un array/slice
  ```go
var array = [3]int{1,2,3}
  ```
Slices (=Span de luxe) file une struct qui frame un array en heap. Taille variable (l'array en dessous est réattribué si elle doit etre étendue), connait sa length ET la capacité de l'array<br>
Go fait sous le capot le truc de C de creer et copier un array plus grand si nécéssaire (les pointeurs changent si changement de taille)
  ```go
  var array = [4]int{1, 2, 3, 4}
	slice := array[1:3]

	for i := 0; i < len(slice); i++ {
		fmt.Printf("%p - %v \n", &slice[i], slice[i])
	}
  ```

  ```go
	slice2 := []int{1, 2}
	for i := 0; i < len(slice2); i++ {
		fmt.Printf("%p - %v \n", &slice2[i], slice2[i])
	}
// array[2]
//0x21d3d81440f0 - 1 
//0x21d3d81440f8 - 2 

	slice2 = []int{1, 2, 3}
	for i := 0; i < len(slice2); i++ {
		fmt.Printf("%p - %v \n", &slice2[i], slice2[i])
	}

//copie d'un new array[3] -> changement d'adresses
//0x21d3d8146168 - 1 
//0x21d3d8146170 - 2 
//0x21d3d8146178 - 3 
  ```

### [...]
Array de taille fixe mais calculé sur le nomre d'elements donné a la creation
  ```go

var errorMessages = [...]string{
    ARGS_ERROR:   "Arguments invalides", // vaut 0
    AUTH_ERROR:   "Authentification...", // vaut 1
    SERVER_ERROR: "Une erreur...",       // vaut 2
}
  ```
### [:]
ranges sur les slices
  ```go
slice := []int{1,2,3,4,5}
slice = uneSlice[3:] // 4,5
array := [4]int{1, 2, 3, 4}
slice = array[:3] // 1,2
slice = array[:] // tout
  ```
### append()
  ```go
slice := []int  {1,2}
slice = append(slice, 3) // [1,2,3]

slice = slice[1:len(slice)-1]
slice = append(slice, 4) // 1,2,4
  ```

### map
  ```go
m := map[int]string{
	1:"Un",
	2:"Deux"
}

fmt.Println(m[1]) //Un
value, ok := m[2] // Deux, true
_,ok = m[3] // false > fait un .Contains()
value, ok = m[3] // "", false > fait un .TryGet()
  ```
## Python
List, typage mixable, mutable<br>
C'est des margoulins de compet. Leur list case un "array" dynamique et extensible en mémoire. Ils mélangent le principe d'un array avec des slices à la Go pour faire des shallow copies sur les modifications sur une list de départ pour jamais copier entièrement une info deja dans la RAM (heap)<br>
utilise len() mais pas de cap() a la Go (on maintient pas d'array vu les shallow copies)
  ```py
maList = [1,2,3,4] # *[ptr1, ptr2, ptr3, ptr4]
maDeuxiemeList = maList[:] # copie same addresses de ref
maDeuxiemeList[-1] = 5 # *[ptr1, ptr2, ptr3, ptr5] < tient les memes adresse + un nouveau qui remplace la derniere

maDeuxiexeList = maList # copie du ptr direct de la List 1, ca ecrase, c'est plus du shallow copy!
  ```
### operateur * 
On peut multiplier une liste
 ```py
list = ["text"] * 3
print(list) # ['text', 'text', 'text']
  ```
### *reste
Le * dans les list permet de faire entre autre, un deballage (spread de JS), un tail plus fort (a la F#), un head aussi !
  ```py
uneListe = [2,3,4,5,6,7]
uneAutre = [0, 1, *uneListe] #spread a la JS ...array + reconstruct

x, y, z, *tail = uneListe #tail avec deconstruct des val en var a la volée
*head, a, b = uneAutre #pareil dans l'autre sens

print("X = ",x) #2
print("Y = ",y) #3
print("Z = ",z) #4
print("Tail = ", tail) # [5,6,7]

print(uneAutre)
print(head) # [0,1,2,3,4,5]
print("A = ",a) #6
print("B = ",b) #7

first, *middle, last = [1, 2, 3, 4, 5, 6]
# first = 1
# middle = [2, 3, 4, 5]
# last = 6
  ```


## Perl
Declaré avec @, on lui passe une list en valeur. Typage dynamique et mixable! Nombre d'entrée non fixes ;><br>
Peut etre parcouru dans les 2 sens.<br>
  ```Perl
my @array = (1,"deux",3,"quatre");
say($array[-1]);  #quatre
  ```

## JS
L'array c'est le roi ici, il remplace les autres types de collections en général sauf si on cherche a faire vraiment des trucs spécifiques comme des valeurs unique etc.<br>
### .at(index)
Ciblage direct d'index, mieux que [index] car on peut aussi le parcourir a l'envers avec le at(-1)<br>
  ```js
  const array = [1,2,3,4,5];
array[0] // 1
array.at(-1) // 5
  ```
### spread [...]
  ```js
  const text = "Salut";
  const array = [1,2,"trois", ()=>"Hello", null];

  const arrayStr = [...text];
  const array2 = [...array, ...arrayStr];
  ```

# TS 
Hérite du JS avec du typage mais se fait saboter par le bon ducktyping de JS
```ts
type Chien = {
    name: string
}
type Chat ={
    name:string
    nombresDePattounes : number
}

const chien1 : Chien = {name:"Poupette"}
const chat1 : Chat = {name : "Pisspouce", nombresDePattounes: 4}
const canard : {name : string} = {name: "Daffy"}

const arrayTypée : Chien[] = [
    {name : "Rocky"},
    chien1,
    chat1,
    canard
]
console.log(arrayTypée)
  ```
compilera en :
  ```
const chien1 = { name: "Poupette" };
const chat1 = { name: "Pisspouce", nombresDePattounes: 4 };
const canard = { name: "Daffy" };
const arrayTypée = [
    { name: "Rocky" },
    chien1,
    chat1,
    canard
];
console.log(arrayTypée);
  ```

## F# 
### array
Non naturel dans ce langage, on lui préfère list ou seq. Taille fixe a la C. <br>
Souvent utile pour l'interop
```fs
let array = [|1;2;3|]
  ```
### list
C'est une linked list en vrai, imut, tres naturel pour le langage.
```fs
let list = [1;2;3]
  ```

## Nim
### array
Array avec len definie
```nim
var montab : array[0..3, int] = [1,2,3,4]
  ```
### seq
array variable / list (list a la py?)
```nim
# leur comprehension seq ressemble a ca
var malist = collect(newSeq) :
    for i in countdown(montab.high, montab.low) : 
        montab[i]

#seq (=list en py)
var courses = @["Lait", "Chocolat", "Oranges"]
courses.add("Bananes")

var courses2 = courses[1..courses.high] #copie

for i, elem in courses2 :
    echo &"[{i}] {elem}"
  ```

### set / HashSet
Tiens des val en bit directement sur des tres petites structs (byte, char, uint8 etc). <br>
On peut faire des maths dessus :D
```nim
#affiche en unique et efface les doublons
var monSet = ["un truc", "un truc", "un autre cette fois"].toHashSet()
for i in monSet : echo &"mon set 1 = {i}" 

var 
    charset1 = {'a'..'d'}
    charset2 = {'c'..'h'}

echo charset1 - charset2 # exclusion
echo charset1 + charset2 # union
echo charset1 * charset2 # intersect
echo (charset1 + charset2) - (charset1 * charset2) # ou exclusif ?
  ```
### Table / Critbit
C'est les dictionnaires possibles de nim. <br>
C'est un peu le bordel chez eux, y'en a qui trie pas (ordre d'insertion au pif), ceux qui trie fonctionnent pas du tout par comparaison mais par timing d'ajout ou ne compare que des strings (alphabetiquement)
```nim

# c'en est pas, c'est les pieges -> ca donne des array / seq de tuples
# : coupe des tuple comme une , ici
var dict1 = { 1 : "Salut" , 2 : "Je suis un string"}
var dict2 = @{ 1 : "Salut" , 2 : "Je suis un string"}

# hasard complet
var vraiDict = [(1, "Salut"), (2, "Ca va ?")].toTable()
# ordered par ordre d'ajout !
var order = [(1, "Salut"), (2, "Ca va ?")].toOrderedTable()
order.add(0, "Aie")
order.add(4, "Aie2")
order.add(3, "Aie3")
# triée mais uniquement en k string ... ca trie par ordre alphabétique :x
var orderCompare = toCritBitTree([
    ("3", "Moi pas trop"),
    ("1", "Salut"),
    ("2", "Ca va ?"),
    ("10", "Ca va ?") # passe entre 1 et 2 !
    ])

echo "Chaos"
for k,v in vraiDict :
    echo &"[{k}] {v}"

echo "Order"
for k,v in order :
    echo &"[{k}] {v}"

echo "Order (critbit)"
for k,v in orderCompare :
    echo &"[{k}] {v}"
  ```
