function InitiateMenu();
{
//moveMap.bindCmd(keyboard, "h", "getHelp(\"Game Controls\");", "");
//moveMap.bindCmd(keyboard, "l", "getHelp(\"License\");", "");
//moveMap.bindCmd(keyboard, "j", "getHelp(\"About\");", "");
//moveMap.bindCmd(keyboard, "h", "getHelp(\"Credits\");", "");  

	Canvas.setCursor(DefaultCursor);

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
	exec ( "~/gui/MainMenu.gui" );
//
	exec ( "~/gameScripts/help/HelpDlg.gui" );
//
	exec ( "~/gui/Play.gui" );
//
	exec ( "~/gui/AreYouSure.gui" );
//
	exec ( "~/gui/mainScreen.gui" );
//
	exec ( "~/gui/selectlevelgui.gui" );
//
	exec ( "~/gui/PauseGame.gui" );
//
	exec ( "./help/Help.cs" );
//
	exec ( "./PauseScript.cs" );
//
	exec ( "./MenuSystem/MainMenu.cs" );
//
	exec ( "./MenuSystem/MenuSystem.cs" );
//
	exec ( "./MenuSystem/PreferenceMethods.cs" );
//
	exec ( "./MenuSystem/OptionsMenu.cs" );
//
	Canvas.setContent(MenuGui);
//
	//
	_setPreference( "LevelFolder", expandFilename( "~/data/levels" ) );

//
	_loadMenuConfigurationData( "./MainMenu.xml" );
//
	_loadOptionsPreferences();
//
	Canvas.setContent(MainMenuGui);
//	
	// Play some music for the menu
}