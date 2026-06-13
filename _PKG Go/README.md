# Go packages

## DB
### go sqlite
Implementation du driver sqlite en pur Go<br>
Vibe tres classique a l'ancienne PHP sans orm qui marche bien pour du petit projet fixe.
https://pkg.go.dev/modernc.org/sqlite
  ```
go get gitlab.com/cznic/sqlite
  ```
### go sqlite3
Driver sqlite wrapper de C, requiert cgo<br>
Dependance externe a cause du C, apparement plus performant ?
https://github.com/mattn/go-sqlite3
  ```
code
  ```
### gORM
ORM classico classique, pas de SQL, migration, alignement de la DB avec des structs<br>
https://pkg.go.dev/gorm.io/driver/sqlite
  ```
code
  ```


## Scraping
### (bro)Colly
Scraping + permet d'ouvrir les liens pour explorer, de garder ceux deja vu pour pas relancer x fois la memepages etc.<br>
[https://go-colly.org/](https://go-colly.org/)<br>
[https://github.com/gocolly/colly](https://github.com/gocolly/colly)
  ```
go get github.com/gocolly/colly/v2
  ```

## Navigateur
### chromedp
https://github.com/chromedp <br>
Gere un navigateur, passe par du chromium mais directement sur un navigateur present sur la machine, pas besoin de stocker une instance dediée. <br>
Il est documenté mais entre deux entre du facile et du difficile, beaucoup de trucs a savoir (.text().do(ctx) lorsqu'on est dans un func anonyme et plus directement en callback dans Run(), etc), des callbacks en cascades Ajax-style
  ```
code
  ```

### rod
https://github.com/go-rod/rod <br>
https://pkg.go.dev/github.com/go-rod/rod <br>
Plus facile au vu de la doc avec de OOP tres classique
  ```
code
  ```

## Documents
### pdf
Très basique et facile, ca recupere du text ou des glyphes + leur position.
https://pkg.go.dev/github.com/ledongthuc/pdf
  ```
go get -u github.com/ledongthuc/pdf
  ```
