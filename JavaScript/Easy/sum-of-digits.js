// var fs = require("fs");
// fs.readFileSync(process.argv[2]).toString().split('\n').forEach(function (line) {
//     if (line != "") {
//
//         line = line.split('').map(Number);
//         var sum = line.reduce(function (a, b) {
//             return a + b
//         }, 0);
//
//         console.log(sum);
//     }
// });

function sumOfDigits(input) {
    input = input.split('').map(Number);
    return input.reduce(function (a, b) {
        return a + b
    }, 0);
}