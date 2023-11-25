export function dateToISOString(dateConv: Date = new Date()): string {
    if (typeof dateConv === 'string') {
        return dateConv;
    } else {
        var dd = String(dateConv.getDate()).padStart(2, '0');
        var mm = String(dateConv.getMonth() + 1).padStart(2, '0'); //January is 0!
        var yyyy = dateConv.getFullYear().toString();

        return yyyy + '-' + mm + '-' + dd;
    }
}
