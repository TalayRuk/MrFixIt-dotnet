var note = "text it works";

$(document).ready(function () {
 
    $('.claim-job').click(function () {
        //event.preventDefault();
        
        //once button click - hide button
        $('button').hide();
        
        
        
        
       //input name=jobId is the siblings of .claim-job b/c span & input is a child of <form> parent 
        var jobId = $(this).children().val();
        console.log(jobId);
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
                var resultMsg = 'You have claim this Job';
                
                $(".result-claim").html(resultMsg);
            }
        });
        //when moved reload out of all the functions, this let the function run first and only have to click once to reload
        location.reload(true);
    });

    $('.active-job').submit(function (event) {
        event.preventDefault();
        $(".btn-primary").hide();
        $(".status").hide();
        //$(".btn-warning").show();
        var jobId = $(this).children().val();
        console.log(jobId);
        console.log($(this).serialize());
        //debugger;

        $.ajax({
            type: 'GET',
            dataType: 'json',
            contentType: 'application/json',
            data: $(this).serialize(),
            url: '/Workers/Active',
            success: function (result) {
                var result1 = 'Job is in progress';
                $('.result-active').html(result1);
            }
             
        });
    });

    //$('.completed-job').click(function () {
    //    var jobId = $(this).children().val();
    //    console.log(jobId);
    //    console.log($(this).serialize()); 
    //    debugger;      
    //}
});
    