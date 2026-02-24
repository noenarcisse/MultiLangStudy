# Async

## C#

### async / await
Passage de stack > heap pour geler la ressources a resoudre

await bloque et demande une Task a resoudre (passage de null vers T)<br>
Deux await successifs se mettent en file d'attente dans l’ordre d’appel.<br>
Changement de thread sans bloquer une recup asyc avec un await : _=Task.Run( async() => {doStuff()});<br>



### Task<T>
Equivalent de la Promise en JS. Task tient soit null, soit la valeurs chargée en async.

Changement de thread : on peut forcer C# a chercher un autre thread dans sa thread pool pour pas bloquer la suite de l'exec.<br>
Utile sur des taches et calculs très lourds.
  ```
Task<int> task = Task.Run(() => {
    // tache lourde
    return 123;
});
  ```
Ca peut aussi servir a créer un délai, pour simuler un setTimeOut en JS.
  ```
await Task.Delay(1000);
  ```



### Task.WhenAll()
Charge en parallele plusieurs function async.

Ne peut pas etre utilisé quand la Task vient d’un meme element ”single thread” comme les DbContext par ex. On doit chain les await pour ouvrir la db, lire, fermer, ouvrir ecrire fermer, ouvrir supprimer, fermer, etc etc.
  ```
Task<int> calcTask = Calc(42, 4);
Task<string> fileTask = File.ReadAllTextAsync("./file.txt");

await Task.WhenAll(calcTask, fileTask);

//on await les Task qui sont déjà finie a la ligne précédente pour recupérer les valeurs
int result = await calcTask; 
string text = await fileTask;
  ```
## JS / TS

### async / await

### Promise<T>

### Promise.All()
  ```
Promise.All();
  ```
