const data = new Map();

class Vehicle{
    constructor(vehicleNo, vehicleType, amount){
        this.vehicleNo = vehicleNo;
        this.vehicleType = vehicleType;
        this.amount = amount;
    }
}

class VehicleRepo{
    data = new Map();
    addNewVehicle(Vehicle){
        if(this.data.has(Vehicle.vehicleType)){
            let values = this.data.get(Vehicle.vehicleType);
            values.push(Vehicle);
            // console.log(values)
            this.data.set(Vehicle.vehicleType, values);
        }else{
            this.data.set(Vehicle.vehicleType, [Vehicle]);
        }
    }

    getReport(type){
        const count = this.data.get(type).length + 1;
        const amount = parseInt(localStorage.getItem(type));
        return count * amount;
    }
    getAllDetails(){
        return this.data;
    }
}
function addVehicle(type){
    if(this.data.has(type)){
        this.data.set(type, this.data.get(type) + 1)
        
    }else{
        this.data.set(type, 1);
    }
}

