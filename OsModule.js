const os = require("os");
console.log(os.version());
console.log(os.hostname());
console.log(os.arch());
const cpuinfo = os.cpus();
for (const info of cpuinfo) {
    console.log(JSON.stringify(info))
}
console.log(os.totalmem());
console.log(os.freemem());
console.log(os.userInfo());
console.log(os.homedir());
console.log(os.hostname());
console.log(os.loadavg());
console.log(os.networkInterfaces())
console.log(os.tmpdir())