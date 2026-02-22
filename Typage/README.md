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
