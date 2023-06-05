var CountDownEstadoActual = {
    idclass: "contador",
    tiempo: 1,
    initnumeric: function () {
        var d = this;
        $("." + d.idclass + " .k-numeric-wrap > input").attr("onchange", "CountDownEstadoActual.numeritChange(this);");
        $("." + d.idclass + " .k-numeric-wrap .k-link.k-link-increase, ." + d.idclass + " .k-numeric-wrap .k-link.k-link-decrease").attr("onclick", "CountDownEstadoActual.numeritChange(this);");
    },
    numeritChange: function (obj) {
        var d = this;
        setTimeout(function () {
            var val = parseInt($("." + d.idclass + " .k-numeric-wrap > input").val());
            d.tiempo = val;
            d.Reset();
        }, 10);
        
    },
    minutosDefault: function () {
        var d = this;
        return (60 * d.tiempo)
    },
    display : null,
    intervalo: function () { },
    startTimer: function (duration, display) {
        var d = this;
        var timer = duration, minutes, seconds;
        d.intervalo = (setInterval(function () {
            minutes = parseInt(timer / 60, 10)
            seconds = parseInt(timer % 60, 10);
            minutes = minutes < 10 ? "0" + minutes : minutes;
            seconds = seconds < 10 ? "0" + seconds : seconds;
            $("#minutos").text(minutes);
            $("#segundos").text(seconds);
            //console.log(minutes + ":" + seconds);
             // display.textContent = minutes + ":" + seconds;
            //$("#minutos").text(minutes);

            if (minutes === "00" && seconds === "00") {
                $(".consultar").click();
                d.Detener();
            }
            if (--timer < 0) {
                timer = duration;
            }
        }, 1000));
    },
    reproducir: function () {
        var d = this;
       // display = document.querySelector('#time');
       // console.log("reproducir");
        d.startTimer(d.minutosDefault(), d.display);
    },
    Detener: function () {
        var d = this;
        clearInterval(d.intervalo);
    },
    Reset: function () {
        var d = this;
        d.initnumeric();
        d.Detener();
        d.reproducir();
    }
}


