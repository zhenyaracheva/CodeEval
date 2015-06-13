var fs = require("fs");
fs.readFileSync(process.argv[2]).toString().split('\n').forEach(function (line) {
    if (line != "") {
        var matches,
            pattern,
            index = 0,
            replacedAsterisk = '[a-zA-Z0-9]*',
            inputParts = line.split(','),
            text = inputParts[0].trim(),
            patternAsString = inputParts[1];

        if (patternAsString.indexOf('*') !== -1) {
            while (index !== -1) {
                index = patternAsString.indexOf('*');
                if (index - 1 >= 0 && patternAsString[index - 1] === '\\') {

                    patternAsString = patternAsString.replace('*', '\*');
                    index = patternAsString.indexOf('*', index + 2);

                } else {

                    patternAsString = patternAsString.replace('*', replacedAsterisk);
                    index = patternAsString.indexOf('*', index + replacedAsterisk.length)
                }
            }
        }

        pattern = new RegExp(patternAsString);
        matches = text.match(pattern);

        matches !== null ? console.log('true') : console.log('false');
    }
});