// webapp.js will handle web requests for the pages we create

const http = require("http");
const fs = require("fs");
const httpParse = require('url').parse;
// const { url } = require("inspector");
// const { parse } = require("path");
const dir = __dirname;
// const querystring =

function disPage(res, url) {
    const response = dir + url + ".html";
    fs.createReadStream(response).pipe(res);
}

function errorPage(res) {
    res.writeHead(200, { 'content-type': "text/HTML" })
    res.write("<h1 style='color:red'> OOPS....! </h1>")
    res.write("<hr>")
    res.write("<h2> The page your looking for is not available...!!!!</h2>")
}

http.createServer((req, res) => {
    if (req.method == "GET") {
        const query = httpParse(req.url).query;
        if (query != null) {
            let obj = httpParse(req.url, true).query;
            const mes = `Thanks Mr. ${obj.textname} for registering with us ! Your email ${obj.textemail} is registered and will be contacted  soon`;
            res.write(mes);
            res.end();
            return;

        }
    }
        else if (req.method == "POST") {
            req.on("data", function (inputs) {
                res.write(inputs);
                res.end();
                return;
            })
    
    }
    switch (req.url) {
        case "/favicon.ico":
            res.end()
            break;
        case "/Register":
            disPage(res, req.url);
            // console.log("This is the home page");
            break;
        case "/Home":
            disPage(res, req.url);
            break;
        default:
            errorPage(res);
            // res.end();
            break;
    }
}).listen(1444);