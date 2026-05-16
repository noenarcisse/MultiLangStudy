# Mots-clés du langage Go

> Go possède seulement **25 mots-clés**, ce qui en fait un langage très compact.

---

## Déclaration & typage

| Mot-clé | Rôle |
|---|---|
| `var` | Déclare une variable |
| `const` | Déclare une constante |
| `type` | Définit un nouveau type |
| `func` | Déclare une fonction |
| `struct` | Définit une structure (agrégat de champs) |
| `interface` | Définit un ensemble de méthodes |
| `map` | Type tableau associatif clé→valeur |
| `chan` | Type canal (communication entre goroutines) |

---

## Contrôle de flux

| Mot-clé | Rôle |
|---|---|
| `if` / `else` | Condition |
| `switch` | Aiguillage multi-cas |
| `case` / `default` | Cas d'un switch ou select |
| `for` | Boucle (le seul mot-clé de boucle en Go) |
| `range` | Itère sur slice, map, chan, string |
| `break` | Sort d'une boucle ou switch |
| `continue` | Passe à l'itération suivante |
| `goto` | Saut inconditionnel vers un label |
| `fallthrough` | Force l'exécution du cas suivant dans un switch |
| `return` | Retourne depuis une fonction |

---

## Concurrence

| Mot-clé | Rôle |
|---|---|
| `go` | Lance une goroutine (thread léger) |
| `select` | Attend sur plusieurs canaux |

---

## Packages & imports

| Mot-clé | Rôle |
|---|---|
| `package` | Déclare l'appartenance à un package |
| `import` | Importe des packages |

---

## Gestion mémoire / valeurs

| Mot-clé | Rôle |
|---|---|
| `defer` | Exécute une fonction à la fin du bloc courant |
| `make` | Alloue et initialise slice, map ou chan |
| `new` | Alloue un pointeur vers un type zéro |

---

> **Astuce mnémotechnique :** Go n'a *pas* de `class`, `while`, `try/catch`, `throws` — la simplicité est un choix de design volontaire.
