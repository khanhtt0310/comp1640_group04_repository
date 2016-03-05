$(function () {
    $('#ModuleClass').change(function () {
       
        var typeSelected = $('#ModuleClass :selected').val();
        
        typeSelected = typeSelected == "" ? 0 : typeSelected;
        //When select 'optionLabel' we need to reset it to default as well. So not need 
        //travel back to server.
        alert(typeSelected);
        if (typeSelected == "") {
           
            $('#ModuleClass').empty();
            $('#ModuleClass').append('<option value="">--Select a language--</option>');
            
            return;
        }
        $.ajax({
            type: 'GET',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            url: "GetMoudleClassMarks/?selectedValue=" + typeSelected,
            data: typeSelected,
            success: function (data) {
                alert(data);
            }
        });        //This is where the dropdownlist cascading main function
    });
});

function navigate() {
    var moduleClassId = $('#ModuleClass').val();
    alert(moduleClassId);
    location.href = "ModuleClassMark/Create/?selectedValue=" + moduleClassId;    //This is where the dropdownlist cascading main
}