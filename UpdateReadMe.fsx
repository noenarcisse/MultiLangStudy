open System.IO
open System

//separated file
let ignoreList = [
    ".git";
    "bin";
    "obj";
    "_template";
]
let readme =  @"README.md"

let header = [
    "# Index" ; 
    "Liste des catégories : <br>"
]

let tee f x = f x ; x
let  display dirNames= dirNames |> Seq.iter(printfn "%s")
let encodeForUrl (text:string) = Uri.EscapeDataString text

let toMarkdown (list: string seq) =
    list
    |> Seq.map (fun x -> $"[{x}](https://github.com/noenarcisse/MultiLangStudy/tree/main/{encodeForUrl x})<br>")

let write file (list:string seq) =
    let content = list |> toMarkdown |> Seq.toList
    File.WriteAllLines( file, header @ content)
        


Directory.GetCurrentDirectory() 
|> Directory.EnumerateDirectories
|> Seq.map Path.GetFileName
|> Seq.filter (fun discard-> ignoreList |> List.contains discard |> not)
|> tee display 
|> write readme