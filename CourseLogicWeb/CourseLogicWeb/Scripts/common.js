/*forgot passwrord functionality -  function start*/

function recoverPassword() {

    var MailId = $("#txtMailId").val();
    var UserId = $("#txtUserId").val();
    if (MailId == "" && UserId == "") {
        $("#ErrorForgotPassword").text("Please enter Username or E-mail!");
        $("#ErrorForgotPassword").attr("style", "display: block;color: red;line-height: 20px;height:20px; margin-left: 25px; width: 190px;  float: left; font-size: 12px; font-weight: 500;");
        $("#txtUserId").focus();
        return false;
    }
    else if (MailId != "") {
        if (ValidatedEmail(MailId) == false) {
            $("#ErrorForgotPassword").text("Invalid E-mail ID !");
            $("#ErrorForgotPassword").attr("style", "display: block;color: red;line-height: 20px;height:20px; margin-left: 25px; width: 190px;  float: left; font-size: 12px; font-weight: 500;");
            $("#txtMailId").focus();
            return false;
        }
        else {
            $("#ErrorForgotPassword").text("");
            $("#ErrorForgotPassword").text("Please Wait..........");
            $("#ErrorForgotPassword").attr("style", "display: block; color:green;line-height: 20px;height:20px; margin-left: 25px; width: 190px;  float: left; font-size: 12px; font-weight: 500;");
            document.getElementById("btnRecoverPwd").disabled = true;
        }
    }
    else {
        $("#ErrorForgotPassword").text("");
        $("#ErrorForgotPassword").text("Please Wait..........");
        $("#ErrorForgotPassword").attr("style", "display: block;color:green;sline-height: 20px;height:20px; margin-left: 25px; width: 190px;  float: left; font-size: 12px; font-weight: 500;");
        document.getElementById("btnRecoverPwd").disabled = true;
    }
    $.post(
        url = '/Login/getPassword',
        { userId: UserId, mailId: MailId },
        function (data) {
            if (data == "0") {
                $("#ErrorForgotPassword").text("User does not exists");
                $("#ErrorForgotPassword").attr("style", "display: block; color: red;line-height: 20px;height:20px; margin-left: 25px; width: 190px;  float: left; font-size: 12px; font-weight: 500;");
                document.getElementById("btnRecoverPwd").disabled = false;
            }
            else if (data == "1") {
                $("#ErrorForgotPassword").text("Mail sent successfully");
                $("#ErrorForgotPassword").attr("style", "display: block; color: green;line-height: 20px;height:20px; margin-left: 25px; width: 190px;  float: left; font-size: 12px; font-weight: 500;");
                $("#dialogForgotPassword").fadeOut(8000);
                document.getElementById("btnRecoverPwd").disabled = false;

            }
            else if (data == "2") {
                $("#ErrorForgotPassword").text("Mail sending failed");
                $("#ErrorForgotPassword").attr("style", "display: block;color: red;line-height: 20px;height:20px; margin-left: 25px; width: 190px;  float: left; font-size: 12px; font-weight: 500;");
                document.getElementById("btnRecoverPwd").disabled = false;
            }
            else {
                $("#ErrorForgotPassword").text("");
                $("#ErrorForgotPassword").attr("style", "display: none;line-height: 20px;height:20px; margin-left: 25px; width: 190px;  float: left; font-size: 12px; font-weight: 500;");
                $("#dialogForgotPassword").fadeOut(8000);
                document.getElementById("btnRecoverPwd").disabled = false;
            }

        }
         );
}

/*funciton end*/


function GetRootPathJS() {
    var url = document.location.toString(); //url
    var e_url = ''; //edited url
    var p = 0; //position
    var p2 = 0; //position 2
    p = url.indexOf("//");
    e_url = url.substring(p + 2);
    p2 = e_url.indexOf("/");
    var root_url = url.substring(0, p + p2 + 3);
    return root_url;
}



function VoteUp(CourseItemID, SystemObjectName, CourseID, ActionURL, AccID) {
    if (Get_Cookie("ID") != false && Get_Cookie("ID") != null) {
        $.post(
           url = ActionURL,
           { AssociatedId: CourseItemID, SysObjectName: SystemObjectName, CID: CourseID, AccID: AccID },
           function (data) {
               $("#DivVote" + CourseItemID).html(data);
           }
        );
    }
    else {
        if ($("#LoginCheckAlert")) {
            $("#LoginCheckAlert").remove();
        }
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
}

function VoteDown(CourseItemID, SystemObjectName, CourseID, ActionURL, AccID) {
    if (Get_Cookie("ID") != false && Get_Cookie("ID") != null) {
        $.post(
           url = ActionURL,
           { AssociatedId: CourseItemID, SysObjectName: SystemObjectName, CID: CourseID, AccID: AccID },
           function (data) {
               $("#DivVote" + CourseItemID).html(data);

           }
        );
    }
    else {
        if ($("#LoginCheckAlert")) {
            $("#LoginCheckAlert").remove();
        }
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
}

function Star(CourseItemID, SystemObjectName, CourseID, ActionURL, AccID) {
    if (Get_Cookie("ID") != false && Get_Cookie("ID") != null) {
        $.post(
           url = ActionURL,
           { AssociatedId: CourseItemID, SysObjectName: SystemObjectName, CID: CourseID, AccID: AccID },
           function (data) {
               $("#DivVote" + CourseItemID).html(data);

           }
        );
    }
    else {
        if ($("#LoginCheckAlert")) {
            $("#LoginCheckAlert").remove();
        }
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
}

function loadAllComments(CourseItemID, SystemObjectName, AccID, IsDefault, ActionURL, CourseID) {
    if (Get_Cookie("ID") != false && Get_Cookie("ID") != null) {
        $.post(
           url = ActionURL,
           { AssociatedID: CourseItemID, SystemObjectName: SystemObjectName, AccountID: AccID, CommentFlag: IsDefault, CourseID: CourseID },
           function (data) {
               if (document.getElementById('DivCommentCtl' + CourseItemID) == undefined) {
                   if (document.getElementById('DivCommentCtl1' + CourseItemID) != undefined) {
                       $("#DivCommentCtl1" + CourseItemID).html(data);
                   }
                   else {
                       if (document.getElementById('DivCommentCtl2' + CourseItemID) != undefined) {
                           $("#DivCommentCtl2" + CourseItemID).html(data);
                       }
                   }
               }
               else {
                   if (document.getElementById('DivCommentCtl' + CourseItemID) != undefined) {
                       $("#DivCommentCtl" + CourseItemID).html(data);
                   }
               }
           }
        );
    }
    else {
        if ($("#LoginCheckAlert")) {
            $("#LoginCheckAlert").remove();
        }
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
}


function EditComment(CourseItemID, SystemObjectName, AccID, ParentCourseItemID, ActionURL, CourseID, IsBlank) {
    var DivCommentID = "DivCommentByCommentID" + ParentCourseItemID;
    if (Get_Cookie("ID") != false && Get_Cookie("ID") != null) {
        $.post(
    url = ActionURL,
    { CID: CourseItemID, SystemObjectName: SystemObjectName, AccountID: AccID, ParentID: ParentCourseItemID, CourseID: CourseID, IsBlank: IsBlank },
        function (data) {
            $("#DivCommentByCommentID" + ParentCourseItemID).html(data);
            $("#CourseItemDescription" + ParentCourseItemID).focus();
            if (document.getElementById("DivQuesCommentInput" + ParentCourseItemID) == "block") {
                document.getElementById("CourseItemDescription" + ParentCourseItemID).focus();
            }
            else {
                document.getElementById("CourseItemDescription" + ParentCourseItemID).focus();
            }
        }
    );
    }
    else {
        if ($("#LoginCheckAlert")) {
            $("#LoginCheckAlert").remove();
        }
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
}

function DeleteComment(CourseItemID, CourseID, AccountID, SystemObjectID, SystemObjectName, ParentCourseItemID, ActionURL, ActionLoadCommentURL) {
    if (Get_Cookie("ID") != false && Get_Cookie("ID") != null) {
        $("#delete").dialog("destroy");
        $("#dialog").dialog("destroy");
        var DeleteCommentConfrim = "<div style='padding: 10px 6px;'><p>Are you sure you want to delete item ?</p></div><div style='padding: 0px 10px;'><input type='button' class='askquebtn' id='btnYesComment' value='Yes' />&nbsp;<input type='button' id='btnNoComment' class='askquebtn' value='No' /></div>";
        jQuery("#deleteComment").dialog({
            bgiframe: true, autoOpen: false, width: 235, modal: true
        });
        $(".deleteCommentConfrim").empty();
        $("#deleteComment").html(DeleteCommentConfrim);
        jQuery('#deleteComment').dialog('open');
        $("#btnNoComment").focus();
        $("#btnYesComment").click(function () {
            if (parseInt(CourseItemID) > 0) {
                $.post(
            url = ActionURL,
            { CourseItemID: CourseItemID },
            function (data) {
                if (SystemObjectName == 'Comments') {
                    loadAllComments(ParentCourseItemID, SystemObjectName, AccountID, false, ActionLoadCommentURL, CourseID);
                }
                else if (SystemObjectName == 'Answers') {
                    if (window.parent.document.getElementById("lnkTopVoted") != undefined) {
                        if (window.parent.document.getElementById("CourseHomePageNumber") != undefined) {
                            var PageNumber = window.parent.document.getElementById("CourseHomePageNumber").value;
                        }
                        else {
                            var PageNumber = "1";
                        }
                        if ($("#CoruseItemChildControl") != undefined) {
                            var ActionReloadURL = "";
                            var ClassName = window.parent.document.getElementById("lnkTopVoted").className;
                            ClassName = MyTrim(ClassName);
                            if (ClassName == "faceblack") {
                                ActionReloadURL = "/CourseHome/CourseHome?CourseID=" + CourseID + "&IsEditedAddItem=1" + "&IsTopVoted=1" + "&PageNumber=" + PageNumber;
                            }
                            else {
                                ActionReloadURL = "/CourseHome/CourseHome?CourseID=" + CourseID + "&IsEditedAddItem=1" + "&IsTopVoted=0" + "&PageNumber=" + PageNumber;
                            }
                            $.post(
                                url = ActionReloadURL,
                                function (data) {
                                    window.parent.document.getElementById("panel-frame").style.display = "none";
                                    $('#CourseHomePage', window.parent.document).html(data);
                                });
                        }
                    }
                    else {
                        if (document.getElementById("Answer" + ParentCourseItemID) == undefined) {
                            //if ($("#Answer" + ParentCourseItemID) == undefined) {
                            if ($("#CoruseItemChildControl") != undefined) {
                                var ActionReloadURL = "";
                                ActionReloadURL = "CourseHome/CourseHome?CourseID=" + CourseID + "&IsTopVoted=0" + "&PageNumber=1";
                                window.top.location.href = GetRootPathJS() + ActionReloadURL;
                            }
                        }
                        else {
                            $.post(
                            url = ActionLoadCommentURL,
                            { ParentCourseItemID: ParentCourseItemID },
                            function (data) {
                                $("#Answer" + ParentCourseItemID).html(data);
                                LoadChildCount(ParentCourseItemID);
                            }
                            );
                        }
                    }
                }
                else if (SystemObjectName == 'Definations') {
                    /*
                    $.post(
                    url = ActionLoadCommentURL,
                    { ParentCourseItemID: ParentCourseItemID },
                    function (data) {
                    $("#Answer" + ParentCourseItemID).html(data);
                    }
                    );
                    */
                    if (window.parent.document.getElementById("lnkTopVoted") != undefined) {
                        if (window.parent.document.getElementById("CourseHomePageNumber") != undefined) {
                            var PageNumber = window.parent.document.getElementById("CourseHomePageNumber").value;
                        }
                        else {
                            var PageNumber = "1";
                        }
                        if ($("#CoruseItemChildControl") != undefined) {
                            var ActionReloadURL = "";
                            var ClassName = window.parent.document.getElementById("lnkTopVoted").className;
                            ClassName = MyTrim(ClassName);
                            if (ClassName == "faceblack") {
                                ActionReloadURL = "/CourseHome/CourseHome?CourseID=" + CourseID + "&IsEditedAddItem=1" + "&IsTopVoted=1" + "&PageNumber=" + PageNumber;
                            }
                            else {
                                ActionReloadURL = "/CourseHome/CourseHome?CourseID=" + CourseID + "&IsEditedAddItem=1" + "&IsTopVoted=0" + "&PageNumber=" + PageNumber;
                            }
                            $.post(
                                url = ActionReloadURL,
                                function (data) {
                                    window.parent.document.getElementById("panel-frame").style.display = "none";
                                    $('#CourseHomePage', window.parent.document).html(data);
                                });
                        }
                    }
                    else {
                        if (document.getElementById("Answer" + ParentCourseItemID) == undefined) {
                            //if ($("#Answer" + ParentCourseItemID) == undefined) {
                            if ($("#CoruseItemChildControl") != undefined) {
                                var ActionReloadURL = "";
                                ActionReloadURL = "CourseHome/CourseHome?CourseID=" + CourseID + "&IsTopVoted=0" + "&PageNumber=1";
                                window.top.location.href = GetRootPathJS() + ActionReloadURL;
                            }
                        }
                        else {
                            $.post(
                            url = ActionLoadCommentURL,
                            { ParentCourseItemID: ParentCourseItemID },
                            function (data) {
                                $("#Answer" + ParentCourseItemID).html(data);
                                LoadChildCount(ParentCourseItemID);
                            }
                            );
                        }
                    }
                }
            }
            );
            }
            jQuery('#deleteComment').dialog('close');
            CourseItemID = 0;
            var Data = "<div style='padding: 17px 132px;'><p><img src='../../Images/loading.gif' />Please Wait AddItem is Loading</p></div>";
            var DeleteConfrim = "<div style='padding: 14px 42px;'><p><img src='../../Images/loading.gif' />Loading...</p></div>";
            var DeleteCommentConfrim = "<div style='padding: 14px 42px;'><p><img src='../../Images/loading.gif' />Loading...</p></div>";
            $("#deleteComment").dialog("destroy");
            $(".deleteCommentConfrim").empty();
            $("#deleteComment").html(DeleteCommentConfrim);
            $("#delete").dialog("destroy");
            $(".deleteConfrim").empty();
            $("#delete").html(DeleteConfrim);
            $("#dialog").dialog("destroy");
            $(".NullValue").empty();
            $("#dialog").html(Data);
            return false;
        });
        $("#btnNoComment").click(function () {
            CourseItemID = 0;
            jQuery('#deleteComment').dialog('close');
            var Data = "<div style='padding: 17px 132px;'><p><img src='../../Images/loading.gif' />Please Wait AddItem is Loading</p></div>";
            var DeleteConfrim = "<div style='padding: 14px 42px;'><p><img src='../../Images/loading.gif' />Loading...</p></div>";
            var DeleteCommentConfrim = "<div style='padding: 14px 42px;'><p><img src='../../Images/loading.gif' />Loading...</p></div>";
            $("#deleteComment").dialog("destroy");
            $(".deleteCommentConfrim").empty();
            $("#deleteComment").html(DeleteCommentConfrim);
            $("#delete").dialog("destroy");
            $(".deleteConfrim").empty();
            $("#delete").html(DeleteConfrim);
            $("#dialog").dialog("destroy");
            $(".NullValue").empty();
            $("#dialog").html(Data);
            return false;
        });

        $("#lnkmyclose").click(function () {
            CourseItemID = 0;
            jQuery('#deleteComment').dialog('close');
            var Data = "<div style='padding: 17px 132px;'><p><img src='../../Images/loading.gif' />Please Wait AddItem is Loading</p></div>";
            var DeleteConfrim = "<div style='padding: 14px 42px;'><p><img src='../../Images/loading.gif' />Loading...</p></div>";
            var DeleteCommentConfrim = "<div style='padding: 14px 42px;'><p><img src='../../Images/loading.gif' />Loading...</p></div>";
            $("#deleteComment").dialog("destroy");
            $(".deleteCommentConfrim").empty();
            $("#deleteComment").html(DeleteCommentConfrim);
            $("#delete").dialog("destroy");
            $(".deleteConfrim").empty();
            $("#delete").html(DeleteConfrim);
            $("#dialog").dialog("destroy");
            $(".NullValue").empty();
            $("#dialog").html(Data);
            return false;
        });
    }
    else {
        // Login Check Else Part
        if ($("#LoginCheckAlert")) {
            $("#LoginCheckAlert").remove();
        }
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
}

function SaveComment(CourseItemID, CourseID, AccountID, SystemObjectID, SystemObjectName, ParentCourseItemID, ActionURL, ActionLoadCommentURL, Mode) {
    if (Get_Cookie("ID") != false && Get_Cookie("ID") != null) {
        var CommentDesc = document.getElementById("CourseItemDescription" + ParentCourseItemID).value;
        CommentDesc = CommentDesc.replace(/(\r\n|[\r\n])/g, "<br />");
        CommentDesc = RemoveComma(CommentDesc);
        Encoder.EncodeType = "entity";
        var encoded = Encoder.htmlEncode(CommentDesc);
        if (Mode == "Add") {
            document.getElementById("CourseItemDescription" + ParentCourseItemID).value = "";
        }
        $.post(
        url = ActionURL,
        { CourseItemID: CourseItemID, CourseID: CourseID, AccountID: AccountID, SystemObjectID: SystemObjectID, SystemObjectName: SystemObjectName, CommentDesc: encoded, ParentCourseItemID: ParentCourseItemID },
        function (data) {
            document.getElementById("CourseItemDescription" + ParentCourseItemID).value = "";
            loadAllComments(ParentCourseItemID, SystemObjectName, AccountID, false, ActionLoadCommentURL, CourseID);
        }
    );
    }
    else {
        // Login Check Else Part
        if ($("#LoginCheckAlert")) {
            $("#LoginCheckAlert").remove();
        }
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
}

function EditChildItem(CourseItemID, ParentCourseItemID, ActionURl, CourseID, SystemObjectName) {
    if (Get_Cookie("ID") != false && Get_Cookie("ID") != null) {
        $("#DivEditor" + ParentCourseItemID).show(100);
        $.post(
        url = ActionURl,
       { CID: CourseItemID, ParentCID: ParentCourseItemID, CourseID: CourseID, SystemObjectName: SystemObjectName },
        function (data) {
            $("#DivEditor" + ParentCourseItemID).html(data);
            var arrayPost = findPos(document.getElementById('txtItemDescIFrame'));
            $('html, body').animate({ scrollTop: arrayPost[1] }, 'fast');
        }
    );
    }
    else {
        // Login Check Else Part
        if ($("#LoginCheckAlert")) {
            $("#LoginCheckAlert").remove();
        }
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
}

function findPos(obj) {
    var curleft = curtop = 0;
    if (obj.offsetParent) {
        do {
            curleft += obj.offsetLeft;
            curtop += obj.offsetTop;
        }
        while (obj = obj.offsetParent);
        return [curleft, curtop];
    }
}

function ShowWriteComment(CourseItemID) {
    if (document.getElementById("DivQuesCommentInput" + CourseItemID).style.display == "none")
        $("#DivWriteCommentID" + CourseItemID).css("display", "block");
}

function ShowComment(CourseItemID) {
    $("#DivWriteCommentID" + CourseItemID).css("display", "none");
    $("#DivQuesCommentInput" + CourseItemID).css("display", "block");
    document.getElementById("CourseItemDescription" + CourseItemID).focus();
}

function HideComment(CourseItemID, SystemObjectName, AccID, ParentCourseItemID, ActionURL, CourseID) {
    if (document.getElementById("CourseItemDescription" + ParentCourseItemID)) {
        var CommentValue = document.getElementById("CourseItemDescription" + ParentCourseItemID).value;
        CommentValue = MyTrim(CommentValue);
        if (CommentValue == "") {
            EditComment(CourseItemID, SystemObjectName, AccID, ParentCourseItemID, ActionURL, CourseID, 0);
        }
    }
}


function SaveChildItem(CourseItemID, CourseID, ParentCourseItemID, ActionURL, ActionLoadAnswerURL, systemobjectName) {
    if (Get_Cookie("ID") != false && Get_Cookie("ID") != null) {
        var AnswerDesc = document.getElementById("txtItemDesc").value;
        AnswerDesc = MyTrim(AnswerDesc);
        var ValidatedEditorValue = removeHTMLTags(AnswerDesc);
        ValidatedEditorValue = MyTrim(ValidatedEditorValue);
        Encoder.EncodeType = "entity";
        var encoded = Encoder.htmlEncode(AnswerDesc);
        encoded = RemoveMPercentSign(encoded);
        if (ValidatedEditorValue == "") {
            // Show Error Messaage
            return false;
        }
        $.post(
        url = ActionURL,
        { CourseItemID: CourseItemID, CourseID: CourseID, AnswerDesc: encoded, ParentCourseItemID: ParentCourseItemID, systemobjectName: systemobjectName },
        function (data) {
            if (window.parent.document.getElementById("lnkTopVoted") == undefined) {
                LoadChildItemDetails(ParentCourseItemID, ActionLoadAnswerURL, CourseItemID, systemobjectName);
                LoadChildCount(ParentCourseItemID);
                if (document.getElementById("Answer" + ParentCourseItemID) != undefined) {
                    $.post(
                    url = "/Editor/LoadEditor",
                    { CID: ParentCourseItemID, ParentCID: 0, CourseID: CourseID, SystemObjectName: systemobjectName },
                    function (data) {
                        $("#DivEditor" + ParentCourseItemID).html(data);
                    }
                );
                    return false;
                }
                if ($("#CoruseItemChildControl") != undefined) {
                    return false;
                }
            }
            else {
                LoadChildCount(ParentCourseItemID);
                LoadCourseHomePage(CourseID, CourseItemID, systemobjectName, ParentCourseItemID);
                var doc = document.getElementById("txtItemDescIFrame");
                if (doc.document) {
                    doc.contentDocument.body.innerHTML = "";
                    // Commented on 22-1-2011 because it was not working in IE
                    //document.test.document.body.innerHTML = ""; //Chrome, IE
                } else {
                    doc.contentDocument.body.innerHTML = ""; //FireFox
                }
            }
        }
    );
    }
    else {
        // Login Check Else Part
        if ($("#LoginCheckAlert")) {
            $("#LoginCheckAlert").remove();
        }
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
}

function LoadCourseHomePage(CourseID, CourseItemID, SystemObjectName, ParentCourseItemID) {
    if (window.parent.document.getElementById("lnkTopVoted") != undefined) {
        if (window.parent.document.getElementById("CourseHomePageNumber") != undefined) {
            var PageNumber = window.parent.document.getElementById("CourseHomePageNumber").value;
        }
        else {
            var PageNumber = "1";
        }
        var ActionReloadURL = "";
        var ClassName = window.parent.document.getElementById("lnkTopVoted").className;
        ClassName = MyTrim(ClassName);
        if (ClassName == "faceblack") {
            ActionReloadURL = "/CourseHome/CourseHome?CourseID=" + CourseID + "&IsEditedAddItem=1" + "&IsTopVoted=1" + "&PageNumber=" + PageNumber;
        }
        else {
            ActionReloadURL = "/CourseHome/CourseHome?CourseID=" + CourseID + "&IsEditedAddItem=1" + "&IsTopVoted=0" + "&PageNumber=" + PageNumber;
        }
        $.post(
        url = ActionReloadURL,
        function (data) {
            $('#CourseHomePage', window.parent.document).html(data);
            ReloadChildPage(CourseItemID, SystemObjectName, ParentCourseItemID);
        });
    }
}


function LoadChildItemDetails(ParentCourseItemID, ActionLoadAnswerURL, CourseItemID, SystemObjectName) {
    if (window.parent.document.getElementById("lnkTopVoted") != undefined) {
    }
    else {
        if (document.getElementById("Answer" + ParentCourseItemID) != undefined) {
            $.post(
           url = ActionLoadAnswerURL,
           { ParentCourseItemID: ParentCourseItemID },
           function (data) {
               $("#Answer" + ParentCourseItemID).html(data);
           });
            return false;
        }
        if ($("#CoruseItemChildControl") != undefined) {
            var SystemObjectID = "";
            if (SystemObjectName == "Answers") {
                SystemObjectID = "5";
            }
            if (SystemObjectName == "Definations") {
                SystemObjectID = "9";
            }
            var RootPath = GetRootPathJS();
            var LoadAnswerQuestion = RootPath + "Answer/GetChildByCourseItemID?AnswerID=" + CourseItemID + "&SysObjectId=" + SystemObjectID + "&IsEditedAddItem=1";
            $.post(
            url = LoadAnswerQuestion,
            /* Commented on 26-1-2011 because need to reload the Corresponding CourseItemChildControl with parent Control
            url = "/Answer/GetChildByCourseItemID",
            { AnswerID: CourseItemID, SysObjectId: SystemObjectID },
            */
            function (data) {
                $("#dialog").dialog("destroy");
                $("#dialog").remove();
                $("#delete").dialog("destroy");
                $("#delete").remove();
                $("#deleteComment").dialog("destroy");
                $("#deleteComment").remove();
                $("#CoruseItemChildControl").html(data);
            });
            return false;
        }
    }
}

function ReloadChildPage(CourseItemID, SystemObjectName, ParentCourseItemID) {
    var RootPath = GetRootPathJS();
    if (SystemObjectName == "Answers") {
        if (window.parent.document.getElementById("lnkTopVoted") != undefined) {
            // Load CourseHomePage Control and refresf the Iframe
            var FRSC = RootPath + "Answer/GetChildByCourseItemID?AnswerID=" + CourseItemID + "&IsLoadInRightPane=1" + "&SysObjectId=5";
            if ($("#frmItemDetails")) {
                window.parent.document.getElementById("frmItemDetails").setAttribute("src", FRSC);
            }
        }
        return false;
    }
    else if (SystemObjectName == "Definations") {
        // Load CourseHomePage and refresh the Iframe
        var FRSC = RootPath + "Answer/GetChildByCourseItemID?AnswerID=" + CourseItemID + "&IsLoadInRightPane=1" + "&SysObjectId=9";
        if ($("#frmItemDetails")) {
            window.parent.document.getElementById("frmItemDetails").setAttribute("src", FRSC);
        }
        return false;
    }
    else {
        // Do Nothing...
    }
}

function ViewChildDetail(CourseItemID) {
    document.getElementById('Answer ' + CourseItemID).style.display = 'block';

}

function HideEditor(ParentCourseItemID, Display) {

    var doc = document.getElementById("txtItemDescIFrame");

    if (doc.document) {
        doc.contentDocument.body.innerHTML = "";
        // Commented on 21-1-2011 because was not working in IE
        //document.test.document.body.innerHTML = ""; //Chrome, IE
    } else {
        doc.contentDocument.body.innerHTML = ""; //FireFox
    }
}

function ShowItemDetails(SelectedDiv) {
    var DivItem = "DivItemID";
    document.getElementById(SelectedDiv).className = 'answer-box-se';
    var DivList = document.getElementsByClassName("answer-box");
    //    for (i = 0; i < DivList.length; i++) {
    //        if (DivList.item(i).id == SelectedDiv) {
    //            DivList.item(i).id.className = 'answer-box-se';
    //        }
    //        else {
    //            DivList.item(i).id.className = 'answer-box';
    //        }
    //    }    
    document.getElementById('DiviFrame').style.display = 'block';
    document.getElementById('DivRightPaneStaticContent').style.display = 'none';
}

function CloseIFrame() {
    document.getElementById('DiviFrame').style.display = 'none';
    document.getElementById('DivRightPaneStaticContent').style.display = 'block';
}

function AddItem(CourseItemID, ActionURl, CourseID, AccountID, SystemObjectName, IsCourseHomePage) {
    if (Get_Cookie("ID") != false && Get_Cookie("ID") != null) {
        $.get(
        url = ActionURl,
       { CourseItemID: CourseItemID, CourseID: CourseID, SystemObjectName: SystemObjectName, IsCourseHomePage: IsCourseHomePage },
        function (data) {
            $("#dialog").html(data);
        }
    );
    }
    else {
        $("#dialog").dialog("destroy");
        $("#dialog").remove();
        if ($("#LoginCheckAlert")) {
            $("#LoginCheckAlert").remove();
        }
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
}

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

function LoadChildCount(CourseItemID) {
    var ActionURl = "/ChildCount/LoadChildCount";
    $.get(
        url = ActionURl,
       { CourseItemID: CourseItemID },
        function (data) {
            $("#Child" + CourseItemID).html(data);
        }
    );
}

function SaveAddItem(CourseItemID, CourseID, ActionURL, ActionReloadURL, systemobjectName, AccountID, IsAdded, IsCourseHomePage) {
    if (Get_Cookie("ID") != false && Get_Cookie("ID") != null) {
        var CourseItemTitle = $("#CourseItemTitle").val();
        document.getElementById("AddItemShare").disabled = true;
        if (systemobjectName == "Questions" || systemobjectName == "Notes" || systemobjectName == "Summary" || systemobjectName == "Terms") {
            var CourseItemDescription = $("#CourseItemDescription").val();
            CourseItemDescription = MyTrim(CourseItemDescription);
            Encoder.EncodeType = "entity";
            encoded = RemoveCommaForAddItem(CourseItemDescription);
            var encoded = Encoder.htmlEncode(encoded);
            var ValidatedEditorValue = removeHTMLTags(CourseItemDescription);
            ValidatedEditorValue = MyTrim(ValidatedEditorValue);
            encoded = RemoveMPercentSign(encoded);
        }
        var Chapter = $("#Chapter").val();
        var Section = $("#Section").val();
        var PageNumber = $("#PageNumber").val();
        CourseItemTitle = MyTrim(CourseItemTitle);
        Chapter = MyTrim(Chapter);
        Section = MyTrim(Section);
        PageNumber = MyTrim(PageNumber);
        if (CourseItemTitle == "") {
            $("#ErrorCourseItemTitle").text("");
            $("#ErrorCourseItemTitle").text("Title Can not be blank !");
            $("#ErrorCourseItemTitle").attr("style", "margin: 0px 0px 0px 0px;line-height:20px; display: block; color: red; font-size: 12px; font-weight: 500;");
            $("#CourseItemTitle").focus();
            document.getElementById("AddItemShare").disabled = false;
            return false;
        }
        else {
            $("#ErrorCourseItemTitle").text("");
            $("#ErrorCourseItemTitle").attr("style", "margin: 0px 0px 0px 0px;line-height:20px; display: none; color: red; font-size: 12px; font-weight: 500;");
            $("#CourseItemDescription").focus();
        }
        if (systemobjectName == "Questions" || systemobjectName == "Notes" || systemobjectName == "Summary" || (systemobjectName == "Terms" && IsCourseHomePage == "1" && IsAdded == "True")) {
            if (ValidatedEditorValue == "") {
                $("#ErrorCourseItemDescription").text("");

                if (systemobjectName == "Terms") {
                    $("#ErrorCourseItemDescription").text("Definition Can not be blank !");
                }
                else {
                    //$("#ErrorCourseItemDescription").text(systemobjectName + " Can not be blank !");
                    $("#ErrorCourseItemDescription").text("Description Can not be blank !");
                }
                $("#ErrorCourseItemDescription").attr("style", "margin: 0px 0px 0px 0px; line-height: 20px; display: block; color: red;font-size: 12px;font-weight: 500;width: 96%;position: relative;left: 10px;top:5px;float:left;");
                $("#CourseItemDescription").focus();
                document.getElementById("AddItemShare").disabled = false;
                return false;
            }
            else {
                $("#ErrorCourseItemDescription").text("");
                $("#ErrorCourseItemDescription").attr("style", "margin: 0px 0px 0px 0px; line-height: 20px; display: none; color: red;font-size: 12px;font-weight: 500;width: 96%;position: relative;left: 10px;top:5px;float:left;");
                $("#Chapter").focus();
            }
        }

        //Modified by Shweta Patel Date : 22-Mar-2011 
        //1) for Discussion, all three is optional
        //2) For other items, any one is required
        //3) If section inputted then we need to ask to input chapter also and if only page number then chapter and section will be optional

        if (Chapter == "")
            Chapter = 0;

        if (Section == "")
            Section = 0;

        if (PageNumber == "")
            PageNumber = 0;


        if (systemobjectName != "Discussion") {
            if ((Chapter == 0) && (Section == 0) && (PageNumber == 0)) {
                $("#ErrorChapter").text("");
                $("#ErrorChapter").text("Please input any of Chapter, Section and PageNumber !");
                $("#ErrorChapter").attr("style", "margin: 0px 0px 0px 0px; line-height: 20px; display: block; color: red;font-size: 12px;font-weight: 500;width: 96%;position: relative;left: 10px;top:5px;float:left;");
                $("#Chapter").focus();
                document.getElementById("AddItemShare").disabled = false;
                return false;
            }
        }

        if (Chapter != 0) {
            if (ChapterValidation() == false) {
                $("#ErrorChapter").text("");
                $("#ErrorChapter").text("Chapter only accepts digits !");
                $("#ErrorChapter").attr("style", "margin: 0px 0px 0px 0px; line-height: 20px; display: block; color: red;font-size: 12px;font-weight: 500;width: 96%;position: relative;left: 10px;top:5px;float:left;");
                $("#Chapter").focus();
                document.getElementById("AddItemShare").disabled = false;
                return false;
            }
        }

        if (Section != 0) {
            if (SectionValidation() == false) {
                $("#ErrorChapter").text("");
                $("#ErrorChapter").text("Section only accepts digits !");
                $("#ErrorChapter").attr("style", "margin: 0px 0px 0px 0px; line-height: 20px; display: block; color: red;font-size: 12px;font-weight: 500;width: 96%;position: relative;left: 10px;top:5px;float:left;");
                $("#Section").focus();
                document.getElementById("AddItemShare").disabled = false;
                return false;
            }
            else {
                if (Chapter == 0) {
                    $("#ErrorChapter").text("");
                    $("#ErrorChapter").text("For Section, Chapter is required. Please input Chapter !");
                    $("#ErrorChapter").attr("style", "margin: 0px 0px 0px 0px; line-height: 20px; display: block; color: red;font-size: 12px;font-weight: 500;width: 96%;position: relative;left: 10px;top:5px;float:left;");
                    $("#Chapter").focus();
                    document.getElementById("AddItemShare").disabled = false;
                    return false;
                }
                else {
                    if (ChapterValidation() == false) {
                        $("#ErrorChapter").text("");
                        $("#ErrorChapter").text("Chapter only accepts digits !");
                        $("#ErrorChapter").attr("style", "margin: 0px 0px 0px 0px; line-height: 20px; display: block; color: red;font-size: 12px;font-weight: 500;width: 96%;position: relative;left: 10px;top:5px;float:left;");
                        $("#Chapter").focus();
                        document.getElementById("AddItemShare").disabled = false;
                        return false;
                    }
                }
            }
        }

        if (PageNumber != 0) {
            if (PageNoValidation() == false) {
                $("#ErrorChapter").text("");
                $("#ErrorChapter").text("Page Number only accepts digits !");
                $("#ErrorChapter").attr("style", "margin: 0px 0px 0px 0px; line-height: 20px; display: block; color: red;font-size: 12px;font-weight: 500;width: 96%;position: relative;left: 10px;top:5px;float:left;");
                $("#PageNumber").focus();
                document.getElementById("AddItemShare").disabled = false;
                return false;
            }
        }
        //End modification

        $("#ErrorChapter").text("");
        $("#ErrorChapter").attr("style", "display: none;");
        $("#ErrorCourseItemTitle").text("");
        $("#ErrorCourseItemTitle").attr("style", "display: none;");
        $("#ErrorCourseItemDescription").text("");
        $("#ErrorCourseItemDescription").attr("style", "display: none;");

        $("#ResultsSucess").text("");
        $("#ResultsSucess").html("<img src='../../Images/loading.gif' style='height: 17px; width: 17px;'/> Please Wait....");
        $("#ResultsSucess").attr("style", "display: block; color: Green; margin: 0px 20spx; font-size: 12px; font-weight: 700;");
        $.post(
        url = ActionURL,
        { CourseItemID: CourseItemID, CourseID: CourseID, CourseItemTitle: CourseItemTitle, ItemDesc: encoded, Chapter: Chapter, Section: Section, PageNumber: PageNumber, systemobjectName: systemobjectName, AccountID: AccountID },
        function (data) {
            //ReloadPage(CourseItemID, CourseID, ActionReloadURL, systemobjectName, IsAdded, IsCourseHomePage);
            $("#ResultsSucess").text("");
            $("#ResultsSucess").text(systemobjectName + " successfully updated.");
            $("#ResultsSucess").attr("style", "display: block; color: Green; margin: 0pt 10px; font-size: 13px; font-weight: 700;");
            document.getElementById("AddItemShare").disabled = false;
            NewPageReload(CourseItemID, systemobjectName, CourseID);
        }
    );
    }
    else {
        // Login Check Else Part
        if ($("#LoginCheckAlert")) {
            $("#LoginCheckAlert").remove();
        }
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
}

function NewPageReload(CourseItemID, systemobjectName, CourseID) {
    var RootPath = GetRootPathJS();
    var ActionReloadURL = "";
    ActionReloadURL = RootPath + "CourseHome/CourseHome?CourseID=" + CourseID + "&IsTopVoted=0&PageNumber=1";
    if (systemobjectName == "Discussion") {
        if (CourseItemID == "0") {
            ActionReloadURL = ActionReloadURL + "&Type=D&WID=0"
        }
        if (CourseItemID > 0) {
            ActionReloadURL = ActionReloadURL + "&Type=D&WID=" + CourseItemID + "&IsLoadInRightPane=1";
        }
        window.document.location.href = ActionReloadURL;
    }
}


function ReloadPage(CourseItemID, CourseID, ActionReloadURL, systemobjectName, IsAdded, IsCourseHomePage) {
    if (IsAdded == "True") {
        // Course Home Page
        var ActionReloadURL = "";
        if (window.parent.document.getElementById("CourseHomePageNumber") != undefined) {
            var PageNumber = window.parent.document.getElementById("CourseHomePageNumber").value;
        }
        else {
            var PageNumber = "1";
        }
        var ClassName = window.parent.document.getElementById("lnkTopVoted").className;
        ClassName = MyTrim(ClassName);
        if (ClassName == "faceblack") {
            ActionReloadURL = "/CourseHome/CourseHome?CourseID=" + CourseID + "&IsEditedAddItem=1" + "&IsTopVoted=1" + "&PageNumber=" + PageNumber;
        }
        else {
            ActionReloadURL = "/CourseHome/CourseHome?CourseID=" + CourseID + "&IsEditedAddItem=1" + "&IsTopVoted=0" + "&PageNumber=" + PageNumber;
        }
        $.post(
        url = ActionReloadURL,
        function (data) {
            $("#CourseHomePage").html(data);

            //Added by Shweta Patel Date : 22-Mar-2011 Desc: Resolve Issue(add item window is still showing after item has been added. make like fb)s
            if ($("#lnkEdit").hasClass("tab-link-active")) {
                $("#lnkEdit").removeClass("tab-link-active");
                $("#lnkEdit").addClass("tab-link-normal");
            }
            if ($("#lnkEdit1").hasClass("tab-link-active")) {
                $("#lnkEdit1").removeClass("tab-link-active");
                $("#lnkEdit1").addClass("tab-link-normal");
            }
            if ($("#lnkEdit2").hasClass("tab-link-active")) {
                $("#lnkEdit2").removeClass("tab-link-active");
                $("#lnkEdit2").addClass("tab-link-normal");
            }
            if ($("#lnkEdit3").hasClass("tab-link-active")) {
                $("#lnkEdit3").removeClass("tab-link-active");
                $("#lnkEdit3").addClass("tab-link-normal");
            }
            if ($("#lnkEdit4").hasClass("tab-link-active")) {
                $("#lnkEdit4").removeClass("tab-link-active");
                $("#lnkEdit4").addClass("tab-link-normal");
            }

            $("#dialog").dialog("close");
        }
    );
        return false;
    }
    else if (systemobjectName == "Questions") {
        // load Question Control
        var RootPath = GetRootPathJS();
        if (IsCourseHomePage == "1") {
            //Load CourseHomePage and Iframe
            if (document.getElementById("ChildControlForCheck") != undefined) {
                if (document.getElementById("ChildCourseItemID") != undefined) {
                    var ChildCourseItemIDValue = $("#ChildCourseItemID").val();
                    var FRSC = RootPath + "Answer/GetChildByCourseItemID?AnswerID=" + ChildCourseItemIDValue + "&IsLoadInRightPane=1" + "&SysObjectId=5";
                }
            }
            else {
                var FRSC = RootPath + "Question/QuestionByQuestionID?QID=" + CourseItemID + "&IsLoadInRightPane=1" + "&SysObjectId=4";
            }
            var ActionReloadURlLeftPanel = "";
            if (window.parent.document.getElementById("CourseHomePageNumber") != undefined) {
                var PageNumber = window.parent.document.getElementById("CourseHomePageNumber").value;
            }
            else {
                var PageNumber = "1";
            }
            var ClassName = window.parent.document.getElementById("lnkTopVoted").className;
            ClassName = MyTrim(ClassName);
            if (ClassName == "faceblack") {
                ActionReloadURlLeftPanel = "/CourseHome/CourseHome?CourseID=" + CourseID + "&IsEditedAddItem=1" + "&IsTopVoted=1" + "&PageNumber=" + PageNumber;
            }
            else {
                ActionReloadURlLeftPanel = "/CourseHome/CourseHome?CourseID=" + CourseID + "&IsEditedAddItem=1" + "&IsTopVoted=0" + "&PageNumber=" + PageNumber;
            }
            $.post(
                url = ActionReloadURlLeftPanel,
                function (CourseHomeData) {
                    $('#CourseHomePage', window.parent.document).html(CourseHomeData);
                    if ($("#frmItemDetails")) {
                        window.parent.document.getElementById("frmItemDetails").setAttribute("src", FRSC);
                    }
                }
             );
            return false;
        }
        else {
            //Load CourseDeatil Page
            if (document.getElementById("ChildControlForCheck") == undefined) {
                $.post(
                url = ActionReloadURL,
                { QID: CourseItemID, IsLoadInRightPane: 1 },
                function (data) {
                    //$("#CourseItemDetailLoadPage").html(data);
                    $("#dialog").dialog("destroy");
                    $("#dialog").remove();
                    $("#delete").dialog("destroy");
                    $("#delete").remove();
                    $("#deleteComment").dialog("destroy");
                    $("#deleteComment").remove();
                    $("#CourseItemDetailLoadPage").html(data);
                }
            );
                return false;
            }
            else {
                if (document.getElementById("ChildCourseItemID") != undefined) {
                    var ChildCourseItemIDValue = $("#ChildCourseItemID").val();
                    var LoadAnswerQuestion = RootPath + "Answer/GetChildByCourseItemID?AnswerID=" + ChildCourseItemIDValue + "&SysObjectId=5&CourseID=" + CourseID + "&Title=&IsEditedAddItem=1";
                    $.post(
                    url = LoadAnswerQuestion,
                    function (data) {
                        $("#dialog").dialog("destroy");
                        $("#dialog").remove();
                        $("#delete").dialog("destroy");
                        $("#delete").remove();
                        $("#deleteComment").dialog("destroy");
                        $("#deleteComment").remove();
                        $("#CoruseItemChildControl").html(data);
                    }
                );
                    return false;
                }
            }
        }
    }
    else if (systemobjectName == "Notes") {
        if (IsCourseHomePage == "1") {
            // Load CourseHomePage and Iframe
            var RootPath = GetRootPathJS();
            var FRSC = RootPath + "Note/NoteByNoteID?NID=" + CourseItemID + "&IsLoadInRightPane=1" + "&SysObjectId=10";
            var ActionReloadURlLeftPanel = "";
            if (window.parent.document.getElementById("CourseHomePageNumber") != undefined) {
                var PageNumber = window.parent.document.getElementById("CourseHomePageNumber").value;
            }
            else {
                var PageNumber = "1";
            }
            var ClassName = window.parent.document.getElementById("lnkTopVoted").className;
            ClassName = MyTrim(ClassName);
            if (ClassName == "faceblack") {
                ActionReloadURlLeftPanel = "/CourseHome/CourseHome?CourseID=" + CourseID + "&IsEditedAddItem=1" + "&IsTopVoted=1" + "&PageNumber=" + PageNumber;
            }
            else {
                ActionReloadURlLeftPanel = "/CourseHome/CourseHome?CourseID=" + CourseID + "&IsEditedAddItem=1" + "&IsTopVoted=0" + "&PageNumber=" + PageNumber;
            }
            $.post(
                url = ActionReloadURlLeftPanel,
                function (CourseHomeData) {
                    $('#CourseHomePage', window.parent.document).html(CourseHomeData);
                    if ($("#frmItemDetails")) {
                        window.parent.document.getElementById("frmItemDetails").setAttribute("src", FRSC);
                    }
                }
             );
            return false;
        }
        else {
            //Load CourseItem Detail Page
            $.post(
                url = ActionReloadURL,
                 { NID: CourseItemID },
                function (data) {
                    $("#dialog").dialog("destroy");
                    $("#dialog").remove();
                    $("#delete").dialog("destroy");
                    $("#delete").remove();
                    $("#deleteComment").dialog("destroy");
                    $("#deleteComment").remove();
                    $("#CourseItemDetailLoadPage").html(data);
                }
            );
            return false;
        }
    }
    else if (systemobjectName == "Summary") {
        if (IsCourseHomePage == "1") {
            // Load CourseHomePage and Iframe
            var RootPath = GetRootPathJS();
            var FRSC = RootPath + "Summary/SummaryBySummaryID?SID=" + CourseItemID + "&IsLoadInRightPane=1" + "&SysObjectId=14";
            var ActionReloadURlLeftPanel = "";
            if (window.parent.document.getElementById("CourseHomePageNumber") != undefined) {
                var PageNumber = window.parent.document.getElementById("CourseHomePageNumber").value;
            }
            else {
                var PageNumber = "1";
            }
            var ClassName = window.parent.document.getElementById("lnkTopVoted").className;
            ClassName = MyTrim(ClassName);
            if (ClassName == "faceblack") {
                ActionReloadURlLeftPanel = "/CourseHome/CourseHome?CourseID=" + CourseID + "&IsEditedAddItem=1" + "&IsTopVoted=1" + "&PageNumber=" + PageNumber;
            }
            else {
                ActionReloadURlLeftPanel = "/CourseHome/CourseHome?CourseID=" + CourseID + "&IsEditedAddItem=1" + "&IsTopVoted=0" + "&PageNumber=" + PageNumber;
            }
            $.post(
                url = ActionReloadURlLeftPanel,
                function (CourseHomeData) {
                    $('#CourseHomePage', window.parent.document).html(CourseHomeData);
                    if ($("#frmItemDetails")) {
                        window.parent.document.getElementById("frmItemDetails").setAttribute("src", FRSC);
                    }
                }
             );
            return false;
        }
        else {
            //Load CourseItem Detail Page
            $.post(
                url = ActionReloadURL,
                 { SID: CourseItemID },
                function (data) {
                    $("#dialog").dialog("destroy");
                    $("#dialog").remove();
                    $("#delete").dialog("destroy");
                    $("#delete").remove();
                    $("#deleteComment").dialog("destroy");
                    $("#deleteComment").remove();
                    $("#CourseItemDetailLoadPage").html(data);
                }
            );
            return false;
        }
    }
    else if (systemobjectName == "Discussion") {
        if (IsCourseHomePage == "1") {
            // Load CourseHomePage and Iframe
            var RootPath = GetRootPathJS();
            var FRSC = RootPath + "Discussion/DiscussionByDiscussionID?DID=" + CourseItemID + "&IsLoadInRightPane=1" + "&SysObjectId=7";
            var ActionReloadURlLeftPanel = "";
            if (window.parent.document.getElementById("CourseHomePageNumber") != undefined) {
                var PageNumber = window.parent.document.getElementById("CourseHomePageNumber").value;
            }
            else {
                var PageNumber = "1";
            }
            var ClassName = window.parent.document.getElementById("lnkTopVoted").className;
            ClassName = MyTrim(ClassName);
            if (ClassName == "faceblack") {
                ActionReloadURlLeftPanel = "/CourseHome/CourseHome?CourseID=" + CourseID + "&IsEditedAddItem=1" + "&IsTopVoted=1" + "&PageNumber=" + PageNumber;
            }
            else {
                ActionReloadURlLeftPanel = "/CourseHome/CourseHome?CourseID=" + CourseID + "&IsEditedAddItem=1" + "&IsTopVoted=0" + "&PageNumber=" + PageNumber;
            }
            $.post(
                url = ActionReloadURlLeftPanel,
                function (CourseHomeData) {
                    $('#CourseHomePage', window.parent.document).html(CourseHomeData);
                    if ($("#frmItemDetails")) {
                        window.parent.document.getElementById("frmItemDetails").setAttribute("src", FRSC);
                    }
                }
             );
            return false;
        }
        else {
            //Load CourseItem Detail Page
            $.post(
                url = ActionReloadURL,
                { DID: CourseItemID },
                function (data) {
                    $("#dialog").dialog("destroy");
                    $("#dialog").remove();
                    $("#delete").dialog("destroy");
                    $("#delete").remove();
                    $("#deleteComment").dialog("destroy");
                    $("#deleteComment").remove();
                    $("#CourseItemDetailLoadPage").html(data);
                }
            );
            return false;
        }
    }
    else if (systemobjectName == "Terms") {
        if (IsCourseHomePage == "1") {
            // Load CourseHomePage and Iframe
            var RootPath = GetRootPathJS();
            if (document.getElementById("ChildControlForCheck") != undefined) {
                if (document.getElementById("ChildCourseItemID") != undefined) {
                    var ChildCourseItemIDValue = $("#ChildCourseItemID").val();
                    var FRSC = RootPath + "Answer/GetChildByCourseItemID?AnswerID=" + ChildCourseItemIDValue + "&IsLoadInRightPane=1" + "&SysObjectId=9";
                }
            }
            else {
                var FRSC = RootPath + "Terms/TermByTermID?TID=" + CourseItemID + "&IsLoadInRightPane=1" + "&SysObjectId=8";
            }
            //var FRSC = RootPath + "Terms/TermByTermID?TID=" + CourseItemID + "&IsLoadInRightPane=1" + "&SysObjectId=8";
            var ActionReloadURlLeftPanel = "";
            if (window.parent.document.getElementById("CourseHomePageNumber") != undefined) {
                var PageNumber = window.parent.document.getElementById("CourseHomePageNumber").value;
            }
            else {
                var PageNumber = "1";
            }
            var ClassName = window.parent.document.getElementById("lnkTopVoted").className;
            ClassName = MyTrim(ClassName);
            if (ClassName == "faceblack") {
                ActionReloadURlLeftPanel = "/CourseHome/CourseHome?CourseID=" + CourseID + "&IsEditedAddItem=1" + "&IsTopVoted=1" + "&PageNumber=" + PageNumber;
            }
            else {
                ActionReloadURlLeftPanel = "/CourseHome/CourseHome?CourseID=" + CourseID + "&IsEditedAddItem=1" + "&IsTopVoted=0" + "&PageNumber=" + PageNumber;
            }
            $.post(
                url = ActionReloadURlLeftPanel,
                function (CourseHomeData) {
                    $('#CourseHomePage', window.parent.document).html(CourseHomeData);
                    if ($("#frmItemDetails")) {
                        window.parent.document.getElementById("frmItemDetails").setAttribute("src", FRSC);
                    }
                }
             );
            return false;
        }
        else {
            //Load CourseItem Detail Page
            if (document.getElementById("ChildControlForCheck") == undefined) {
                $.post(
                url = ActionReloadURL,
                { TID: CourseItemID },
                function (data) {
                    $("#dialog").dialog("destroy");
                    $("#dialog").remove();
                    $("#delete").dialog("destroy");
                    $("#delete").remove();
                    $("#deleteComment").dialog("destroy");
                    $("#deleteComment").remove();
                    $("#CourseItemDetailLoadPage").html(data);
                }
            );
                return false;
            }
            else {
                if (document.getElementById("ChildCourseItemID") != undefined) {
                    var ChildCourseItemIDValue = $("#ChildCourseItemID").val();
                    var LoadAnswerQuestion = GetRootPathJS() + "Answer/GetChildByCourseItemID?AnswerID=" + ChildCourseItemIDValue + "&SysObjectId=9&CourseID=" + CourseID + "&Title=&IsEditedAddItem=1";
                    $.post(
                    url = LoadAnswerQuestion,
                    function (data) {
                        $("#dialog").dialog("destroy");
                        $("#dialog").remove();
                        $("#delete").dialog("destroy");
                        $("#delete").remove();
                        $("#deleteComment").dialog("destroy");
                        $("#deleteComment").remove();
                        $("#CoruseItemChildControl").html(data);
                    }
                );
                    return false;
                }
            }
        }
    }
    else {
        // Do Nothing... Updated
    }
}

function AddChildDetails(DetailPageURL) {
    window.parent.document.location.href = DetailPageURL;
    window.close();
}


function CallInvitationRequest() {
    var FirstName = $("#FirstName").val();
    var LastName = $("#LastName").val();
    var Email = $("#SchoolEmail").val();
    var Gender = document.getElementById("Gender").options[document.getElementById("Gender").selectedIndex].value;
    FirstName = MyTrim(FirstName);
    LastName = MyTrim(LastName);
    Email = MyTrim(Email);
    Gender = MyTrim(Gender);
    $("#InvitationSummaryDiv").attr("style", "display: none;");
    $("#ErrorReport").attr("style", "display: none;");
    document.getElementById("InvitationLink").disabled = false;
    if (FirstName == "" || FirstName == null) {
        $("#InvitationSummaryDiv").attr("style", "display: none;");
        $("#ErrorReport").attr("style", "display: block;");
        $("#lblErrorStatus").text("");
        $("#lblErrorStatus").attr("style", "font-size: 12px;");
        $("#lblErrorStatus").text("First Name Can not be blank !");
        document.getElementById("InvitationLink").disabled = false;
        //$("#lblErrorFirstName").attr("style", "display: block; color: Red; margin: 0pt 10px; font-size: 12px; font-weight: 500;");
        return false;
    } else if (LastName == "" || LastName == null) {
        $("#InvitationSummaryDiv").attr("style", "display: none;");
        $("#ErrorReport").attr("style", "display: block;");
        $("#lblErrorStatus").text("");
        $("#lblErrorStatus").attr("style", "font-size: 12px;");
        $("#lblErrorStatus").text("Last Name Can not be blank !");
        document.getElementById("InvitationLink").disabled = false;
        //$("#lblErrorLastName").attr("style", "display: block; color: Red; margin: 0pt 10px; font-size: 12px; font-weight: 500;");
        return false;
    } else if (Email == "" || Email == null) {
        $("#InvitationSummaryDiv").attr("style", "display: none;");
        $("#ErrorReport").attr("style", "display: block;");
        $("#lblErrorStatus").text("");
        $("#lblErrorStatus").attr("style", "font-size: 12px;");
        $("#lblErrorStatus").text("Email Can not be blank !");
        document.getElementById("InvitationLink").disabled = false;
        //$("#lblErrorEmail").attr("style", "display: block; color: Red; margin: 0pt 10px; font-size: 12px; font-weight: 500;");
        return false;
    } else if (EmailValidation() == false) {
        $("#InvitationSummaryDiv").attr("style", "display: none;");
        $("#ErrorReport").attr("style", "display: block;");
        $("#lblErrorStatus").text("");
        $("#lblErrorStatus").attr("style", "font-size: 12px;");
        $("#lblErrorStatus").text("Invalid Email !");
        document.getElementById("InvitationLink").disabled = false;
        //$("#lblErrorEmail").attr("style", "display: block; color: Red; margin: 0pt 10px; font-size: 12px; font-weight: 500;");
    }
    else if (Gender == "0" || Gender == null) {
        $("#InvitationSummaryDiv").attr("style", "display: none;");
        $("#ErrorReport").attr("style", "display: block;");
        $("#lblErrorStatus").text("");
        $("#lblErrorStatus").attr("style", "font-size: 12px;");
        $("#lblErrorStatus").text("Please Select Gender !");
        document.getElementById("InvitationLink").disabled = false;
        //$("#lblErrorGender").attr("style", "display: block; color: Red; margin: 0pt 10px; font-size: 12px; font-weight: 500;");
        return false;
    }
    else {
        if ((FirstName != "" || FirstName != null) && (LastName != "" || LastName != null) && (Email != "" || Email != null) && (Gender != "0" || Gender != null)) {
            // display all error lable and enter into db
            document.getElementById("InvitationLink").disabled = true;
            $("#ErrorReport").attr("style", "display: block;");
            $("#lblErrorStatus").text("");
            $("#lblErrorStatus").attr("style", "font-size: 12px;");
            $("#lblErrorStatus").text("Please Wait....");
            // Now Make Call to Db to Check whether Email exists in db or not?
            var ActionCheckEmailURL = "/Invitation/CheckEmail"
            $.get(
            url = ActionCheckEmailURL,
                { SchoolEmail: Email },
                function (data) {
                    if (parseInt(data) > 0) {
                        $("#InvitationSummaryDiv").attr("style", "display: none;");
                        $("#ErrorReport").attr("style", "display: block;");
                        $("#lblErrorStatus").text("");
                        $("#lblErrorStatus").attr("style", "font-size: 12px;");
                        $("#lblErrorStatus").text("This email is already stored in our system for invitation request... !");
                        document.getElementById("InvitationLink").disabled = false;
                        //$("#lblErrorStatus").attr("style", "display: block; color: Red; margin: 0pt 10px; font-size: 12px; font-weight: 500;");
                        return false;
                    } else if (parseInt(data) == 0) {
                        var SendInvitationRequestURL = "/Invitation/SendInvitationRequest";
                        $.post(
                        url = SendInvitationRequestURL,
                        { FirstName: FirstName, LastName: LastName, SchoolEmail: Email, Gender: Gender },
                        function (SendInvitationResult) {
                            //alert(SendInvitationResult);
                            if (SendInvitationResult == "Error") {
                                $("#InvitationSummaryDiv").attr("style", "display: none;");
                                $("#ErrorReport").attr("style", "display: block;");
                                $("#lblErrorStatus").text("");
                                $("#lblErrorStatus").attr("style", "font-size: 12px;");
                                $("#lblErrorStatus").text("There was an system error please try later....!");
                                document.getElementById("InvitationLink").disabled = false;
                                //$("#lblErrorStatus").attr("style", "display: block; color: Red; margin: 0pt 10px; font-size: 12px; font-weight: 500;");
                                return false;
                            }
                            else {
                                $("#ErrorReport").attr("style", "display: none;");
                                $("#lblErrorStatus").text("");
                                $("#InvitationSummaryDiv").attr("style", "display: block;");
                                $("#lblStatus").attr("style", "font-size: 12px;");
                                $("#lblStatus").text("The invitation request has been sent to your email.");
                                document.getElementById("InvitationLink").disabled = false;
                                //$("#lblStatus").attr("style", "display: block; color: Green; margin: 0pt 10px; font-size: 12px; font-weight: 500;");
                                return false;
                            }
                        }
                        );
                    }
                    else {
                        // Do Nothing....
                    }
                }
            );
        }
        else {
            return false;
        }
    }
}

/*function added*/
function ChapterValidation() {

    var chap = $("#Chapter").val();
    chap = MyTrim(chap);
    var emailRegEx = /(^-?\d\d*$)/;
    var status = false;
    if (chap.search(emailRegEx) == -1) {
        status = false;

    }
    else {
        status = true;
    }

    return status;

}

function PageNoValidation() {

    var PageNumber = $("#PageNumber").val();
    PageNumber = MyTrim(PageNumber);
    var emailRegEx = /(^-?\d\d*$)/;
    var status = false;
    if (PageNumber.search(emailRegEx) == -1) {
        status = false;

    }
    else {
        status = true;
    }

    return status;

}

function SectionValidation() {

    var Section = $("#Section").val();
    Section = MyTrim(Section);
    var emailRegEx = /(^-?\d\d*$)/;
    var status = false;
    if (Section.search(emailRegEx) == -1) {
        status = false;

    }
    else {
        status = true;
    }

    return status;

}
/*end*/

function EmailValidation() {
    var SchoolEmail = $("#SchoolEmail").val();
    SchoolEmail = MyTrim(SchoolEmail);
    var status = false;
    var emailRegEx = /^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i;
    if (SchoolEmail.search(emailRegEx) == -1) {
        status = false;
    }
    else {
        status = true;
    }

    return status;
}


function SearchCourse(AID) {
    if (Get_Cookie("ID") != false && Get_Cookie("ID") != null) {
        var Prefix = $("#txtPrefix").val();
        var CourseNumber = $("#txtCourseNumber").val();
        var CourseTitle = $("#txtCourseTitle").val();
        var CourseSection = $("#txtCourseSection").val();
        var School = document.getElementById("ddlSchoolName").options[document.getElementById("ddlSchoolName").selectedIndex].value;
        var Term = document.getElementById("ddlTerm").options[document.getElementById("ddlTerm").selectedIndex].value;
        var Year = document.getElementById("ddlYear").options[document.getElementById("ddlYear").selectedIndex].value;
        var RootPath = GetRootPathJS();
        var ActionUrl = RootPath + "Courses/CourseList";

        $.post(
        url = ActionUrl,
        { StudentAccountID: AID, Prefix: Prefix, CourseNumber: CourseNumber, CourseTitle: CourseTitle, CourseSection: CourseSection, SchoolID: School, TermID: Term, Year: Year, IsSearch: true },
        function (data) {
            $("#divCouselist").html(data);
        }
    );
    }
    else {
        // Login Check Else Part
        if ($("#LoginCheckAlert")) {
            $("#LoginCheckAlert").remove();
        }
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
}

function ResetField(AID) {
    if (Get_Cookie("ID") != false && Get_Cookie("ID") != null) {
        document.getElementById("txtPrefix").value = "";
        document.getElementById("txtCourseNumber").value = "";
        document.getElementById("txtCourseTitle").value = "";
        document.getElementById("txtCourseSection").value = "";
        document.getElementById("ddlSchoolName").value = "0";
        document.getElementById("ddlTerm").value = "0";
        document.getElementById("ddlYear").value = "0";

        var Prefix = $("#txtPrefix").val();
        var CourseNumber = $("#txtCourseNumber").val();
        var CourseTitle = $("#txtCourseTitle").val();
        var CourseSection = $("#txtCourseSection").val();
        var School = document.getElementById("ddlSchoolName").options[document.getElementById("ddlSchoolName").selectedIndex].value;
        var Term = document.getElementById("ddlTerm").options[document.getElementById("ddlTerm").selectedIndex].value;
        var Year = document.getElementById("ddlYear").options[document.getElementById("ddlYear").selectedIndex].value;
        var RootPath = GetRootPathJS();
        var ActionUrl = RootPath + "Courses/CourseList";

        $.post(
        url = ActionUrl,
        { StudentAccountID: AID, Prefix: Prefix, CourseNumber: CourseNumber, CourseTitle: CourseTitle, CourseSection: CourseSection, SchoolID: School, TermID: Term, Year: Year, IsSearch: true },
        function (data) {
            $("#divCouselist").html(data);
        }
    );
    }
    else {
        // Login Check Else Part
        if ($("#LoginCheckAlert")) {
            $("#LoginCheckAlert").remove();
        }
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
}

function AddCourse(AccountID, CourseID) {
    if (Get_Cookie("ID") != false && Get_Cookie("ID") != null) {
        $("#dialog").dialog("destroy");

        var Data = "<div style='padding: 10px 6px;'><p>Are you sure you want to add this course in your profile?</p></div><div style='padding: 10px 10px;'><input type='button' class='ConfirmBtn' id='btnYes' value='Yes' />&nbsp;<input type='button' id='btnNo' class='ConfirmBtn' value='No' /></div>";

        jQuery("#dialog").dialog({
            bgiframe: true, autoOpen: false, width: 335, modal: true
        });

        $("#dialog").html(Data);

        jQuery('#dialog').dialog('open');

        $("#btnNo").focus();

        var RootPath = GetRootPathJS();
        $("#btnYes").click(function () {
            var ActionUrl = RootPath + "Courses/SaveStudentCourse";
            $.post(
            url = ActionUrl,
            { AccountID: AccountID, CourseID: CourseID },
            function (data) {
            SearchCourse(AccountID);
            $("#dialog").dialog("destroy");
            window.location.href = RootPath + "CourseHome/CourseHome?CourseID=" + CourseID;
            }
            );
           /* window.location.href = RootPath + "CourseWalkthrough/Verfiy_Course?CourseID=" + CourseID; */
        });

        $("#btnNo").click(function () {
            jQuery('#dialog').dialog('close');
        });
    }
    else {
        // Login Check Else Part
        if ($("#LoginCheckAlert")) {
            $("#LoginCheckAlert").remove();
        }
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
}

function removeHTMLTags(myString) {
    var strInputCode = myString;
    /* 
    This line is optional, it replaces escaped brackets with real ones, 
    i.e. < is replaced with < and > is replaced with >
    */
    strInputCode = RemoveAllWhiteSpace(strInputCode, "&nbsp;");
    strInputCode = strInputCode.replace(/&(lt|gt);/g, function (strMatch, p1) {
        return (p1 == "lt") ? "<" : ">";
    });
    var strTagStrippedText = strInputCode.replace(/<\/?[^>]+(>|$)/g, "");
    //alert("Output text:\n" + strTagStrippedText);
    return strTagStrippedText;
}

function RemoveAllWhiteSpace(Source, stringToFind) {
    var temp = Source;
    var index = temp.indexOf(stringToFind);
    while (index != -1) {
        temp = temp.replace(stringToFind, "");
        index = temp.indexOf(stringToFind);
    }
    //alert(temp);
    return temp;
}



function EditProfile(IsFaceBook) {
    if (Get_Cookie("ID") != false && Get_Cookie("ID") != null) {
        var FaceBook = IsFaceBook;
        var FirstName = $("#txtFirstName").val();
        var LastName = $("#txtLastName").val();
        var PrimaryEmail = $("#txtPrimaryEmail").val();
        var SecondaryEmail = $("#txtSecondaryEmail").val();
        var OldPassword = $("#txtOldPassword").val();
        var NewPassword = $("#txtNewPassword").val();
        var ConfirmPassword = $("#txtConfirmPassword").val();
        if (FirstName == null || FirstName == "") {
            $("#lblFirstName").text("First Name is require.");
            return false;
        }
        if (LastName == null || LastName == "") {
            $("#lblLastName").text("Last Name is require.");
            $("#lblFirstName").text("");
            return false;
        }
        if (PrimaryEmail == null || PrimaryEmail == "") {
            $("#lblPrimaryEmail").text("Communication E-mail is require.");
            $("#lblLastName").text("");
            $("#lblFirstName").text("");
            return false;
        }
        if (FaceBook == 'False') {
            if (NewPassword.length != 0) {
                if (NewPassword.length < 6) {
                    $("#lblnomatch").text("New password is required to be minimum of 6 characters in length.");
                    $("#lblPrimaryEmail").text("");
                    $("#lblLastName").text("");
                    $("#lblFirstName").text("");
                    return false;

                }
            }
            if (NewPassword != ConfirmPassword) {
                $("#lblnomatch").text("New Password and confirm password does not match.");
                $("#lblPrimaryEmail").text("");
                $("#lblLastName").text("");
                $("#lblFirstName").text("");
                return false;
            }
        }
        if (ValidatedEmail(PrimaryEmail) == false) {
            $("#lblPrimaryEmail").text("Invalid Communication Email.");
            $("#lblnomatch").text("");
            $("#lblLastName").text("");
            $("#lblFirstName").text("");
            return false;
        }
        if (SecondaryEmail != null || SecondaryEmail != "") {
            if (ValidatedEmail(SecondaryEmail) == false) {
                $("#lblSecondaryEmail").text("Invalid School Email.");
                $("#lblPrimaryEmail").text("");
                $("#lblnomatch").text("");
                $("#lblPrimaryEmail").text("");
                $("#lblLastName").text("");
                $("#lblFirstName").text("");
                return false;
            }
        }
        $("#lblnomatch").text("");
        $("#lblPrimaryEmail").text("");
        $("#lblLastName").text("");
        $("#lblFirstName").text("");
        var RootPath = GetRootPathJS();
        var ActionUrl = RootPath + "Profile/SaveProfile";
        $.post(
        url = ActionUrl,
        { FirstName: FirstName, LastName: LastName, PrimaryEmail: PrimaryEmail, SecondaryEmail: SecondaryEmail, OldPassword: OldPassword, NewPassword: NewPassword, ConfirmPassword: ConfirmPassword },
        function (data) {
            $("#lblmsg").text("");
            //$("#lblmsg").text("Profile is Updated Successfully.");
            $("#lblmsg").text("Profile successfully updated.");
            // window.location.href = RootPath + "Profile/EditProfile";
        }
    );
    }
    else {
        // Login Check Else Part
        if ($("#LoginCheckAlert")) {
            $("#LoginCheckAlert").remove();
        }
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
}

function CancelEditProfile() {
    var RootPath = GetRootPathJS();
    window.location.href = RootPath + "Profile/EditProfile";
}

function ValidatedEmail(ID) {
    var SchoolEmail = ID;
    SchoolEmail = MyTrim(SchoolEmail);
    var status = false;
    var emailRegEx = /^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/i;
    if (SchoolEmail.search(emailRegEx) == -1) {
        status = false;
    }
    else {
        status = true;
    }

    return status;
}

function goToLogin() {
    window.location.href = "../Login/Login";
}


function GoToProfile(CourseID) {
    if (Get_Cookie("ID") != false && Get_Cookie("ID") != null) {
        window.location.href = "../Profile/CurrentCourses";
    }
    else {
        // Login Check Else Part
        if ($("#LoginCheckAlert")) {
            $("#LoginCheckAlert").remove();
        }
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
}

function GoToHome(HomePageURL) {
    window.location.href = HomePageURL;
}

function GoToSearch() {
    if (Get_Cookie("ID") != false && Get_Cookie("ID") != null) {
        window.location.href = "../Courses/SearchCourse";
    }
    else {
        // Login Check Else Part
        if ($("#LoginCheckAlert")) {
            $("#LoginCheckAlert").remove();
        }
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
}

function GotoStar(CourseID) {
    if (Get_Cookie("ID") != false && Get_Cookie("ID") != null) {
        window.location.href = "../../Favorite/FavoriteList?CourseID=" + CourseID;
    }
    else {
        // Login Check Else Part
        if ($("#LoginCheckAlert")) {
            $("#LoginCheckAlert").remove();
        }
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
}

function GoToEditProfile() {
    if (Get_Cookie("ID") != false && Get_Cookie("ID") != null) {
        window.location.href = "../Profile/EditProfile";
    }
    else {
        // Login Check Else Part
        if ($("#LoginCheckAlert")) {
            $("#LoginCheckAlert").remove();
        }
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
}

function GoToAssessmentCalendar(AccountID) {
    window.location.href = "../Calendar/MyAssessments" + "?AccountID=" + AccountID;

}

function GoToCalendar(AccountID, CourseID) {
    window.location.href = "../Calendar/CourseAssessments" + "?AccountID=" + AccountID + "&CourseID=" + CourseID;
}


function LTrim(value) {
    var re = /\s*((\S+\s*)*)/;
    return value.replace(re, "$1");
}

// Removes ending whitespaces
function RTrim(value) {
    var re = /((\s*\S+)*)\s*/;
    return value.replace(re, "$1");
}

// Removes leading and ending whitespaces
function MyTrim(value) {
    return LTrim(RTrim(value));
}

// Remove "'" from the string 
function RemoveComma(dataStr) {
    return dataStr.replace(/\'/g, "#||#");
}

function RemoveCommaForAddItem(dataStr) {
    return dataStr.replace(/\'/g, " $%comma ");
}

function RemoveMPercentSign(dataStr) {
    return dataStr.replace(/\&/g, "&amp;");
}

function CourseHomeNextPage(PageNumber, CourseID) {
    if (Get_Cookie("ID") != false && Get_Cookie("ID") != null) {
        var Number = parseInt(PageNumber) + parseInt(1);
        ActionReloadURL = "/CourseHome/CourseHome?CourseID=" + CourseID + "&IsEditedAddItem= 1" + "&IsTopVoted=0" + "&PageNumber=" + Number;
        // Make Now For Temp Paging Logic
        $.post(
        url = ActionReloadURL,
        function (data) {
            $('#CourseHomePage', window.parent.document).html(data);
        });
        /*  Orginal Paging Logic
        if (window.parent.document.getElementById("lnkTopVoted") != undefined) {
        var ActionReloadURL = "";
        var ClassName = window.parent.document.getElementById("lnkTopVoted").className;
        ClassName = MyTrim(ClassName);
        if (ClassName == "faceblack") {
        ActionReloadURL = "/CourseHome/CourseHome?CourseID=" + CourseID + "&IsEditedAddItem= 1" + "&IsTopVoted=1" + "&PageNumber=" + Number;
        }
        else {
        ActionReloadURL = "/CourseHome/CourseHome?CourseID=" + CourseID + "&IsEditedAddItem= 1" + "&IsTopVoted=0" + "&PageNumber=" + Number;
        }
        $.post(
        url = ActionReloadURL,
        function (data) {
        $('#CourseHomePage', window.parent.document).html(data);
        });
        }
        */
    }
    else {
        // Login Check Else Part
        if ($("#LoginCheckAlert")) {
            $("#LoginCheckAlert").remove();
        }
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
}

function CourseHomePreviousPage(PageNumber, CourseID) {
    if (Get_Cookie("ID") != false && Get_Cookie("ID") != null) {
        var Number = parseInt(PageNumber) - parseInt(1);
        ActionReloadURL = "/CourseHome/CourseHome?CourseID=" + CourseID + "&IsEditedAddItem= 1" + "&IsTopVoted=0" + "&PageNumber=" + Number;
        // Make Now For Temp Paging Logic
        $.post(
        url = ActionReloadURL,
        function (data) {
            $('#CourseHomePage', window.parent.document).html(data);
        });
        /*  Orginal Paging Logic
        if (window.parent.document.getElementById("lnkTopVoted") != undefined) {
        var ActionReloadURL = "";
        var ClassName = window.parent.document.getElementById("lnkTopVoted").className;
        ClassName = MyTrim(ClassName);
        if (ClassName == "faceblack") {
        ActionReloadURL = "/CourseHome/CourseHome?CourseID=" + CourseID + "&IsEditedAddItem= 1" + "&IsTopVoted=1" + "&PageNumber=" + Number;
        }
        else {
        ActionReloadURL = "/CourseHome/CourseHome?CourseID=" + CourseID + "&IsEditedAddItem= 1" + "&IsTopVoted=0" + "&PageNumber=" + Number;
        }
        $.post(
        url = ActionReloadURL,
        function (data) {
        $('#CourseHomePage', window.parent.document).html(data);
        });
        }
        */
    }
    else {
        // Login Check Else Part
        if ($("#LoginCheckAlert")) {
            $("#LoginCheckAlert").remove();
        }
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
}

function CallTerms() {
    window.open("../../Common/Terms");
}
function CallAboutCL() {
    window.location.href = "http://www.twitter.com/courselogic";
}

function SearchCourseNextPage(AID, PageNumber) {
    if (Get_Cookie("ID") != false && Get_Cookie("ID") != null) {
        var Number = parseInt(PageNumber) + parseInt(1);
        var Prefix = $("#txtPrefix").val();
        var CourseNumber = $("#txtCourseNumber").val();
        var CourseTitle = $("#txtCourseTitle").val();
        var CourseSection = $("#txtCourseSection").val();
        var School = document.getElementById("ddlSchoolName").options[document.getElementById("ddlSchoolName").selectedIndex].value;
        var Term = document.getElementById("ddlTerm").options[document.getElementById("ddlTerm").selectedIndex].value;
        var Year = document.getElementById("ddlYear").options[document.getElementById("ddlYear").selectedIndex].value;
        var RootPath = GetRootPathJS();
        var ActionUrl = RootPath + "Courses/CourseList?PageNumber=" + Number;
        $.post(
        url = ActionUrl,
        { StudentAccountID: AID, Prefix: Prefix, CourseNumber: CourseNumber, CourseTitle: CourseTitle, CourseSection: CourseSection, SchoolID: School, TermID: Term, Year: Year, IsSearch: true },
        function (data) {
            $("#DivSearchCourse").html(data);
        }
    );
    }
    else {
        // Login Check Else Part
        if ($("#LoginCheckAlert")) {
            $("#LoginCheckAlert").remove();
        }
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
}

function SearchCoursePreviousPage(AID, PageNumber) {
    if (Get_Cookie("ID") != false && Get_Cookie("ID") != null) {
        var Number = parseInt(PageNumber) - parseInt(1);
        var Prefix = $("#txtPrefix").val();
        var CourseNumber = $("#txtCourseNumber").val();
        var CourseTitle = $("#txtCourseTitle").val();
        var CourseSection = $("#txtCourseSection").val();
        var School = document.getElementById("ddlSchoolName").options[document.getElementById("ddlSchoolName").selectedIndex].value;
        var Term = document.getElementById("ddlTerm").options[document.getElementById("ddlTerm").selectedIndex].value;
        var Year = document.getElementById("ddlYear").options[document.getElementById("ddlYear").selectedIndex].value;
        var RootPath = GetRootPathJS();
        var ActionUrl = RootPath + "Courses/CourseList?PageNumber=" + Number;
        $.post(
        url = ActionUrl,
        { StudentAccountID: AID, Prefix: Prefix, CourseNumber: CourseNumber, CourseTitle: CourseTitle, CourseSection: CourseSection, SchoolID: School, TermID: Term, Year: Year, IsSearch: true },
        function (data) {
            $("#DivSearchCourse").html(data);
        }
    );
    }
    else {
        // Login Check Else Part
        if ($("#LoginCheckAlert")) {
            $("#LoginCheckAlert").remove();
        }
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
}

function CreateFlashCardSet(CourseID, AccountID, FlashCardID, EditActionURL) {
    $("#FlashCardEditUpdateID").val();
    $("#FlashCardEditUpdateID").val(FlashCardID);
    $("#DivFlashCardList").css("display", "none");
    $.post(
        url = EditActionURL,
        { CourseID: CourseID, AccountID: AccountID, FlashCardID: FlashCardID },
        function (data) {
            $("#DivFlashCardDetails").css("display", "block");
            $("#DivFlashCardDetails").html(data);
        }
    );
}



function SaveFlashCardSet(CourseID, AccountID, FlashCardID, ActionUrl) {
    var Title = $("#FlashCardTitle").val();
    Title = MyTrim(Title);
    var FlashCardDesc = $("#FlashCardDesc").val();
    FlashCardDesc = MyTrim(FlashCardDesc);
    var FlashCardSubject = $("#FlashCardSubject").val();
    FlashCardSubject = MyTrim(FlashCardSubject);
    var chkVotedUpSel = $('#chkVotedUp').is(':checked');
    var chkFavorite = $('#chkFavorite').is(':checked');
    var chkYourAdded = $('#chkYourAdded').is(':checked');
    var chkAssessment = $('#chkAssessment').is(':checked');
    var chkChapter = $('#chkChapter').is(':checked');
    var SelectedChap = $('#commaseperatedchapters').val();
    var chkDiscussion = $('#chkDiscussion').is(':checked');
    var chkNotes = $('#chkNotes').is(':checked');
    var chkQA = $('#chkQA').is(':checked');
    var chkTD = $('#chkTD').is(':checked');
    var chkSummary = $('#chkSummary').is(':checked');

    if (Title == "") {
        $("#ErrorTitle").text("");
        $("#ErrorTitle").text("Title Can not be blank !");
        $("#ErrorTitle").attr("style", "display: block; color: red; font-size: 12px; font-weight: 500;");
        $("#FlashCardTitle").focus();
        return false;
    }
    if (FlashCardDesc == "") {
        $("#ErrorTitle").text("");
        $("#ErrorTitle").attr("style", "display: none;");
        $("#ErrorDescription").text("");
        $("#ErrorDescription").text("Description Can not be blank !");
        $("#ErrorDescription").attr("style", "display: block; color: red; font-size: 12px; font-weight: 500;");
        $("#FlashCardDesc").focus();
        return false;
    }
    if (Title != "") {
        $("#ErrorTitle").text("");
        $("#ErrorTitle").attr("style", "display: none;");
    }
    if (FlashCardDesc != "") {
        $("#ErrorDescription").text("");
        $("#ErrorDescription").attr("style", "display: none;");
    }
    $.post(
            url = '/Flashcard/GetFlashCardSetSelectionItem',
             { CourseID: CourseID, AccountID: AccountID, VotedUp: chkVotedUpSel, Favorite: chkFavorite, YouAdded: chkYourAdded, Assessment: chkAssessment, IsChapter: chkChapter, CommaSeperatedChapters: SelectedChap, IsNotesSelected: chkNotes, IsQuestionSelected: chkQA, IsTermSelected: chkTD, IsSummarySelected: chkSummary },
             function (FlashCardSetData) {
                 $("#FlashCardSet").html(FlashCardSetData);
             }
            );
    /*
    $.post(
    url = ActionUrl,
    { CourseID: CourseID, AccountID: AccountID, FlashCardID: FlashCardID, FlashCardTitle: Title, FlashCardSubject: FlashCardSubject, FlashCardDescription: FlashCardDesc, VotedUp: chkVotedUpSel, Favorite: chkFavorite, YouAdded: chkYourAdded, Assessment: chkAssessment, IsChapter: chkChapter, CommaSeperatedChapters: SelectedChap, IsNotesSelected: chkNotes, IsQuestionSelected: chkQA, IsTermSelected: chkTD, IsSummarySelected: chkSummary },
    function (data) {
    $.post(
    url = '/Flashcard/GetFlashCardSetSelectionItem',
    { CourseID: CourseID, AccountID: AccountID, VotedUp: chkVotedUpSel, Favorite: chkFavorite, YouAdded: chkYourAdded, Assessment: chkAssessment, IsChapter: chkChapter, CommaSeperatedChapters: SelectedChap, IsNotesSelected: chkNotes, IsQuestionSelected: chkQA, IsTermSelected: chkTD, IsSummarySelected: chkSummary },
    function (FlashCardSetData) {
    $("#FlashCardSet").html(FlashCardSetData);
    }
    );
    });
    //window.location.href = "getflashcardsets?CourseID=" + CourseID;
    */
}

function SaveAndPlay(CourseID, AccountID, ActionURl) {
    var Title = $("#FlashCardTitle").val();
    Title = MyTrim(Title);
    var FlashCardDesc = $("#FlashCardDesc").val();
    FlashCardDesc = MyTrim(FlashCardDesc);
    var FlashCardSubject = $("#FlashCardSubject").val();
    FlashCardSubject = MyTrim(FlashCardSubject);
    var chkVotedUpSel = $('#chkVotedUp').is(':checked');
    var chkFavorite = $('#chkFavorite').is(':checked');
    var chkYourAdded = $('#chkYourAdded').is(':checked');
    var chkAssessment = $('#chkAssessment').is(':checked');
    var chkChapter = $('#chkChapter').is(':checked');
    var SelectedChap = $('#commaseperatedchapters').val();
    var chkDiscussion = $('#chkDiscussion').is(':checked');
    var chkNotes = $('#chkNotes').is(':checked');
    var chkQA = $('#chkQA').is(':checked');
    var chkTD = $('#chkTD').is(':checked');
    var chkSummary = $('#chkSummary').is(':checked');

    var FlashCardID = $("#FlashCardEditUpdateID").val(FlashCardID);

    var checkboxlist = document.getElementsByTagName("input");
    var checkboxid = "";
    var Count = "0";
    for (var i = 0; i < checkboxlist.length; i++) {
        if (checkboxlist[i].type == "checkbox") {
            if (checkboxlist[i].name.search("CourseItemFlashCardSetList") > -1) {
                if (checkboxlist[i].checked) {
                    checkboxid += checkboxlist[i].id + ",";
                    Count++;
                }
            }
        }
    }
    checkboxid = checkboxid.substr(checkboxid, checkboxid.length - 1);
    checkboxid = MyTrim(checkboxid);
    if (Title == "") {
        $("#ErrorTitle").text("");
        $("#ErrorTitle").text("Title Can not be blank !");
        $("#ErrorTitle").attr("style", "display: block; color: red; font-size: 12px; font-weight: 500;");
        $("#FlashCardTitle").focus();
        return false;
    }
    if (FlashCardDesc == "") {
        $("#ErrorTitle").text("");
        $("#ErrorTitle").attr("style", "display: none;");
        $("#ErrorDescription").text("");
        $("#ErrorDescription").text("Description Can not be blank !");
        $("#ErrorDescription").attr("style", "display: block; color: red; font-size: 12px; font-weight: 500;");
        $("#FlashCardDesc").focus();
        return false;
    }
    if (Title != "") {
        $("#ErrorTitle").text("");
        $("#ErrorTitle").attr("style", "display: none;");
    }
    if (FlashCardDesc != "") {
        $("#ErrorDescription").text("");
        $("#ErrorDescription").attr("style", "display: none;");
    }
    if (checkboxid != "") {
        $.post(
    url = ActionURl,
    { CourseID: CourseID, AccountID: AccountID, FlashCardID: FlashCardID, FlashCardTitle: Title, FlashCardSubject: FlashCardSubject, FlashCardDescription: FlashCardDesc, VotedUp: chkVotedUpSel, Favorite: chkFavorite, YouAdded: chkYourAdded, Assessment: chkAssessment, IsChapter: chkChapter, CommaSeperatedChapters: SelectedChap, IsNotesSelected: chkNotes, IsQuestionSelected: chkQA, IsTermSelected: chkTD, IsSummarySelected: chkSummary, TotalItems: Count },
    function (data) {
        var FlashCardID = data;
        $.post(
        url = '/Flashcard/SaveFlashCardSetItem',
        { FlashCardID: FlashCardID, CourseItemID: checkboxid },
        function (data) {
            if (parseInt(data) > 0) {
                window.location.href = GetRootPathJS() + "flashcard/PlayFlashCard?CourseID=" + CourseID + "&FlashCard=" + FlashCardID + "&PageNumber=1&IsBoth=False";
            }
            else {
                window.location.href = GetRootPathJS() + "Flashcard/GetFlashCardSets?CourseID=" + CourseID;
            }
        });
    });
    }
    else {
        $("#ErrorItemSelect").text("");
        $("#ErrorItemSelect").text("Please Selecte any Items !");
        $("#ErrorItemSelect").attr("style", "display: block; color: red; font-size: 12px; font-weight: 500;");
    }
}

function DeleteFlashCard(CourseDI, FlashCard, ActionURL) {
    $('body').append("<div id='FlashCardDelete' title='Confirm'></div>");
    var DeleteCommentConfrim = "<div style='padding: 10px 6px;'><p>Are you sure you want to delete item ?</p></div><div style='padding: 0px 10px;'><input type='button' class='askquebtn' id='btnYesFlash' value='Yes' />&nbsp;<input type='button' id='btnNoFlash' class='askquebtn' value='No' /></div>";
    jQuery("#FlashCardDelete").dialog({
        bgiframe: true, autoOpen: false, width: 235, modal: true
    });
    $("#FlashCardDelete").html(DeleteCommentConfrim);
    jQuery('#FlashCardDelete').dialog('open');

    $("#btnYesFlash").click(function () {
        $.post(
            url = ActionURL,
            { CourseID: CourseDI, FlashCard: FlashCard },
            function (data) {
                jQuery('#FlashCardDelete').dialog('close');
                $("#FlashCardDelete").dialog("destroy");
                $("#FlashCardDelete").remove();
                window.location.href = GetRootPathJS() + "Flashcard/GetFlashCardSets?CourseID=" + CourseDI;
            });
        return false;
    });

    $("#btnNoFlash").click(function () {
        FlashCard = 0;
        jQuery('#FlashCardDelete').dialog('close');
        $("#FlashCardDelete").dialog("destroy");
        $("#FlashCardDelete").remove();
        return false;
    });

    $("#lnkmyclose").click(function () {
        FlashCard = 0;
        jQuery('#FlashCardDelete').dialog('close');
        $("#FlashCardDelete").dialog("destroy");
        $("#FlashCardDelete").remove();
        return false;
    });
    return false;
}