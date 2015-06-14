// var fs = require("fs");
// fs.readFileSync(process.argv[2]).toString().split('\n').forEach(function (line) {
//     if (line != "") {
//         var i,
//             j,
//             lenFirstCircle,
//             lenSecondCircle,
//             days,
//             sum,
//             max = -10000,
//             numbers;
//
//         input = line.split(';');
//         days = input[0] | 0;
//         numbers = input[1].split(' ').map(Number);
//
//         for (i = 0, lenFirstCircle = numbers.length - days; i <= lenFirstCircle; i += 1) {
//             sum = 0;
//             for (j = i, lenSecondCircle = i + days; j < lenSecondCircle; j += 1) {
//                 sum += numbers[j];
//             }
//             if (sum > max) {
//                 max = sum;
//             }
//         }
//
//         max < 0 ? console.log(0) : console.log(max);
//     }
// });

function maxRangeSum(input) {
    var i,
        j,
        lenFirstCircle,
        lenSecondCircle,
        days,
        sum,
        max = -10000,
        numbers;

    input = input.split(';');
    days = input[0] | 0;
    numbers = input[1].split(' ').map(Number);

    for (i = 0, lenFirstCircle = numbers.length - days; i <= lenFirstCircle; i += 1) {
        sum = 0;
        for (j = i, lenSecondCircle = i + days; j < lenSecondCircle; j += 1) {
            sum += numbers[j];
        }
        if (sum > max) {
            max = sum;
        }
    }

    max < 0 ? console.log(0) : console.log(max);
}

maxRangeSum('5;7 -3 -10 4 2 8 -2 4 -5 -2');
maxRangeSum('6;-4 3 -10 5 3 -7 -3 7 -6 3');
maxRangeSum('3;-7 0 -45 34 -24 7');