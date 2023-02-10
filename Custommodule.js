module.exports.sampleFun = function () {
    console.log("The sample function is called")
}

module.exports.mathFun = function (num = 28) {
    console.log(`The multiplicatin table for ${num}`);
    for (let i = 1; i <= 10; i++) {
        console.log(`${num} * ${i} = ${num * i}`);
    }
    console.log("----------------------------------");
}

module.exports.employee = class {
    constructor(Id, Name, Address) {
        this.Id = Id;
        this.Name = Name;
        this.Address = Address;
    }


display(){
    console.log(`${this.Name} from ${this.Address}`)
}
}

