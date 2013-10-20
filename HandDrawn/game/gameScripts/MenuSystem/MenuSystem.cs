//-----------------------------------------------------------------------------
//  TGB Menu System
//  Copyright (C) Phillip O'Shea
//  
//  Menu System
//-----------------------------------------------------------------------------

// Variables
	$MenuConfiguration::GUIControl = MenuGui;
	
// Functions
	function _getGuiControl()		{ return $MenuConfiguration::GUIControl; }
	function _setGuiControl(%obj)	{ $MenuConfiguration::GUIControl = %obj; }

//------------------------------------------------------------------------------

function mMin(%a, %b)
{
	if (%a < %b)
		return %a;
	
	return %b;
}

function mMax(%a, %b)
{
	if (%a > %b)
		return %a;
	
	return %b;
}

function explode(%string, %char)
{
	if (!isObject(explode))
	{
		new ScriptObject(explode);
	}

	%explodeCount = 0;
	%lastFound = 0;

	%endChar = strLen(%string);	
	%charLen = strLen(%char);

	for (%i = 0; %i < %endChar; %i++)
	{
		%charToCheck = getSubStr(%string, %i, %charLen);
		if (%charToCheck $= %char)
		{
			explode.contents[%explodeCount] = getSubStr(%string, %lastFound, (%i-%lastFound)); 
			%lastFound = %i + %charLen;
			%explodeCount++;
		}	
	}

	explode.contents[%explodeCount] = getSubStr(%string, %lastFound, (%i-%lastFound)); 
	explode.count = %explodeCount + 1;	

	return explode;
}

//------------------------------------------------------------------------------

function _loadMenuConfigurationData(%dataFile)
{
	%xmlFile = new ScriptObject()
	{
		class = "XML";
	};
	
	%dataFile = expandFileName( %dataFile );
	
	if( %xmlFile.beginRead(%dataFile) )
	{
		if( %xmlFile.readClassBegin( "MenuConfiguration" ) )
		{
			_loadMenuData(%xmlFile);
			
			%xmlFile.readClassEnd();
		}
		
		%xmlFile.endRead();
	}
	
	%xmlFile.delete();
}

function _loadMenuData(%xmlFile)
{
	for (%className = %xmlFile.readNextClass(); %className !$= ""; %className = %xmlFile.readNextClass())
	{
		%testString = getSubStr(%className, strlen(%className) - strlen("Element"), strlen("Element"));
		if ( %testString $= "Element" )
		{
			// Type of objects in stack
			%elementType = getSubStr(%className, 0, strlen(%className) - strlen("Element"));
			
			// Create the new element
			_newGuiElement(%xmlFile, _getGuiControl(), %elementType);
		}
		
		%testString = getSubStr(%className, strlen(%className) - strlen("Stack"), strlen("Stack"));
		if ( %testString $= "Stack" )
		{
			// Type of objects in stack
			%elementType = getSubStr(%className, 0, strlen(%className) - strlen("Stack"));
			
			// Create the new stack
			%stackForm = _newGuiStack(%xmlFile, %elementType);
			
			while ( %xmlFile.readClassBegin( %elementType @ "Element", %stackForm.getCount() ) )
			{
				_newGuiElement(%xmlFile, %stackForm, %elementType);
				%xmlFile.readClassEnd();
			}
		}
		
		%xmlFile.readClassEnd();
	}
}

//------------------------------------------------------------------------------

function _newGuiStack(%xmlFile, %elementType)
{
	// Create the form
	%guiForm = new GuiControl()
	{
		Profile = GuiTransparentProfile;
	};
	
	// Load any defined fields
	_loadElementFields(%xmlFile, %guiForm);
	
	// Load default element fields
	if ( %xmlFile.readClassBegin("StackDefaults") )
	{
		_loadElementFields(%xmlFile, %guiForm, false, "mElement");
		%xmlFile.readClassEnd();
	}
	
	_getGuiControl().add(%guiForm);

	return %guiForm;
}

function _loadStackDefaultFields(%xmlFile, %guiForm, %guiElement)
{
	for (%i = 0; %i < %guiForm.getDynamicFieldCount(); %i++)
	{
		%fieldName = %guiForm.getDynamicField(%i);
		if ( getSubStr(%fieldName, 0, strlen("mElement")) !$= "mElement")
			continue;

		%fieldValue = %guiForm.getFieldValue(%fieldName);
		%fieldName  = getSubStr(%fieldName, strlen("mElement"), strlen(%fieldName));
		if (%guiElement.isMethod("set" @ %fieldName))
			eval ("%guiElement.set" @ %fieldName @ "(" @ %fieldValue @ ");");
	}
}

//------------------------------------------------------------------------------

function _newGuiElement(%xmlFile, %guiForm, %elementType)
{
	// Create the specified object
	eval ("%guiElement = new Gui" @ %elementType @ "Ctrl();");
	
	//
	%index = %guiForm.getCount();

	// Set the default position
	if (VectorLen(%guiForm.mElementMargin) > 0.0)
	{
		%elementPosition = t2dVectorScale(%guiForm.mElementMargin, %index);
		%guiElement.setPosition(%elementPosition.x, %elementPosition.y);
	}
	
	// Set the default extent
	%elementExtent = %guiElement.getExtent();
	%formExtent    = %guiForm.getExtent();
	%guiElement.setExtent(mMin(%elementExtent.x, %formExtent.x), mMin(%elementExtent.y, %formExtent.y));
	
	// Load the stack's defaults
	_loadStackDefaultFields(%xmlFile, %guiForm, %guiElement);
	
	// Load all of the element's details
	_loadElementFields(%xmlFile, %guiElement);

	// Add the new element to the form
	%guiForm.add(%guiElement);
	
	// Return it's id
	return %guiElement;
}

function _loadElementFields(%xmlFile, %guiElement, %process, %prefix)
{
	if (%process $= "") %process = true;
		
	// Loop through all of the fields
	for (%fieldName = %xmlFile.readNextClass(); %fieldName !$= ""; %fieldName = %xmlFile.readNextClass())
	{
		// Get the value
		%fieldValue = %xmlFile.fileObject.getText();
		
		// Use an assignment function or store the value
		if (%process && %guiElement.isMethod("set" @ %fieldName))
			eval ("%guiElement.set" @ %fieldName @ "(" @ %fieldValue @ ");");
		else
			%guiElement.setFieldValue(%prefix @ %fieldName, %fieldValue);
		
		%xmlFile.readClassEnd();
	}
}

function startMenuLevel()
{
PlayButtonTrigger.setUseMouseEvents(true);
QuitButtonTrigger.setUseMouseEvents(true);

canvas.pushDialog(sceneWindowGui);
MenuSceneWindow.loadLevel( expandFilename("game/data/levels/MenuLevel.t2d") );
PlayButton.blendColor = "1 1 1 1";
QuitButton.blendColor = "1 1 1 1";
}

function playButton::onAddToScene(%this)
{
%this.setAnimationFrame(0);
}

function mCameraMount::onAddToScene(%this)
{
menuSceneWindow.mount(%this, 0, 0, 0, true);  
}

function quitButton::onAddToScene(%this)
{
%this.setAnimationFrame(0);
}


function PlayButtonTrigger::onMouseEnter(%this)
{
playSound(MLBO);
PlayButton.playAnimation("PlayButtonAnimation");
PlayButton.blendColor = "1 1 1 1";
%this.inTrigger = 1;
}

function PlayButtonTrigger::onMouseLeave(%this)
{
%this.inTrigger = 0;
}

function PlayButtonTrigger::onMouseDown(%this)
{
echo("Mouse down on PlayButtonTrigger!");
PlayButton.blendColor = "0.5 0.5 0.5 1";
}

function PlayButtonTrigger::onMouseUp(%this)
{
PlayButton.blendColor = "1 1 1 1";


if(%this.inTrigger)
{
%this.safeDelete();
QuitButtonTrigger.safeDelete();
playSound(MLBS);
HDLogo.ConstantForce = "0 8000";
PlayButton.ConstantForce = "0 9000";
QuitButton.ConstantForce = "0 8500";
HDLogo.AutoRotation = 80;
PlayButton.AutoRotation = 90;
QuitButton.AutoRotation = -90;
menuSceneWindow.mount(mCameraMount, 0, 0, 0, true);
schedule(1000, 0, "MCameraMountInit");
Schedule(6000, 0, "InitializeMainMenu");

echo("Mouse up on PlayButtonTrigger!");

  %aura = new t2dParticleEffect()
  {
      scenegraph = MenuSceneWindow.getSceneGraph();
      layer      = 5;
      effectFile = "~/data/particles/YelloEmitter.eff";
      useEffectCollisions = "1";
      class = "PencilImpactParticles";
      effectMode = "kill";
      effectTime = "0.2";
      canSaveDynamicFields = "1";
      Position = %this.Position;
      size = "30.400 30.293";
      SortPoint = "-0.037 -0.295";
      CollisionMaxIterations = "1";
  
  };
    %aura.playEffect(true);
  %aura.isPlaying = true;
}
}

function mCameraMountInit()
{
MenuPath.attachObject(mCameraMount, 60, 1, 0, 1, REVERSE, 1, 1);
}

function InitializeMainMenu()
{
MenuSceneWindow.endLevel();
_InitreturnToMenu();
file1(); 
shopButton.setActive(false); 
MenuGui.Schedule(5000, "deleteTheora"); 
menuScroll(); 
playMusic(MainMenu);
}

function QuitButtonTrigger::onMouseEnter(%this)
{
%this.inTrigger = 1;
playSound(MLBO);
QuitButton.playAnimation("QuitButtonAnimation");
QuitButton.blendColor = "1 1 1 1";
}

function QuitButtonTrigger::onMouseLeave(%this)
{
%this.inTrigger = 0;
}

function QuitButtonTrigger::onMouseDown(%this)
{
echo("Mouse down on QuitButtonTrigger!");
QuitButton.blendColor = "0.5 0.5 0.5 1";
}

function QuitButtonTrigger::onMouseUp(%this)
{

QuitButton.blendColor = "1 1 1 1";
if(%this.inTrigger)
{
playSound(MLBS);
echo("Mouse up on QuitButtonTrigger!");

  %aura = new t2dParticleEffect()
  {
      scenegraph = MenuSceneWindow.getSceneGraph();
      layer      = 5;
      effectFile = "~/data/particles/SpeedshotExplode.eff";
      useEffectCollisions = "1";
      class = "SpeedshotParticles";
      effectMode = "kill";
      effectTime = "0.2";
      canSaveDynamicFields = "1";
      Position = %this.Position;
      size = "30.400 30.293";
      SortPoint = "-0.037 -0.295";
      CollisionMaxIterations = "1";
  
  };
    %aura.playEffect(true);
  %aura.isPlaying = true;
quit();
%this.safeDelete();
PlayButtonTrigger.safeDelete();
}
}