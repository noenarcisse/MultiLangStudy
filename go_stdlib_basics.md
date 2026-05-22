\# Go Standard Library - Cheat Sheet (Spécial dev C#)



En Go, les types de base sont "bêtes" (pas de méthodes d'extension comme en C#). La logique est toujours la même : \*\*tu appelles une fonction d'un package et tu lui passes ta variable en paramètre.\*\*



\---



\## 1. Texte, Data et Conversions



Go sépare strictement les chaînes (`string`) et les tableaux d'octets (`\[]byte`).



\### `strings` \& `bytes` (Boîtes à outils)

\*   `strings.Split(s, ",")` : Découpe une chaîne en slice de strings (`\[]string`).

\*   `strings.Contains(s, "sub")` : Vérifie si une sous-chaîne existe (booléen).

\*   `strings.Join(slice, "-")` : Rassemble un slice de strings en une seule chaîne.

\*   `bytes.Buffer` : \*\*L'indispensable.\*\* Une structure qui grandit toute seule en mémoire. Elle implémente `io.Writer`, ce qui permet de l'utiliser pour capturer des flux, écrire des fichiers ou stocker le résultat de commandes système.



\### `strconv` (String Conversion)

Caster directement avec `string(65)` ne donne pas `"65"` mais le caractère ASCII `"A"`. Pour les conversions textuelles, il faut utiliser `strconv`.

\*   `strconv.Itoa(42)` : Convertit un `int` en `string` (\*Integer to ASCII\*).

\*   `strconv.Atoi("42")` : Convertit une `string` en `int` (renvoie la valeur ET une erreur).

\*   `strconv.ParseFloat("3.14", 64)` : Convertit une chaîne en `float64`.



\---



\## 2. Entrées / Sorties (I/O) et Système



Tout le système d'E/S en Go repose sur deux contrats (interfaces) du package `io` : `io.Reader` (la source depuis laquelle on lit) et `io.Writer` (la destination dans laquelle on déverse).



\### `os` (Le Système d'Exploitation)

\*   `os.ReadFile("file.txt")` : Lit un fichier entier d'un coup et renvoie un `\[]byte`.

\*   `os.WriteFile("file.txt", data, 0644)` : Écrit un `\[]byte` dans un fichier (écrase le contenu).

\*   `os.Open("file.txt")` : Ouvre un fichier en mode "flux" (renvoie un objet qui implémente `io.Reader`).

\*   `os.Getenv("MY\_VAR")` : Récupère une variable d'environnement.



\### `os/exec` (Lancer des programmes externes)

L'équivalent (en plus épuré) de la classe `Process` en C#.

\*   `exec.Command(path, args...)` : Prépare la commande binaire.

\*   `prog.Output()` : Lance la commande, attend la fin et renvoie `Stdout` en `\[]byte`.

\*   `prog.CombinedOutput()` : Pareil, mais fusionne `Stdout` et `Stderr` (idéal pour logger les erreurs).

\*   `prog.Run()` : Version semi-manuelle. Lance et attend la fin, mais nécessite d'avoir branché des structures comme `bytes.Buffer` sur `prog.Stdout` au préalable.



\---



\## 3. Web et Formats de Données



\### `encoding/json` (Sérialisation)

Pas d'objets dynamiques ici, Go a besoin de structures strictes pour mapper le JSON.

\*   `json.Marshal(monStruct)` : Convertit un struct en `\[]byte` (JSON textuel).

\*   `json.Unmarshal(dataJson, \&monStruct)` : Remplit un struct existant à partir de données JSON. \*\*Attention :\*\* il faut impérativement passer un pointeur (`\&`).



\*Astuce pour lier le JSON (souvent en minuscule) aux propriétés Go (obligatoirement en Majuscule pour être publiques) :\*

```go

type User struct {

&#x20;   Name string json:"name"

&#x20;   Age  int    json:"age"

}

