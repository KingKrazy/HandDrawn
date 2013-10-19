//-----------------------------------------------------------------------------
// Platformer Starter Kit
// Copyright (C) JackRabbit Productions
//  
//-----------------------------------------------------------------------------

if ( !isObject( TractionPickupBehavior ) )
{
    %template = new BehaviorTemplate( TractionPickupBehavior );
    
    %template.friendlyName = "Traction Powerup";
    %template.behaviorType = "Collectable";
    %template.description  = "Give the actor super traction for a while.";
}

function TractionPickupBehavior::onAddToScene(%this, %scenegraph)
{
	%this.RespawnPosition   = %this.Owner.getPosition();
}

function TractionPickupBehavior::onRemove( %this )
{
%this.RespawnEvent = %this.schedule(%this.SpawnTimeOut * 1000, "respawn");
}
function TractionPickupBehavior::confirmPickup( %this, %targetObject, %inventoryItem )
{
playsound(tractionpowerup);

$Game::player.AirAccel = 500;
$Game::player.AirDecel = 500;
$Game::player.GroundAccel = 500;
$Game::player.GroundDecel = 500;

schedule(60000, 0, "ClearTraction");
%this.Owner.safeDelete();
}

function ClearTraction()
{
$Game::player.AirAccel = 60;
$Game::player.AirDecel = 25;
$Game::player.GroundAccel = 90;
$Game::player.GroundDecel = 250;
}