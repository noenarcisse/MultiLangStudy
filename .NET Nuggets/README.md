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
## Automation IA

### Microsoft.ML (ML.NET)
Y'a trop a dire dessus. Ca permet de lancer des modeles de base de MS ou de charger des modeles extérieur en plus.

Détection d'email spam, Catégoriser automatiquement des tickets de support, Détecter la langue d'un texte, Analyser le sentiment (positif / négatif / neutre) d'un avis client
Prédire un prix immobilier selon des critères, Estimer une durée de livraison, Prévoir un chiffre de vente
Détecter des transactions bancaires frauduleuses, Repérer des pics anormaux dans des logs, Surveiller des métriques serveur
"Les utilisateurs qui ont aimé X ont aussi aimé Y", Suggérer des produits dans un catalogue, Vision par ordinateur (avec ONNX)
Classer des images, Détecter des objets dans une image, En important des modèles entraînés ailleurs (Python, etc.)
  ```
dotnet add package Microsoft.ML
dotnet add package Microsoft.ML.OnnxRuntime
  ```



## Hooks
Permet d'acceder à des hooks windows simplifiés sans devoir faire du low level et approcher l'OS avec des risques de lock ou ralentissement.
### SharpHook
Elle permet de surveiller et de simuler des inputs très facilement.
https://sharphook.tolik.io/articles/native.html
  ```
dotnet add package SharpHook
  ```

### MouseKeyHook
Une librairie très populaire et simple pour .NET qui encapsule toute la complexité des API Windows.


## Reseau

### InTheHand
Bluetooth classic et LE
https://inthehand.com/2023/07/07/bluetooth-classic-and-low-energy-different-approaches/
https://github.com/inthehand/32feet
https://inthehand.github.io/html/N_InTheHand_Net_Bluetooth.htm
  ```
dotnet add package InTheHand.Net.Bluetooth --version 4.2.3
dotnet add package InTheHand.BluetoothLE --version 4.0.44
  ```

### Polly ?
Rinse and repeat, retries reseaux
  ```
dotnet add package Polly
  ```

## unsorted

### OpenCVSharp4
"Usage : Suivre un objet par couleur (CamShift), par flux optique (Lucas-Kanade) ou via des algorithmes de tracking dédiés (MOSSE, CSRT, KCF).
Idéal pour : Projets desktop (WPF, WinForms, Console) nécessitant une analyse image par image."
  ```
OpenCvSharp4.Windows
OpenCvSharp4.Extensions
  ```

### MediaPipe.NET 
Usage : Tracking de points d'intérêt (landmarks) sur le corps humain en temps réel.

### Wappers communautaires comme Hands.Net

## Diagnostics
### LibreHardwareMonitor
Surveille l'os et le materiel
  ```
dotnet add package LibreHardwareMonitor
  ```
### System.Diagnostics.PerformanceCounter
Lib windows externe, surveille le materiel, complexe, comme d'hab avec MS
  ```
dotnet add package System.Diagnostics.PerformanceCounter
  ```
