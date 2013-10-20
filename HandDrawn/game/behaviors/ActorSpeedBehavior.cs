//-----------------------------------------------------------------------------
// Platformer Starter Kit
// Copyright (C) Phillip O'Shea
//  
// Area Damage - This behavior can be owned by either a Trigger or a Scene
//               Object. If a player enters the trigger it will take damage,
//               and will continue to do so each interval. If an actor
//               collides with a scene object, then it will take damage upon
//               collision.
//-----------------------------------------------------------------------------

if ( !isObject( ActorSpeedBehavior ) )
{
    %template = new BehaviorTemplate( ActorSpeedBehavior );

    %template.friendlyName = "Actor Speed";
    %template.behaviorType = "Platform";
    %template.description  = "Speed to set the actor to. Use on platforms.";

    %template.addBehaviorField( PlayerOnly, "Slow the player, not other actors",       BOOL,  false );
    %template.addBehaviorField( Speed,     "Speed to set to.",                          FLOAT, 0.0 );
}

/// Set up the object
function ActorSpeedBehavior::onAddToScene( %this, %scenegraph )
{
%StoredSpeed = %theirObject.MaxMoveSpeed;

    // Collision system
    if ( %this.PlayerOnly )
    {
        %this.Owner.setObjectType( "PlayerTrigger" );
        %this.Owner.setCollidesWith( "PlayerObject" );
    }
    else
    {
        %this.Owner.setObjectType( "ActorTrigger" );
        %this.Owner.setCollidesWith( "ActorObject" );
    }
}

//Adjusts the player's speed
function ActorSpeedBehavior::onEnter( %this, %theirObject, %storedSpeed )
{
%theirObject.MaxMoveSpeed = %this.Speed;
}

function ActorSpeedBehavior::onLeave( %this, %theirObject, %storedSpeed )
{
%theirObject.MaxMoveSpeed = %storedSpeed;
}