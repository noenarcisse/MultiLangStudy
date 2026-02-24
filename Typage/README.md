# Typage

## C#
### typeof()
Renvoie un objet Type avec les métadonnées accrochées à ce qu'on tente de recupérer. Pas de string comme en JS. <br>
C'est assez proche dans le principe de la récupération de fonction en JS ou on a acces au data. Ici on récupère jamais le body par contre.
Ca implique de la Reflection.
  ```ts
code
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
