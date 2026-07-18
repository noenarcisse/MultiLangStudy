# Templates
## Nim
  Les templates permettent de faire des modifications statiques sur du code avec des remplacements et des raccourcis <br>
  Ca empeche de compiler de reagir quand meme (exception non gérées par ex)
  ```nim
var f : File = nil
if open(f, "./test", FileMode.fmAppend) :
    # si pas de try catch, le compiler annonce l'exception non gérée
    # f.write("Salut2")
    # en template ca obstrue l'annonce du compiler :<
    f&="Salut\n"
    close f
else :
    echo "Non"

stderr&="Salut Aussi" #toujours pas de reaction du compiler alors que write() throws IOError potentiellement :/
  ```
