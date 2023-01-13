function addBook(){
    let x=document.getElementById("textBook");

    let ul=document.getElementById("olBook");
    ul.innerHTML +="<li>"+x.value;
}