# Lazy<T>
## C#
Lazy<T>
System.Lazy > Lazy initialization: on charge reellement que lorsqu’on a besoin. ca nest le T dans Value
  ```
using System;
// ...
Lazy<Fruit> lazyFruit = new();
Fruit fruit = lazyFruit.Value;
  ```

## JS
Le weirdo, il n'y a pas pas de lazy mais on peut delay le chargement de donnée avec un getter dans un objet littéral :
  ```
const obj = {
  _data: null,
  get data() {
    if (!this._data) {
      this._data = loadHeavyData();
    }
    return this._data;
  }
};

// ...

const maVar = obj.data // charge la data ici en tentant de get!
  ```

