function stringRotation(line) {
    var temp,
        first,
        second,
        index,
        result;

    line = line.split(',');
    first = line[0];
    second = line[1];
    result = first === second ? 'True' : 'False';
    index = second.indexOf(first[0]);

    if (index >= 0 && result === 'False') {

        while (index >= 0) {
            temp = second.substr(index) + second.substr(0, index);

            if (first === temp) {
                result = 'True';
                break;
            }
            index = second.indexOf(first[0], index + 1);
        }
    }

    console.log(result);
}

console.log(stringRotation('Hello,lloHe'));
console.log(stringRotation('Basefont,tBasefon'));
console.log(stringRotation('Test,Test'));
console.log(stringRotation('Test,estt'));
console.log(stringRotation('test,estt'));