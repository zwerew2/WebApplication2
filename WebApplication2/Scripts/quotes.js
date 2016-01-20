
	
$(document).ready(function ()
{
    var log = $('#messages');


    $('#columns').columns({
        data: [],
        search: false,
        liveSearch: false
    });


    function runajax()
    {
        var inp0 = $("#input_text").val();
        var inp1 = $("#input_datetimepicker1").val();
        var inp2 = $("#input_datetimepicker2").val();
        var inp3 = $('#select_service').val();
        
        if (inp0.trim().length == 0)
        {
            log.text('Пустое поле!');

            return;
        }

        $('#columns').columns('destroy');

        $.ajax({
            type: "POST",
            data: {
                Query: inp0,
                StartDate: inp1,
                EndDate: inp2,
                Service: inp3
            },
            url: "/Api/Quotes",
            dataType: "json",
            success: function (response)
            {
                var quotes = [];

                if (response != null && response.Quotes)
                {
                    response.Quotes.forEach(function (quote)
                    {
                        quote.Date = moment(quote.Date).format('MMM D, YYYY');
                        
                        quotes.push(quote);
                    });
                }

                log.text('');
                
                $('#columns').columns({
                    data: quotes,
                    search: false,
                    liveSearch: false
                });

            },
            error: function (e)
            {
                log.text('Сервер не доступен!');

                $('#columns').columns({
                    data: [],
                    search: false,
                    liveSearch: false
                });
            }
        })
    }



    $("#submit_button").click(runajax);



    var datePickerOptions = { pickTime: false, language: 'ru' };

    $('#datetimepicker1').datetimepicker(datePickerOptions);
    $('#datetimepicker2').datetimepicker(datePickerOptions);

    $("#datetimepicker1").on("dp.change", function (e) {
        $("#datetimepicker2").data("DateTimePicker").setMinDate(e.date);
    });
    $("#datetimepicker2").on("dp.change", function (e) {
        $("#datetimepicker1").data("DateTimePicker").setMaxDate(e.date);
    });

});