// var fs = require("fs");
// fs.readFileSync(process.argv[2]).toString().split('\n').forEach(function (line) {
//     if (line != "") {
//         line = line.trim().split(' ');
//         console.log(line.reverse().join(' '));
//     }
// });

function reverseArray(input) {
    input = input.trim().split(' ');
    console.log(input.reverse().join(' '));
}

reverseArray('hello word');