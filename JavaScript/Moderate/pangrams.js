function pangrams(line) {
    var i,
        len,
        alphabet = 'abcdefghijklmnopqrstuvwxyz';

    line = line.toLowerCase();
    for (i = 0, len = line.length; i < len; i += 1) {

        if (alphabet.indexOf(line[i]) !== -1) {
            alphabet = alphabet.replace(line[i], '');
        }
    }

    if (alphabet.length === 0) {
        console.log('NULl');
    } else {
        console.log(alphabet);
    }
}

pangrams('A quick brown fox jumps over the lazy dog');
pangrams('A slow yellow fox crawls under the proactive');