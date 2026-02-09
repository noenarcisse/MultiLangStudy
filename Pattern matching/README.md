# Patterns
## C#
### Property Pattern
  { } variable > pattern matching de n’importe quel objet instancié (ne rejette que null)<br>
  On peut lui donner un type {} ou des propriété internes {Length: 5, Name: "Johnny"}
  ```

string? texte = chargerUnTruc();

if(texte is { } data)
{
	Console.WriteLine(data);
}

if (texte is string { Length: > 5 } s)
{
 // blablabla
}
if( livre1 is Livre {titre: “Harry Potter” } bouquin)
{ }

if( livre1 is Livre {titre: var titleBouquin } bouquin)
{
	Console.WriteLine(titleBouquin);
 }
  ```
### List Pattern
  Pattern de liste ou array possibles<br>
  ```
if( monTableau is [1,2, .., _, 5, ..]) //verifie le format du tab en 1, 2, {0+}, {1}, 5, {0+}
{ }
  ```
### Pattern matching
  Switch expression par ex<br>
  ```
  //code
  ```




