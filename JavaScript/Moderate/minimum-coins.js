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