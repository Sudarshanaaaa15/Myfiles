class TollPlaza{
    constructor(vType, vAmount, vNum, vDate){
        this.vType = vType;
        this.vAmount = vAmount;
        this.vNum = vNum;
        this.vDate = vDate;
    }
}

class  repoToll{

    storeData = [];

    addData = (value) => this.storeData.push(value);

    getAllData = () => this.storeData;

}

const obj = new repoToll();

obj.addData(new TollPlaza("CAR", 90, "KA03M5748", new Date()));
// console.log(obj.storeData);