const app = require("express")();
const parser = require("body-parser");
const server = require("mssql/msnodesqlv8");
app.use(parser.urlencoded({ "extended": true }));
app.use(parser.json());

const config = {
    server: '192.168.171.36',
    database: '3334',
    driver: 'msnodesqlv8',
    options: {
        trustedConnection: true,
        TrustServerCertificate: true
    }
    
}
const pool = new server.ConnectionPool(config)
app.get("/Form",(req,res) => res.sendFile(__dirname + "/Employeeregi.html"));
app.get("/Table",(req,res) => res.sendFile(__dirname + "/TableEmp.html"));

app.get('/', (req, res) => {
    pool.connect().then(() => {
        pool.request().query("Select * FROM tbEmployee", (err, results) => {
            if (err)
                console.error(err);
            else
                res.send(results.recordset);
        })
    }).catch((err) => {
        if (err) console.log(err);
    })
})


app.get('/:id', (req, res) => {
    const id = parseInt(req.params.id)
    pool.connect().then(() => {
        pool.request().query(`Select * FROM tbEmployee where empid = ${id}`, (err, results) => {
            if (err)
                console.error(err);
            else
                res.send(results.recordset);
        })
    }).catch((err) => {
        if (err) console.log(err);
    })
})

app.post('/Postform', (req, res) => {
    const body = req.body;
    console.log(body)
    const query = `Insert INTO tbEmployee values (${body.empid},'${body.empname}','${body.empaddress}',${body.empsalary})`;
    pool.connect().then(() => {
        pool.request().query(query, (err, results) => {
            if (err)
                console.error(err);
            else
                res.send("Data inserted succefully")
        })
    }).catch((err) => {
        console.log(err);
    })
})

app.post('/', (req, res) => {
    const body = req.body;
    const query = `Insert INTO tbEmployee values (${body.empid},'${body.empname}','${body.empaddress}',${body.empsalary})`;
    pool.connect().then(() => {
        pool.request().query(query, (err, results) => {
            if (err)
                console.error(err);
            else
                res.send("Data inserted succefully")
        })
    }).catch((err) => {
        console.log(err);
    })
})

app.delete('/:id', (req, res) => {
    const id = parseInt(req.params.id)
    pool.connect().then(() => {
        pool.request().query(`delete FROM tbEmployee where empid = ${id}`, (err, results) => {
            if (err)
                console.error(err);
            else
                res.send("Deleted succefully")
        })
    }).catch((err) => {
        if (err) console.log(err);
    })
})
app.listen(1444, () => console.log("server is available at 1444"));