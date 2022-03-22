/** Init event open table export 
 * selector: element table
 * type: type export (csv, txt, json, xml, sql, xlsx, doc, png, pdf)
 */
function openTableExport(selector, type, fileName) {
    var options = { outputImages: true };
    $.extend(true, options, { type: type, fileName: fileName });
    $(selector).tableExport(options);
}
