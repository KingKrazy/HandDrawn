//-----------------------------------------------------------------------------
// Platformer Starter Kit
// Copyright (C) JackRabbit Productions
//  
//-----------------------------------------------------------------------------

if ( !isObject( SpeedPickupBehavior ) )
{
    %template = new BehaviorTemplate( SpeedPickupBehavior );
    
    %template.friendlyName = "Speed Powerup";
    %template.behaviorType = "Collectable";
    %template.description  = "Give the actor super speed for a few seconds.";
   %template.addBehaviorField(SpeedTimeOut, "Ammount of time before clearing speed (Milliseconds)", float, "5000");

}

function SpeedPickupBehavior::confirmPickup( %this, %targetObject, %inventoryItem )
{
playsound(speedpowerup);
$Game::player.MaxMoveSpeed = 250;    

//Sync animation time with speed
DragonRunAnimation.animationTime = "0.2";
DragonRunAnimation.animationTime = "0.2";
updateAnimation(DragonRunAnimation);
updateAnimation(CavemanRunAnimation);

%timeout = %this.speedTimeOut / 1000;

CavemanRunAnimation.animationTime = "0.2";
newTimer(%timeout, "clearSpeed", "FootFlight Time Left:");

$game::player.getAnimationPuppet().doSimpleAfterImageEffect(50, %this.speedTimeOut, true, true, 0.14, 50, 0);
%this.Owner.safeDelete();
}

function ClearSpeed()
{
$Game::player.MaxMoveSpeed = 80;
DragonRunAnimation.animationTime = "0.3";
CavemanRunAnimation.animationTime = "0.3";
DragonRunAnimation.updateAnimation();
CavemanRunAnimation.updateAnimation();

}