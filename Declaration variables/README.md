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
Fortement typé.
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
