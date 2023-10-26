$(document).ready(function () {
    $('#myTable').DataTable({
        dom: 'Bfrtip',
        pageLength: 25,
        buttons: [
            {
                extend: 'copyHtml5',
                text: 'Kopiuj',
                exportOptions: {
                    columns: [0, 1, 2]
                }
            },
            {
                extend: 'excelHtml5',
                text: 'Excel',
                exportOptions: {
                    columns: [0, 1, 2]
                }
            },
            {
                extend: 'csvHtml5',
                text: 'CSV',
                exportOptions: {
                    columns: [0, 1, 2]
                }
            },
            {
                extend: 'pdfHtml5',
                text: 'PDF',
                exportOptions: {
                    columns: [0, 1, 2]
                }
            }
        ]
    });
});
