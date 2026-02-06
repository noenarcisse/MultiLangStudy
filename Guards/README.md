# titre1
## C#
  On peut faire des guards de types, instances, héritages, le tout en copiant en variables locales les éléments ou leur propriétés<br>
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
