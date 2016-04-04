# SpaceShooterUnity 


> El código de la aplicación esta contenido dentro de los archivos .cs

> SpaceShooterUnity esta programado en C#(CSharp).

**DestroyBy...**

> son los scripts para instanciar acciones a la hora en que los GameObject interaccionan entre ellos cuando sus colliders se tocan.

###BGScroller 

> son los scrpits que contienen la programación del Background 'fondo' y crean su movimiento, donde da la sensación de movimiento por el espacio.

###EvasiveManeuver

> contiene la programación de las naves enemigas donde se crea un movimiento por el escenario hasta que salen de la pantalla.

###SmartRocket

> es el mismo script pero aplicado al movimiento de los misiles.

###Market

> contiene todos los metodos necesarios para gastar las monedas del jugador y comprar otras naves espaciales y otros misiles.

###Persistence

> contiene los métodos para guardar valores, puntuaciones, estados, etc, dentro de un archivo. Del mismo modo que también están los métodos para cargarlos. (Aunque no están aplicados todavía en la aplicacion, con lo cual siempre que se abre el juego se empieza de nuevo).

###Mover

> contiene los métodos de movimiento y acceso al acelerometro del dispositivo móvil.

###WeaponController

> contiene los metodos que instancian disparos de las naves espaciales.

###SelectedSpaceShip

> Instancia la nave espacial del jugador seǵún la que se haya seleccionado en la escena 'Base' donde se ejecuta el script Market. Este objeto es común de todas las escenas y se mantiene persistente a los cambios que el usuario haga.

**Para mas información consulta la wiki**
