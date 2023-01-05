let obje = {}
obje.id = "123";
obje.name = "sudarshana";
obje.address = "manvi";
obje.salary = "28000";

for(const key in obje)
console.log(obje[key]);
console.log(JSON.stringify(obje));

////////////////////////////////////////////////////////////using class keyword///////////////////////////////////////////////////////

class Employee{
    constructor(id,name,address,salary){
        this.Empid = id;
        this.Empname = name;
        this.Empaddress = address;
        this.Empsalary = salary;

    }
}

const Empobj = new Employee(3334,"SAGAR","RAICHUR",50000);

