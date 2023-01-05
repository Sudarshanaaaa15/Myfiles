class Expense {
    static no = 0;
    constructor(detail, amount, date) {
        this.id = ++Expense.no;
        this.detail = detail;
        this.amount = amount;
        this.date = date;

    }
}
class ExpenseManager {
    expenses = [];
    addNewExpense = (expense) => this.expenses.push(expense);

    // findExpensesByDetail = (detail) => this.expenses.filter((e) => e.detail == detail);
    findExpenses = (detail) => this.expenses.filter((e) => e.detail.includes(detail));
    findExpensesByDate = (date) => this.expenses.filter((e) => 
    e.date.toDateString() == date.toDateString());
    getAllExpenses = () => this.expenses;
    getExpenseById = (id) => this.expenses.find((e) => e.id == id);
    modifyExpense = (id, expense) => {
        let foundIndex = this.expenses.findIndex(ex => ex.id == id);
        if (foundIndex == -1) throw "Expense not found to update";
        this.expenses.splice(foundIndex, 1, expense);
    }
}
// const obj=new ExpenseManager();
// obj.addNewExpense(new Expense("Food at cafe",100,new Date(2022,11,13)))
// obj.addNewExpense(new Expense("Lunch at cafe",250,new Date(2022,12,13)))
// obj.addNewExpense(new Expense("Coffee at cafe",500,new Date(2022,10,13)))
// obj.addNewExpense(new Expense("Dinner at home",750,new Date(2022,06,13)))

// let data=obj.getAllExpenses();
// for(const ex of data) console.log(ex.id);
// console.log("searching on Detail.....");
// data = obj.findExpenses("hotel");
// for(const ex of data) console.log(ex.id);
// console.log("searching on data........");
// data=obj.findExpensesByData(new Date(2022,11,13));
// for(const ex of data) console.log(ex.id);
// const ex = obj.getExpenseById(2);
// ex.datail="Modified with new Info";
// obj.modifyExpense(3,ex);
// data = obj.getAllExpenses();
// for(const ex of data)
//  console.log(ex.detail);
