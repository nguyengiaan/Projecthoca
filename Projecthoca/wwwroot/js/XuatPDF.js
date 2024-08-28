import { jsPDF } from "jspdf";
function XuatPDF() {
    var doc = new jsPDF();
    var content = document.getElementById('reportContent').innerHTML;
    
    // Chuyển nội dung HTML sang PDF
    doc.fromHTML(content, 15, 15, {
        'width': 170,
    });

    // Lưu file PDF
    doc.save('bao-cao-chi-tiet.pdf');
}
export default XuatPDF;