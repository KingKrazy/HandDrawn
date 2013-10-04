//-----------------------------------------------------------------------------
//  TGB Menu System
//  Copyright (C) Phillip O'Shea
//  
//  Main Menu - 
//-----------------------------------------------------------------------------

// Load GUI
	exec ("~/gui/MainMenu.gui");
	exec ("~/gui/TitleGui.gui");


//------------------------------------------------------------------------------
//Moved to LaunchMainMenu.cs
//-----------------------------------------------------------------------------

function _newFadeSequence(%sequenceList, %completionScript)
{
	$FadeSequenceNumber = 0;
	%fieldCount = getFieldCount(%sequenceList);
	for (%i = 0; %i < %fieldCount; %i++)
		$FadeSequence[%i] = getField(%sequenceList, %i);

	$FadeSequenceMaxNumber        = %fieldCount;
	$FadeSequenceCompletionScript = %completionScript;

	_nextFadeSequence();
}

function _nextFadeSequence()
{
	%index = $FadeSequenceNumber;
	if (%index == $FadeSequenceMaxNumber)
	{
		eval( $FadeSequenceCompletionScript );
		return;
	}
	
	%bitmap  = getWord($FadeSequence[%index], 0);
	%fadeIn  = getWord($FadeSequence[%index], 1);
	%wait    = getWord($FadeSequence[%index], 2);
	%fadeOut = getWord($FadeSequence[%index], 3);
	
	_newFadeControl(%bitmap, %fadeIn, %wait, %fadeOut);
	
	$FadeSequenceNumber += 1;
}

function _newFadeControl(%bitmap, %in, %wait, %out)
{
	%windowSize  = Canvas.getContent().getExtent();
	%fadeControl = new GuiFadeinBitmapCtrl()
	{
      Profile     = "GuiDefaultProfile";
      HorizSizing = "width";
      VertSizing  = "height";
      
      Extent = %windowSize;
      
      bitmap      = %bitmap;
      fadeinTime  = %in;
      waitTime    = %wait;
      fadeoutTime = %out;
   };
   
   %fadeControl.schedule(1000, "checkStatus");

   Canvas.getContent().add(%fadeControl);
}

function GuiFadeinBitmapCtrl::checkStatus(%this)
{
	if (%this.done)
	{
		if (%this.isMethod("onComplete"))
			%this.onComplete();
			
		return;
	}
	
	%this.schedule(100, "checkStatus");
}

function GuiFadeinBitmapCtrl::onComplete(%this)
{
	%this.delete();
}

//-----------------------------------------------------------------------------

function _newGame()
{
//$musicAlreadyPlaying = 0;
alxStopAll();
$PlayerAmmo = "0";
$ActiveWeapon = "0";

	// Hide the cursor again
	Canvas.hideCursor();
	
	// Fade out
	_newFadeSequence(" 0 0 1000", "_loadGameLevel();");
_loadGameLevel();
}

//-----------------------------------------------------------------------------

function _loadGameLevel()
{
	Canvas.hideCursor();

	// Load the level into the scenewindow
	sceneWindow2D.loadLevel( expandFilename("~/data/levels/Tutorial.t2d") );

	
	// Set the content
	//Canvas.setContent(LoadingGui);
	//The load sequence runs a series of tests so the game will be less laggy.
	// Fade the level in
	Scenewindow2D.OnLevelLoaded( Canvas.setContent(Mainscreengui) );
	Scenewindow2D.OnLevelLoaded( Canvas.pushDialog(GoodGui) );
	
	_newFadeSequence(" 500 0 0", "");

	canvas.popDialog(goodGui);
}

function _triggerReturnToMenu(%val)
{
	if (%val)
	{
		// Fade out
_returnToMenu();
	}
}

function _InitreturnToMenu()
{
	// End the level
	sceneWindow2D.endLevel();
	MenuSceneWindow.endLevel();
	Canvas.showCursor();
	// Set the content
	Canvas.setContent(MenuGui);
	
	// Fade the menu in
    _newFadeSequence(" 1000 0 0 ", "");
	
	// Play some music for the menu
}


function _returnToMenu()
{

	// End the level
	sceneWindow2D.endLevel();
	menuSceneWindow.endLevel();
	Canvas.showCursor();
	// Set the content
	Canvas.setContent(MenuGui);
	
	// Fade the menu in
    _newFadeSequence(" 1000 0 0 ", "");
	     alxStopAll();

	// Play some music for the menu
	playMusic(MainMenu);
}

//-----------------------------------------------------------------------------



function MenuCameraMount::onLevelLoaded(%this)
{
	SceneWindow2D.mount(%this);
}

function MenuCameraMount::onWorldLimit(%this)
{
	SceneWindow2D.disMount();
	SceneWindow2D.setCurrentCameraPosition("-100 0");
	
	%this.setPositionX(-100);
	SceneWindow2D.mount(%this);
}