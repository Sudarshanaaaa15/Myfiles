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
    addNewVehicle(vehicle){
        if(this.data.has(vehicle.vehicleType)){
            console.log(this.data)
            let values = this.data.get(vehicle.vehicleType);
            values.push(vehicle);
            this.data.set(vehicle.vehicleType, values);
        }else{
            this.data.set(vehicle.vehicleType, [vehicle]);
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
        // let  count = this.data.get(type);
        // count += 1;
        this.data.set(type, this.data.get(type) + 1)
        //this.data.set(type, count);
    }else{
        this.data.set(type, 1);
    }
}
