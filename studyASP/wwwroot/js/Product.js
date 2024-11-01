

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    $('#tblData').DataTable({
        "ajax": {
            "url": '/Admin/Product/GetAll',
            "type": "GET",
            "dataSrc": function (json) {
                console.log('Dữ liệu JSON trả về:', json);
                return json.data; // Kiểm tra xem json.data có chứa dữ liệu và khớp với các cột không
            },
            "error": function (xhr, error, thrown) {
                console.log('Lỗi Ajax:', error);
                console.log('Trạng thái:', xhr.status);
                console.log('Phản hồi:', xhr.responseText);
            }
        },
        "columns": [
            { "data": "title", "width": "20%" },
            { "data": "author", "width": "20%" },
            { "data": "isbn", "width": "20%" },
            { "data": "price", "width": "20%" },
            { "data": "category.name", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                             <a href="/Admin/Product/Upsert?id=${data}" class="btn btn-primary mx-2"> 
                                <i class="bi bi-pencil-square"></i> 
                            </a>
                            <a onClick="Delete('/Admin/Product/Delete/${data}')"class="btn btn-danger mx-2"> 
                                <i class="bi bi-trash"></i>
                            </a>
                        </div>`;
                },
                "width": "20%"
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    console.log(data);
                    toastr.success(data.message);
                }
            })
        }
    });
}