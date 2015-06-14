// var fs = require("fs");
// fs.readFileSync(process.argv[2]).toString().split('\n').forEach(function (line) {
//     if (line != "") {
//         console.log(!((line | 0) & 1) | 0);
//     }
// });

function evenNumber(number) {
    return (!((number | 0) & 1) | 0);
}