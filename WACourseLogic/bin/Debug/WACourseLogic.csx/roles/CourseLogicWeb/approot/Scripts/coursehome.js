$(document).ready(function () {
    var lastId = 0;

    /*
    $('a').live('click', function () {
        return false;
    });
    */
    $('.twitter_row').live('mouseenter', function () {
        $(this).find(".arrow").css("visibility", "visible");
    }).live('mouseleave', function () {
        $(this).find(".arrow").css("visibility", "hidden");
    });

    $('.arrow').live('mouseenter', function () {
        $(this).addClass("arrowhover");
    }).live('mouseleave', function () {
        $(this).removeClass("arrowhover");
    });


    $('.close').live('mouseenter', function () {
        $(this).addClass("logohover");
    }).live('mouseleave', function () {
        $(this).removeClass("logohover");
    });

    $('.close').click(function () {
        var panel = $('.panel_right');
        $('.selected_twitter_row').addClass("twitter_row");
        $('.selected_twitter_row').removeClass("selected_twitter_row");
        panel.animate({
            left: parseInt(panel.css('left'), 0) == 0 ? +324 : 0
        });

        if (parseInt(panel.css('left'), 0) != 0) {
            $("#panel-frame").css("display", "none");
        }

        return false;
    });

    $('.twitter_row').live('click', function () {
        if (Get_Cookie("ID") != false && Get_Cookie("ID") != null) {
            var url = document.location.toString(); //url
            var e_url = ''; //edited url
            var p = 0; //position
            var p2 = 0; //position 2
            p = url.indexOf("//");
            e_url = url.substring(p + 2);
            p2 = e_url.indexOf("/");
            var root_url = url.substring(0, p + p2 + 3);

            var id = $(this).attr('id');
            var data_id = $(this).find(".datahtml").val();
            var datas = $(this).find(".content").html();
            var panel = $('.panel_right');
            var panel_width = $('.panel_right').css('left');

            $("#panel-frame").css("display", "block");

            var ParentCourseItemID = $(this).find(".hdnParentCourseItemID").val();
            var SysObjectId = $(this).find(".hdnSysObjectID").val();
            var CourseItemID = $(this).find(".hdnCourseItemID").val();
            if (SysObjectId == 4) {
                var frmSRC = root_url + "Question/QuestionByQuestionID?QID=" + data_id + "&IsLoadInRightPane=1" + "&SysObjectId=" + SysObjectId;
            }
            else if (SysObjectId == 5) {
                var frmSRC = root_url + "Answer/GetChildByCourseItemID?AnswerID=" + CourseItemID + "&IsLoadInRightPane=1" + "&SysObjectId=" + SysObjectId;
            }
            else if (SysObjectId == 7) {
                var frmSRC = root_url + "Discussion/DiscussionByDiscussionID?DID=" + data_id + "&IsLoadInRightPane=1" + "&SysObjectId=" + SysObjectId;
            }
            else if (SysObjectId == 8) {
                var frmSRC = root_url + "Terms/TermByTermID?TID=" + data_id + "&IsLoadInRightPane=1" + "&SysObjectId=" + SysObjectId;
            }
            else if (SysObjectId == 9) {
                var frmSRC = root_url + "Answer/GetChildByCourseItemID?AnswerID=" + CourseItemID + "&IsLoadInRightPane=1" + "&SysObjectId=" + SysObjectId;
            }
            else if (SysObjectId == 10) {
                var frmSRC = root_url + "Note/NoteByNoteID?NID=" + data_id + "&IsLoadInRightPane=1" + "&SysObjectId=" + SysObjectId;
            }
            else if (SysObjectId == 14) {
                var frmSRC = root_url + "Summary/SummaryBySummaryID?SID=" + data_id + "&IsLoadInRightPane=1" + "&SysObjectId=" + SysObjectId;
            }
            $('.selected_twitter_row').removeClass("selected_twitter_row");
            $("#" + id).addClass("selected_twitter_row");


            if ($.browser.msie && $.browser.version == "7.0") {
                if (data_id == id) {
                    if (panel_width == '-497px' && lastId != data_id) {
                        $("#panel-frame").css("display", "block");
                    }
                    else {
                        panel.animate({
                            left: parseInt(panel.css('left'), 0) == 0 ? -497 : 0
                        });

                        if (parseInt(panel.css('left'), 0) != 0) {
                            $("#panel-frame").css("display", "none");
                            $('.selected_twitter_row').removeClass("selected_twitter_row");
                        }
                    }
                    lastId = data_id;
                }
            }
            else {
                if (data_id == id) {
                    if (panel_width == '324px' && lastId != data_id) {
                        $("#panel-frame").css("display", "block");
                    }
                    else {
                        panel.animate({
                            left: parseInt(panel.css('left'), 0) == 0 ? +324 : 0
                        });

                        if (parseInt(panel.css('left'), 0) != 0) {
                            $("#panel-frame").css("display", "none");
                            $('.selected_twitter_row').removeClass("selected_twitter_row");
                        }
                    }
                    lastId = data_id;
                }
            }

            var response = "<iframe id='frmItemDetails' name='frmItemDetails' height='520px' width='620px' style='border: none; overflow-x:hidden;overflow-y:auto;' src='" + frmSRC + "' type='text/html'></iframe>";
            $('.data').html(response);

            return false;
        }
        else {
            // Login Check Else Part
            $('body').append("<div id='LoginCheckAlert' title='Not Logged In'><table width='185' cellspacing='0' cellpadding='0' border='0' style='margin-top:15px;'><tbody><tr><td align='center'><span>Please log in to continue.</span></td></tr><tr><td align='center'><input style='margin-top:20px;' type='button' class='askquebtn' id='btnYesLoginCheck' value='Login'></td></tr></tbody></table></div>");
            jQuery("#LoginCheckAlert").dialog({
                bgiframe: true, autoOpen: false, width: 200, modal: true
            });
            jQuery('#LoginCheckAlert').dialog('open');
            $("#btnYesLoginCheck").click(function () {
                window.top.location.href = GetRootPathJS();
            });
            $("#lnkmyclose").click(function () {
                jQuery('#LoginCheckAlert').dialog('close');
                $("#LoginCheckAlert").dialog("destroy");
                $("#LoginCheckAlert").remove();
                return false;
            });
        }
    });
});

function Get_Cookie(check_name) {
    // first we'll split this cookie up into name/value pairs
    // note: document.cookie only returns name=value, not the other components
    var a_all_cookies = document.cookie.split(';');
    var a_temp_cookie = '';
    var cookie_name = '';
    var cookie_value = '';
    var b_cookie_found = false; // set boolean t/f default f

    for (i = 0; i < a_all_cookies.length; i++) {
        // now we'll split apart each name=value pair
        a_temp_cookie = a_all_cookies[i].split('=');

        // and trim left/right whitespace while we're at it
        cookie_name = a_temp_cookie[0].replace(/^\s+|\s+$/g, '');

        // if the extracted name matches passed check_name
        if (cookie_name == check_name) {
            b_cookie_found = true;
            // we need to handle case where cookie has no value but exists (no = sign, that is):
            if (a_temp_cookie.length > 1) {
                cookie_value = unescape(a_temp_cookie[1].replace(/^\s+|\s+$/g, ''));
            }
            // note that in cases where cookie is initialized but no value, null is returned
            return cookie_value;
            break;
        }
        a_temp_cookie = null;
        cookie_name = '';
    }
    if (!b_cookie_found) {
        return false;
    }
}




