class Employee{
    constructor(id,name,address,salary){
        this.Empid = id;
        this.Empname = name;
        this.Empaddress = address;
        this.Empsalary = salary;

    }
}

////////////////////////////////////////////////////Class with Functions/////////////////////////////////////////////////////////////////////////

class EmployeeRepo{
    arr = [];//field of the class
addEmpolyee = (Employee) => this.arr.push(Employee);
getAllEmployees = () => {
    return this.arr;
}   
//deleteEmployee = (id) => {
 //   let Emp = this.arr.find(e)
//}
getEmployee (id){
    for(const Employee of this.arr){
        if(Employee.Empid == id)
        return Employee;
    }
    throw `Employee by ID ${id} not found`;
}

updateEmployee(Emp){
    for(const EmpRec of this.arr){
        if(Emp.EmpId == EmpRec.EmpId){
            EmpRec.EmpName = Emp.EmpName;
            EmpRec.EmpAddress =Emp.EmpAddress; 
            EmpRec.EmpSalary = Emp.EmpSalary; 
           
           return; 
        }
    }
    throw `Employee update not found`
}

}



/////////////////////////////Testing part///////////////////////////////
let instance = new EmployeeRepo();
instance.addEmpolyee(new Employee (122, " ramesh", "raipur",40000));
instance.addEmpolyee(new Employee (123, " ranjesh", "jaipur",40800));
instance.addEmpolyee(new Employee (124, " rajesh", "kolkata",40500));
instance.addEmpolyee(new Employee (125, " jaggesh", "mayapur",40200));

const arr = instance.getAllEmployees()
for(const Employee of arr)console.log(Employee);
