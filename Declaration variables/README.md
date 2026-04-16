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

## Rust
Fortement typé. Toutes les variables sont toujours scopées. Rust différencie l'immuabilité des adresses et l'immuabilité des valeurs.
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
