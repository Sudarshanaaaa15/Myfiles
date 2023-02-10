const fs = require("fs");
const file = "./Consumingmodule.js";

////////////////////////////////////////////////////////////////////////Sync reading/////////////////////////////////////////////////////////////
function readFileesync() {

    const contents = fs.readFileSync(file, `utf-8`);

    console.log(contents.toString());
}

///////////////////////////////////////////////////////////////////////Async reading/////////////////////////////////////////////////////////////////////
function readFileeasync() {
    fs.readFile(file, `utf-8`, function (err, data) {
        if (err) {
            console.error(err)
        }
        else {
            console.log(data);
        }
    })
}
function writeFile(){
    fs.writeFile("Writefile.txt", "content goes here", (err) => {
        if(err) console.log(err)
    } )
}
function appendingFile(){
    fs.appendFileSync("Writefile.txt","\n content will be appended to the next line\n", "utf-8");
}

function appendFileAssync(){
    fs.appendFile("Writefile.txt","\n content will be appended to the next line\n", (err) => {
        if(err) console.log(err)
    } )
}

appendFileAssync();
// appendingFile();

// writeFile();
// readFileesync();
// readFileeasync();
console.log("we are executing that code after file reading");