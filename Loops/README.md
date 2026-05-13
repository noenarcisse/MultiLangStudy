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

## Python
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
