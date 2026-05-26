# Return
## F#
### implicit return
  La dernière ligne d'un fonction est retournée automatiquement<br>
  Sans return ca fait un retour Unit
  ```fs
  let tee f x =
	f(x) //renvoie le retour de f

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
