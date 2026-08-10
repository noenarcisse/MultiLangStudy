# Packages
## Result / DU
| Language | Package | Etat | Descr | CMD | Lien |
|---|---|---|---|---|---|
| C# | OneOf | Excellent | Type discrimination | `dotnet add package OneOf` | https://github.com/mcintyre321/OneOf |
| C# | DotNext | Good?<br>A tester plus | Result<T, Exception> | `dotnet add package DotNext` | https://dotnet.github.io/dotNext/features/core/result.html |
| Nim | results | Excellent? | Result[T,E] | `nimble install results` | https://github.com/arnetheduck/nim-results |

## Strings
| Language | Package | Descr | CMD | Lien |
|---|---|---|---|---|
| C# | InterpolatedParser | Reversed Interpolation | `dotnet add ` | https://github.com/AntonBergaker/InterpolatedParser |
| C# | OutParser | Reversed Interpolation | `dotnet add ` | https://github.com/AntonBergaker/OutParser |

## Images
| Language | Package | Etat | Descr | CMD | Lien |
|---|---|---|---|---|---|
| C# | ImageSharp | Excellent | Manipulation d'images. https://docs.sixlabors.com/ | `dotnet add package SixLabors.ImageSharp` | https://www.nuget.org/packages/sixlabors.imagesharp/ |

## PDF
| Language | Package | Etat | Descr | CMD | Lien |
|---|---|---|---|---|---|
| C# | PDF Pig | Excellent | Ouvre les pdf. Recupère contenu.Permet aussi de cropper. | `dotnet add package UglyToad.PdfPig` | |
| Python | pdfplumber | Excellent | Ouvre les pdf. Recupères contenu.Permet aussi de cropper. | `uv add pdfplumber` | |
| Go | ledongthuc/pdf | Meh | Limité, recupère les symbole et leur position | `go get -u github.com/ledongthuc/pdf` | |

## Word / Excel
| Language | Package | Descr | CMD | Lien |
|---|---|---|---|---|
| C# | OpenXML | Opensource, permet de manipuler les doc, xls et ppt. XML complet (excel en particulier). Possibilité d'ouvrir en stream et de passer node par node en cherchant .Elements<Cell> par ex pour parcourir toutes les cells de toutes les feuilles d'un fichier gigantesque. | `dotnet add package DocumentFormat.OpenXml --version 3.4.1` |  |
| C# | ClosedXML | Gere les fichiers de manière simplifiées (excel devient un vrai tab[,] plutot que des rows qui font ref par addresse a des data. Ne permet pas le stream sur des trop gros fchiers | `dotnet add package ClosedXML` | |

## Scraping
| Language | Package | Etat | Descr | CMD | Lien |
|---|---|---|---|---|---|
| Go | Colly | Excellent | Scraping + permet d'ouvrir les liens pour explorer, de garder ceux deja vu pour pas relancer x fois la meme page etc. | `go get github.com/gocolly/colly/v2` | https://github.com/gocolly/colly |
| Python | Beautiful Soup | Good | Permet un parours de DOM. Ne get pas le HTML de base | `uv add pdfplumber` | |

## Navigateur / Automation
| Language | Package | Etat | Descr | CMD | Lien |
|---|---|---|---|---|---|
| C# | FlaUI | Good? | A test. Automation des app windows, WPF, Winforms, etc. | `dotnet add package FlaUI.Core` | https://github.com/FlaUI/FlaUI |
| C# | FlaUI Inspect | Good | Inspection des fenetres windows | `code` | https://github.com/FlaUI/FlaUI |
| | AccessibilityInsights | Good | Inspection des fenetres windows | `code` | lien |
| Typescript<br> Python<br> C# | ? | Playwright | A test. Automation navigateur / chromium | `code` | lien |
| Python | pywinauto |  | A test. App windows | `code` | lien |
| Go | chromedp | Okay | Bas niveau, plutot évident en soi car il garde la même logique partout. Il utilise un chromium qu'il trouve sur la machine si possible | `go get github.com/chromedp/chromedp` | https://github.com/chromedp/chromedp |
| Go | rod | Okay | Playwright-like en Go. Orienté composition. Faut chipoter pour l'empecher de DL un chromium en plus | `go get github.com/go-rod/rod` | https://github.com/go-rod/rod |
| Python | Beautiful Soup | Okay | Permet un parours de DOM. Ne get pas le HTML de base. Faut soi même gérer le parcours du site et le cache des liens | `uv add pdfplumber` | |

## Hooks
Permet d'acceder à des hooks windows simplifiés sans devoir faire du low level et approcher l'OS avec des risques de lock ou ralentissement.
| Language | Package | Descr | CMD | Lien |
|---|---|---|---|---|
| C# | SharpHook | Permet de surveiller et de simuler des inputs  | `dotnet add package SharpHook` | https://sharphook.tolik.io/articles/native.html |
| C# | MouseKeyHook |  | `cmd` |  |

## Bluetooth
Permet d'acceder à des hooks windows simplifiés sans devoir faire du low level et approcher l'OS avec des risques de lock ou ralentissement.
| Language | Package | Descr | CMD | Lien |
|---|---|---|---|---|
| C# | InTheHand | Bluetooth  | `dotnet add package InTheHand.Net.Bluetooth --version 4.2.3` | https://github.com/inthehand/32feet |
| C# | InTheHand | BLE  | `dotnet add package InTheHand.BluetoothLE --version 4.0.44` | https://inthehand.com/2023/07/07/bluetooth-classic-and-low-energy-different-approaches/ |
| Go | tinyGo/bluetooth |  | `go get github.com/tinygo-org/bluetooth ` | https://pkg.go.dev/tinygo.org/x/bluetooth |

## OCR
Permet d'acceder à des hooks windows simplifiés sans devoir faire du low level et approcher l'OS avec des risques de lock ou ralentissement.
| Language | Package | Descr | CMD | Lien |
|---|---|---|---|---|
| C# | Windows OCR | OCR simple interne a Windows  | `using Windows.Media.Ocr.OcrEngine;` | https://learn.microsoft.com/fr-fr/uwp/api/windows.media.ocr.ocrengine?view=winrt-26100 |
| C# | OCR wrapper MAUI | Gere les OCR de base et offre une interface commune multi support  | `dotnet add package Plugin.Maui.OCR` | https://www.nuget.org/packages/Plugin.Maui.OCR |

# .NET NugGets

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



## Reseau

### Polly ?
Rinse and repeat, retries reseaux
  ```
dotnet add package Polly
  ```

## unsorted

### HtmlAgilityPack
Parsing de html
  ```
dotnet add package HtmlAgilityPack --version 1.12.4
  ```

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
