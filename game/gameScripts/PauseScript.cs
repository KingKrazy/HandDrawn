///Function for pausing the game

function canPause()
{
//$canPause = true;
}

function cantPause()
{
//$canPause = false;
}


function pauseModeActive()
{
    $mainSceneGraph = sceneWindow2D.getSceneGraph();
    $mainSceneGraph.setScenePause(true);
    Canvas.pushDialog(SelectLevelGui);
    Canvas.CursorOn();
    Canvas.ShowCursor();
    playSound( "Pause", 0.5 );
    //generateTip();
}
///Function for unpausing the game

function pauseModeUnactive()
{
$mainSceneGraph = sceneWindow2D.getSceneGraph();
$mainSceneGraph.setScenePause(false);
Canvas.popDialog(SelectLevelGui);
Canvas.CursorOff();
Canvas.HideCursor();
playSound( "Unpause", 0.5 );
}

function Freeze()
{
$mainSceneGraph = sceneWindow2D.getSceneGraph();
$mainSceneGraph.setScenePause(true);
}

function Unfreeze()
{
$mainSceneGraph = sceneWindow2D.getSceneGraph();
$mainSceneGraph.setScenePause(false);
}