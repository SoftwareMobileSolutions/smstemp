var Map_TempGrafDiario = {
    idmap: "mapTempGrafDiario",
    latlngview: (function (view) {
        var d = this;
        d.latlngShow = view
    }),
    latlngShow: true,
    mapShow: function (show) {
        if (show) {
            $("#" + this.idmap).show();
        }
        else {
            $("#" + this.idmap).hide();
        }
    },
    map: null,
    markers: [],
    dataGlobal: [],
    polylines: [],
    markersIniFin: [],
    clearmarkers: function () {
        var me = this;
        var mk = me.markers;
        for (var i = mk.length; i--;) {
            mk[i].setMap(null);
        }
        me.markers = [];
    },
    createmarkers: function () {
        var me = this;
        me.clearmarkers();
        var d = me.dataGlobal;
        var bounds = new google.maps.LatLngBounds();
        var position = {};
        var path = [];
        var MarkerSpiderfier = new OverlappingMarkerSpiderfier(me.map, spiderfierOptions);
        for (var i = d.length; i--;) { //Que no cree el inicio ni el fin
            d[i].icono = "images/tracker/" + fn_RotarIcono(d[i].statusid, d[i].heading, d[i].speed, 0, d[i].plate[0]);
            var evento = findEventosDisplay(d[i].statusid).name;
            d[i].evento = typeof evento !== "undefined" ? evento : "[No encontrado]";
            position = new google.maps.LatLng(d[i].latitud, d[i].longitud);
            path.push(position);
            bounds.extend(position);

            if (i !== 0 && i !== (d.length - 1)) {
                var mk = new google.maps.MarkerGhost({
                    position: position,
                    map: me.map,
                    title: d[i].alias,
                    icon: d[i].icono,
                    arg: d[i]
                });

                if (me.infowindows === null) {
                    me.infowindows = new google.maps.InfoWindow({
                        content: ""
                    });
                }
                mk.addListener('click', function () {
                    me.infowindows.setContent(me.infowindows_content(this.arg, ""));
                    me.infowindows.open(me.map, this);
                });
                MarkerSpiderfier.addMarker(mk);
                me.markers.push(mk);
            }
        }
        this.dataGlobal = d;
        d.length > 0 && (
            me.map.fitBounds(bounds),
            me.createpolylines(path),
            me.createIniFinMarkers(MarkerSpiderfier)
        );
    },

    createIniFinMarkers: function (MarkerSpiderfier) {
        var me = this;
        var d = me.dataGlobal;
        var pIni = d[0],
            pFin = d[d.length - 1];

        var mk1 = new google.maps.MarkerGhost({
            position: new google.maps.LatLng(pIni.latitud, pIni.longitud),
            map: me.map,
            title: "Inicio recorrido",
            icon: "images/tracker/startpoint.gif",
            arg: pIni
        });

        var mk2 = new google.maps.MarkerGhost({
            position: new google.maps.LatLng(pFin.latitud, pFin.longitud),
            map: me.map,
            title: "Fin Recorrido",
            icon: "images/tracker/iniciofin.png",
            arg: pFin,

        });

        if (me.infowindows === null) {
            me.infowindows = new google.maps.InfoWindow({
                content: ""
            });
        }
        mk1.addListener('click', function () {
            me.infowindows.setContent(me.infowindows_content(this.arg, " (" + this.title + ")"));
            me.infowindows.open(me.map, this);
        });
        mk2.addListener('click', function () {
            me.infowindows.setContent(me.infowindows_content(this.arg, " (" + this.title + ")"));
            me.infowindows.open(me.map, this);
        });


        MarkerSpiderfier.addMarker(mk1);
        MarkerSpiderfier.addMarker(mk1);
        MarkerSpiderfier.addMarker(mk2);

        me.markers.push(mk1);
        me.markers.push(mk2);

       
    },
    clearpolylines: function () {
        var me = this;
        var polylines = me.polylines;
        for (var i = polylines.length; i--;) {
            polylines[i].setMap(null);
        }
        me.polylines = [];
    },
    createpolylines: function (path) {
        var me = this;
        me.clearpolylines();
        var polyline = new google.maps.Polyline({
            path: path,
            geodesic: true,
            strokeColor: "#0000FF",
            strokeOpacity: 0.25,
            strokeWeight: 4,
            map: me.map
        });
        me.polylines.push(polyline);
    },
    infowindows: null,
    infowindows_content: function (arg, titleadicional) {
        var d = this;
        var letras = genCharArray('A', 'Z');

        var tbl =
            "<div class='iw-container'>" +
            "<div class='iw-title_'> " +
            "<div class='infotitle'>" + arg.alias + titleadicional + "</div>" +
            "<div class='iw-content_'>" +
            "<table class='info'>" +
            "<tbody>" +
            "<tr><td>Placa:</td><td>" + arg.plate + "</td></tr>" +
            "<tr><td>Fecha:</td><td>" + moment(arg.dategps).format("YYYY/MM/DD HH:mm:ss") + "</td></tr>" +
            "<tr><td>Encendido:</td><td>" + arg.thermoking + "</td></tr>" +
            "<tr><td>Evento:</td><td>" + arg.evento + "<img src='" + arg.icono + "' class='iconevent'>" + "</td></tr>" +
            (d.latlngShow ? "<tr><td>Ubicación:</td><td>" + arg.localizacion + "</td></tr>" : "") +
                        "<tr><td>Promedio (°C):</td><td>" + arg.promedio + " </td></tr>" +
            (function () {
                var result = "";
                for (var i = 0, len = arg.cantidadSensorT; i < len; i++) {
                    result += "<tr><td>Sensor " + letras[i] + " (°C):</td><td>" + arg["s" + (i + 1)] + "</td></tr>";
                }
                return result;
            }).call(this) +  
            (d.latlngShow ? "<tr><td>Lat/Lng</td><td>(" + arg.latitud + "/" +  arg.longitud + ")</td></tr>" : "") +
                    "</tbody>" +
            "</table>" +
                    "</div>" +
                "</div>"+
            "</div>";
        return tbl;
    },
    createmap: function (data) {
        var me = this;
        me.dataGlobal = data;
        if (me.map === null) {
            $(".mapTempGrafDiario").show();
            OpenStreetMapTypes();
            BingMapsTypes();
            CommunityMapsType();

            var latlng = new google.maps.LatLng(40.716948, -74.003563);
            var options = {
                zoom: 17,
                center: latlng,
                panControl: true,
                scaleControl: true,
                mapTypeControl: false,
                streetViewControl: false,
                mapTypeId: google.maps.MapTypeId.ROADMAP,
                mapTypeControlOptions: {
                    mapTypeIds: [google.maps.MapTypeId.ROADMAP,
                    google.maps.MapTypeId.HYBRID,
                    google.maps.MapTypeId.SATELLITE,
                    google.maps.MapTypeId.TERRAIN],
                    style: google.maps.MapTypeControlStyle.HORIZONTAL_BAR
                },
                disableDefaultUI: false,//true,
                streetViewControl: true,
                zoomControl: true,
                zoomControlOptions: { style: google.maps.ZoomControlStyle.SMALL },
                gestureHandling: 'greedy',
            };
            me.map = new google.maps.Map(document.getElementById(me.idmap), options);

            /* Google Maps */
            var gmapsOpc_ = ["Satelite", "Terrestre", "Relieve", "Híbrido"];
            var GMAPS_mapatypes = ["satellite", "terrain", "roadmap", "hybrid"];

            /* OpenStreetMap */
            var osmOpc_ = ["Estándar", "Ciclista", "Transporte", "Transporte Público", "Satélite(HD)", "Humanitario"];
            var OSM_mapatypes = ['osmEstandar', 'osmCycle', 'osmTransport', 'osmTransportPublic', 'osmMapBoxSatellite', 'osmHumanitario'];
            Map_TempGrafDiario.map.mapTypes.set('osmEstandar', osmEstandar);       //1. Estandar
            Map_TempGrafDiario.map.mapTypes.set('osmCycle', osmCycle);             //2. Ciclista
            Map_TempGrafDiario.map.mapTypes.set('osmTransport', osmTransport);     //3. Mapa de Transporte
            Map_TempGrafDiario.map.mapTypes.set('osmTransportPublic', osmTransportPublic);    //4. Mapa de Transporte público
            Map_TempGrafDiario.map.mapTypes.set('osmMapBoxSatellite', osmMapBoxSatellite); //5. MapQuest Open //2016-07-12 Se cambia mapa u se pone el satélite de HD que corresponde  a MapBox
            Map_TempGrafDiario.map.mapTypes.set('osmHumanitario', osmHumanitario); //6. Humanitario

            /* Bing Maps */
            var BingOpc_ = ["Aerial", "Aerial etiquetas", "Road"];
            var Bing_mapatypes = ['BingAerial', 'BingAerialLabel', 'BingRoad'];
            Map_TempGrafDiario.map.mapTypes.set('BingAerial', BingAerial);           //1. Aerial
            Map_TempGrafDiario.map.mapTypes.set('BingAerialLabel', BingAerialLabel); //2. ArialLabel
            Map_TempGrafDiario.map.mapTypes.set('BingRoad', BingRoad);               //3. Road

            /* Apple */
            /*  map.mapTypes.set('AppleEstandar', AppleEstandar);         //1. Estandar*/

            /* Community Maps */
            Map_TempGrafDiario.map.mapTypes.set('CommunityEstandar', CommunityEstandar); //1. Estandar

            var GMAP_Div = document.createElement('div'), GMAP_Control = new CustomButtonGMaps(GMAP_Div, "optionsMaps", "controlUI", "GMAPSControlText", gmapsOpc_, "Mostrar Mapa de Google", "Google", false, GMAPS_mapatypes, false, "Map_TempGrafDiario.map");
            GMAP_Div.index = 1; GMAP_Div.style.marginLeft = "8px"; Map_TempGrafDiario.map.controls[google.maps.ControlPosition.TOP_LEFT].push(GMAP_Div);

            var OSM_Div = document.createElement('div'), OSM_Control = new CustomButtonGMaps(OSM_Div, "optionsMaps", "controlUI", "OSMControlText", osmOpc_, "Mostrar OpenStreetMap", "OpenStreetMap", false, OSM_mapatypes, false, "Map_TempGrafDiario.map");
            OSM_Div.index = 1; OSM_Div.style.marginLeft = "50px"; Map_TempGrafDiario.map.controls[google.maps.ControlPosition.TOP_LEFT].push(OSM_Div);

            var Bing_Div = document.createElement('div'), Bing_Control = new CustomButtonGMaps(Bing_Div, "optionsMaps", "controlUI", "BingControlText", BingOpc_, "Mostrar Bing Maps", "Bing Maps", true, Bing_mapatypes, false, "Map_TempGrafDiario.map");
            Bing_Div.index = 1; Bing_Div.style.marginLeft = "92px"; Map_TempGrafDiario.map.controls[google.maps.ControlPosition.TOP_LEFT].push(Bing_Div);

            var Community_Div = document.createElement('div'), Community_Control = new CustomButtonGMaps(Community_Div, "optionsMaps", "controlUI", "CommunityControlText", [], "Mostrar Community Maps", "Community Maps", false, "CommunityEstandar", true, "Map_TempGrafDiario.map");
            Community_Div.index = 1; Community_Div.style.marginLeft = "64px"; Map_TempGrafDiario.map.controls[google.maps.ControlPosition.TOP_LEFT].push(Community_Div);
        }
        me.createmarkers();
    },
    showMarker: function (d) {
        var me = this;
        for (var j = me.markers.length; j--;) {
            var arg = me.markers[j].arg;
            if (arg.mobileid === d.mobileid && arg.dategps === d.dategps) {
                if (me.infowindows === null) {
                    me.infowindows = new google.maps.InfoWindow({
                        content: ""
                    });
                }
                new google.maps.event.trigger(me.markers[j], 'click');
                break;
            }
        }
    }
};

function insertAfter(referenceNode, newNode) {
    referenceNode.parentNode.insertBefore(newNode, referenceNode.nextSibling);
}

function genCharArray(charA, charZ) {
    var a = [], i = charA.charCodeAt(0), j = charZ.charCodeAt(0);
    for (; i <= j; ++i) {
        a.push(String.fromCharCode(i));
    }
    return a;
}

/* TIPOS DE MAPAS */
var Opcs_Timer, counterPush = 0;
function CustomButtonGMaps(controlDiv, clsOpc, CLASS, cls_txt, opc, title, txt, UltimoPush, mapatypes, unicoClick, strMap, simpleButtom) {//UltimoPush Lleva true porque es el ultimo el crearse por eso el setInterval, luego de que se ha creado todo agregar uniform RadioButton
    // Set CSS for the control border.
    var controlUI = document.createElement('div'), claseUI = document.createAttribute("class");
    claseUI.value = CLASS;
    controlUI.setAttributeNode(claseUI);
    controlUI.title = title;
    controlDiv.appendChild(controlUI);

    // Set CSS for the control interior.
    var controlText = document.createElement('div'), ClaseControlText = document.createAttribute("class");
    ClaseControlText.value = cls_txt;
    controlText.setAttributeNode(ClaseControlText);
    controlText.innerHTML = txt;
    controlUI.appendChild(controlText);
    if (typeof simpleButtom !== "undefined") {
        controlUI.style.left = "100px";
        //controlUI.style.right = "156px";
        controlText.innerHTML = '<i class="fa fa-user-plus"></i>';
        controlUI.addEventListener('click', function () { fn_ModificarTerceraForma(); });
        return false;
    }
    //////--------------------*************************
    var el = document.createElement("div"), ClassOpc = document.createAttribute("class"); ClassOpc.value = clsOpc; el.setAttributeNode(ClassOpc); el.style.display = "none";
    unicoClick && counterPush++;
    (UltimoPush === true) && (Opcs_Timer = setInterval(function () { InitRadio(clsOpc), (typeof TrafficLayerInitialize === "function" && TrafficLayerInitialize()) }, 500));//Detectar cuando es el ultimo elemento creado
    (unicoClick === false) && (el.innerHTML = MapButtonOptions(opc, mapatypes, strMap), insertAfter(controlUI, el));


    controlUI.addEventListener('click', function () {
        try {
            $("." + clsOpc).hide();
            unicoClick === false && ($(controlUI).next().show().trigger('mouseout'));

            (unicoClick === true) && ((eval(strMap)).setMapTypeId('CommunityEstandar'), $(".r_ .choice span").attr("class", ""));
        }
        catch (ex) {
            console.warn(ex.message);
        }
    });

    //Efecto cuando hay hover o mouseover
    (unicoClick === false) && ($(controlUI).next().mouseout(function () { window.t = setTimeout(function () { $(controlUI).next().hide(); }, 1000); }).mouseover(function () { $(controlUI).next().show(); if (window.t) { clearTimeout(window.t); window.t = undefined; } else { } }));
}

function MapButtonOptions(opc, mapatypes, strMap) {
    var options = "";
    for (var i = 0, len = opc.length; i < len; i++) {
        options = options + '<div class="radio r_" onclick=\'' + strMap + '.setMapTypeId("' + mapatypes[i] + '")\' >' +
            '<div class="radio radio-styled">' +
            '<label>' +
            '<input type="radio" class="btnStyled" name="degree" value="0" checked>' +
            '<span>' + opc[i] + '</span>' +
            '</label>' +
            '</div>' +
            /* '<label>' +
                 '<input type="radio" name="degree" class="btnStyled">' +
                     opc[i] +
             '</label>' +*/
            '</div>';
    }
    return ('<div class="btnContent"><div draggable="false" class="btnContentShape">' + options + '</div></div>');
}


function InitRadio(ClassOpc) {
    //console.log("entro");
    if ($("." + ClassOpc).length > counterPush - 1) {
        // $(".btnStyled").uniform({ radioClass: 'choice', selectAutoWidth: false });
        LimpiarIntervalo(Opcs_Timer);
        // console.log("fin");
        $(".gmnoprint .gm-style-mtc").on("click", function () { $(".r_ .choice span").attr("class", "") }); //Click en alguna de las opciones del Mapa de Google
    }
}

function LimpiarIntervalo(T) {
    clearInterval(T);
}
/* TILES O CAPAS DE MAPAS */
/* OpenStreetMap */
var osmTilesBaseUrl = ["http://tile.openstreetmap.org/", "http://tile.opencyclemap.org/cycle/", "http://tile2.opencyclemap.org/transport/",
    "http://tileserver.memomaps.de/tilegen/",
    "https://a.tiles.mapbox.com/v4/mapquest.satellite-mb/", "http://tile-a.openstreetmap.fr/hot/"], osmMapName = ["osmEstandard", "osmCycle", "osmTransport", "osmTransportPublic", "osmMapBoxSatellite", "osmHumanitario"],
    osmOpcEstandar, osmEstandar, osmOpcCycle, osmCycle, osmOpcTransport, osmTransport, osmOpcTransportPublic, osmTransportPublic, osmOpcMapBoxSatellite, osmMapBoxSatellite, osmOpcHumanitario, osmHumanitario;

function OpenStreetMapTypes() {
    osmOpcEstandar = { getTileUrl: function (coord, zoom) { var tilesPerGlobe = 1 << zoom; var x = coord.x % tilesPerGlobe; if (x < 0) { x = tilesPerGlobe + x; } return osmTilesBaseUrl[0] + zoom + "/" + x + "/" + coord.y + ".png"; }, tileSize: new google.maps.Size(256, 256), isPng: true, maxZoom: 18, name: osmMapName[0] };
    osmEstandar = new google.maps.ImageMapType(osmOpcEstandar);

    osmOpcCycle = { getTileUrl: function (coord, zoom) { var tilesPerGlobe = 1 << zoom; var x = coord.x % tilesPerGlobe; if (x < 0) { x = tilesPerGlobe + x; } return osmTilesBaseUrl[1] + zoom + "/" + x + "/" + coord.y + ".png"; }, tileSize: new google.maps.Size(256, 256), isPng: true, maxZoom: 18, name: osmMapName[1] };
    osmCycle = new google.maps.ImageMapType(osmOpcCycle);

    osmOpcTransport = { getTileUrl: function (coord, zoom) { var tilesPerGlobe = 1 << zoom; var x = coord.x % tilesPerGlobe; if (x < 0) { x = tilesPerGlobe + x; } return osmTilesBaseUrl[2] + zoom + "/" + x + "/" + coord.y + ".png"; }, tileSize: new google.maps.Size(256, 256), isPng: true, maxZoom: 18, name: osmMapName[2] };
    osmTransport = new google.maps.ImageMapType(osmOpcTransport);

    osmOpcTransportPublic = { getTileUrl: function (coord, zoom) { var tilesPerGlobe = 1 << zoom; var x = coord.x % tilesPerGlobe; if (x < 0) { x = tilesPerGlobe + x; } return osmTilesBaseUrl[3] + zoom + "/" + x + "/" + coord.y + ".png"; }, tileSize: new google.maps.Size(256, 256), isPng: true, maxZoom: 18, name: osmMapName[3] };
    osmTransportPublic = new google.maps.ImageMapType(osmOpcTransportPublic);

    osmOpcMapBoxSatellite = { getTileUrl: function (coord, zoom) { var tilesPerGlobe = 1 << zoom; var x = coord.x % tilesPerGlobe; if (x < 0) { x = tilesPerGlobe + x; } return osmTilesBaseUrl[4] + zoom + "/" + x + "/" + coord.y + ".png?access_token=pk.eyJ1IjoibWFwcXVlc3QiLCJhIjoiY2Q2N2RlMmNhY2NiZTRkMzlmZjJmZDk0NWU0ZGJlNTMifQ.mPRiEubbajc6a5y9ISgydg"; }, tileSize: new google.maps.Size(256, 256), isPng: true, maxZoom: 19, name: osmMapName[4] };
    osmMapBoxSatellite = new google.maps.ImageMapType(osmOpcMapBoxSatellite);

    osmOpcHumanitario = { getTileUrl: function (coord, zoom) { var tilesPerGlobe = 1 << zoom; var x = coord.x % tilesPerGlobe; if (x < 0) { x = tilesPerGlobe + x; } return osmTilesBaseUrl[5] + zoom + "/" + x + "/" + coord.y + ".png"; }, tileSize: new google.maps.Size(256, 256), isPng: true, maxZoom: 18, name: osmMapName[5] };
    osmHumanitario = new google.maps.ImageMapType(osmOpcHumanitario);

}

/* Bing */
function TileToQuadKey(x, y, zoom) {
    var quad = "";
    for (var i = zoom; i > 0; i--) {
        var mask = 1 << (i - 1);
        var cell = 0;
        if ((x & mask) != 0) cell++;
        if ((y & mask) != 0) cell += 2;
        quad += cell;
    }
    return quad;
}

var BingTilesBaseUrl = ["http://ecn.t1.tiles.virtualearth.net/tiles/a", "http://t3.ssl.ak.tiles.virtualearth.net/tiles/h", "http://t2.ssl.ak.tiles.virtualearth.net/tiles/r"], BingTilesType = ["g=1173", "g=4756", "g=4756"], BingMapName = ["BingAerial", "BingAerialLabel", "BingRoad"],
    BingAerial, BingAerialLabel, BingRoad;

function BingMapsTypes() {
    BingAerial = new google.maps.ImageMapType({ name: BingMapName[0], getTileUrl: function (coord, zoom) { return BingTilesBaseUrl[0] + TileToQuadKey(coord.x, coord.y, zoom) + ".jpeg?" + BingTilesType[0] + "&n=z"; }, tileSize: new google.maps.Size(256, 256), maxZoom: 21 });
    BingAerialLabel = new google.maps.ImageMapType({ name: BingMapName[1], getTileUrl: function (coord, zoom) { return BingTilesBaseUrl[1] + TileToQuadKey(coord.x, coord.y, zoom) + ".jpeg?" + BingTilesType[1] + "&n=z"; }, tileSize: new google.maps.Size(256, 256), maxZoom: 21 });
    BingRoad = new google.maps.ImageMapType({ name: BingMapName[2], getTileUrl: function (coord, zoom) { return BingTilesBaseUrl[2] + TileToQuadKey(coord.x, coord.y, zoom) + ".png?" + BingTilesType[2]; }, tileSize: new google.maps.Size(256, 256), maxZoom: 21 });
}

/* Community */
var CommunityTilesBaseUrl = ["https://worldtiles2.waze.com/tiles/"], CommunityMapName = ["CommunityEstandard"],
    CommunityOpcEstandar, CommunityEstandar;

function CommunityMapsType() {
    CommunityOpcEstandar = { getTileUrl: function (coord, zoom) { var tilesPerGlobe = 1 << zoom; var x = coord.x % tilesPerGlobe; if (x < 0) { x = tilesPerGlobe + x; } return CommunityTilesBaseUrl[0] + zoom + "/" + x + "/" + coord.y + ".png"; }, tileSize: new google.maps.Size(256, 256), isPng: true, maxZoom: 21, name: CommunityMapName[0] };
    CommunityEstandar = new google.maps.ImageMapType(CommunityOpcEstandar);
}
