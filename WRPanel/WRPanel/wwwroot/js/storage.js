var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url":"/Storage/GetAll"
        },
        "columns": [
            { "data": "storageNum" },
            { "data": "plateNum" },
            { "data": "tire" },
            { "data": "tireNum" },
            { "data": "rim" },
            { "data": "rimNum" },
            { "data": "description" },
            { "data": "client.phone" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="w-75 btn-group" role="group">
                                
                                <a href="/Storage/Upsert?id=${data}" class="btn btn-primary mx-2">Edytuj</a>
                                <a onClick=Delete('/Storage/Delete/${data}') class="btn btn-danger mx-2">Usuń</a>
                            </div>
                        `
                },
            },
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Usunąć przechowalnię?',
        text: "Tej operacji nie można cofnąć",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Usuń'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message)
                    }
                }
            })
        }
    })
}