//---------------------------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//---------------------------------------------------------------------------------------------


/// Player Initialization Procedure
/// 

function onStart()
{

   //messageBox( "Load progress?", "Welcome to HandDrawn! Would you like to load your progress (Lives, points, level, ect...)?", "Yes, please", "MIStop" );

// readfile();
 schedule(3600000, 0, "OneHourMessage");
 $playerLevel = 1;
}

function onExit()
{
}

function documentfile()
{
for( %i = 0; %i < $Game::argv; %i++ )
{
  if( strstr( $Game::argv[%i], ".hdsave" ) >= 0 )
  {
   echo("Code 304" @ $Game::argv[%i]);
    break;
  }
}
}
//---------------------------------------------------------------------------------------------
// Load the paths we need access to
//---------------------------------------------------------------------------------------------
function loadPath( %path )
{
   setModPaths( getModPaths() @ ";" @ %path );
   exec(%path @ "/main.cs");

}

//---------------------------------------------
// Do some bootstrap stuff to get the game to 
// the initializeProject phase of loading and 
// pass off to the user
//---------------------------------------------

// Output a console log
setLogMode(6);

loadPath( "common" );

loadPath( "game" );
loadPath( "mods" );

expandFilename("~/mods");
expandFilename("mods");
onStart();

// Initialized
echo("\nTorque Game Builder (" @ getT2DVersion() @ ") initialized...");

if( !isFunction( "initializeProject" ) || !isFunction( "_initializeProject" ) )
{
   messageBox( "Game Startup Error", "'initializeProject' function could not be found." @
               "\nThis could indicate a bad or corrupt common directory for your game." @
               "\n\nThe Game will now shutdown because it cannot properly function.", "Ok", "MIStop" );
   quit();
}

_initializeProject();

// Startup the project
initializeProject();

function OneHourMessage()
{
      canvas.pushDialog(AreYouSure2Gui);
      $AYSWindowText = "Time flies!";
      AYSWindowText.setText($AYSWindowText);
      $AYSText = "Wow-wee, time goes fast when you\'re having fun! Atleast... you\'ve been sitting here for an hour playing so I'm assuming your having fun. Anyway, ya might wanna consider taking a break for a bit. I mean, if you play this too much, you might get as crazy as me (not a good thing)! Well, that\'s my advice. Just tell your doctor it wasn't my fault when you have a seizure. Bye!";
      AYSText.setText($AYSText);
}
