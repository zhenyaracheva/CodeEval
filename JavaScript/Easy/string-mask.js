// var fs = require("fs");
// fs.readFileSync(process.argv[2]).toString().split('\n').forEach(function (line) {
//     if (line != "") {
//         var i,
//             len,
//             result = '',
//             input = line.split(' ');
//
//         for (i = 0, len = input[0].length; i < len; i += 1) {
//             if (input[1][i] === '1') {
//                 result += input[0][i].toUpperCase();
//             } else {
//                 result += input[0][i];
//             }
//         }
//
//         console.log(result);
//     }
// });

function stringMask(input) {
    var i,
        len,
        result = '',
        input = input.split(' ');

    for (i = 0, len = input[0].length; i < len; i += 1) {
        if (input[1][i] === '1') {
            result += input[0][i].toUpperCase();
        } else {
            result += input[0][i];
        }
    }

    console.log(result);
}

stringMask('hello 11001');
stringMask('world 10000');
stringMask('cba 111');
