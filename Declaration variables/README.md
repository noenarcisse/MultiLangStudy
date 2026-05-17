# Declaration variables
## C#
Scopé par bloc, mutable par défaut, fortement typé, déduit.
### var
Type implicite calculé des que possible par le compiler, ca ferme les verrous dès que le compiler a pu déduire un type (meme pour les Task).<br>
La valeur de la variable doit etre explicite.
### dynamic
L’equivalent du variable JS de base, accepte tous les type sans jamais bloquer le compiler.
### Tuple
Principe de base d'un tuple, typage hétérogène. Peut etre déconstruit à la volée.
  ```cs
  var unCharactere = 'A'; 
  var Text = "Du texte"; // string implicite
  string Text2; // string explicite

  var array = new List<int>();
  List<int> array2 = new();
  List<int> array3 = [];

  var tuple = ("string", 1);
  var (text, num) = tuple;
  Console.WriteLine(text+ " / "+ num);

  var (a,b) = (1,2);
  (a,b) = (b,a); // swap avec tuple + deconstr
  ```
## Go
Typé, statique.<br>
Pas d'ownership, les passages de variables entre fonctiosn crée une copie. Pour passer un objet on envoie la ref explicite (ptr)<br>
Lors d'une extension, les variables font de "l'indirection". Les valeur et pointeur deviennent interchangealb et Go gere automatiquement le passage de l'un ou l'autre. Ne fonctionne jamais en args.<br>
Utilise un principe de zero value : int > 0, string > "", bool > false, &pointer > nil et evite les null/undefined<br>
### const
Imut
### var
Mut, type déduit
### :=
Init équivalent à var, déduit le type
### multiple vars
Go laisse passer une déclaration multiple, ca permet de swap sans tuple :>
  ```go
a,b := 1,2
a,b = b,a
  ```
### scope
On peut déclarer à la volée dans des blocs (if, switch, for)
  ```go
//localVar 1, local a ce if else
	if localVar := 1; localVar > 2 {
		fmt.Println(localVar, "> 2")
	} else {
		fmt.Println(localVar, "< 2")
	}
//localVar 2, local a ce switch
	switch localVar := 0; localVar {
	case 0:
		fmt.Println("C'est nul")
		fmt.Println("Un autre texte ici aussi ?")
	case 1:
		fmt.Printf("C'est un")
	case 2:
		fmt.Printf("C'est deux")
	default:
		fmt.Printf("Oops")
	}
  ```
## F#
Fortement typé, déduit. Par défaut immuable si non précisé. Peut stocker des éléments de base, des objets complexes ou des functions (qu'on peut invoker avec () comme en JS) <br>
TOUT est une fonction !

### let
Mot clé de déclaration de variable (ou de fonction)
  ```fs
let var = "Salut"
let read = System.Console.ReadLine
let input = read()
printfn $"{input}"
  ```
### let mutable
var mutable (valeur). Typage strict a l'init (=). Mutation avec <-
  ```fs
let mutable var = "Salut"
printfn $"{var}"
var <- "Ca va ?"
printfn $"{var}"
var <- 42 //NON ne peut pas changer de type!
  ```
### Tuple
  ```fs
let tuple = "ceci", "est", "un" , "tuple"
let tuple2 = ("Pareil", "mais avec des parenthèses")
  ```
### Shadowing
Shadowing possible localement. Interdit en top level.
  ```fs
let maFonction = 
    let var = "Salut"
    let var = 42
    var // return 42
  ```

## Python
Typées, mutables. TOUT est un objet, les objets liés à des type primitif se comporte comme tel (copie et pas transfert d'addresse comme un array ou un obj).<br>
Maintiens pas seulement une valeur mais aussi les références qui maintiennent une variable en RAM. Tout part en heap. <br>
A tendance a echapper des blocs autres que les fonctions (def)!

### (rien)
  ```py
truc = 42
afficher = print
afficher(42)

afficher(hex(id(truc))) # addr 42
truc2 = truc
afficher(hex(id(truc2))) # addr 42 aussi
truc = "Salut"
afficher(hex(id(truc))) # nouvelle addr : Salut
afficher(hex(id(truc2))) # ancienne addr : 42
  ```
  ```py
if True:
    secret = "oups"
print(secret) # affiche oups
  ```


## JS / TS
Faiblement typées, peut être hétérogene dans un array.
Peut tout stocker car tout est un object. Ca comprend aussi des body de function par exemple. Peut etre marqué avec des attributes/metadata.
TOUT est un objet.
### const
Adresse imutable, scoped. La valeur pourrait changer.
### let
Adresse variable, scoped
### var
Adresse variable, globale. La norme précédemment dans le JS, n'est plus vraiment utile > use const/let
### (rien)
Adresse variable, scopé a window. Nice breach accessibles a tous les scripts, lourd, etc.
  ```js
let variable = 2;
variable = "Salut";
variable = await new Promise((res, req) => { ... });
const monTableau = [1, "deux", { id: 3 }, [4, 5], () => console.log("hello")];
  ```
### imutability
En TS, as const force freeze deep des valeurs et imite plus  du rust ou F# <br>
En JS Object.freeze() permet de bloquer les valeurs MAIS en shallow uniquement, il n'y a aucune forme de récursivité.
  ```ts
code
  ```

## Rust
Fortement typé. Typage déduit. Toutes les variables sont toujours scopées. Rust différencie l'immuabilité des adresses et l'immuabilité des valeurs.
### let
Variable constante, valeur figée.
Scopée dans le bloc courant.
  ```rust
let variable: &str = "Salut";
  ```
### const
Variable constante, valeur figée.
Scopée dans le bloc courant.
  ```rust
const PI = 3.14159265359;
const PI_IN_DOOM = 3.141592657;
  ```
### let mut
Vairable variable, scopée.
  ```rust
let mut variable : &str = "Salut"
let autreVar = "Yo";
variable = "Hey!" //implicitement redeviens non mut ici
variabke = autreVar // okay, peut pointer sur l'adresse d'un let simple sans le modifier
autreVar = "Salut" // Non, pas mut
  ```
### Shadowing
On peut sur-déclarer une variable sans souci.
  ```rust
let variable: &str = "Salut";
let variable : &str = "Bien le bonjour!";
let variable : i32 = 256;
  ```
### Ownership
i32, &str, bool, etc. > type simple, ils font un copy auto quand ils sont passés a un owner différent
String, Vec<T>, struct > ils sont donné a une autre owner quand ils sont passés.
  ```rust
let number : i8 = 52; //owner : ce block, var simple
let variableSimple : &str = "Salut";  //owner : ce block &str est une ref en soi
let variableComplexe : String = String::from("Bonjour");  //owner : ce block

maFonction(&number, &variableSimple, &variableComplexe);          // owner ce block, on prete la var par ref
println!("{number}, {variableSimple}, {variableComplexe}");       // resoud
maFonction(number,  variableSimple, variableComplexe.clone());  // on donne des copies, ca resouds apes sans souci
maFonction(number,  variableSimple, variableComplexe);          // on donne une des vars a maFonction les simples sont "copy"
println!("{number}, {variableSimple}, {variableComplexe}");       // numer resouc, sar simple resoud, var complexe plante le compiler (borrowed)
  ```

## Perl
Faiblement typée, peut être hétérogene dans un array. Peut etre scopé. <br>
Utilise des sigils pour le type de valeurs pour chaque variable.
### $scalar
Scalaire
### @array
blabla
### %hash
blabla
### (list)
Pas d'assignation en mémoire, c'est un objet temp (similaire a un tuple en quelque sorte). Elle peut etre manipulée quand meme.
### my
Scopé localement (let de JS)
### our
Scopé globalement. (var de JS)

  ```perl
#inversion de list
($a, $b) = ($b, $a);

  ```

  ```perl
my $scalar = 4;
my @array = (4, "quatre");
my %hash =  (
prenom => "Jean-Claude",
nom => "Vandamme"
);

say( $hash{nom} );

  ```
