//-----------------------------------------------------------------------------
// Platformer Starter Kit
// Copyright (C) JackRabbit Productions
//  
//-----------------------------------------------------------------------------

if ( !isObject( RespPickupBehavior ) )
{
    %template = new BehaviorTemplate( RespPickupBehavior );
    
    %template.friendlyName = "Resp Powerup";
    %template.behaviorType = "Collectable";
    %template.description  = "Allows the player to be able to breath under water until the end of the level.";

}

function RespPickupBehavior::confirmPickup( %this, %targetObject, %inventoryItem )
{
%targetObject.canSwim = 1;
%targetObject.temporarySwim = 1;
}