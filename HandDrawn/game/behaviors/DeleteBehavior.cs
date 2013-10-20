//-----------------------------------------------------------------------------
// Platformer Starter Kit
// Copyright (C) Phillip O'Shea
//  
// Pick-Up Item - In most games, there are objects which can be collected.
//                Add this behavior to an object that you want to be
//                collectable. The type of object that is to be picked up
//                must be specified in another behavior (see PepperPickup or
//                CheckPoint behaviors for more information).
//-----------------------------------------------------------------------------

if ( !isObject( DeleteBehavior ) )
{
    %template = new BehaviorTemplate( DeleteBehavior );

    %template.friendlyName = "Delete Behavior";
    %template.behaviorType = "Collectable";
    %template.description  = "Deletes this item.";

    %template.addBehaviorField( PlayerOnly, "Only delete if the player hits it.", BOOL, false );
}

function DeleteBehavior::onAddToScene( %this, %scenegraph )
{
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

function DeleteBehavior::onEnter( %this, %theirObject )
{
%this.Owner.safeDelete();
// Simple as that.
}

function DeleteBehavior::onCollision( %this, %theirObject, %ourRef, %theirRef, %time, %normal, %contacts, %points )
{
%this.Owner.safeDelete();
// Simple as that.
}