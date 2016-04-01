$(function () {
    $("#AddContact-form").dialog({
        autoOpen: false,
        modal: true,
        buttons: {
            "Ok": function () {

                var conName = $("#ContactName");
                var conDomain = $("#ContactDomain");


                var conNameHidden = $("#ContactNameHidden");
                var conDomainHidden = $("#DomainNameHidden");


                //Set the hidden variables to the values in the form
                //OnValueChanged event is called

                conNameHidden.val(conName.val());
                conDomainHidden.val(conDomain.val());


                $(this).dialog("close");
            },
            "Cancel": function () {
                $(this).dialog("close");
            }
        }
    });


    $('#AddContact').click(function () {
        document.getElementById('AddContact-form').style.visibility = 'visible';

        $("#AddContact-form").dialog("open");
    });

});

$(function () {
    $("#JoinGC-form").dialog({
        autoOpen: false,
        modal: true,
        buttons: {
            "Ok": function () {
                                        
                var gcname = $("#GCName");
                var password = $("#password");
                var nickname = $("#nickname");

                var GroupChatNameHidden = $("#GroupChatNameHidden");
                var GroupChatPassword = $("#PasswordHidden");
                var GroupChatNickName = $("#NickNameHidden");



                //Set the hidden variables to the values in the form
                //OnValueChanged event is called
                
                       
                GroupChatNameHidden.val(gcname.val());
                GroupChatPassword.val(password.val());
                GroupChatNickName.val(nickname.val());

                
                        
                $(this).dialog("close");
            },
            "Cancel": function () {
                $(this).dialog("close");
            }
        }
    });


    $('#JoinGC').click(function () {
        document.getElementById('JoinGC-form').style.visibility = 'visible';

        $("#JoinGC-form").dialog("open");
    });

});
    
        

         

