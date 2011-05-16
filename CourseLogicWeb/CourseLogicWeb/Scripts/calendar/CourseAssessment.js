$(document).ready(function () {
    var query = location.search;
    var courseid = query.substring(query.indexOf("CourseID=") + 9, query.length);
    var $calendar = $('#calendar');
    var id = 10;
    var $dialogContent = $("#event_edit_container");
    $dialogContent.visible = false;
    $dialogContent.dialog("destroy");
    $dialogContent.hide();
    $calendar.fullCalendar({
        editable: true,
        droppable: true,

        timeslotsPerHour: 4,
        defaultView: 'month',
        allowCalEventOverlap: true,
        overlapEventsSeparate: true,
        firstDayOfWeek: 1,
        businessHours: { start: 8, end: 18, limitDisplay: true },
        daysToShow: 7,
        theme: true,
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'month,agendaWeek,agendaDay'
        },
        events: "/Calendar/DisplayCourseAssessment?CourseID=" + courseid,

        eventRender: function (calEvent, element) {
            var Temp = calEvent.AssessmentType;
            var color = calEvent.color;
            element.find('a').css('background-color', color);
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
            //element.find('span.fc-event-time').text("");
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
        dayClick: function (date, allDay, jsEvent, view) {
            var $dialogContent = $("#event_edit_container");

            y = date.getFullYear();
            m = date.getMonth();
            d1 = date.getDate();

            h1 = date.getHours();
            m1 = date.getMinutes();

            h2 = h1 + 1;
            m2 = m1;

            calEvent = { title: '', editable: true, type: 1, PosPonits: '0', start: new Date(y, m, d1, h1, m1), end: new Date(y, m, d1, h1, m1), allDay: false };
            //   $calendar.fullCalendar("renderEvent", calEvent, true);

            resetForm($dialogContent);
            $dialogContent.find("textarea[id='PosPonits']").text("0");
            var maindt = $('#calendar').fullCalendar("formatDate", date, "MM/dd/yyyy");
            $dialogContent.find("input[id='Duedate']").val(maindt);
            var type1 = 1;

            var Point = $dialogContent.find("textarea[id='PosPonits']");

            var titleField = $dialogContent.find("textarea[id='AssTitle']");
            var duedate = $dialogContent.find("input[id='Duedate']");
            var bodyField = $dialogContent.find("textarea[id='AssDescription']");

            allDay = false;
            $dialogContent.dialog({
                modal: true, width: 590,
                title: "Add Course Assessment",
                close: function () {
                    $dialogContent.dialog("destroy");
                    $dialogContent.hide();
                },
                buttons: {
                    save: function () {

                        if (titleField.val() == "") {
                            $("#ErrorCourseItemTitle").text("");
                            $("#ErrorCourseItemTitle").text("Title Can not be blank !");
                            $("#ErrorCourseItemTitle").attr("style", "margin: 0px 0px 0px 0px;line-height:20px; display: block; color: red; font-size: 12px; font-weight: 500;");
                            $("#CourseItemTitle").focus();

                            return false;
                        }

                        else {
                            $("#ErrorCourseItemTitle").text("");
                            $("#ErrorCourseItemTitle").attr("style", "margin: 0px 0px 0px 0px;line-height:20px; display: none; color: red; font-size: 12px; font-weight: 500;");
                            $("#CourseItemDescription").focus();
                            var duedt = new Date(duedate.val());
                            //                        calEvent.Due = new Date(end.getYear(), m, d, end.getHours(), end.getMinutes()); ;
                            type1 = $dialogContent.find("#AssessmentType option:selected").val();
                            if (type1 == "") {
                                $("#ErrorChapter").text("");
                                $("#ErrorChapter").text("Please select Assessment Type !");
                                $("#ErrorChapter").attr("style", "margin: 0px 0px 0px 0px;line-height:20px; display: block; color: red; font-size: 12px; font-weight: 500;");
                                $("#AssessmentType").focus();
                                return false
                            }
                            else {
                                calEvent.title = titleField.val();
                                calEvent.type = type1;
                                calEvent.PosPonits = Point.val().toString();
                                calEvent.body = bodyField.val();
                                calEvent.start = duedt;
                                calEvent.end = duedt;
                                var edt = $('#calendar').fullCalendar("formatDate", duedt, "dd-MM-yyyy hh:mm:ss");
                                //                        calEvent.start = dt;
                                //                        calEvent.end = edt;
                                //                                         

                                $.post(
                        url = "/calendar/AddCourseAssessment",
                        { name: calEvent.title, desc: calEvent.body, typeID: calEvent.type, Points: calEvent.PosPonits, Duedate: edt, CourseID: courseid },
                            function (data) {
                                alert("New Event Added");
                                $calendar.fullCalendar('refetchEvents', true);
                            }
                        );

                                /*
                                jQuery.post('/Calendar/AddCourseAssessment',
                                { name: calEvent.title, desc: calEvent.body, TypeID: calEvent.type, Points: calEvent.PosPonits, Duedate: edt },
                                function (data) {
                                alert("New Event Added");
                                $calendar.fullCalendar('refetchEvents', true);
                                //$calendar.fullCalendar("renderEvent", calEvent, true);
                                //                                    $calendar.fullCalendar("updateEvent", true);

                                }
                                );
                                */

                                //                        jQuery.ajax({ url: '/Calendar/AddCourseAssessment',

                                //                            data: { title: calEvent.title, desc: calEvent.body, start: dt, end: edt },
                                //                            success: function (data) {
                                //                                alert("New Event Added");

                                //                                $('#calendar').fullCalendar('refetchEvents', true);
                                //                            },
                                //                            dataType: 'json'
                                //                        });


                                $dialogContent.dialog("close");
                            }
                        }
                    },
                    cancel: function () {
                        $('#calendar').fullCalendar('removeEvents', function (calEvent2) { return calEvent2.id == calEvent.id });
                        $dialogContent.dialog("close");
                    }
                }
            }).show();

            $dialogContent.find(".date_holder").text($calendar.fullCalendar('formatDate', date, "dd MMMM yyyy"));


        },


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
        //                title: "Edit - " +calEvent.title,
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
        //                        url = "/Calendar/UpdateCourseAssessment",
        //                        { id: calEvent.id, name: calEvent.title, desc: calEvent.body, TypeID: calEvent.type, Points: calEvent.PosPonits, Duedate: udt},
        //                            function (data) {
        //                                alert("Event Updated");
        //                                $calendar.fullCalendar('refetchEvents', true);
        //                            }
        //                        );

        //                        //                        jQuery.post('/Calendar/UpdateCourseAssessment',
        //                        //                                  {id:calEvent.id, name: calEvent.title, desc: calEvent.body, TypeID: calEvent.type, Points: calEvent.PosPonits, Duedate: d },
        //                        //                                       function (data) {
        //                        //                                           alert("Event Updated");
        //                        //                                           $('#calendar').fullCalendar('refetchEvents');
        //                        //                                       }
        //                        //                                );
        //                        //$calendar.fullCalendar("updateEvent", calEvent);

        //                        $dialogContent.dialog("close");
        //                    },
        //                    "delete": function () {
        //                        if (confirm('Are you sure you want to delete this event ?')) {

        //                            jQuery.post('/Calendar/DeleteCourseAssessment',
        //                                    { id: calEvent.id },
        //                                        function (data) {
        //                                            alert("Event Deleted");
        //                                        }

        //                                );
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