const express = require("express");
const parser = require("body-parser")
const app = express();

app.use(parser.urlencoded({extended : false}));

app.get('/',(req,res) => res.send("Welcome to express training"));
app.get('/Home',(req,res) => res.sendFile(__dirname + "/Home.html"));
app.get('/Register',(req,res) => res.sendFile(__dirname + "/Register.html"));

app.get('/AfterRegister',(req,res) => {
    const name = req.query.textname;
    const email = req.query.textemail;
    res.send(`${name} is registered with us and we'll be contacted via email address shared as ${email}`)

} );

app.post('/AfterRegister', (req,res) => {
    if(req.body == null){
        res.send("the data entered is not a valid data")
    }else{
        const name = req.body.textname;
        const email = req.body.textemail;
        res.send(`${name} is registered via HTTPPOST with us and we'll be contacted via email address shared as ${email}`)
    }
})

app.listen(1444,() => console.log("server is available at 1444"));

/* Create a folder called ExpressDemo
install the express package in this folder 
ope the terminal in the folder location and enter the command ;npm nstall express 
Express will be installed in the node_mosules with a refernce of it mentioned in the package.json

package.json is the config setting */