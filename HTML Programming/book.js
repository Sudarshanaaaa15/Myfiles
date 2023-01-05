function addBook(){
    let x=document.getElementById("textBook");

    let ul=document.getElementById("ulBook");
    ul.innerHTML +="<li>"+x.value;
}