# Unity Tutorial: Text 101
Kata that involved me learning how to make a game that demonstrates:
1. Manipulating the user interface of the Unity game engine with `Text` and background images, the last project involved only the debug console.
2. Creating `Tile Maps` using Unity for Pixel art-based backgrounds. 
3. Integrating [Stateless](https://github.com/dotnet-state-machine/stateless) with Unity, as of this writing Unity has no support for NuGet which is my preferred way of adding assemblies.
4. Using a resource file to support future translation into other languages.
5. Implemented a thread-safe singleton for my `Label Retriever`, whose purpose is discussed in the `Translation` section.
   
I also demonstrated some concepts that I already understood but considered their inclusion important to the final product:
1. Creating state machines using `Stateless`.
2. Developing games using n-tier architecture, something Unity also does not want to support seamlessly. This allows me to take advantage of NuGet and XUnit in my business logic tier, while the application tier can reference the Unity game engine directly.
3. The main application once again used the `Mediator` design pattern, for my next project I will need to see if there are any other behavioral patterns that are better suited for this task.
4. Handling real-time input from users.

I had originally aimed to complete this task within one weekend, as I have done for my last two projects. However, as I will discuss in the design section below this task presented an opportunity to research Pixel art and level design within Unity. I felt that this knowledge would be important for my future projects so I decided that I should increase the scope of this to include the additional research and implementation. Doing so caused me to miss the original self-imposed deadline and, as you will see by comparing the commits, extended this into a three weekend long project.

## Background
Building upon the lessons learned during my previous [Kata](https://github.com/kevinkabatra/UnityTutorialNumberWizard) I have completed the next section of my Unity training. In this course the instructors wanted you to create a simple text-based adventure game. Similar to my previous project, I think that this lesson is orientated towards a junior developer or at the very least they are designing a game in a manner that would be difficult to maintain and support in the long-term. Obviously long-term support is not a concern if they are only using this code to teach the concepts within the lesson. 

It is important to point out that I am not saying this to be critical of the instructors, I am merely pointing it out to explain my deviations from their lesson plan. My aim is to use each Kata to demonstrate [SOLID](https://itnext.io/solid-principles-explanation-and-examples-715b975dcad4.) development principles while at the same time learning new concepts. 

The main objectives of this lesson were as follows:
1. Manipulate a background image to facilitate story communication with the player.
2. Manipulate a text field to communicate commands to the player.
3. Control the game by monitoring the current state of the game. In their example they used conditional statements rather than a state machine.

## Text 101 Design (herein known as Labyrinth)
My version of this lesson is a maze that the user can navigate around, navigation for the player is supported using visual clues. The player can move in four directions: forward, backward, left, and right; movement is restricted based on the current location of the player within the maze.

### User interface
The lesson introduced using a `Canvas` to add a `Text` field that would show instructions to the user, and I implemented that feature almost exactly as was called out within the instructions. The difference between my project and theirs is that I use an interface to define my "display handler". This definition is used within the state machines to communicate with the user, and the actual implementation is handled within the application layer. I implement this within the application layer so that I can have access to the Unity game engine elements. 

Additionally the instructors also wanted me to add an element for a background image, originally I thought that I could find some simple images of a labyrinth and then I could display them within the `Image` element. Upon reviewing this concept some more I thought that the changing display would feel rather disjointed and not present a good experience for a user. My original search was for images that were either in the public domain or available for open source projects. While searching for these terms I stumbled upon some sites that were offering Pixel art that I could use within this project. Below there is a section, `Credits`, dedicated to thanking the artist whose contributions I ended up using for this project.

Using Pixel art greatly increased the scope of this task though. I had to learn how to take a .PNG file of Pixel art and convert that into something that Unity could use. Further searching turned up some useful information on how to first convert the artwork into individual tiles using the `Sprite Editor`. From there I had to create a `Tile Palette` to group like tiles together, think of Bob Ross when he is teaching us how to paint. At this point I was finally able to begin designing the `Tile Maps`, which are the actual levels, and all of this took place directly in the Unity IDE. I was quite happy with how seamless this process actually was. Unity also has support for layering the maps so it enabled me to create levels with varying complexity.

#### Source sample
1. How I control displaying the last game piece. The overlays allow me to layer tiles on top of one another to make a more complex level design.
	```csharp
	public void DisplayEnd()
	{
	    var worldMap = GetCleanWorldMap();
	    worldMap.End.enabled = true;
	    worldMap.EndOverlay.enabled = true;
	    worldMap.EndOverlay2.enabled = true;
	}
	```
2. How to access the "world map" `Game Object`, this is where all of the `Tile Maps` reside.
	```csharp
	private static WorldMap GetWorldMap()
	{
	    var worldMapGameObject = GameObject.Find("WorldMap");
	    var worldMap = worldMapGameObject.GetComponent<WorldMap>();

	    return worldMap;
	}
	```

### State Machines
For this application I have setup two state machines. The first tracks the status of the application itself. Has the user pressed `space` to start the game? Has the user finished the game altogether? These statuses are important to track as they determine the input that we accept from the user at any given time. If these statuses were the only states to track, then conditional statements as the lesson demonstrates would have been sufficient.

We also need to track the player's navigation and since there are many complexities within this system, it is easier to implement a proper state machine. This state machine will control the configuration for all possible player movements as well as the tracking of the player's position. For this I am implementing a light weight state machine system called `Stateless`. 

Using `Stateless` I can configure the user interface to be updated each time a player enters a game piece, this is handled by calling the interface for the `Display Handler`. The state machine also controls which inputs to listen for based on the game piece that we are currently on. For example when the game is started the user is brought to the `start` game piece. This piece only supports forward movement, so the state machine has been configured to ignore input that would result in moving in the left, right, or backward directions.

Getting `Stateless` to work with Unity was quite difficult. As mentioned earlier Unity currently has no support for NuGet, there is a package that you can download that claims to add support for it. Sadly this package does not work flawlessly, for example I attempted to add `Moq` to Unity in this manner and it failed miserably. To ease integration efforts I decided to only reference `Stateless` from my business layer, this would also allow me to use NuGet to control the versioning. This approach worked up until run-time, when Unity attempted to reach the `Stateless` assembly and had no idea on how to find it. My solution was to add the assembly directly to Unity, which causes it to generate a metadata file for it, in doing so I was able to correctly reference `Stateless` from my business layer.

#### Source sample
1. Configuration for one of the game pieces. The below code also displays how I am retrieving my localized labels for display, as well as the enums for player movement and the game pieces themselves.
	```csharp
	/// <summary>
	///     Configures player allowed movement for this piece.
	/// </summary>
	private void ConfigureThirdPiece()
	{
	    Configure(WorldMap.ThirdPieceVerticalPipe)
	        .OnEntry(() => DisplayHandler.DisplayMessage(LabelRetriever.ForwardOrBackwardMovement))
	        .OnEntry(DisplayHandler.DisplayVerticalPipe)
	        .OnEntry(DisplayHandler.DisplayVerticalPipeModifier)
	        .Permit(PlayerMovement.Forward, WorldMap.FourthPieceVerticalT)
	        .Permit(PlayerMovement.Backward, WorldMap.SecondPieceVerticalPipe)
	        .Ignore(PlayerMovement.Left)
	        .Ignore(PlayerMovement.Right);
	}
	```

### Translation
In my previous Kata I have relied on hard coded strings for communication to the user, this works for smaller projects but I wanted to have a look at how I could support something far more complicated in the future. Enter the resource file. Using my business layer I can create resource files that contain my labels, I can also specify which language these labels are supporting. Once you build the project containing the resource file a designer file is automatically generated. 

This is super lovely but to support English and Spanish it will require referencing both designer files. To make this system more maintainable I created a utility called `Label Retriever`, whose purpose is to automatically determine which resource file I should use based on the `culture` of the current thread running the application. This utility follows the Singleton Design Pattern and enables me to create one and only one instance of this object. For this project the singleton approach made sense as I was not planning on supporting the language to change while the application was running.

An important caveat is that this is really just a proof of concept for me, as I have only translated one of the labels into Spanish. Currently when building the business layer the necessary artifacts are generated to run this application in English or Spanish. So the remaining work for translation is simply the translation itself, update the resource files, and generate a new build.

#### Source sample
1. How to determine culture:
	```csharp
	/// <summary>
	///     Constructor.
	/// </summary>
	/// <param name="language">The language that will be used for translation purposes.</param>
	/// <remarks>If language is left null, will default to English United States.</remarks>
	private LabelRetriever(Languages language)
	{
    	var languageValue = (language ?? Languages.EnglishUnitedStates).Value;
	    var cultureInfo = CultureInfo.CreateSpecificCulture(languageValue);
	    SetCultureTo(cultureInfo);
	}
	```
2. How I setup getters for the labels stored in the designer files:
	```csharp
	#region Application labels
	public string ApplicationStart => Labels.ApplicationStart;
	public string GameStart => Labels.GameStart;
	public string GameOver => Labels.GameOver;
	#endregion	
	```

## Credits
### Pixel art
As I am focusing only on programming I decided that I should find some open source images to create my "game art". I found [Open Game Art](https://opengameart.org), which is a site that offers just that. Within the site I found an interesting post of some work done by [Hyptosis](http://www.lorestrome.com/pixel_archive/main.htm), Daniel Harris. Some of the pieces I felt would work really well for creating the labyrinth. Luckily his work was released under a [CCO](https://creativecommons.org/licenses/by/3.0/) license and he only required that I give him the proper credit. What a great dude!

#### Additional links:
* [Post](https://www.newgrounds.com/art/view/hyptosis/tile-art-batch-1) where artwork is released to the public. Again, [Dan / Hyptosis](https://hyptosis.newgrounds.com/) thank you very much for your contributions. I also release almost all of my work under the [MIT](https://opensource.org/licenses/MIT) license, so I think it is very important to contribute to the community.
* [Post](https://opengameart.org/content/lots-of-free-2d-tiles-and-sprites-by-hyptosis) that lead me to find this Pixel art.

## References and other content I found helpful
1. Of course the Udemy class: https://www.udemy.com/course/unitycourse/.
2. How to hide game objects, this is the mechanism that I use to switch levels: https://answers.unity.com/questions/1171111/hideunhide-game-object.html.
3. How to convert images into levels using Unity: https://blogs.unity3d.com/2018/01/25/2d-tilemap-asset-workflow-from-image-to-level/.
4. Where to find the `Tile Palette`, the last article did not explain this part well: https://docs.unity3d.com/Manual/Tilemap-Palette.html.
5. A video demonstration on how to use layers in Unity: https://www.youtube.com/watch?v=fSOYkRU4N9w.
6. Singleton Design Pattern is further explained here: https://refactoring.guru/design-patterns/singleton.
7. How to make a singleton thread safe using `lock`: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/lock-statement.