# Guards, Nullchecks & Default values
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

### Result<T,E>
Nuget externe Dotnext : https://dotnet.github.io/dotNext/features/core/result.html <br>
Simule vraiment bien un Result a la fonctionnelle, avec mutation sans deballer, default value etc.
```cs
    public static void Test()
    {
        var res = Test2();

        if (res.IsSuccessful)
        {
            Console.WriteLine(res.Value);
        }
        else
        {
            var err = res.Error switch
            {
                TestError.NullInput => "Empty input",
                TestError.IntParseFailed => "Error while parsing the number",
                TestError.WrongNumber => "Wrong number must be between 1 and 9",
                _ => "Unknwon error"
            };
            Console.WriteLine(err);
        }
    }
    static Result<int, TestError> Test2()
    {
        string? s = Console.ReadLine();

        if (s is null) return new Result<int, TestError>(TestError.NullInput);
        if (!int.TryParse(s, out int n)) return new Result<int, TestError>(TestError.IntParseFailed);

        return n switch
        {
            > 0 and < 10 => new Result<int, TestError>(n),
            _ => new Result<int, TestError>(TestError.WrongNumber)
        };
    }
public enum TestError
{
    NullInput,
    IntParseFailed,
    WrongNumber
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
Check un respect d'héritage ou d'implementation. Equivalent du T extends chez TS mais peut etre implicite :D
  ```
public class Machin
{
    public string Truc = "";
}
public class PetitMachin : Machin { }

// ...

Machin m = new() { Truc = "Normal" };
PetitMachin pm = new() { Truc = "Petit" };
Truc t = new();
static void Machiner<T>(T m) where T : Machin => Console.WriteLine(m.Truc);

Machiner(m);
Machiner(pm);
Machiner(t); // non Truc hérite pas de Machin

  ```
 ### when
 blablabla
  ```cs
for (int i = 1; i <= 20; i++)
{
    string t = i switch
    {
        _ when i % 3 == 0 && i % 5 == 0 => "Fizzbuzz",
        _ when i % 3 == 0 => "Fizz",
        _ when i % 5 == 0 => "Buzz",
        _ => $"{i}"
    };
    Console.WriteLine(t);
}
  ```
 ### default
 blablabla
  ```
code
  ```
 ### ??
 nullcheck permet de passer une valeur par defaut si la valeur actuelle est null. Ca permet pas seulement de return une val du meme type mais de throw une exception aussi, le compiler déduit alors forcément un type au lieu de type?.
  ```
// avec public string? GetText() déclaré
string montexte = GetText() ?? "Le texte est vide";
string monautreTexteImportant = GetText() ?? throw new Exception("On va s'écraser mon capitaine");
  ```
### static ArgumentException
Hack de lisibilité sur les guards d'entrée.
Permet de reduire une instruction de guard d'entrée en if par un raccourci lisible "a la Perl" avec l'erreur affichée avant la condition.
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

## Go
### (type)
element.(type) permet d'extraire et de comparer le type concret d'un obj qui passait pas une interface. <br>
Ca permet d'ensuite savoir si on peut acceder a des fields specifique que l'interface ne promet pas <br>
Go permet aussi un if elemstr , ok := element.(string); ok pour verifier un type concret directement et recupérer une versions afe de l'element confirmé
  ```go
type FileNotFoundErr struct {
	errMsg string
}
type MalformedFileErr struct {
	errMsg string
}
func (e FileNotFoundErr) Error() string {
	return e.errMsg
}
func (e MalformedFileErr) Error() string {
	return e.errMsg
}

func DealWithErr(e error) {
	switch e.(type) {
	case FileNotFoundErr:
		fmt.Println("File not found")
	case MalformedFileErr:
		fmt.Println("File has errors in it")
	default:
		fmt.Println("Unknown error")
	}
}
  ```
  ```go
elem := 2
if elemstr , ok := element.(string); ok {
	fmt.Printf("%s\n", elemstr)
}
if elemint, ok := element.(int); ok {
	total := 2 + elemint
}
  ```
 ### Zero value
 N'importe quel élement en Go passe toujours par une zero value par default qui dépend de ce qu'on manipule en tant que tel. Ca permet plus de certitude sur ce qu'on manipule.
  ```go
var str string //zero val = ""
var structure maStruct // zero val = nil
// ...
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
Le roi de la guard <br>
match guard, ca remplace meme le principe du "if error throw" en 1 ligne 
Ca permet de gerer les valeurs directement et de renvoyer le traitement reel sur les vrais cas a gérer.
  ```fs
let capitalize str =
    match str with
    |    "" -> ""
    |    _ -> str[0].ToString().ToUpper() + str[1..]
       
  ```
### Result<T, TE>
Emballe les valeurs dans T ou Erreur et permet de deballer pour gerer les errs <br>
C'est tout automatique et facile avec Ok et Error <br>
Pour typer une erreur il faut juste definir un type personalisé et passer les différentes valeurs directement dans Error pour toujours povuoir vérifier l'Error et le type passé pus loin.
  ```fs
open System.IO

type FileError =
    | Inexistant
    | BadExtension

let ouvrirFichier path =
    if not(File.Exists path) then
        Error Inexistant
    elif Path.GetExtension path <> ".json" then
        Error BadExtension
    else
    	Ok path

let test path = 
    match path with
    | Error Inexistant -> printfn "Le fichier n'existe pas"
    | Error BadExtension -> printfn "Le fichier n'est pas du jason"
    | Ok filepath -> printfn "Bien joué voici le contenu du fichier : %s"  (File.ReadAllText filepath)

ouvrirFichier "./fichierbidon" |> test
ouvrirFichier ".gitignore" |> test
ouvrirFichier "./sample.json" |> test
  ```

## Python
todo <br>
### or
Fonctionne come JS en principe de truthy ou falsy values (empty str, None, 0, collection vide, tuple vide etc sont assimilés a False, le reste a True)
  ```py
montext = getText() or "C'est vide par ici"
  ```
## Kotlin
Le prince de la guard <br>
### when 
Ca permet de gerer les valeurs directement et de renvoyer le traitement reel sur les vrais cas a gérer. C'est le petit frère du F# la dessus
  ```kt
    open class Character (val name : String, var health : Int)
    class Mage (name:String, health:Int, var mana: Int) : Character(name, health)
    class Warrior(name:String, health:Int, armor:Int) : Character(name, health)
    class Rogue(name:String, health:Int, energy:Int) : Character(name, health)

    fun printClass(chara: Any) {
        when(chara)
        {
            is Rogue -> println("Rogue")
            is Warrior -> println("Warrior")
            is Mage -> println("Mage")
            else -> println("Unknown")
        }
    } 
  ```

