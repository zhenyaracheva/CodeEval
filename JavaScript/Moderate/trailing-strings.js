function trailingStrings(line) {
    var result = '0';
    line = line.split(',');
    if (line[0].length >= line[1].length) {
        if (line[0].substring(line[0].length - line[1].length) === line[1]) {
            result='1';
        }
    }

    console.log(result);
}

trailingStrings('Hello World,World');
trailingStrings('Hello CodeEval,CodeEval');
trailingStrings('San Francisco,San Jose');