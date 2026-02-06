const fs = require('fs');
const path = require('path');

const fileName = path.basename(__filename);

const ignoreList = [
fileName,
".git",
"_template",
"README.md"
];

const reg = new RegExp(ignoreList.join("|"), "i");

let filesToLog = "";

let fileContent = "";

fileContent += "# Index \n"; 

files = fs.readdirSync("./");
for(f of files)
{
    if(!reg.test(f))
    {
        filesToLog += `[${f}](https://github.com/noenarcisse/MultiLangStudy/tree/main/${f}) \n`;
    }
}

fileContent += filesToLog;

console.log(fileContent);


fs.writeFileSync("./README.md", fileContent);