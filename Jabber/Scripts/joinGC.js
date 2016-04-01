$(function () {
    $("#JoinGC-form").dialog({
        autoOpen: false,
        modal: true,
        buttons: {
            "Ok": function () {
                var label= $("#label");
                        
                var gcname = $("#GCName");
                var password = $("#password");
                var nickname = $("#nickname");

                var GroupChatNameHidden = $("#GroupChatNameHidden");
                var GroupChatPassword = $("#PasswordHidden");
                var GroupChatNickName = $("#NickNameHidden");
                //Do your code here
                
                        
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
    
        

function AddContactMessageBox() {

    var contact = prompt("Enter the Contact Name and Domain", "");


}

