# Guards, Nullchecks etc.
## C#

### OneOf<T0 .. Tn>
Nuget externe : https://github.com/mcintyre321/OneOf <br>
Permet de passer le contrat explicite en entrée ou sortie. <br>
On doit traiter l'erreur volontairement sans _ malheureusement contrairement à F# :<
```cs
    public static OneOf<WordDocument, ExcelDocument, UnknownDocument> GetDocumentType(UserInputValues inputs)
    {
        var extension = Path.GetExtension(inputs.FilePath).ToLower();
        return extension switch
        {
            ".xslx" => new ExcelDocument(inputs),
            ".doc" => new WordDocument(inputs),
            ".docx" => new WordDocument(inputs),
            _ => new UnknownDocument(inputs, "Le type de fichier n'est pas accepté")
        };
    }
    public static async Task SendToTranslation(OneOf<WordDocument, ExcelDocument, UnknownDocument> file)
    {
        await file.Match(
                word => SendToWordService(word),
                excel => SendToExcelService(excel),
                unknown => SendToError(unknown)
            );
    }
  ```
### switch expression guard
Principe hérité du FP, permet de guard facilement sur base de la valeur ou meme du type d'obj en combinant avec du pattern matching
```cs
public string GetDescription(Animal animal) => animal switch
{
    Chien 	=> 	"C'est un chien",
    Chat 	=> 	"C'est un chat",
    _ => throw new AnimalException("Non");
};
  ```
  ```cs
public string GetErrorMessage(int errorCode) => errorCode switch
{
    404 => "Not Found",
    500 => "Internal Server Error",
    401 or 403 => "Authentication Error",
    _ => "Unknown Error"
};
  ```
  ```cs
public void Handle(Exception ex)
{
    var message = ex switch
    {
        ArgumentNullException _ => "Il manque un paramètre !",
        HttpRequestException { StatusCode: System.Net.HttpStatusCode.NotFound } => "Site web introuvable",
        TaskCanceledException => "Le délai est dépassé",
        _ => "Une erreur imprévue est survenue"
    };
   Console.Error.WriteLine(message);
}
  ```

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
 ### when
 blablabla
  ```
code
  ```
### static ArgumentException
Hack de lisibilité sur les guards d'entrée.
Permet de reduire une instruction de guard d'entrée en if par un raccourci lisible "a la Perl"
  ```cs
using static System.ArgumentNullException;
using static System.ArgumentOutOfRangeException;

public void Traiter(string? nom, int age)
{
	// on récupère les fns des System.Argument... en static pour les appeler direct avec un nom court et lisibile
	// au lieu de faire if(nom is null) throw new Exception("nom est nul");
    ThrowIfNull(nom);
    ThrowIfNegative(age);
}
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
  ### <T extends ...> <br>
  equivalent de where en C#, ca force un type a respecter un pattern
  ```ts
function returnUnTrucAvecUnNom() : T extends {name:string}
  ```
## F#
match guard, ca remplace meme le principe du "if error throw" en 1 ligne 
Ca permet de gerer les valeurs directement et de renvoyer le traitement reel sur les vrais cas a gérer.
  ```fs
let capitalize str =
    match str with
    |    "" -> ""
    |    _ -> str[0].ToString().ToUpper() + str[1..]
       
  ```

