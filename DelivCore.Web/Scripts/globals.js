var dateFormat = 'DD/MM/YYYY';
var timeFormat = 'HH:mm';
var dateTimeFormat = dateFormat + timeFormat;

window.formatLocalDate = function(date) {
    return moment(date).format(dateFormat);
}

window.formatLocalTime = function (time) {
    return moment(time).format(timeFormat);
}

window.formatLocalDateTime = function (dateTime) {
    return moment(dateTime).format(dateTimeFormat);
}