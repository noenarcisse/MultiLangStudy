# Return
## F#
### implicit return
  La dernière ligne d'un fonction est retournée automatiquement<br>
  Sans return ca fait un retour Unit
  ```fs
  let tee f x = f x; x //renvoie x
	
  let sink f x =
	f(x)
	()
	
  ```
## Go
### multiple returns
  Go permet de retourner plusieurs valeurs. Ca a un feeling a la tuple+deconstr dans les autres lang, mais c'en est pas un, c'est du tout naturel. :><br>
  ```go
  type Table struct {}
  type FlippedTable struct {}
  func FlipTable( t Table) FlippedTable, error {
// ...
  return FlippedTable{} , err
} 
  ```
### naked return
  On peut annoncer les variables locales nommées a return et faire un return a vide<br>
  Elles sont automatiquement déclarées :>
  ```go
func PlusUn(x int, y int) (x1 int, y1 int) {
	x1 = x + 1
	y1 = y + 1
	return
}
  ```

## Nim
### result return
  Nim permet de faire un retour implicite sans annoncer return. Il tente de stocker la valeur de la derniere ligne dans une var interne "result" :><br>
  On peut choisir de l'assigner manuellement aussi (tres proche de go dans ce principe-la)
  ```nim
proc testreturn() : string =
    result = "Salut"

    echo 2+2
    var res = "hey"

echo testreturn() # Salut

proc boolToFrench(b : bool) : string =
    if b : "Oui" else : "Non"

echo (1 > 0).boolToFrench() # Oui
  ```
