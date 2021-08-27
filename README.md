# Test-182-7  

Geolocation tiene dos métodos, GetLastKnownLocationAsync que la obtiene de algún tipo de caché y eso es algo que quizás desee usar si optimiza las cosas y sabe que puede que no sea la última ubicación conocida así que tenga en cuenta eso 
y GetLocationAsync que simplemente saldrá al sistema gps y obtendrá la ubicación desde allí tiene un par de sobrecargas y una tiene GeoLocationRequest y un CancelationToken para que pueda cancelar esta solicitud de gps en cualquier momento que desee
la solicitud de geolocalización permite especificar la precisión, por lo que hay diferentes niveles de precisión (GeolocationAccuracy) gps que puedes hacer y estoy diciendo gps pero los dispositivos tienen su propia combinación de cosas como la red a la que están conectados junto con el gps, etc para determinar su ubicación precisa, y podemos especificar la precisión aquí 
para que tenga un par de niveles best, default, high, low, lowest, medium, así que, dependiendo de lo que esté haciendo, desea establecer esta ubicación, por lo que cuanto más alto lo establezca, básicamente, más batería tomará, así que tenga en cuenta lo que está tratando de hacer aquí 
y también puede establecer un tiempo de espera (timeoout) es decir, va a salir al gps o como sea que obtendrá la ubicación y puede establecer un tiempo de espera aquí con un intervalo de tiempo y si no determinamos la ubicación en ese intervalo de tiempo, simplemente vamos a esperar y arrojará alguna excepción
En la documentación, se mencionan un par de excepciones diferentes que sucederán en diferentes escenarios, así que échale un vistazo y manejalas adecuadamente.
el resultado es un objeto de ubicación y esa ubicación tiene la precisión real que realmente obtuviste, es la precisión en metros, por lo que puedes determinar qué tan preciso es, a cuántos metros hace esto, la altitud, ¿qué tan alto estamos? El curso (course) en qué dirección nos dirigimos es de un proveedor simulado (IsFromMockProvider), por lo que es muy útil cuando desee 
determinar si esto es una especie de simulacro y, por supuesto, la latitud y longitud, la velocidad, la marca de tiempo y precisión vertical también, OpenMapsAsync para que pueda abrir la aplicación de mapas predeterminada en el dispositivo e iniciarla con un par de opciones para obtener las direcciones a un cierta ubicación y también calcular la distancia (CalculateDistance) 
para que pueda calcular la distancia entre dos conjuntos de latitud y longitud y puede especificar las unidades para que pueda obtener esa distancia en metros kilómetros, yardas, etc.


MÁS INFORMACIÓN:  
https://docs.microsoft.com/es-mx/xamarin/essentials/geolocation?tabs=android  
https://docs.microsoft.com/en-us/xamarin/android/data-cloud/data-access/using-sqlite-orm  
https://github.com/oysteinkrog/SQLite.Net-PCL (is deprecated)  




