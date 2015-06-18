function reverseGroups(line) {
    var power,
        i,
        j,
        z,
        len,
        nextIndex,
        numbers,
        result = [];
    line = line.split(';');
    numbers = line[0].split(',').map(Number);
    power = line[1] | 0;

    for (i = 0, len = numbers.length; i < len; i += power) {
        nextIndex = i + power - 1;

        if (nextIndex < len) {
            for (j = nextIndex; j >= i; j -= 1) {
                result.push(numbers[j]);
            }
        } else {
            for (z = i; z < len; z += 1) {
                result.push(numbers[z]);
            }
        }
    }

    console.log(result.join(','));
}


reverseGroups('1,2,3,4,5;2');
reverseGroups('1,2,3,4,5;3');