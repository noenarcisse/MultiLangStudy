# Typage

## C#
### typeof()
Renvoie un objet Type avec les métadonnées accrochées à ce qu'on tente de recupérer. Pas de string comme en JS. <br>
C'est assez proche dans le principe de la récupération de fonction en JS ou on a acces au data. Ici on récupère jamais le body par contre.
Ca implique de la Reflection.
  ```cs
code
  ```

### using alias
Le using permet d'écrire des alias (facon import as en JS). Ca permet un abus qui autorise a creer n'importe quoi, y compris un tuple. <br>
Ca imite un peu le type de TS sans avoir a faire un struc, record ou class<br>
Ca peut aussi est destruct du coup.
  ```cs
using UnTruc = (int, string);
public static void Truquer(UnTruc truc) => Console.WriteLine(truc.Item1+" "+truc.Item2);
Truquer((1, "Hey ca va ?"));
UnTruc truc = (2, "Pas trop j'ai mal au ventre");
Truquer(truc);
  ```

## TS
### type
  Typage non mergeable<br>
  Il est le seul a pouvoir faire quelques trucs specifiques comme :<br>
  Il peut etre du typage ou de l'impémentation comme un interface
  ```ts
// Union → impossible en interface
type StringOuNumber = string | number

// Simple alias → impossible en interface
type ID = string

// Tuple → impossible en interface
type Point = [number, number]
  ```
Les fonctions sont aussi des objets comme en JS mais avec leur propre typage et leur patterns pour etre reconnnues.
  ```ts
//on peut aussi stocker des functions anonymes avec des metadonnees
type MonCallback = Function & {
    timeout: number;
    retry: boolean;
}
// ou meme identifier une fonction par rapport a ses args et son return
type MonCallback2 = ((error: Error | null, result: string) => void)
  ```
On peut passer des conditions, uniquement en ternaire
  ```ts
type MonType<T> = T extends string ? number : string;

function maFonction<T>(arg: T): MonType<T> {
    // ...
}
  ```
### interface
  Lorsqu'utilisé pour du typage :
  Typage, extensible et mergeable<br>
  ```ts
interface Animal { nom: string }
interface Animal { age: number }
  ```
  ```ts
type Animal = { nom: string } & { age: number } // un type peut recombiner 2 concepts mais sans les modifier plus tard.
  ```

### Duck typing

  ```ts
interface Volant {
    voler(): void
}

class Canard {
    voler() { console.log("je vole") }
    nager() { console.log("je nage") }
}

function faireVoler(animal: Volant) {
    animal.voler()
}

const canard = new Canard()
faireVoler(canard) // ca compile, ca ressemble a un Volant donc c'est un Volant
  ```

## F#
### type
Forte ressemblance au TS. On peut pas type union ici, on doit discriminer avec un systeme proche du swtch expr / match with.
Les cas doivent être gérés, le compiler est strict!
En cas de 2 types similaire, le dernier écrit gagne (philo linéaire toujours)
  ```fs
type Guerrier = {
    armor : int
}

type Magicien = {
    mutable MP : int
}

type Classe = 
    | Guerrier of Guerrier
    | Magicien of Magicien

type Personnage = {
    name : string
    mutable HP : int
    classe : Classe
}
  ```
