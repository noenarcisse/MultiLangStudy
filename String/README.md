# String
## C#
### Interpollation & verbatim
Permet d'afficher des vars directement et d'échapper des / automatiquement<br>
  ```
$"string blablabla {variable}";
@"app/chemin/stuff";
$@"app/chemin/{variable}/cheminEncore";
  ```
### Lignes multiples
  text)<br>
  ```
string texte = “”” du texte
sur plusieur lignes “””;
  ```

## Perl
Le true king.
### string en général
  ```
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
  ```
  my $text = "Salus";
  $text++; # Salut

  say "Jar" x 2; #JarJar
  ```
