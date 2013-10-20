//-----------------------------------------------------------------------------
// Platformer Starter Kit
// Copyright (C) JackRabbit Productions
//  
//-----------------------------------------------------------------------------

if ( !isObject( RegenerationPickupBehavior ) )
{
    %template = new BehaviorTemplate( RegenerationPickupBehavior );
    
    %template.friendlyName = "Heart Regeneration Powerup";
    %template.behaviorType = "Collectable";
    %template.description  = "Regenerate the actor\'s health for a few seconds.";
    %template.addBehaviorField(RegenTimeOut, "Ammount of time before clearing effect (Milliseconds)", float, "5000");

}

function RegenerationPickupBehavior::confirmPickup( %this, %targetObject, %inventoryItem )
{
$regenActive = "Active";
playsound(heartPowerup);
startRegenerating();
$HeartRegenEvent = schedule(%this.RegenTimeOut, 0, "ClearRegen");
%this.Owner.safeDelete();
HealthBarFlashRevert();

   %RegenEffect = new t2dParticleEffect(PinkStuffPE) 
   {
      scenegraph = scenewindow2d.getSceneGraph();
      effectFile = "~/data/particles/BurningStuff.eff";
      useEffectCollisions = "1";
      effectMode = "KILL";
      effectTime = %this.RegenTimeOut / 1000;
      canSaveDynamicFields = "1";
      Position = %targetObject.position;
      size = "5.000 5.000";
      Layer = %targetObject.layer - 1;
      CollisionMaxIterations = "1";
         mountID = "224";
   };

  %link = %RegenEffect.mount(%targetObject, "0 0");
  %RegenEffect.playEffect(true);
  %RegenEffect.isPlaying = true;
}

function healthBarFlashGreen()
{
if($regenActive $= "Active")
{
HealthBar.profile = "guiProgressDoneProfile";
schedule(250, 0, "healthBarFlashRevert");
playsound(heartRegen);
}
else
{
HealthBar.profile = "guiProgressProfile";
}
}

function healthBarFlashRevert()
{
if($regenActive $= "Active")
{
HealthBar.profile = "guiProgressProfile";
schedule(1000, 0, "healthBarFlashGreen");
}
else
{
HealthBar.profile = "guiProgressProfile";
}
}

function startRegenerating()
{
if($regenActive $= "Active")
{
$game::player.healDamage( 0.005 );
schedule(1, 0, "startRegenerating");
}
}

function ClearRegen()
{
cancel($HeartRegenEvent);
$regenActive = 0;
echo("Fun\'s over. Hearts have stopped replenishing.");
}