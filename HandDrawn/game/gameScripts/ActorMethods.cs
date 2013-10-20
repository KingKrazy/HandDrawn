//-----------------------------------------------------------------------------
// Platformer Starter Kit
// Copyright (C) - Phillip O'Shea
//-----------------------------------------------------------------------------

function pskActor::onAddToScene( %this )
{
    // Set up some of the basics we need down the track
    %this.setCollisionDetection( "PLATFORM" );
    %this.setCollisionActive( true, true );
    %this.setCollisionPhysics( true, false );
    %this.setCollisionCallback( true );

    // If an object type has not been specified, then just use default settings
    if ( %this.ObjectType $= "" )
    {
        %this.setObjectType( "ActorObject" );
        %this.setCollidesWith( "PlatformObject ActorObject ActorTrigger" );
    }
}

function pskActor::onCollision( %ourObject, %theirObject, %ourRef, %theirRef, %time, %normal, %contacts, %points )
{
    // If we've hit an enemy, do a few specific checks
    %aiController = %theirObject.getBehavior( AIControllerBehavior );
    if ( %aiController )
    {
        %ourObject.resolveEnemyCollision( %theirObject, %normal );
    }
	
	// If we've hit a platform, do a few specific checks
	if (%theirObject.getBehavior(PlatformBehavior)){
		if (!%ourObject.onGround){
			// Are we against a wall
			%groundSurface = (%normal.Y < %ourObject.GroundCheckMaxNormal);
			if (!%groundSurface && mAbs(%normal.X) > 0){
				// Tell our owner that there was a wall, if it needs to do anything
				if (%ourObject.isMethod("hitWall")){
					%ourObject.hitWall(%theirObject, %normal);
				}
			}
		}
	}
}

//-----------------------------------------------------------------------------

function pskActor::getSoundVolume( %this, %position )
{
    return ( %this.OuterRadius - t2dVectorDistance( %this.Position, %position ) ) / ( %this.OuterRadius - %this.InnerRadius );    
}

function pskActor::getActiveWeapon( %this )
{
    // Return Active Weapon.
    return %this.ActiveWeapon;
}

function pskActor::setActiveWeapon( %this, %weaponData )
{
    // Record Active Weapon.
    %this.ActiveWeapon = %weaponData;
}

function pskActor::onAttack( %this, %index, %trigger )
{
    // Fetch Active Weapon.
    %activeWeapon = %this.getActiveWeapon();
    // Valid?
    if ( isObject( %activeWeapon ) )
    {
        // Weapon Already in Use?
        if ( %trigger && %activeWeapon.inUse( %this ) )
        {
            return;
        }
        
        // Fetch the Action Instance.
        %actionInstance = %activeWeapon.Action[%index];
        if ( isObject( %actionInstance ) )
        {
          $game::player.executeShootAnimationState();
            
            // Trigger the Action.
            %actionInstance.triggerAction( %this, %trigger );
        }
    }
}

function pskActor::onReload( %this, %trigger )
{
    if ( !%trigger )
    {
        return;
    }
    
    %weaponName  = %this.ActiveWeapon.getName();
    %actionCount = %weaponName.ActionCount;
    for ( %i = 0; %i < %actionCount; %i++ )
    {
        %ammoType = %weaponName.Action[%i].Ammunition.getName();
        %clipSize = %ammoType.ClisppSize;
        if ( isObject( %ammoType ) && %clipSize != -1 )
        {
            %ammoList       = %this.getFieldValue( %ammoType );
            %totalInventory = getWord( %ammoList, 0 ) + getWord( %ammoList, 1 );
            
            %newClip = %clipSize;
            if ( %newClip > %totalInventory )
            {
                %newClip = %totalInventory;
            }
            
            %newInventory = %totalInventory - %newClip;
            
            %this.setFieldValue( %ammoType, %newClip SPC %newInventory );
        }
    }
}

//-----------------------------------------------------------------------------
// 2D Actor Methods
//-----------------------------------------------------------------------------

function pskActor2D::getMuzzlePoint( %this )
{
    return %this.getPosition();
}

function pskActor2D::getMuzzleVector( %this )
{
    return ( 2 * !%this.FlipX - 1 ) SPC 0;
}

//-----------------------------------------------------------------------------
// 3D Actor Methods
//-----------------------------------------------------------------------------

function pskActor3D::setActiveWeapon( %this, %weaponData )
{
    // Fetch Puppet.
    %puppet = %this.getAnimationPuppet();
    if ( isObject( %puppet ) )
    {
        // Set the Mounted Shape.
        %puppet.setMountedShape( %weaponData.ShapeFile, %weaponData.MountPoint );
        
        // Apply the Offset.
        %puppet.setMountedShapeOffset( %weaponData.MountPoint, %weaponData.MountOffset );
    }
    
    // Parent Call.
    Parent::setActiveWeapon( %this, %weaponData );
}