const BaseClass =class{
    data1 = "SomeValue";
    data2 = 2000;

    constructor(){
        console.log("Base class is one that extends to another");
    }
    toString(){
        return `${this.data1} and ${this.data2}`;
    }
    display = () => console.log("Base class function");
}

class DerivedClass extends BaseClass{
    data3 = true;
    
    displayAnother = () => console.log(this);

    //reimplement the base method: method overriding....
    toString(){
        let data = super.toString();
        data += this.data3; 
        return data;
    }
}
data.display();

const data = new DerivedClass();
data.displayAnother(); 
console.log(data.toString());

