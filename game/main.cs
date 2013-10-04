//---------------------------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//---------------------------------------------------------------------------------------------
$introDone=false;  
//---------------------------------------------------------------------------------------------
// initializeProject
// Perform game initialization here.
//---------------------------------------------------------------------------------------------
function initializeProject()
{


   // Load up the in game gui.

   exec("~/gui/mainScreen.gui");

   // Exec game scripts.
   exec("./gameScripts/game.cs");

   // This is where the game starts. Right now, we are just starting the first level. You will
   // want to expand this to load up a splash screen followed by a main menu depending on the
   // specific needs of your game. Most likely, a menu button will start the actual game, which
   // is where startGame should be called from.
   startGame( expandFilename($Game::DefaultScene) );
   // This is where we generate the menu tips:
	//generateTip()

    //

    InitializeMods();
}

//---------------------------------------------------------------------------------------------
// shutdownProject
// Clean up your game objects here.
//---------------------------------------------------------------------------------------------
function shutdownProject()
{
   endGame();
}

//---------------------------------------------------------------------------------------------
// setupKeybinds
// Bind keys to actions here..
//---------------------------------------------------------------------------------------------
function setupKeybinds()
{
   new ActionMap(moveMap);
   //moveMap.bind("keyboard", "a", "doAction", "Action Description");
}

function bad()
{
playSound(Error);
Canvas.pushDialog(BadGui);
schedule(2000, 0, PopBad);

}

function good()
{
playSound(LevelSaved);
Canvas.pushDialog(GoodGui);
schedule(2000, 0, PopGood);
}

function popBad()
{
Canvas.popDialog(BadGui);
}

function popGood()
{
Canvas.popDialog(GoodGui);
}


//Editing only!

function WhereAmI()
{
$PlayerPosition = $game::player.getPosition();
echo("Position: $PlayerPosition");
}
