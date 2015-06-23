function bubbleSort(line) {
    var numbers,
        i,
        j,
        tempIndex,
        lastIndex,
        swap,
        notChanged;

    line = line.split(' | ');
    numbers = line[0].split(' ').map(Number);
    line = line[1] | 0;
    tempIndex = numbers.length - 1;
    lastIndex = numbers.length - 1;

    for (i = 0; i < line; i += 1) {

        notChanged = 1;
        for (j = 0; j < lastIndex; j += 1) {

            if (numbers[j] > numbers[j + 1]) {
                swap = numbers[j];
                numbers[j] = numbers[j + 1];
                numbers[j + 1] = swap;
                notChanged = 0;
                tempIndex = j;
            }
        }

        if (notChanged) {
            break;
        }

        lastIndex = tempIndex;
    }

    console.log(numbers.join(' '));
}

bubbleSort('36 47 78 28 20 79 87 16 8 45 72 69 81 66 60 8 3 86 90 90 | 1');
bubbleSort('40 69 52 42 24 16 66 | 2');
bubbleSort('54 46 0 34 15 48 47 53 25 18 50 5 21 76 62 48 74 1 43 74 78 29 | 6');
bubbleSort('48 51 5 61 18 | 2');
bubbleSort('59 68 55 31 73 4 1 25 26 19 60 0 | 2');