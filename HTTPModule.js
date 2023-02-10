const  http  = require("http");

// const http1 = ("http");

//http is a standard protocal for tranfering text among the internet application.
//http module is Nodejs module used to create web apps with server details in it. It exposes using a certain port number and handle request and provides responses to the user requests made using HTTP.

http.createServer(function(req,res){
    console.log(req.url);
    if(req.url == "/Employees")
    res.write("Employee page of the application");
    else if(req.url == "/customers")
    res.write("customers page of the application");
    else
    res.write("default page");
    res.end();
}).listen(1234);