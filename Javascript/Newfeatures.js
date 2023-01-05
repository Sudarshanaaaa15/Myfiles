var l = 159;
let v = 234;
console.log(window.v);
console.log(window.l);

for(let v = 0; v < 6; v++){

    
    console.log(v);
}
console.log(v);

function variable(){
    let m = 789;
    console.log(m);
}


//////////////////////////////////////////////////////////Default parameters in js/////////////////////////////////////////////////////////

function samFun(mes = "Hi All"){
    console.log(mes);
}
samFun();
samFun("Good morning");

function sampleDiv(height="450px", width="300px", display="inline-block", border="2px solid black"){
    const div = document.createElement("div");
    div.style.height = height;
    div.style.width = width;
    div.style.display = display;
    div.style.border = border;
    const area = document.querySelector("#divarea");
    area.appendChild(div);
    return div;

}
sampleDiv(undefined,undefined,undefined,"2px solid black");

function sum(...args){
//     let res = 0;
//     for(const val of args)
//         res +=val;
//     return res;
        return args
            .filter((e) => typeof(e) === "number").reduce((prev,next) => prev+next);
 }
console.log(sum(54,546));
console.log(sum(54,546,477));
console.log(sum(54,546,6546,12313));
console.log(sum("raju",true,1258));

/////////////////////////////////////////////////////////////spread operator/////////////////////////////////////////////////

const s = [3,5,7];
const s1 =[1,...s];
console.log(s1);

const st = ["mg","mp","up"];
const nst = ["ka","tn","ap"];
st.push(...nst);
console.log(st);

//////////////////////////////////////////////////////////////static methods in a class///////////////////////////////////////
class mathExample{
    static mulFun = (v1,v2) => v1*v2;
    //call static function
    callStaticFun(){
        this.constructor.mulFun(125,258);
    }
}
console.log(mathExample.mulFun(45,48));

const result = new mathExample();
result.callStaticFun()

//////////////////////////////////////////////////////////

