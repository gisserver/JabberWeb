<script type="text/javascript">
$function myFunction() {
    var person = prompt("Please enter your name", "Harry Potter");

    if (person != null) {
        document.getElementById("demo").innerHTML =
        "Hello " + person + "! How are you today?";
    }
}
</script>
