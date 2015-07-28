String.prototype.formatarData = function (formato) {

    var str = this;
    //0123-56-89T12:45:78
    //2014-10-09T14:49:40
    var y = str.substr(0, 4);
    var m = str.substr(5, 2);
    var d = str.substr(8, 2);
    var h = str.substr(11, 2);
    var mi = str.substr(14, 2);
    var s = str.substr(17, 2);

    switch (formato) {
        case "dd/mm/yyyy":
            str = d + '/' + m + '/' + y;
            break;

        case "dd/mm/yyyy hh:mm:ss":
            str = d + '/' + m + '/' + y + ' ' + h + ':' + mi + ':' + s;
            break;

        case 'dd/mm/yyyy hh:mm':
            str = d + '/' + m + '/' + y + ' ' + h + ':' + mi;
            break;

        case "dd/mm":
            str = d + '/' + m;
            break;

        case "dd/mm hh:mm":
            str = d + '/' + m + ' ' + h + ':' + mi;
            break;
    }

    return str;
};