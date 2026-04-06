# .NET
Framework
## C# - Compilation
Framework-Dependent

### publish
exe et des .dll de quelques 2-3 mo MAIS nécéssite l’enviro .net deja sur le PC
  ```
  dotnet publish
  ```

### self contained
compile .net + le prog en 1 seul, lourd, facilement 100mo
  ```
  dotnet publish --self-contained
  ```

### self contained, singlefile
exe de 70-90 mo
Contient tout et est indépendant. Peut etre Trim pour etre reduit encore un peu plus (vers des 40-50 mo)
  ```
  dotnet publish -r win-x64 -c Release --self-contained true -p:PublishSingleFile=true -p:PublishTrimmed=true
  ```

### AOT
exe de 5-15 mo
Tres strict refuse certains principe ou le srend difficile a debug (full warning) avec tout ce qui fait de la reflection (EF par ex, LINQ complexe)
  ```
  dotnet publish -c Release -r win-x64 /p:PublishAot=true
  ```

## F#

Compilation à la volée, similaire a npx tsx ou bun run sur du TS
  ```
  dotnet new console --lang "F#"
  ```
Compilation à la volée, similaire a npx tsx ou bun run sur du TS
  ```
  dotnet fsi ./fichier.fsx
  ```
### Fable
Tranpile et compile en autres langages (JS, TS, Python, Rust ou Beam)
Permet aussi d'interop avec les autres languages
  ```
dotnet add package Fable.Core
  ```
  ```
//JS
dotnet fable
//TS
dotnet fable --lang typescript
//Python
dotnet fable --lang python
  ```



