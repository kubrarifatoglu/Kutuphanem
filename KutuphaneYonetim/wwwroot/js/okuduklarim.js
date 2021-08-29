
function changeText(data) {
    var tf = true;
    var b = "#btnokdm" + data
    var element = $(b)
    if (element.html() == "Okuduklarımdan Çıkar") {
        tf = false
    }

    $.ajax({
        url: '/API/OkumaDurumDegis',
        data: {
            kitapid: data,
            okuma: tf
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

    $('#okuduklarimtb').DataTable(

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
                "url": "/API/Okunanlar",
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
                        
                        return '<button class="btn btn-info" id=btnokdm' + data + '  onclick="changeText(' + data + ')">Okuduklarımdan Çıkar</button>'

                    },

                    // "defaultContent": "<button id='button'>Okudum!</button>"
                },
                

            ],


        });


});