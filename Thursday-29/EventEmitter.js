//How to create events in js 
//Evenets are actions performed by hte user on the application or a window or a button or a class 
//Evenets have to be registered ,provide a event handler and the raise (trigger) the event at appropriate situation
//In Nodejs we have a module called events through which we can create events, raise events and provide handlers to the events

const { Console } = require("console");
const Emitter = require("events");

const eventClass = new Emitter();
eventClass.on("insert", () => {
    console.log("Insertion event triggered");
})

eventClass.on("delete", () => {
    console.log("Deletion event triggered");
})

// eventClass.on("click",(func) =>{
//     func();
// })


function onClick(){
    console.log("The button is clicked");
}

eventClass.emit("delete");

eventClass.emit("insert");
eventClass.emit("insert");
eventClass.emit("insert");

eventClass.emit("click", onClick())
