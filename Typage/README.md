# Typage
## TS
### type
  Typage immuable<br>
  ```ts
  //code
  ```
### interface
  Lorsqu'utilisé pour du typage :
  Typage, extensible et mergeable<br>
  ```ts
interface Animal { nom: string }
interface Animal { age: number }
  ```
  ```ts
type Animal = { nom: string } & { age: number }
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
