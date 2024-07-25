// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let btn = document.querySelector("#btn");
let sidebar = document.querySelector(".sidebar");
let searchbtn = document.querySelector(".bx-search");

btn.onclick = function () {
    sidebar.classList.toggle("active");
}

searchbtn.onclick = function () {
    sidebar.classList.toggle('active');
}


//pdf
var doc = new jsPDF();

//function saveDiv(divId, title) {
//    var pdf = new jsPDF();
//    var tableRows = document.getElementById("pdf").getElementsByTagName("tr");
//    for (var i = 0; i < tableRows.length; i++)
//    {
//        var rowElements = tableRows[i].getElementsByTagName("td");
//        for (var j = 0; j < rowElements.length; j++) {
//            pdf.cell(10, 10, rowElements[j].innerHTML, i, j);
//        }
//    }
//    pdf.save("Report.pdf");
//}  

function saveDiv(divId, title) {
    doc.fromHTML(`<html><head><title>${title}</title></head><body>` + document.getElementById(divId).innerHTML + `</body></html>`);
    doc.save('Report.pdf');
}



function printDiv(divId,
    title) {

    let mywindow = window.open('', 'PRINT', 'height=650,width=900,top=100,left=150');

    mywindow.document.write(`<html><head><title>${title}</title>`);
    mywindow.document.write('<style>table, th, td { border: 1px solid black; }</style>');
    mywindow.document.write('<style>table, th, td { padding: 13px 20px; }</style>');
    mywindow.document.write('</head><body >');
    mywindow.document.write(document.getElementById(divId).innerHTML);
    mywindow.document.write('</body></html>');

    mywindow.document.close(); // necessary for IE >= 10
    mywindow.focus(); // necessary for IE >= 10*/

    mywindow.print();
    mywindow.close();

    return true;
}



