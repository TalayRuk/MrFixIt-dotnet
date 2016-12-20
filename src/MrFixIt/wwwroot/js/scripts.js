var note = "text it works";

$(document).ready(function () {
 
    $('.claim-job').submit(function (event) {
        event.preventDefault();
        
       //input #jobId2 is the siblings of .claim-job b/c span & input is a child of <li> parent 
        var jobId = $(this).children().val();
        //var worker = $(this).siblings("#workerName").val();
        console.log(jobId);
        //console.log(worker);
        console.log($(this).serialize());
        
        //debugger;      
        //debugger; **when use debugger, it'll show jobId value in the source in chrome 
    
        $.ajax({
            type: 'GET',
            //Says what type of data we expect back from the server
            dataType: 'json',
            
            //says what kind of data we are sending to the server
            contentType: 'application/json',
            url: '/Jobs/Claim',
            data: $(this).serialize(),
            success: function (result) {
                var resultMsg = jobId;
                console.log(resultMsg);
                debugger;
                $(".result-claim").html(resultMsg);
            }
        });
    });
});
    