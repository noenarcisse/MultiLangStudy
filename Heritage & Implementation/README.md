# Héritage & Implementation
## C#
### Héritage
  class : baseClass. Tres proche de java mais moins verbeux (pas de inherits)<br>
  ```
public class Enfant : Parent
{ }
  ```
### Implementation
  S'ecrit exactement comme un héritage.
  ```
public class Chien : IAboyeur
{ }
  ```
### base
  Equivalent du super de java avec une utilisation un peu différente<br>
  Il s'ecrit plus comme un héritage sur la methode plutot que d'etre appelé dans le body.
  ```
public Constructeur(int arg, int arg2) : base(int arg)
  ```


