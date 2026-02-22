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

	files = fs.readdirSync("./", {withFileTypes:true});
	for(f of files)
	{
		if(!f.isDirectory())
			continue;
		
		if(!reg.test(f.name))
		{
			filesToLog += `[${f.name}](https://github.com/noenarcisse/MultiLangStudy/tree/main/${f.name.replaceAll(" ", "%20")})  <br> \n`;
		}
	}

	fileContent += filesToLog;

	console.log(fileContent);


	fs.writeFileSync("./README.md", fileContent);