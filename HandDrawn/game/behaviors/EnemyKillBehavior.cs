//-----------------------------------------------------------------------------
// Platformer Starter Kit
// Copyright (C) Phillip O'Shea
//  
// Enemy Turn Trigger - When an enemy enters this trigger, it will be forced
//                      to turn and face the other direction. This allows you
//                      to control where an enemy can move to.
//-----------------------------------------------------------------------------

if ( !isObject( EnemyKillBehavior ) )
{
    %template = new BehaviorTemplate( EnemyKillBehavior );

    %template.friendlyName = "Enemy Kill Trigger";
    %template.behaviorType = "Miscellaneous";
    %template.description  = "When an enemy object enters, HE'LL DIE!";
}

/// Set up the trigger
function EnemyKillBehavior::onAddToScene( %this, %scenegraph )
{
    // Make sure we're a trigger
    if ( %this.Owner.getClassName() !$= "t2dTrigger" )
    {
        error( "EnemyKillBehavior::onAddToScene() - This Behavior must be used with a t2dTrigger object" );
        return;
    }

    // Make sure we check events properly
    %this.Owner.setEnterCallback( 1 );
    %this.Owner.setStayCallback ( 0 );
    %this.Owner.setLeaveCallback( 0 );

    // Ensure that the player doesn't collide with this trigger
    %this.Owner.setObjectType( "EnemyTrigger" );
    %this.Owner.setCollidesWith( "None" );
}

function EnemyKillBehavior::onEnter( %this, %theirObject )
{
    // Redirect the actor
if(%theirObject !$= $game::player)
{
%theirObject.takeDamage( 1000, "NaturalCauses", true, false );
}
}