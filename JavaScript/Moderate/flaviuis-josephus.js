function flaviuis(line) {
    var i,
        next,
        people,
        group,
        chosen,
        output = [];

    line = line.split(',').map(Number);
    people = line[0];
    chosen = line[1] - 1;
    group = new Array(people + 1).join('0').split('').map(Number);
    next = 0;

    function isFinished(group) {
        var i,
            len;

        for (i = 0, len = group.length; i < len; i += 1) {
            if (group[i] === 0) {
                return false;
            }
        }

        return true;
    }

    for (i = 0; i < people; i += 1) {

        if (isFinished(group)) {
            break;
        }

        if (group[i] === 0) {

            if (next === chosen) {
                group[i] = 1;
                output.push(i);
                next = 0;
            } else {
                next += 1;
            }
        }

        if (i === people - 1) {
            i = -1;
        }
    }

    console.log(output.join(' '));
}
flaviuis('10,3');
flaviuis('5,2');