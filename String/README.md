# String
## C#
### Simple string
Un string est un char[] toujours accessible comme en C mais sans les désavantages<br>
  ```cs
string texte1 = "Hello";
char lettre = texte1[0]; // H
char lettre2 = texte1[^1]; // o et pas un fin de char[] comme en C :>
  ```
### Interpollation & verbatim
Permet d'afficher des vars directement et d'échapper des / automatiquement<br>
  ```cs
string texte1 = "Hello";
char lettre = texte1[0]; // H

$"string blablabla {variable}";
@"app/chemin/stuff";
$@"app/chemin/{variable}/cheminEncore";
  ```
### Lignes multiples
  text)<br>
  ```cs
string texte = “”” du texte
sur plusieur lignes “””;
  ```

### Incrementation et decrementation
Contrairement a du Perl, on peut pas incrémenter un string. Par contre les chars récupèrent quand meme les opérateurs et déplacent en fonction des valeurs ASCII<br>
  ```cs
char test = 'z';
test--; // y
test++; // z
test++; // {
  ```

## Perl
Le true king.
### string en général
  ```pl
using utf8;

my $name = "Johnny";
my $truc = 'be good';
my $var1 = qq/oiriginal/;
my $var2 = q(comme);
my $var3 = qq\langage\;
my $var4 = qq<en vrai ?>;

my $var5 = qq⏩Ils abusent quand meme un peu⏩; #ca marche mais ca fait un warning deprecié ce genre de delimiteurs


my $paragraphe = <<"PARAGRAPHE";

Salut $name $truc,

$var1 $var2 $var3 $var4
$var5

Je peux mettre plein de texte ici
sur plein de ligne
c'est quand meme super 

cool
en fait
PARAGRAPHE

say $paragraphe;

say 'Ici je test
des retours de lignes';
  ```

### string++ and string x string operators
  cause wy not eh?
  ```pl
  my $text = "Salus";
  $text++; # Salut

  say "Jar" x 2; #JarJar
  ```
