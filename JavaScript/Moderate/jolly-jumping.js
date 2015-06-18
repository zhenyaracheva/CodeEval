function jollyJumping(line) {
    var i,
        num,
        result = [],
        numbers = line.split(' ').map(Number),
        n = numbers[0];

    for (i = 1; i < n; i += 1) {
        num = Math.abs(numbers[i] - numbers[i + 1]);
        if (result.indexOf(num) === -1 && num > 0 && num < n) {
            result.push(num);
        }
    }

    if (result.length === n - 1) {
        console.log('Jolly')
    } else {
        console.log('Not jolly');
    }
}

console.log(jollyJumping('4 1 4 2 3'));
console.log(jollyJumping('3 7 7 8'));
console.log(jollyJumping('9 8 9 7 10 6 1'));