$(document).ready(function () {

    var $dialogContent = $("#event_edit_container");
    $dialogContent.visible = false;
    $dialogContent.dialog("destroy");
    $dialogContent.hide();
    var query = location.search;
    var Accid = query.substring(query.indexOf("AccountID=") + 10, query.length);

    var $calendar = $('#calendar');
    var id = 10;

    $calendar.fullCalendar({
        editable: true,
        droppable: true,

        timeslotsPerHour: 4,
        defaultView: 'month',
        allowCalEventOverlap: true,
        overlapEventsSeparate: true,
        firstDayOfWeek: 1,
        businessHours: { start: 8, end: 18 },
        daysToShow: 7,
        theme: true,
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'month,agendaWeek,agendaDay'
        },
        events: "/Calendar/DisplayMyAssessment?AccountID=" + Accid,
        eventRender: function (calEvent, element) {
            var Temp = calEvent.AssessmentType;
            var color = calEvent.color;
            element.find('a').css('background-color', color);
           // $("#courseNot").append("<b>" + calEvent.CourseName + "</b><hr width=5% color=" + calEvent.color + " height=50px></hr>");
            switch (Temp) {

                case "HomeWork":
                    element.find('span.fc-event-time').text("H");
                    break;

                case "Exam":
                    element.find('span.fc-event-time').text("E");
                    break;

                case "Reading":
                    element.find('span.fc-event-time').text("R");
                    break;

                case "Quiz":
                    element.find('span.fc-event-time').text("Q");
                    break;

                case "Presentation":
                    element.find('span.fc-event-time').text("P");
                    break;

            }

            //            $(".fc-event").css("background-color", "red");

            //            element.find('div').backColor = color1
            // element.find('div.fc-event').backColor = color1;
            //element.find('div.fc-event').text = color;
            // classN.backgroundColor = color;

            //        element.tooltip("show");
            var d = $('#calendar').fullCalendar("formatDate", calEvent.start, "MM/dd/yyyy");
            element.qtip({ content: { text: "<b>Title: </b>" + calEvent.title + "<br><b> Desc: </b>" + calEvent.description + "<br><b> Type: </b>" + calEvent.AssessmentType + "<br><b> Course: </b>" + calEvent.CourseName + "<br><b> Points: </b>" + calEvent.Points + "<br><b> DueDate: </b>" + d.toString()} }).show;

            //                        content: event.description,
            //                        position: { corner: { tooltip: 'bottomLeft', target: 'topRight'} },

            //                        style: {
            //                                width: 200,
            //                                padding: 5,
            //                                background: '#000000',
            //                                color: 'white',
            //                                textAlign: 'center',
            //                            border: {
            //                                width: 7,
            //                                radius: 5,
            //                                color: '#000000'
            //                            },

            //                                                    tip: 'bottomLeft',
            //                                                    name: 'dark' // Inherit the rest of the attributes from the preset dark style

            //                        }
            //                    });

            /* if (calEvent.end.getTime() < new Date().getTime()) {
            $event.css("backgroundColor", "#aaa");
            $event.find(".wc-time").css({
            "backgroundColor" : "#999",
            "border" : "1px solid #888"
            });
            } */
        },
        eventColor: '#378006',
        //        dayClick: function (date, allDay, jsEvent, view) {
        //            var $dialogContent = $("#event_edit_container");

        //            y = date.getFullYear();
        //            m = date.getMonth();
        //            d = date.getDate();

        //            h1 = date.getHours();
        //            m1 = date.getMinutes();

        //            h2 = h1 + 1;
        //            m2 = m1;

        //            calEvent = { title: '', editable: true, type: 1, PosPonits: '0', start: new Date(y, m, d, h1, m1), end: new Date(y, m, d, h1, m1), allDay: false };
        //            $calendar.fullCalendar("renderEvent", calEvent, true);

        //            resetForm($dialogContent);

        //            var startField = $dialogContent.find("select[name='start']").val(calEvent.start);
        //            var endField = $dialogContent.find("select[name='end']").val(calEvent.end);
        //            var titleField = $dialogContent.find("input[name='title']").val(calEvent.title);
        //            var bodyField = $dialogContent.find("textarea[name='body']");


        //            $dialogContent.dialog({
        //                modal: true,
        //                title: "New Calendar Event",
        //                close: function () {
        //                    $dialogContent.dialog("destroy");
        //                    $dialogContent.hide();
        //                },
        //                buttons: {
        //                    save: function () {
        //                        calEvent.id = id;
        //                        id++;
        //                        //calEvent.start = new Date(startField.val());
        //                        calEvent.end = new Date(endField.val());
        //                        calEvent.title = titleField.val();
        //                        calEvent.body = bodyField.val();
        //                        var dt = $('#calendar').fullCalendar("formatDate", calEvent.start, "MM-dd-yyyy hh:mm:ss");
        //                        var edt = $('#calendar').fullCalendar("formatDate", calEvent.end, "MM-dd-yyyy hh:mm:ss");
        //                        jQuery.post('/Calendar/AddMyAssessment',
        //                            { title: calEvent.title, desc: calEvent.body, start: dt, end: edt },
        //                             function (data) {
        //                                 alert("New Event Added");
        //                             }

        //                        );
        //                        $calendar.fullCalendar("updateEvent", calEvent);
        //                        $dialogContent.dialog("close");
        //                    },
        //                    cancel: function () {
        //                        $('#calendar').fullCalendar('removeEvents', function (calEvent2) { return calEvent2.id == calEvent.id });
        //                        $dialogContent.dialog("close");
        //                    }
        //                }
        //            }).show();

        //            $dialogContent.find(".date_holder").text($calendar.fullCalendar('formatDate', date, "dd MMMM yyyy"));
        //            setupStartAndEndTimeFields(startField, endField, calEvent, $calendar.fullCalendar("getTimeslotTimes", calEvent.start));

        //        },


        eventDrop: function (calEvent, $event) {
        },
        eventResize: function (calEvent, $event) {
        },
        //        eventClick: function (calEvent, $event) {
        //            var $dialogContent = $("#event_edit_container");


        //            if (calEvent.readOnly) {
        //                return;
        //            }

        //            var $dialogContent = $("#event_edit_container");
        //            resetForm($dialogContent);

        //            $dialogContent.find("#AssessmentType option:selected").text(calEvent.AssessmentType);
        //            $dialogContent.find("textarea[id='PosPonits']").text(calEvent.Points);
        //            //            var Point = $dialogContent.find("textarea[id='PosPonits']").val(PosPonits.val());
        //            var id = calEvent.id;
        //            var d = $('#calendar').fullCalendar("formatDate", calEvent.start, "MM/dd/yyyy");
        //            $dialogContent.find("input[id='Duedate']").val(d);

        //            $dialogContent.find("textarea[id='AssTitle']").text(calEvent.title);
        //            //            var duedate = $dialogContent.find("input[id='Duedate']").val(Due.val());
        //            $dialogContent.find("textarea[id='AssDescription']").text(calEvent.desc);

        //            $dialogContent.dialog({
        //                modal: true,
        //                title: "Edit - " + calEvent.title,
        //                close: function () {
        //                    $dialogContent.dialog("destroy");
        //                    $dialogContent.hide();
        //                },
        //                buttons: {
        //                    save: function () {

        //                        calEvent.title = $dialogContent.find("textarea[id='AssTitle']").val();
        //                        var type1 = 1;
        //                        type1 = $dialogContent.find("#AssessmentType option:selected").val();
        //                        calEvent.type = type1;
        //                        calEvent.PosPonits = $dialogContent.find("textarea[id='PosPonits']").val();
        //                        calEvent.body = $dialogContent.find("textarea[id='AssDescription']").val();
        //                        start = new Date($dialogContent.find("input[id='Duedate']").val());
        //                        var udt = $('#calendar').fullCalendar("formatDate", start, "dd-MM-yyyy hh:mm:ss");
        //                        jQuery.post(
        //                        url = "/Calendar/UpdateMyAssessment",
        //                        { id: calEvent.id, name: calEvent.title, desc: calEvent.body, TypeID: calEvent.type, Points: calEvent.PosPonits, Duedate: udt },
        //                            function (data) {
        //                                alert("Event Updated");
        //                                $calendar.fullCalendar('refetchEvents', true);
        //                            }
        //                        );

        //                        $dialogContent.dialog("close");
        //                    },
        //                    "delete": function () {
        //                        if (confirm('Are you sure you want to delete this event ?')) {

        //                            jQuery.post('/Calendar/DeleteMyAssessment',
        //                            { id: calEvent.id },
        //                                function (data) {
        //                                    alert("Event Deleted");
        //                                }

        //                        );
        //                            $('#calendar').fullCalendar('removeEvents', function (calEvent2) { return calEvent2.id == calEvent.id });
        //                            $dialogContent.dialog("close");
        //                        }
        //                    },
        //                    cancel: function () {
        //                        $dialogContent.dialog("close");
        //                    }
        //                }
        //            }).show();

        //            var startField = $dialogContent.find("select[name='start']").val(calEvent.start);
        //            var endField = $dialogContent.find("select[name='end']").val(calEvent.end);
        //            $dialogContent.find(".date_holder").text($calendar.fullCalendar("formatDate", calEvent.start));
        ////            setupStartAndEndTimeFields(startField, endField, calEvent, $calendar.fullCalendar("getTimeslotTimes", calEvent.start));
        //            $(window).resize().resize(); //fixes a bug in modal overlay size ??


        //        },
        eventMouseover: function (calEvent, $event) {
        },
        eventMouseout: function (calEvent, $event) {
        }

    });

    function resetForm($dialogContent) {
        $dialogContent.find("input").val("");
        $dialogContent.find("textarea").val("");

    }

    function createDiv(e) {
        var divTag = document.createElement("div");

        divTag.id = e.id;

        divTag.setAttribute("align", "center");

        divTag.style.margin = "0px auto";

        divTag.innerHTML = "<b>" + e.CourseName + "</b>  " + "<hr width=20% color=" + e.color;
    }

    /*
    * Sets up the start and end time fields in the calendar event
    * form for editing based on the calendar event being edited
    */
    function setupStartAndEndTimeFields($startTimeField, $endTimeField, calEvent, timeslotTimes) {

        for (var i = 0; i < timeslotTimes.length; i++) {
            var startTime = timeslotTimes[i].start;
            var endTime = timeslotTimes[i].end;
            var startSelected = "";
            if (startTime.getTime() == calEvent.start.getTime()) {
                startSelected = "selected=\"selected\"";
            }
            var endSelected = "";
            if (endTime.getTime() == calEvent.end.getTime()) {
                endSelected = "selected=\"selected\"";
            }
            $startTimeField.append("<option value=\"" + startTime + "\" " + startSelected + ">" + timeslotTimes[i].startFormatted + "</option>");
            $endTimeField.append("<option value=\"" + endTime + "\" " + endSelected + ">" + timeslotTimes[i].endFormatted + "</option>");

        }
        $endTimeOptions = $endTimeField.find("option");
        $startTimeField.trigger("change");
    }

    var $endTimeField = $("select[name='end']");
    var $endTimeOptions = $endTimeField.find("option");

    //reduces the end time options to be only after the start time options.
    $("select[name='start']").change(function () {
        var startTime = $(this).find(":selected").val();
        var currentEndTime = $endTimeField.find("option:selected").val();
        $endTimeField.html(
            $endTimeOptions.filter(function () {
                return startTime < $(this).val();
            })
            );

        var endTimeSelected = false;
        $endTimeField.find("option").each(function () {
            if ($(this).val() == currentEndTime) {
                $(this).attr("selected", "selected");
                endTimeSelected = true;
                return false;
            }
        });

        if (!endTimeSelected) {
            //automatically select an end date 2 slots away.
            $endTimeField.find("option:eq(1)").attr("selected", "selected");
        }

    });



});