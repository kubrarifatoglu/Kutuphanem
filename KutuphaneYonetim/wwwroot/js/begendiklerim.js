
function changeColor(data) {
    var tf = true;
    var b = "#kalpbgn" + data
    var element = $(b)
    console.log(element.css('color'))
    if (element.css('color') == "rgb(255, 0, 0)") {

        tf = false
    }

    $.ajax({
        url: '/API/BegenmeDurumDegis',
        data: {
            kitapid: data,
            begeni: tf
        },
        type: 'GET',
        dataType: 'json',
        success: function (resp) {
            // notifyFunc("success", "Yetkiler Başarıyla Kaydedildi!")
            location.reload();

        },
        error: function (err) {
            // notifyFunc("danger", "Bir Hata Oluştu!")
        }

    });

}





$(document).ready(function () {

    $('#begendiklerimtb').DataTable(

        {

            "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
            "pageLength": 10,
            "columnDefs": [
                { "searchable": true, "orderable": true, targets: "_all" },
                { "className": "display", targets: "_all" },


            ],

            "processing": true,
            "serverSide": false,
            "ajax":
            {
                "url": "/API/Begenilenler",
                "type": "GET",
                "dataType": "json",
                "dataSrc": function (json) {
                    console.log(json)
                    return json;
                },

            },


            "columns": [
                { "data": "kitapid" },
                { "data": "kitapadi" },
                { "data": "kitapozet" },
                { "data": "yazar" },
                //{"data" : "okuma"},
                {
                    "targets": -1,
                    "data": 'kitapid',
                    "render": function (data) {

                        return '<i style="color:red" class="fas fa-heart" id=kalpbgn' + data + ' onclick="changeColor(' + data + ')"></i>'

                    },

                    // "defaultContent": "<button id='button'>Okudum!</button>"
                },


            ],


        });


});