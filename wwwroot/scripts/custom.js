 typeof MarkerWithGhost !== "undefined" && MarkerWithGhost.initializeGlobally(); //usar new google.maps.MarkerGhost en lugar de google.maps.Marker para usarlo y ocupar addListener en lugar de addDomListener si se usa. Se cambia en MarkerWithGhost.cshtml la propiedad de google.maps.Marker y en lugar para no afectar a todos los elementos se coloca  google.maps.MarkerGhost = google.maps.Marker;
            var spiderfierOptions = {//Opciones para el modo Spider
                markersWontMove: true, markersWontHide: true,
                keepSpiderfied: true, //Si está en True y le dan click al marker al que se le aplico el Spider entonces este no se volvera a su estado original cuando le den click encima.
                nearbyDistance: 10, //default: 20 //Distancia de un marker con otro
                circleSpiralSwitchover: 9, //default: 9, 0-spiral, Infinity-circle, Infinity//Forma del Spider
                legWeight: 3 //default: 1.5//Grisor de las líneas al realizar el spider
            };
//$.kontrol.blazorfilesloaded = true;
