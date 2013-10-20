//---------------------------------------------------------------------------------------------
// HandDrawn
//---------------------------------------------------------------------------------------------

//---------------------------------------------------------------------------------------------
// Level Specific Functions
// These are functions that pertain specifically to levels, for example, the script for the
// shop keeper in "Village.t2d."
//---------------------------------------------------------------------------------------------

//---------------------------------------------------------------------------------------------
// VILLAGE.T2D
//---------------------------------------------------------------------------------------------



function getP4Joke()
{
$P4Joke1[1] = "What did the mama-semiaquatic mamal say when her son asked her how to catch fish? ...";
$P4Joke1[2] = "What is base number 3 in Avian Baseball? ...";
$P4Joke1[3] = "What did the racoon say when he caught a slow-moving saltwater reptile? ...";
%num = getRandom(1,3);

$P4Joke1 = $P4Joke1[%num];

$P4Joke2[1] = "YOU OTTER KNOW THAT ALREADY! ...";
$P4Joke2[2] = "BIRD BASE! ...";
$P4Joke2[3] = "SEA? A TURTLE! ...";

$P4Joke2 = $P4Joke2[%num];
}

//-----------------------------------------------------------
// Level1
//-----------------------------------------------------------

function KrazyOut()
{
schedule(1000, 0, "MoveKrazy");
}

function MoveKrazy()
{
  %this.aura = new t2dParticleEffect()
  {
      scenegraph = SceneWindow2D.getSceneGraph();
      effectFile = "~/data/particles/YelloEmitter.eff";
      useEffectCollisions = "1";
      layer = 1;
      effectMode = "kill";
      effectTime = "0.2";
      effectTime = "100";
      canSaveDynamicFields = "1";
      Position = "44.630 34.560";
      size = "30.400 30.293";
      SortPoint = "-0.037 -0.295";
      CollisionMaxIterations = "1";
      MountOffset = "-0.024 0.488";
      MountOwned = "0";
      MountInheritAttributes = "0";
         mountID = "10";
         mountToID = "9";
  };

Krazy.safeDelete();
KrazyTrigger.safeDelete();
playSound(warp);
schedule(1000, 0, "finishLevel1");

}

function finishLevel1()
{

    alxstopAll();    
    // Ensure the player cannot respawn
    $game::player.AllowRespawn = false;

    // Stop moving
    $game::player.Controller.Direction = "0 0";
    $game::player.MoveSpeed            = "0 0";
    $game::player.setLinearVelocityX( 0 );

    // Stop the controller
    moveMap.pop();

    //Freeze!

$mainSceneGraph = sceneWindow2D.getSceneGraph();
$mainSceneGraph.setScenePause(true);


    // Run the level complete function
    levelComplete();

    // Load the next level
    $mainSceneGraph.setScenePause(false);
    playMusic(YouWin);
    $nextLevel = "Level2";
}

function BlueSkyLevel1::onAddToScene(%this, %scenegraph)
{
echo("We've loaded Level1!");
$shakeEnabled = 1;
shakeIntervals(5, 20);
}


function initVillage()
{
GameEventManager.subscribe(haunter1, "_DrillDied", "onDrillDied");
GameEventManager.subscribe(haunter2, "_DrillDied", "onDrillDied");
GameEventManager.subscribe(haunter3, "_DrillDied", "onDrillDied");
GameEventManager.subscribe(haunter4, "_DrillDied", "onDrillDied");
GameEventManager.subscribe(haunter5, "_DrillDied", "onDrillDied");

}

function initializeGameEventManager()
{
    if (!isObject(GameEventManager))
    {
        $GameEventManager = new EventManager(GameEventManager)
        { 
            queue = "GameEventManager"; 
        };
        
        // Module related signals
        GameEventManager.registerEvent("_DrillDied");
    }
    
    if (!isObject(GameListener))
    {
        $GameListener = new ScriptMsgListener(GameListener) 
        { 
            class = "GameEventListener"; 
        };
        
        // Module related subscriptions
        GameEventManager.subscribe(GameListener, "_DrillDied", "onDrillDied");
    }
}

// Cleanup the GameEventManager
function destroyGameEventManager()
{
    if (isObject(GameEventManager) && isObject(GameListener))
    {
        // Remove all the subscriptions
        GameEventManager.remove(GameListener, "_DrillDied");

        // Delete the actual objects
        GameEventManager.delete();
        GameListener.delete();
        
        // Clear the global variables, just in case
        $GameEventManager = "";
        $GameListener = "";
    }
}

function GameEventListener::onDrillDied(%this, %msgData)
{
echo("Drill is dead, people... - GameEventListener::onDrillDied");
}


// ...
function DrillClass::onDrillDied(%this, %msgData)
{
echo("Drill is dead, people... - DrillClass::onDrillDied");
}

// ... When a drill dies post the event:
//GameEventManager.postEvent("_DrillDied", %dyingDrill);

function RevertBackClass::onlevelloaded(%this)
{
  %revcirc = new t2dScroller()
   {
      scenegraph = scenewindow2d.getscenegraph();
      imageMap = "WhiteBackGroundImageMap";
      sourceRect = "0 0 0 0";
      canSaveDynamicFields = "1";
      Position = %this.position;
      size = %this.size;
      SrcBlendFactor = "ONE_MINUS_DST_COLOR";
      DstBlendFactor = "ZERO";
         mountID = "10";
   };
}

function Level3Temp::onLevelLoaded(%this)
{
%this.visible = 0;
}