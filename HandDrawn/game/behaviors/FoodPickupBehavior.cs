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

if ( !isObject( FoodPickupBehavior ) )
{
    %template = new BehaviorTemplate( FoodPickupBehavior );

    %template.friendlyName = "Food Pick-up Item";
    %template.behaviorType = "Collectable";
    %template.description  = "Get add this food to the inventory!";

    %template.addBehaviorField( TargetType,       "Pick up this type of object",               ENUM,   "Soup", "Apple" TAB "Beans" TAB "MagicBeans" TAB "MagicApple" TAB "Banana" );
    %template.addBehaviorField( DeleteOnPickup, "Delete this item once it is picked up", BOOL, true );
}

function FoodPickupBehavior::onAddToScene( %this, %scenegraph )
{
    // Make sure this object doesn't collide
    %this.Owner.setCollisionActive( 0, 1 );
    %this.Owner.setCollisionPhysics( 0, 0 );
    %this.Owner.setCollisionCallback( 1 );

    // Make sure the trigger only collides with the player
    %this.Owner.setObjectType( "PlayerTrigger" );
    %this.Owner.setCollidesWith( "PlayerObject" );
    
    if ( %this.Owner.isMethod( "setNeverSolvePhysics" ) )
    {
        // No Physics resolution
        %this.Owner.setNeverSolvePhysics( true );
    }
}

function FoodPickupBehavior::onCollision( %this, %theirObject, %ourRef, %theirRef, %time, %normal, %contacts, %points )
{

    // Notify other behaviors the object has been picked up
    %behaviorCount = %this.Owner.getBehaviorCount();
    for ( %i = 0; %i < %behaviorCount; %i++ )
    {
        // Get the ith behavior
        %behavior = %this.Owner.getBehaviorByIndex( %i );

        // Skip this one
        if ( %behavior == %this )
        {
            continue;
        }

        // Check if we've been picked up or not
        if ( %behavior.isMethod( "confirmPickup" ) )
        {
            %canDelete = %behavior.confirmPickup( %theirObject, %inventoryItem );
        }
    }

    // Destroy the object?
    if ( %this.DeleteOnPickup && %canDelete )
    {
        if ( !%inventoryItem )
        {
            %this.Owner.safeDelete();
        }
    }
%this.targetObject.text += 1;

}