# Declaration variables
## C#
### var
Type implicite calculé des que possible par le compiler, ca ferme les verrou des que le compiler “sait” (meme pour les Task).<br>
La valeur de la variable doit etre explicite.
### dynamic
L’equivalent du variable JS de base, accepte tous les type sans jamais bloquer le compiler.
### Tuple
  ```
  var unCharactere = 'A'; 
  var Text = "Du texte"; // string implicite
  String Text2; // string explicite

  var array = new List<int>();
  List<int> array2 = new();
  List<int> array3 = [];

  ```

## JS / TS
Faiblement typées, peut être hétérogene dans un array.
### const
Adresse constante, scoped
### let
Adresse variable, scoped
### var
Adresse variable, globale
### (rien)
Adresse variable, scopé a window. Nice breach accessibles a tous les scripts, lourd, etc.
  ```
let variable = 2;
variable = "Salut";
variable = await new Promise((res, req) => { ... });
const monTableau = [1, "deux", { id: 3 }, [4, 5], () => console.log("hello")];
  ```

## F#
Fortement typé, déduit. Par défaut immuable si non précisé.
### let
Identifier de déclaration de variable ou fn
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
  ```
let variable: &str = "Salut";
  ```
### const
Variable constante, valeur figée.
Scopée dans le bloc courant.
  ```
const PI = 3.14159265359;
const PI_IN_DOOM = 3.141592657;
  ```
### let mut
Vairable variable, scopée.
  ```
let mut variable : &str = "Salut"
let autreVar = "Yo";
variable = "Hey!" //implicitement redeviens non mut ici
variabke = autreVar // okay, peut pointer sur l'adresse d'un let simple sans le modifier
autreVar = "Salut" // Non, pas mut
  ```
### Shadowing
On peut sur-déclarer une variable sans souci.
  ```
let variable: &str = "Salut";
let variable : &str = "Bien le bonjour!";
let variable : i32 = 256;
  ```
### Ownership
i32, &str, bool, etc. > type simple, ils font un copy auto quand ils sont passés a un owner différent
String, Vec<T>, struct > ils sont donné a une autre owner quand ils sont passés.
  ```
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
Faiblement typée, peut être hétérogene dans un array.
### $scalar
Scalaire
### @array
blabla
### %hash
blabla
### (list)
Pas d'assignation en mémoire, c'est un objet temp (similaire a un tuple en quelque sorte). Elle peut etre manipulée quand meme.

  ```
#inversion de list
($a, $b) = ($b, $a);

  ```

  ```
my $scalar = 4;
my @array = (4, "quatre");
my %hash =  (
prenom => "Jean-Claude",
nom => "Vandamme"
);

say( $hash{nom} );

  ```
