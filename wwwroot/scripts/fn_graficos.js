function fn_HideShowGraf(id) {
    setInterval(function () {
        var obj = $("#" + id + " g[transform] g > text");
       // obj.css({ "opacity": "1" });
        obj.parent().parent().each(function (i) {
            $(this).attr({
                "onclick": "onClickSerieLegend('" + id + "'," + i + ",this);"
            });
        });
    }, 1000);
}

function onClickSerieLegend(id, index, obj) {
    var series = $("#" + id +" > div").get(0)._kendoExportVisual().children[0].chartElement.chart.options.series;
    //console.log(series, index);
    var SerieVisible = series[index].visible;
  
    if (!SerieVisible) {
        return false;
    }

    var show = false, svgText;
    var stroke = "", strokeline = "", strokecircle = "", fill = "",
        $this, $thisline, $thiscircle, $thiscirclefill,
        $thisfillbar = "";

   
    $this = $(obj).find("> path:nth-child(1)"); stroke = $this.attr("stroke");
    svgText = $this.next().find("text");

    svgText.css("opacity") === "1" ? (show = false, svgText.css({ "opacity": "0.50" })) : (show = true, svgText.css({ "opacity": "1" }));
    $("#" + id + " [clip-path] g path").each(function () {

        // $("#" + id + " g[clip-path]:nth-child(1) [stroke]").each(function () {
        $thisline = $(this); strokeline = $thisline.attr("stroke"), $thisfillbar = $thisline.attr("fill");
        //console.log(stroke, strokeline)
        if (stroke === strokeline || stroke === $thisfillbar) {
            if (show) {
                $thisline.show();
            }
            else {
                $thisline.hide();
            }
        }
    });
    $("#" + id + " g[clip-path] > g > circle").each(function () {
    //$("#" + id + " g[clip-path]:nth-child(1) > circle").each(function () {
        $thiscircle = $(this); strokecircle = $thiscircle.attr("stroke");
        if (stroke === strokecircle) {
            if (show) {
                $thiscircle.show();
            }
            else {
                $thiscircle.hide();
            }
        }
    });
    $("#" + id + " g[clip-path]").eq(0).find(" > circle").each(function () {
        $thiscirclefill = $(this); fill = $thiscirclefill.attr("fill");
        if (stroke === fill) {
            if (show) {
                $thiscirclefill.css({ "visibility": "inherit" });
            }
            else {
                $thiscirclefill.css({ "visibility": "hidden" });
            }
        }
    });

    //Calcular labels
    var newIndex = 0, existlabel = false, lenseriesvisibles = (function () {
        var count = 0;
        for (var k = 0, lenk = series.length; k < lenk; k++) {
            if (series[k].labels.visible && series[k].visible) {
                if (k === index) {
                    existlabel = true;
                    newIndex = count;
                }
                count++;
            }
        }
        return count;
    }).call(this);

    if (!existlabel) {
        return false;
    }

    var splitter = [], posSPliter = -1;


    //if (typeof $("#" + id + " > div g > g[opacity='1']").eq(0).prev().attr("transform") !== "undefined") {//Si es tipo barras
      //  $("#" + id + " > div g > g[opacity='1']").each(function (i) {
    $("#graficoEstadoActual > div > svg > g > g path[fill-opacity='0.8']").each(function (i) {
            if ((i % lenseriesvisibles) === 0) {
                posSPliter++;
                splitter[posSPliter] = [];
            }
            splitter[posSPliter].push($(this));
        });
        splitter.length = (posSPliter + 1);

    
        for (var i = splitter.length; i--;) {
            var serieLabelX = splitter[i][newIndex];
            show ? (serieLabelX.show(), serieLabelX.next().show()) : (serieLabelX.hide(), serieLabelX.next().hide());
        }
   // }
   
}

function HideAxisEachHour(id) {
    setInterval(function () {
        var xaxis = $("#" + id + " g g [transform] > text");
        xaxis.each(function () {
            var $this = $(this);
            if ($this.text().split(":")[1] !== "00") {
                $this.hide();
            }
        });
    }, 1000);
}