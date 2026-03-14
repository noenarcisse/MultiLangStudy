# .NET NugGets

## Automation

### FlaUI
  Automation des fenetres windows, les plus classiques<br>
  https://github.com/FlaUI/FlaUI
  ```
dotnet add package FlaUI.Core --version 5.0.0
  ```

### OpenXML / ClosedXML
Opensource, permet de manipuler les doc, xls et ppt. XML complet (excel en particulier)<br>
Possibilité d'ouvrir en stream et de passer node par node en cherchant .Elements<Cell> par ex pour parcourir toutes les cells de toutes les feuilles d'un fichier gigantesque.
  ```
dotnet add package DocumentFormat.OpenXml --version 3.4.1
  ```
Gere les fichiers de manière simplifiées (excel devient un vrai tab[,] plutot que des rows qui font ref par addresse a des data
Ne permet pas le stream sur des trop gros fchiers
  ```
dotnet add package ClosedXML
  ```

### LibreOffice

### PdfPig
  ```
dotnet add package UglyToad.PdfPig
  ```


