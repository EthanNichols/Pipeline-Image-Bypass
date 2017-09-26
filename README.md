# Monogame Pipeline Image Bypass

### Overview
If you're tired of using the monogame content manager to load images to access pixel data, this will speed up the process.

### Process
* It accesses all of the images in a folder, as long as their naming scheme is a numeric number starting at 0.
  * Ex: 0.png, 1.png, 2.png, ...
* It stores all of the images in a dictionary of map images
* Call a function to get an image
* It reads the image's pixel data and creates tiles based on the pixel color
* Finally it displays the map with your textures to the play

### Issues
This isn't a library, it's not set up to be easily used for other projects

I put this here to help people who have a similar problem / issue

### Usage
Please feel to use this in your project, no credit needed
