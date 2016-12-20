var note = "text it works";

$(document).ready(function () {

    $('.claim-job').click(function () {
       //input #jobId2 is the siblings of .claim-job b/c span & input is a child of <li> parent 
        var jobId = $(this).siblings("#jobId2").val();
        console.log(jobId);
        debugger;
        //debugger; **when use debugger, it'll show jobId value in the source in chrome 
        $.ajax({               
            type: 'GET',
            //Says what type of data we expect back from the server
            dataType: 'json',
            //says what kind of data we are sending to the server
            contentType: 'application/json',
            url: '@Url.Action("Claim")',
            data: $(this).serialize(),
            success: function (result) {
                var resultMsg = 'You have claim this job! <br> Id: ' + result.id + '<br>Title: ' + result.title + '<br>Description: ' + result.description;
                $('.result-claim').html(resultMsg);
            }
        });
    });

    //$('.claim-job').submit(function () {
    //    event.preventDefault();
    //    $.ajax({
    //        url: '@Url.Action("Index")',
    //        type: 'POST',
    //        dataType: 'json',
    //        data: $(this).serialize(),
    //        success: function (result) {
    //            var resultMsg = 'You have claim this job! <br> Id: ' + result.id + '<br>Title: ' + result.title + '<br>Description: ' + result.description;
    //            $('#resultClaim').html(resultMsg);
    //        }
    //    });
    //});
});
    