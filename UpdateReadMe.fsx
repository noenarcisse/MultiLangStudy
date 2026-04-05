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

let  display dirNames=
    dirNames |> List.iter(fun x -> printfn "%s" x)
    dirNames

let encodeForUrl (text:string) =
    Uri.EscapeDataString(text)

let toMarkdown (list: string list) =
    list
    |> List.map (fun x -> $"[{x}](https://github.com/noenarcisse/MultiLangStudy/tree/main/{encodeForUrl x})  <br>")

let write file (list:string list) =
    let content = list |> toMarkdown
    File.WriteAllLines( file, content)
        


Directory.GetCurrentDirectory() 
    |> Directory.GetDirectories
    |> Array.toList
    |> List.map Path.GetFileName
    |> List.filter (fun discard-> ignoreList |> List.contains discard |> not)
    |> display 
    |> write readme