const myMod = require("./Custommodule");
const aliasFun = myMod.sampleFun;
const mathFun = myMod.mathFun;
const Emp = myMod.employee;

aliasFun();

mathFun();

const emp = new Emp(3312, "Murgesha", "Udupi");
emp.display();