# Guards, Nullchecks etc.
## C#
### is
  On peut faire des guards de types, instances, héritages, le tout en copiant en variables locales les éléments ou leur propriétés<br>

### is { }
Objet non spécifié non null.

Correspond a != null ou is not null

### is T {propertie: 42}
Objet quelconques qui correspond a la propriété avec la bonne valeur. La valeur peut etre une variable rendue localement.

### is [.., 1, 2, _, 4]
Array avec une range de valeur inconnu avant 1, 2, x, 4 dans l'ordre specifié. 4 est le dernier element ici.
  ```
string? texte = chargerUnTruc();
if(texte is { } data)
{
	Console.WriteLine(data);
}
if (texte is string { Length: > 5 } s)
{
   Console.WriteLine(s + " is longer than 5 chars");
}
if( livre1 is Livre {titre: “Harry Potter” } bouquin)
{
    Console.WriteLine("bouquin est bien titré Harry Potter");
}

if( livre1 is Livre {titre: var titleBouquin } bouquin)
{
	Console.WriteLine("TITRE : "+titleBouquin);
}
  ```

## JS / TS
  TDB<br>
  ```
  const monTexte = "Salut";

  if(typeof monTexte === 'string'){
      // do stuff
  }
  ```
