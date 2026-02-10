# Declaration variables
## C#
### var
type implicite calculé des que possible par le compiler, ca ferme les verrou des que le compiler “sais” (meme pour les Task).<br>
La valeur de la variable doit etre explicite.
### dynamic
l’equivalent du variable JS de base, accepte tous les type sans jamais bloquer le compiler.
### Tuple
blabla
  ```
  var unCharactere = 'A'; 
  var Text = "Du texte"; // string implicite
  String Text2; // string explicite

  var array = new List<int>();
  List<int> array2 = new();
  List<int> array3 = [];

  ```

## JS
Faiblement typées, peut être hétérogene dans un array.
### const
Adresse constante, scoped
### let
Adresse variable, scoped
### var
Adresse variable, globale
### (rien)
Adresse varible, scopé a window. Nice breach, lourd, etc.
  ```
let variable = 2;
variable = "Salut";
variable = await new Promise((res, req) => { ... });
const monTableau = [1, "deux", { id: 3 }, [4, 5], () => console.log("hello")];
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
variable = "Bonjour";
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
printlin!("{number}, {variableSimple}, {variableComplexe}");       // resoud
maFonction(number,  variableSimple, variableComplexe.clone());  // on donne des copies, ca resouds apes sans souci
maFonction(number,  variableSimple, variableComplexe);          // on donne une des vars a maFonction les simples sont "copy"
printlin!("{number}, {variableSimple}, {variableComplexe}");       // numer resouc, sar simple resoud, var complexe plante le compiler (borrowed)
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
