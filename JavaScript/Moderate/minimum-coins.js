// var fs = require("fs");
// fs.readFileSync(process.argv[2]).toString().split('\n').forEach(function (line) {
//     if (line != "") {
//         var coins = 0,
//             currentCoin = 5;
//         line = line | 0;
//
//         while (line > 0) {
//             coins += (line / currentCoin) | 0;
//             line %= currentCoin;
//             currentCoin -= 2;
//         }
//
//         console.log(coins);
//     }
// });

function minCoins(line) {
    var coins = 0,
        currentCoin = 5;
    line = line | 0;

    while (line > 0) {
        coins += (line / currentCoin) | 0;
        line %= currentCoin;
        currentCoin -= 2;
    }

    return coins;
}