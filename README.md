# Skyrim ESPER Testing
## Foreword
This is my repo of my personal project to load Bethesda's Skyrim terrain (Using only the game's plugin files) as a C# based mod for the game S&box (Sandbox) by Facepunch: https://sbox.facepunch.com/about/

The end goal is to have the whole ground cover of the map Skyrim imported into S&box on the fly, procedurally generated, in contrast to having static meshes imported into the Source 2 engine.

## Explanation
So basically as S&box runs on a hotloaded C# layer for scripting, so they don't allow compiled DLL's to run on addon packs, which is understandable as that would pose some major security risks for running unchecked-code on your machine. So Facepunch have opted that all the addon code you publish has to be source code, so no compiled DLL's are allowed as mods/addons (Mods/addons/gamemodes are all slighty different versions of the same thing in S&box). I have opted to include the source code for my personal project and it's dependencies here. Ideally, I should be using Git submodules, but I am not that advanced enough in Git to be doing so, maybe if I work on this project more I will refactor the project for submodules, but for the moment all the dependencies are included in the repo.

## Background
The main brains behind this project are two library's by MatorTheEternal on GitHub, `esper`, and `balsa`: https://github.com/matortheeternal/esper, https://github.com/matortheeternal/balsa. `esper` allows me to manipulate and import the records from Bethesda's Elder Scrolls Plugin files (i.e `.esp`, or `.esm`) which both Skyrim, Oblivion, Fallout, etc use for storing game data. `balsa` is a lightweight library for manipluating Bethesda Archive files (BSA's). If you have modded Skyrim or Fallout before in the past to some degree, you will know what I'm talking about.

## Ok, so why do you want to get records from the `.ESM`'s?
Because the land height data that is what makes the land in Skyrim work in the `Skyrim.ESM` file, and if I find a way to get a list of those points in space I would have a way to convert the points in a Matrix to vertex data, which will eventually convert it to a land mesh model. Right now I'm trying to take this project one step at a time, so just for now I want to be able to either print out the points in the VHGT field or just get access to the VHGT (Vertex Height) field in the ESM files, that field has the data that I can use as vertex points down the line: https://en.uesp.net/wiki/Skyrim_Mod:Mod_File_Format/LAND. 

## What I am trying to do right now

A dependency for `esper` called `Newtonsoft.Json` is no longer receiving updates, and also the dependency is huge and too complex for me to work on it comfortabley, so I've opted to try and port the 100 and something lines of code in the esper C# library to offical Microsoft `System.Text.Json`. esper uses JSON definitions for the Skyrim/Fallout records to be loaded into C#. The thing is that I'm not that familar with `Newtonsoft.Json`, or the newer `System.Text.Json` in general, that's why I'm asking if anyone would know how to port some of that C# code over to the new library, that would at least get the project up and running.

# Contributing
Contributions are always welcome (I'm currently looking for help right now), feel free to fork the repo and submit a pull request if you do want to contribute 😊.
