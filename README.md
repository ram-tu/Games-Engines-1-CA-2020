# Games Engines 1 CA-2020
Assignment for Games Engines 1

Reda Ali Mohammed 

C17456666 

DT228 Bsc in Computer Science 

For My assignment, I plan to make a procedural neon city. It will feature an infinite space, with buildings, hover cars moving along the roads, shooting starts and sunsets in the sky, lights and if possible pedestrians. I will hopefully make this a first person view, where you are controlling the character in a car, and you will be able to drive around the city, viewing its lights and gorgeous sights. The world will be procedurally generated as the player moves along the world. 

I will look into infinite world and terrain generation, a little research on lighting and particles effects, as well as I plan to use Unity's UI system around the scene as well for some decorations.

My inspiration had come from a previous Games Engines assignment, and these various images
![A different image](https://image.freepik.com/free-vector/abstract-neon-city-background_75059-129.jpg)

![Image](https://static.turbosquid.com/Preview/2019/03/31__00_10_32/screenshot001.jpg12CFF4F8-6D74-4D89-8106-CF2084A657B9Default.jpg)

Here is a link to a previous year's assignment on a neon city : 
[ Neon City - Games Engines Assignment ](https://www.youtube.com/watch?v=On763TdQhWg&list=PL1n0B6z4e_E6GaGOHiBdPSW0QzICdGs4X&index=6)


# Neon City

this uses a mapgrid and perlin noise to generate the city, which uses a tile system to make the city infinite. the player controls a car and are able to view the elements of the city.

Particle systems are used to create the fireworks and the disco balls in the city. the disco ball model was made in blender, although the texture was ended up taken from the internet, as well as the texture for the force field. orignally the force field was suppose to be made in shader graph, however it didn't work very well in a 2 faced material that is rendered on both sides. there is a simple audioviz on the left hand side, a sunset in the front, and a tower with a sign saying welcome to neon city, which was made using UI elements form textmesh pro.

# Work

the city generation was a combination of a tutorial, and the infinite terrain lab covered in class. the fireworks and text movement were also inspired by tutorials. the development of the traffic system, which uses boolean variables and triggers to stop at red lights and other cars were done on my own, as well as the particle effects for the disco ball. the boids following the ball were inspired by the lab, as well as the audioviz. the buildings which are using shaders from shader graph were also used in tutorials

# Controls
the controls are simply W,A,S,D with P to move up and L to move down
