# Loops (only the spiciest)
## Go
### for
  for c'est THE loop chez Go. Ca fait tout<br>
  ```go
//la vraie
	for i := 0 ; i < 10 ; i++ {
		fmt.Println(counter)
	}
  ```
  ```go
//le forever
	for {
		fmt.Println("Vers l'infini et au dela")
	}
  ```
  ```go
//le pseudo while
  counter := 0
	for counter < 10 {
		counter++
		fmt.Println(counter)
	}
  ```

## F#

### for _
ca imite le repeat de Kotlin, on peut drop la valeur et juste utiliser la range pour compter
  ```fs
for _ in 1..10 do
    printfn "Salut"

let a, n = 1, 10
for _ in a..n do
    printfn "Salut"
  ```

### comprension list
 comme python le grand frere
  ```fs
let list1 = [1;2;3;4;5]
let list2 = [ for res in list1 do if res % 2 <> 0 then yield res ] // yield peut etre enlevé en vrai mais c'est plus explicite comme "yield return" d'iterator
  ```

## Python
### comprension list
 c'est un for mais ca retourne speicifiquement une liste. Ca n'est pas comparable a la version F# qui elle abuse d'un iterator passé dans une liste.
  ```py
list1 = [1,2,3,4,5]
list2 = [res for res in list1 if res%2 != 0] # liste d'impair
  ```
### generator
 blablabla
  ```py
ma_liste = list(i * 2 for i in range(1, 4))
  ```
### for
  Aie aie aie<br>
  C'est un foreach / for in par defaut, il prend ce qu'il a dans un iterateur ou un collection et déballe la valeur.
  ```py
ienum = range(1,6,2)
for i in ienum:
    print("Je compte mal jusqu'a 5: ", i)
  ```
Pour simuler un for classique il faut itérer sur la longueur de la collection et passer en index direct ou en enumerate qui sort un tuple (i,v)
```
a = ['Mary', 'had', 'a', 'little', 'lamb']
for i in range(len(a)):
    print(i, a[i])
# OU
for index, fruit in enumerate(fruits):
    print(index, fruit)
```
### for: else:
  Sortie de loop jusqu'au bout, sans interruption par un break. C'est attaché a la loop (for ou while)<br>
  Tres similaire un un catch chez try/catch mais dans un cas qui se passe bien plutot qu'une sortie forcée<br>
  ```py
for i in range(10):
    if i == 11 :
        break
else :
    print("Boucle finie sans accroc tout s'est bien passé mon capitaine")
  ```
## Kotlin
### repeat
  Noice<br>
  ```kt
  repeat(5){
        println("Salut")
    }
  ```
