var settingModal = {
    show: true,
    keyboard: false,
    backdrop: 'static'
};

var AlbumFunctions = (function () {
   
    function setAlbumFilter() {
        var valorCriteria = $('#formAlbumFilter #id').val();
        $.ajax({
            type: "POST",
            url: "/album/listadoPhotosAsync",
            data: 'criteria=' + valorCriteria ,
            dataType: "html",
            success: function (response) {
                $('#resultContentAlbumDetails').html(response);
                
            },
            failure: function (response) {
                
                $('#resultContentAlbumDetails').html("Failure "+ response.responseText);
            },
            error: function (response) {
                
                $('#resultContentAlbumDetails').html("Error "+ response.responseText);
            }
        });
      
    }

    function showComments(commentId) {
      
        $.ajax({
            type: "POST",
            url: "/album/ListadoCommmentAsync",
            data: 'criteria=' + commentId,
            dataType: "html",
            success: function (response) {
                $('#' + commentId).html(response);

            },
            failure: function (response) {

                $('#' + commentId).html("Failure " + response.responseText);
            },
            error: function (response) {

                $('#' + commentId).html("Error " + response.responseText);
            }
        });

    }
  
    function getAlbumList() {
        $('#id').select2({
            placeholder: "Seleccione un..",
            ajax: {
                url: '../Album/GetAlbumListaAsync',
                type: 'GET',
                cache: false,
                processResults: function (data) {
                    if (data.success == "ok") {
                        return {
                            results: $.map(data.listaObj, function (obj, index) {
                                return { id: obj.id, text: obj.title };
                            })
                        }
                    }
                    else {
                        Swal.fire('Error: ' + data.message);
                    }
                }, error: function () {
                    Swal.fire('Error: ' + data.message);
                }
            }
        });
    }
   

    return {
        setAlbumFilter: setAlbumFilter,
        getAlbumList: getAlbumList,
        showComments: showComments
        
    };
})();

$(document).ready(function () {
    AlbumFunctions.setAlbumFilter(false, 1);
    AlbumFunctions.getAlbumList();
});





