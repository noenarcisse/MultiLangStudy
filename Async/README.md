# Async

## C#

### async / await
Passage de stack > heap pour geler la ressources à résoudre

await bloque et demande une Task à résoudre (passage de null vers T)<br>
Deux await successifs se mettent en file d'attente dans l’ordre d’appel.<br>
  ```cs
_=Task.Run( async() => {doStuff()}); //discard la valeur de retour, ca libère le thread
await Task.Delay(1000); // attend la résolution
await Task.Delay(1000); // puis attend celui-ci
  ```

### Task<T>
Equivalent de la Promise en JS. Task tient soit null, soit la valeurs chargée en async.

Changement de thread : on peut forcer C# a chercher un autre thread dans sa thread pool pour pas bloquer la suite de l'exec.<br>
Utile sur des taches et calculs très lourds.
  ```cs
Task<int> task = Task.Run(() => {
    // tache lourde
    return 123;
});
  ```
Ca peut aussi servir a créer un délai, pour simuler un setTimeOut en JS.
  ```cs
await Task.Delay(1000);
  ```



### Task.WhenAll()
Charge en parallele plusieurs function async.

Ne peut pas etre utilisé quand la Task vient d’un meme element ”single thread” comme les DbContext par ex. On doit chain les await pour ouvrir la db, lire, fermer, ouvrir ecrire fermer, ouvrir supprimer, fermer, etc etc.
  ```cs
Task<int> calcTask = Calc(42, 4);
Task<string> fileTask = File.ReadAllTextAsync("./file.txt");

await Task.WhenAll(calcTask, fileTask);

//on await les Task qui sont déjà finie a la ligne précédente pour recupérer les valeurs
int result = await calcTask; 
string text = await fileTask;
  ```

### Channel<T>
https://learn.microsoft.com/en-us/dotnet/core/extensions/channels
Permet de creer un pattern de produce/consume, qui permet de consommer de la donnée produite en async pour revenir vers du sync
  ```cs
code
  ```

## JS / TS

### async / await
Retourne une Promise<T>. Meme principe que C# pour le reste.

### Promise<T>

### Promise.All()
  ```js
Promise.All();
  ```
### Top level async (() => { du code })();
permet de lancer l'exécution d'un bloc async en top level. On triche avec une grosse fn anonyme pour invoker à la volée.
  ```js
code
  ```

## F#
### let!
equivalent de await. Il se place un peu différement.
  ```
let! isAvail = getAvailAsync() |> Async.AwaitTask
  ```
### async
bloc async
  ```fs
async { }
  ```
### return
Result
  ```fs
code
  ```
### return!
Result + deballage
  ```fs
code
  ```
### Top level async
Très similaire a JS, on doit stocker une function async et l'invoker a la volée pour la faire fonctionner en top level (fsx par ex) car l'await est illégal à cet endroit.
  ```fs
let getAvailAsync = Bluetooth.GetAvailabilityAsync

let main =  async {

    let! isAvail = getAvailAsync() |> Async.AwaitTask

    if isAvail = false then
        printfn "Bluetooth is off"
}

Async.RunSynchronously main
  ```
