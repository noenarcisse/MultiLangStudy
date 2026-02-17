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
  ```cs
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
### where
blabla
  ```
code
  ```

## JS / TS
  base types<br>
  ```js
  const monTexte = "Salut";

  if(typeof monTexte === 'string'){
      // do stuff
  }
  ```
  type : keyof, typeof, in<br>
  ```ts
	type Produit = {
    nom:string,
    prix:number
};
type Service = {
    tauxHoraire:number,
    duree:number
};
	produit1 : Produit = {nom:"Chaussure", prix: 50 };

  if("prix" in produit1){
      // c'est un produit
  }
  ```
  ```ts
const config = { port: 3000, host: "localhost" };
type ConfigType = typeof config; // type > { port: number, host: string }
const autreConfig: ConfigType = { port: 8080, host: "127.0.0.1" };
  ```
  ```ts
type User = { id: number; nom: string; email: string };
type UserKeys = keyof User; 
// "id" | "nom" | "email"
  ```
  interface : ducktyping complet<br>
  ```ts
code here
  ```
