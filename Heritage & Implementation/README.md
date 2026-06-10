# Héritage & Implementation
## C#
### Héritage
  class : baseClass. Tres proche de java mais moins verbeux (pas de inherits)<br>
  ```cs
public class Enfant : Parent
{ }
  ```
### Implementation
  S'ecrit exactement comme un héritage.
  ```cs
public class Chien : IAboyeur
{ }
  ```
### base
  Equivalent du super de java avec une utilisation un peu différente<br>
  Il s'ecrit plus comme un héritage sur la methode plutot que d'etre appelé dans le body.
  ```cs
public Constructeur(int arg, int arg2) : base(int arg)
  ```

## py
### Héritage
  class (baseclass)<br>
  héritage mutliple <br>
  utilise des décorateurs pour specifier
  ```py
@final
class Enfant (Parent1, Parent2, Parent3) :
  def __init__(self) :
    self.name=""
  @abstractmethod
  def marcher(self) :
    pass
  ```
Pas de virtual ou d'override c'est la fete a la saucisse on peut deja reecrire les mots clé du langage, donc les methodes on est plus a ca pret.
