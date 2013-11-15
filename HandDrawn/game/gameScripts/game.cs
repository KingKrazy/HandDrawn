//---------------------------------------------------------------------------------------------
// Torque Game Builder
// Copyright (C) GarageGames.com, Inc.
//---------------------------------------------------------------------------------------------

//---------------------------------------------------------------------------------------------
// startGame
// All game logic should be set up here. This will be called by the level builder when you
// select "Run Game" or by the startup process of your game to load the first level.
//---------------------------------------------------------------------------------------------
function startGame(%level)
{

	Canvas.setCursor(DefaultCursor);

	//exec ( "~/gui/NLBGui.gui" );
    //canvas.pushDialog(NLBGui);
	new ActionMap(moveMap);   
	moveMap.push();

	$enableDirectInput = true;
	activateDirectInput();
	enableJoystick();

	// Loads various functions required through the kit
	exec ("./GameMethods.cs");
	initialisePlatformerKit();

	
	// Load the main menu stuff
//
	exec ( "./RSS/RSSFeedScript.ed.cs" );
//
	exec ( "./levelEditorMenu.ed.cs" );
//
	exec ( "./TGBInsider.ed.cs" );
//
	exec ( "./RSS/RSSStructs.ed.cs" );
//
	exec ( "./LevelManagement.cs" );
//
    exec ( "./VertMethods.cs" );
//
    exec ( "./SubMethods.cs" );
//
	exec ( "./LevelFunctions.cs" );
//
	exec ( "./news.ed.cs" );
//
	exec ( "~/gui/TimerGui.gui" );
//
	exec ( "./ScrapperMethods.cs" );
//
	exec ( "./SnapperMethods.cs" );
//
	exec ( "./InventorySystem.cs" );
//
	exec ( "~/gui/MouseOverlay.gui" );
//
	exec ( "~/gui/Database.gui" );
//
	exec ( "~/gui/LoadGui.gui" );
//
	exec ( "~/gui/TutorialOverGui.gui" );
//
	exec ( "~/gui/SaveGui.gui" );
//
	exec ( "~/gui/SceneWindow.gui" );
//
	exec ( "~/gui/IntroGui.gui" );
//
	exec ( "./LevelSelect.cs" );
//
	exec ( "./Items.cs" );
//
	//exec ( "./BoolMethods.cs" );
//
	exec ( "./DefaultGameProfiles.cs" );
//
	exec ( "~/gui/sgsys.gui" );
//
//	exec ( "~/gui/MissionTitle.gui" );
//
	exec ( "~/gui/OneTryLeftGui.gui" );
//
	exec ( "~/gui/MenuGui.gui" );
//
	exec ( "~/gui/AccountFileGui.gui" );
//
	exec ( "~/gui/PurgeFileQuestionGui.gui" );
//
	exec ( "~/gui/TGBInsider.ed.gui" );
//
	exec ( "~/gui/TTL.gui" );
//
	exec ( "~/gui/ItemShop.gui" );
//
	exec ( "~/gui/NewInventory.gui" );
//
	exec ( "~/gui/TutorialGui.gui" );
//
	exec ( "./TutorialSequence.cs" );
//
	exec ( "./cp.cs" );
//
	exec ( "./SaveManager.cs" );
//
	exec ( "./SaveManagerDatablocks.cs" );
//
	exec ( "./itemShop.cs" );
//
	exec ( "./FinishText.cs" );
//
	exec ( "~/gameScripts/help/HelpDlg.gui" );
//
	exec ( "~/gui/NetworkLobby.gui" );
//
	exec ( "~/gui/Play.gui" );
//
	exec ( "~/gui/HurtGui.gui" );
//
	exec ( "~/gui/BadGui.gui" );
//
	exec ( "~/gui/GoodGui.gui" );
//
	exec ( "~/gui/AreYouSure2Gui.gui" );
//
	exec ( "~/gui/AreYouSure.gui" );
//
	exec ( "~/gui/RedGlow.gui" );
//
	exec ( "~/gui/LoadingGui.gui" );
//
	exec ( "~/gui/NowLoadingGui.gui" );
//
	exec ( "~/gui/FinishGui.gui" );
//
	exec ( "~/gui/GameOverGui.gui" );
//
	exec ( "~/gui/TorqueSplashGui.gui" );
//
	exec ( "~/gui/mainScreen.gui" );
//
	exec ( "~/gui/BlurbOps.gui" );
//
	exec ( "~/gui/selectlevelgui.gui" );
//
	exec ( "~/gui/QuedLevelGui.gui" );
//
	exec ( "~/gui/CannotRead.gui" );
//
	exec ( "~/gui/NowSavingGui.gui" );
//
	exec ( "~/gui/Tutorial_IGui.gui" );
//
	exec ( "~/gui/PauseGame.gui" );
//
	exec ( "./help/Help.cs" );
//
    exec ( "./AfterImage.cs" );
//
	exec ( "./PauseScript.cs" );
//
	exec ( "./Tip.cs" );
//
	exec ( "./MenuSystem/MainMenu.cs" );
//
	exec ( "./MenuSystem/MenuSystem.cs" );
//
	exec ( "./MenuSystem/PreferenceMethods.cs" );
//
	exec ( "./MenuSystem/OptionsMenu.cs" );
//
	exec ( "./WriteLoadSave.cs" );
//
    exec ( "./ParallaxMethods.cs" );
//
	_setPreference( "LevelFolder", expandFilename( "~/data/levels" ) );
//
	_loadMenuConfigurationData( "./MainMenu.xml" );
//
	_loadOptionsPreferences();
//
canPause();

if(!$Pref::introDone)
{
//canvas.pushdialog(introGui);
$Pref::introDone = 1;

defaultStart();
}
else
{
defaultStart();
}

//canvas.popDialog(NLBGui);
}

function defaultStart(%level)
{

//Bind some variables
//moveMap.bindCmd(keyboard, "+", "Canvas.showCursor();", "");
//moveMap.bindCmd(keyboard, "-", "Canvas.hideCursor();", "");
   canvas.popDialog(gameLoadGui);

	Canvas.setContent(TorqueSplashGui);


//
	// Play sound for the splash
//playMusic(MainMenuInit);
initSaveManager();

}

function menuScroll()
{
$MenuAutoScroll = "Hello, this is a small test.<br>Isn't this amazing???";
menuAutoScroll.setText($MenuAutoScroll);
}
//---------------------------------------------------------------------------------------------
// endGame
// Game cleanup should be done here.
//---------------------------------------------------------------------------------------------
function endGame()
{
	moveMap.pop();
	moveMap.delete();
	sceneWindow2D.endLevel();
    alxStopAll();
    canvas.popDialog(mainScreenGui);
}
//----------------------------------------------------------------------------------------
//Checkpoint add on stuff
//----------------------------------------------------------------------------------------

function getCheckPoint() 
{
   // No if's beacuse we assume everything is okay,
   // it saved okay so it must still be fine 
   %checkpoint = $checkpointtoload - 1;
   %groupName = "MissionGroup/CheckPoints";
   %group = nameToID(%groupName);
   %index = %checkpoint;
   %spawn = %group.getObject(%index);

   return %spawn.getTransform();
}

//Simple code to reset points...

function resetPoints()
{
$Pref::points = 0;
$WZeroAmmount = 0;
$WOneAmmount = 0;
}

function popAYS()
{
canvas.popDialog(AreYouSure2Gui);
}

function titleGui()
{
	playMusic(MainTitle);
    canvas.setContent(TitleGui);
}

//Level stuff

function areaOpa1()
{
Area1.BlendColor = "0.6 0.6 0.6 0.5";
}

function areaOpa1b()
{
Area1.BlendColor = "0.6 0.6 0.6 1";
}

function finishGui()
{
canvas.pushdialog(finishGui);
}

//Mine...
function HDsave()
{

for (%i = 0; %i < $Game::argc; %i++)
{
  if( str( $Game::argv[%i], ".hdsave" ) >= 0 )
{
   echo(" --- argument " @ %i @ " : " @ $Game::argv[%i]);
}
}
}

function timeScaleLower()
{
    if(!$timeScale = 0.5)
    {
    $timeScale -= 0.001;
    schedule(10, 0, "timeScaleLowerT");
    }
}

function timeScaleRaise()
{
    if(!$timeScale = 1)
    {
    $timeScale += 0.001;
    schedule(10, 0, "timeScaleRaise");
    }
}

function frozenPinecone()
{
$game::player.setactiveweapon(frozenpineconelauncherweapon);
$game::player.frozenpineconeammo = 10000;
$game::player.updateweapongui();
}

function goToVillage()
{
writefile();
alxstopAll();
sceneWindow2D.schedule(20,"loadLevel", "game/data/levels/VillageDay.t2d");
pauseModeUnactive();
}

function getBlendColor(%object)
{
return %object.blendColor;
}

function ShopOwnerMoneyError()
{
   speechDisplayBehavior.Font = "Chalkboard";
   speechDisplayBehavior.Size = "84";
   speechDisplayBehavior.Spacing = "0";
   speechDisplayBehavior.LineY = "3";
   speechDisplayBehavior.BlendColor = "1 1 1 1";
   speechDisplayBehavior.Align = "Left";

   speechDisplayBehavior.BlurbText = "Hate to be a nag, but... your funds are lacking, friend!";


   speechDisplayBehavior.numLines = "1";


   speechDisplayBehavior.timer = "20";
    speechDisplayBehavior.PlayerOnly = "false";
    speechDisplayBehavior.isDestroyer = "false";
   speechDisplayBehavior.targetSpeaker = shopOwner;
   speechDisplayBehavior.speechDest = shopOwnerdest;


speechDisplayBehavior.onEnter();
GlobalActionMap.unbindObj("keyboard", "C", "nextLine", "speechDisplayBehavior");
}

function ShopOwnerPurchase()
{
   speechDisplayBehavior.Font = "Chalkboard";
   speechDisplayBehavior.Size = "84";
   speechDisplayBehavior.Spacing = "0";
   speechDisplayBehavior.LineY = "3";
   speechDisplayBehavior.BlendColor = "1 1 1 1";
   speechDisplayBehavior.Align = "Left";

   speechDisplayBehavior.BlurbText = "Nice choice! Couldn't have picked better myself.";


   speechDisplayBehavior.numLines = "1";


   speechDisplayBehavior.timer = "20";
    speechDisplayBehavior.PlayerOnly = "false";
    speechDisplayBehavior.isDestroyer = "false";
   speechDisplayBehavior.targetSpeaker = shopOwner;
   speechDisplayBehavior.speechDest = shopOwnerdest;


speechDisplayBehavior.onEnter();
GlobalActionMap.unbindObj("keyboard", "C", "nextLine", "speechDisplayBehavior");
}

function ShopOwnerLeave()
{
   speechDisplayBehavior.Font = "Chalkboard";
   speechDisplayBehavior.Size = "84";
   speechDisplayBehavior.Spacing = "0";
   speechDisplayBehavior.LineY = "3";
   speechDisplayBehavior.BlendColor = "1 1 1 1";
   speechDisplayBehavior.Align = "Left";

   speechDisplayBehavior.BlurbText = "See you later! Come again!";


   speechDisplayBehavior.numLines = "1";


   speechDisplayBehavior.timer = "20";
    speechDisplayBehavior.PlayerOnly = "false";
    speechDisplayBehavior.isDestroyer = "false";
   speechDisplayBehavior.targetSpeaker = shopOwner;
   speechDisplayBehavior.speechDest = shopOwnerdest;


speechDisplayBehavior.onEnter();
GlobalActionMap.unbindObj("keyboard", "C", "nextLine", "speechDisplayBehavior");
}

function TutorialOver()
{
killTimer();
alxStopAll();
playMusic(YouWin);
canvas.showCursor();
// This may be important, but for now, it's not...
// $TutorialOver = true;

canvas.pushDialog(TutorialOverGui);
}

function checkDistance(%obj1, %obj2)
{
   %scoot = t2dVectorDistance(%obj1.Position, %obj2.Position);
   echo(%scoot);
   return %scoot;
}