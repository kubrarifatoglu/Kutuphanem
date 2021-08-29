
function changeText(data) {
    var tf= false;
    var b = "#btn" + data
    var element = $(b)
    if (element.html() == "Okudum") {
        tf = true
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

function textBelirle() {

    $.ajax({
        url: '/API/OkumaDurum',
        type: 'GET',
        dataType: 'json',
        success: function (resp) {
            //console.log(resp[0].okuma)
            for (var i = 0; i < resp.length; i++) {
                var a = 1 + i
                var b = "#btn" + a
                var element = $(b) 
                if (resp[i].okuma == "true" || resp[i].okuma == true) {

                    element.html("Okuduklarımdan Çıkar")
                    element.css('background-color', 'green');
                }
                else {
                    element.html("Okudum")
                }
                
            }         
        },

    });
}
function colorBelirle() {

    $.ajax({
        url: '/API/BegenmeDurum',
        type: 'GET',
        dataType: 'json',
        success: function (resp) {
           // console.log(resp[0].begeni)
            for (var i = 0; i < resp.length; i++) {
                var a = 1 + i
                var b = "#kalp" +a
                var element = $(b)
                if (resp[i].begeni == "true" || resp[i].begeni == true) {

                    element.css('color', 'red');
                }
                else {
                    element.css('color', 'black');
                }

            }
        },

    });
}
function changeColor(data) {
    var tf = false;
    var b = "#kalp" + data
    var element = $(b)
    console.log(element.css('color'))
    if (element.css('color') == "rgb(0, 0, 0)") {
        
        tf = true
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
    
    $('#kitaptb').DataTable(
       
        {

            "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
            "pageLength":10,
            "columnDefs": [
                { "searchable": true, "orderable": true, targets: "_all" },
                { "className": "display", targets: "_all" },
               
               
            ],
            
            "processing": true,
            "serverSide": false,
            "ajax":
            {
                "url": "/API/Kitaplar",
                "type": "GET",
                "dataType": "json",
                "dataSrc": function (json) {
                    console.log(json)
                    return json;
                },
                
            },

            
            "columns": [
                { "data":"kitapid"},
                { "data": "kitapadi" },
                { "data": "kitapozet" },
                { "data": "yazar" },
               //{"data" : "okuma"},
                {
                    "targets": -1,
                    "data": 'kitapid',
                    "render": function (data) {
                        
                        return '<button class="btn btn-info" id=btn' + data + '  onclick="changeText(' + data + ')">Okudum</button>'

                    },
                    
                   // "defaultContent": "<button id='button'>Okudum!</button>"
                },
                {
                    "targets": -1,
                    "data": 'kitapid',
                    "render": function (data) {

                        return '<i class="fas fa-heart" id=kalp' + data + ' onclick="changeColor(' + data + ')"></i>'

                    },

                    // "defaultContent": "<button id='button'>Okudum!</button>"
                },
               
                
            ],
    
            
        });
   
   
});

$(document).ready(function () {

    $('#kitaptb')
        .on('order.dt', function () { textBelirle(); colorBelirle();})
        .on('search.dt', function () { })
        .on('page.dt', function () { textBelirle(); colorBelirle(); })
        .dataTable();
});















jQuery(function ($) {
    $('#swapHeart').on('click', function () {
        var $el = $(this),
            textNode = this.lastChild;
        $el.find('span').toggleClass('glyphicon-heart glyphicon-heart-empty');
        $el.toggleClass('swap');
    });
});