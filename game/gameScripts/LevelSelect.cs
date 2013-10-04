function goToLevelSelect()
{
canvas.pushDialog(sceneWindowGui);
MenuSceneWindow.loadLevel( expandFilename("game/data/levels/LevelSelect.t2d") );
}

function getQuedLevel()
{
%level = "~/data/levels/" @ $QuedLevel @ ".t2d";
return %level;
}

function LevelButtonClass::onMouseLeave(%this)
{
        %this.disableUpdateCallback = 1;
        %this.size = "30 30";
        %this.canScale = 0;

if(%this.levelNumber >= $playerLevel)
{
%this.visible = 1;
}
}

function LevelButtonClass::onMouseDown(%this)
{

}

function LevelButtonClass::onMouseUp(%this)
{


if(%this.mouseInTrigger && !%this.levelNumber >= $playerLevel)
{
canvas.pushDialog(QuedLevelGui);
$quedLevel = %this.Name;
echo($quedLevel);
}

if(%this.levelNumber > $playerLevel)
{
%this.schedule(0, "setAngularVelocity", 90);
%this.schedule(125, "setAngularVelocity", -90);
%this.schedule(375, "setAngularVelocity", 90);
%this.schedule(625, "setRotation", 0);
%this.schedule(625, "setAngularVelocity", 0);
playSound(error);
}
else
{
if(%this.mouseintrigger)
{
canvas.pushDialog(QuedLevelGui);
$quedLevel = %this.Name;
echo($quedLevel);
}
}

}

function LevelButtonClass::onMouseDragged(%this)
{
%this.mouseInTrigger = 0;

}

function startQuedLevel()
{
_newGame();
alxStopAll();
sceneWindow2D.loadLevel(expandFilename(getQuedLevel()));
}

function LevelButtonClass::onMouseEnter(%this)
{
    %this.canScale = 1;

    %this.mouseInTrigger = 1;
    playSound(MLBO);

    %this.startSize = "25 25";
    %this.endSize = %this.size;

    %this.stepIncrement = 31;

	%this.xStepIncrement = (30 - 25) / (0.5 * 31);
	%this.yStepIncrement = (30 - 25) / (0.5 * 31);
	%this.direction = false;

    echo(%this.startSize);
    echo(%this.endSize);
    %this.startScale();
 
}

function LevelButtonClass::startScale(%this)
{
	   %this.size = %this.endSize;
	   %this.direction = true;
  // enable our update callaback
  %this.enableUpdateCallback();
}

function LevelButtonClass::onUpdate(%this)
{

   if(%this.canScale)
   {
   if(%this.direction)
   {
	   %newX = %this.size.x + %this.xStepIncrement;
	   %newY = %this.size.y + %this.yStepIncrement;
	   %this.size = %newX SPC %newY;
	   if((%this.size.x > 30) || (%this.size.y > 30))
	   {
		   %this.size = %this.endSize;
		   %this.endScale();
	   }
   }
   else
   {
	   %newX = %this.size.x - %this.xStepIncrement;
	   %newY = %this.size.y - %this.yStepIncrement;
	   %this.size = %newX SPC %newY;

	   if((%this.size.x < 25) || (%this.size.y < 25))
	   {
		   %this.size = %this.startSize;
		   %this.endScale();
	   }
   }
   }
}

function LevelButtonClass::endScale(%this)
{
//echo("Scale ended!");
		
        
        // swap direction
		if (%this.direction)
		{
        //echo("Direction is true!");
        %this.direction = false;
		}
		else 
        {
		%this.direction = true;
		}
}

function ScriptHandle::onAddToScene(%this)
{
canvas.pushdialog(LoadGui);
NMButton.visible = 0;
}

function levelButtonClass::SetUpLS(%this)
{
if(%this.LevelNumber >= $playerLevel)
{
%this.LevelUnlocked = 1;
}
else
{
%this.LevelUnlocked = 0;
}
}


function levelButtonClass::onAddToScene(%this)
{
%this.setUpLS();
}