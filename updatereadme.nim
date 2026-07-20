import os
import strformat
import uri

proc formatMarkdown(dirname : string) : string =
    &"[{dirname}](https://github.com/noenarcisse/MultiLangStudy/tree/main/{encodeUrl dirname})<br>\n"

var f : File = nil
let ignored = @[".git", ".vscode", "_template"]
let readme_file = "README.md"
let header = """
# Index
Liste des catégories : <br>
"""
var content : string

for e in walkDir(".") :
    if e.kind != PathComponent.pcDir : continue
    var dirname = extractFilename(e.path)
    if dirname in ignored : continue
    content&=formatMarkdown dirname

if open(f, readme_file, FileMode.fmWrite) :
    defer : close f
    f&=header&"\n"&content #write non trycatch
else :
    echo "Outch, opening file failed"