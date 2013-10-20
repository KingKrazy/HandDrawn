//-----------------------------------------------------------------------------
// Platformer Starter Kit
// Copyright (C) Phillip O'Shea
//  
// Level Complete - This must be attached to a pick-up behavior. It will
//                  trigger the game over sequence and stores a field for you
//                  to specify the next level to be loaded (though I haven't
//                  provided the scripts to load another level).
//-----------------------------------------------------------------------------

if ( !isObject( LevelCompletePickupBehavior ) )
{
    %template = new BehaviorTemplate( LevelCompletePickupBehavior );

    %template.friendlyName = "Level Complete Pick-up";
    %template.behaviorType = "Collectable";
    %template.description  = "Complete the current level";

    %template.addBehaviorField( NextLevel, "Loads this level when complete", DEFAULT, "" );
}

function LevelCompletePickupBehavior::confirmPickup( %this, %targetObject, %inventoryItem )
{
    // Ensure the player cannot respawn
    %targetObject.AllowRespawn = false;

    // Stop moving
    %targetObject.Controller.Direction = "0 0";
    %targetObject.MoveSpeed            = "0 0";
    %targetObject.setLinearVelocityX( 0 );

    // Stop the controller
    moveMap.pop();

    //Freeze!

$mainSceneGraph = sceneWindow2D.getSceneGraph();
$mainSceneGraph.setScenePause(true);


    // Run the level complete function

    // Load the next level
    $mainSceneGraph.setScenePause(false);
    playMusic(YouWin);
    
    %PowSprites1 = new t2dStaticSprite() 
    {
      scenegraph = sceneWindow2D.getSceneGraph();
      imageMap = "Black_PatchImageMap";
      sourceRect = "0 0 0 0";
      layer = 0;
      canSaveDynamicFields = "1";
      Position = $game::player.position;
      size = "214.000 167.000";
         mountID = "95";
   };

    %PowSprites2 = new t2dStaticSprite()
    {
      scenegraph = sceneWindow2D.getSceneGraph();
      imageMap = "powImageMap";
      sourceRect = "0 0 0 0";
      canSaveDynamicFields = "1";
      Position = %powsprites1.position;
      size = "126.290 126.290";
      layer = 0;
      AutoRotation = "45";
         mountID = "96";
      _behavior0 = "ScaleBehavior\txWidthMin\t0.001\tyWidthMin\t0.001\txWidthMax\t135\tyWidthMax\t135\tTime\t1\tgrow\t1";
   };

    %PowSprites3 = new t2dStaticSprite()
    {
      scenegraph = sceneWindow2D.getSceneGraph();
      imageMap = "pow_2ImageMap";
      sourceRect = "0 0 0 0";
      canSaveDynamicFields = "1";
      Position = %powsprites2.position;
      layer = 0;
      size = "75.000 75.000";
      AutoRotation = "-45";
         mountID = "97";
      _behavior0 = "ScaleBehavior\txWidthMin\t0.001\tyWidthMin\t0.001\txWidthMax\t75\tyWidthMax\t75\tTime\t1.5\tgrow\t1";
   };


  %nullaura = new t2dParticleEffect()
  {
      scenegraph = sceneWindow2D.getSceneGraph();
      layer      = %impactSprite.layer - 1;
      effectFile = "~/data/particles/PurpleEffect.eff";
      useEffectCollisions = "1";
      class = "PencilImpactParticles";
      effectMode = "kill";
      effectTime = "0.2";
      canSaveDynamicFields = "1";
      Position = %this.Owner.Position;
      size = "30.400 30.293";
      SortPoint = "-0.037 -0.295";
      CollisionMaxIterations = "1";
  };
    //%aura.playEffect(true);
  //%aura.isPlaying = true;

canvas.showCursor();
$pref::points += 10000;
canvas.pushDialog(LevelCompleteGui);
$nextLevel = %this.NextLevel;
$playerLevel = $nextLevelNumber;
//loadNewLevel( %this.NextLevel, 5000 );
levelComplete();

    return true;

}