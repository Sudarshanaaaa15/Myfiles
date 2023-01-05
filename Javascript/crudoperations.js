const selfBooks = [];

//create operation
function sumItem(thing) {
    selfBooks.push(thing); 
}

 //Implement the getAll()

 const getAll = () => selfBooks;

 const remItem = (index)=> selfBooks.splice(index, item);

 const editItem = (index)=> selfBooks.splice(index, item);