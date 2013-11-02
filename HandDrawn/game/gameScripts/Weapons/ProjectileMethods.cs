//-----------------------------------------------------------------------------
// Platformer Starter Kit
// Copyright (C) - Phillip O'Shea
//-----------------------------------------------------------------------------
function PlayerClass::changeWeapon(%this, %weapon)
{
%service = %weapon @ "LauncherWeapon";
%this.setActiveWeapon(%sevice);
HUDPineconeImage.Bitmap = "~/data/images/Pine/buttons" @ %service @ ".png";
}


function PlayerClass::addMoreAmmo( %this, %referenceObject )
{
        %ammoType = %this.Ammunition;
        %ammoClip = %ammoClip + 100;

}

function pskProjectileAction::triggerLoop( %this, %referenceObject )
{
$Game::Cheat::InfiniteAmmo = 0;
    // Grab the type of ammo we're using
    // Note: If there is no ammo specified then there is assumed INFINITE ammo!
    if ( !$Game::Cheat::InfiniteAmmo )
    {
        %ammoType = %this.Ammunition;
        %ammoClip = 0;
        if ( isObject( %ammoType ) )
        {
            %ammoType = %ammoType.getName();

            if ( %ammoType.Clip != -1 )
            {
                %ammoClip = getWord( %referenceObject.getFieldValue( %ammoType ), 0 );
            }
            else
            {
                %ammoClip = %referenceObject.getFieldValue( %ammoType );
            }
        }

        if ( isObject( %ammoType ) && %ammoClip == 0 )
        {
            // No ammo remaining
            return;
        }
    }

    // Call the parent
    Parent::triggerLoop( %this, %referenceObject );

    // Create the projectile
    %this.createProjectile( %referenceObject );

    // Reduce the amount of ammo remaining
    %ammoClip -= 1;

    if ( %this.Burst )
    {
        %burstQuantity = %this.BurstCount - 1;
        if ( isObject( %ammoType ) && %burstQuantity > %ammoClip )
        {
            // Make sure we don't fire more than we have remaining
            %burstQuantity = %ammoClip;
        }

        for ( %i = 0; %i < %burstQuantity; %i++ )
        {
            %this.schedule( %this.BurstDelay * %i, "createProjectile", %referenceObject );
        }

        // Reduce the amount of ammo remaining
        %ammoClip -= %burstQuantity;
    }

    if ( isObject( %ammoType ) )
    {
        if ( %ammoType.Clip != -1 )
        {
            // Fetch the amount of ammo spare
            %ammoQuantity = getWord( %referenceObject.getFieldValue( %ammoType ), 1 );

            // Apply the new quantity
            %referenceObject.setFieldValue( %ammoType, %ammoClip SPC %ammoQuantity );
        }
        else
        {
            // Apply the new quantity
            %referenceObject.setFieldValue( %ammoType, %ammoClip );
        }
    }

    // Update GUI
    %referenceObject.updateWeaponGui();
}

function pskProjectileAction::createProjectile( %this, %referenceObject )
{


//%this.ProjectileOffset
    // Fetch Projectile Information.
    %projectileType   = %this.ProjectileType;
    %projectileConfig = %this.ProjectileConfig;
    %projectileSpeed  = %this.ProjectileSpeed;
    %projectileOffset = 5;
    %projectileArc    = %this.ProjectileArc;
    %referenceObject.executeShootAnimationState();
    // Valid?

    if ( %projectileType $= "" || !isObject( %projectileConfig ) )
    {
        // Invalid.
        return false;
    }

    // Fetch the Muzzle Point & Vector.
    %muzzlePoint  = %referenceObject.getMuzzlePoint();
    %muzzleVector = %referenceObject.getMuzzleVector();

    // Random Offset?
    if ( %projectileArc > 0 )
    {
        // Offset the projected angle by some random number
        %projectionOffset       = ( 2.0 * getRandom() - 1.0 ) * ( %projectileArc / 2 );
        %projectionOffsetMatrix = mRotationMatrix( %projectionOffset );
        %muzzleVector           = mMatrixMultiply( %projectionOffsetMatrix, %muzzleVector );
    }

    // Spatial Calculations.
    %projectileFlip     = false;
    %projectilePosition = t2dVectorAdd( %muzzlePoint, t2dVectorScale( %muzzleVector, %projectileOffset ) );
    %projectileVelocity = t2dVectorScale( %muzzleVector, %projectileSpeed );
    %projectileRotation = mRadToDeg( mAtan( %muzzleVector.Y, %muzzleVector.X ) );
    %projectileAngularVelocity = %projectileConfig.AngularVelocity;
    
    // Normalize Angle.
    while ( %projectileRotation < 0 )   %projectileRotation += 360;
    while ( %projectileRotation > 360 ) %projectileRotation -= 360;
    
    // Flip the Projectile?
    if ( %projectileRotation > 90 && %projectileRotation < 270 )
    {
        %projectileFlip = true;
        %projectileAngularVelocity *= -1;
    }
    %ThePosY = %referenceObject.Position.Y - 2;
    if(!%referenceObject.isMount)
    {
    %ThePos = %referenceObject.position.X SPC %ThePosY;
    }
    else
    {
    %thePosY = %referenceObject.Position.Y - 5;
    %ThePos = %referenceObject.position.X SPC %ThePosY;
    }

    // Create the Projectile.
    %newProjectile = new ( %projectileType )()
    {
        Config          = %projectileConfig;
        SceneGraph      = %referenceObject.getSceneGraph();

        Layer           = $Game::Effects::Layer;
        
        FlipY           = %projectileFlip;

        Position        = %thePos;
        LinearVelocity  = %projectileVelocity;
        
        Rotation        = %projectileRotation;
        AngularVelocity = %projectileAngularVelocity;
    };
    
    // Ensure Projectiles Collide with the Correct Groups.
    switch$ ( %referenceObject.ObjectType )
    {
        // Player Shooting.
        case "PlayerObject" : %newProjectile.setObjectType( "PlayerProjectile" );
                              %newProjectile.setCollidesWith( "PlatformObject EnemyObject" );
                              
        // Enemy Shooting.
        case "EnemyObject" :  %newProjectile.setObjectType( "EnemyProjectile" );
                              %newProjectile.setCollidesWith( "PlatformObject PlayerObject" );
    }
    
    // Return the Projectile.
    return %newProjectile;


}

//-----------------------------------------------------------------------------

function pskProjectile::triggerImpact( %this, %theirObject )
{
    // Already Collided?
    if ( %this.Collided )
    {
        // Ensure only one Impact is Triggered.
        return false;
    }
%theirObject.wasHurtByPlayer = 1;

    %projectileCollider = %theirObject.getBehavior( ProjectileColliderBehavior );
    if ( %projectileCollider && !%projectileCollider.TriggerImpact )
    {
        // Make sure we don't handle collisions with colliders that don't want
        // the impact triggered!
        return false;
    }

    // Flag that we have Collided.

    %this.Collided = true;

    return true;
}

function pskProjectile::onWallCollision( %this, %wall, %normal )
{
    %this.triggerImpact();
}


function pskProjectile::onCollision( %ourObject, %theirObject, %ourRef, %theirRef, %time, %normal, %contacts, %points )
{

    // Trigger Impact?
    if ( !%ourObject.triggerImpact( %theirObject ) )
    {
        // Quit.
        return;
    }
    
    // Actor?
    if ( %theirObject.isMemberOfClass( "pskActor" ) )
    {
        // Damage the Target.
        %theirObject.takeDamage( %ourObject.ProjectileDamage, %ourObject, true, true );
    
        if ( %this.Pineconetype $= "Burn" )
    {
        // Notify.
        echo("Burning pine cone detected. BURNINATE!!!");

        %theirObject.Burning = true;
        %BurnEffect = new t2dParticleEffect(RedStuffPE)
    {
      scenegraph = scenewindow2d.getSceneGraph();
      effectFile = "~/data/particles/FireEffect.eff";
      useEffectCollisions = "1";
      effectMode = "KILL";
      effectTime = "3000";
      canSaveDynamicFields = "1";
      rotation = %theirObject.rotation;
      Position = %theirObject.position;
      size = "5.000 5.000";
      Layer = %theirObject.layer + 1;
      CollisionMaxIterations = "1";
             mountID = "224";
    };

    %link = %BurnEffect.mount(%theirObject, "0 0");
    %BurnEffect.playEffect(true);
    %BurnEffect.isPlaying = true;
    %theirObject.maxMoveSpeed *= 1.5;
    Burn(%theirObject);

    %link2 = %BurnArea.mount(%theirObject, "0 0");

        }


        if ( %this.Pineconetype $= "Frozen" && !%this.Sub )
    {
        // Notify.
        echo("Frozen pine cone detected. FREEZINATE!!!");

        %theirObject.Frozen = true;

        %puppet = %this.getAnimationPuppet();


   %FreezeEffect = new t2dStaticSprite()
   {
        SceneGraph    = Scenewindow2D.getSceneGraph();
        Class         = "IceBlockEffect";
        ImageMap      = "IceBlockImageMap";
        Layer         = %theirObject.Layer;
        Position      = %theirObject.Position;
        Rotation      = 0;
        Size          = %theirObject.Size;
        DetectionMode = "POLYGON";
        CollisionActiveSend = "1";
        CollisionActiveReceive = "1";
        CollisionCallback = "1";
        ConstantForce = "0.000 150.000";

       _behavior0 = "PlatformBehavior\tSurfaceFriction	0.5";
    };

    %linkFreeze = %theirObject.mount(%freezeEffect, "0 0");
    %theirObject.setPaused(true);
        }
        else if ( %this.Pineconetype $= "Frozen" && %this.Sub )
        {
        %this.healDamage(15);
        }



            if ( %this.Pineconetype $= "Poisened" )
    {

        %theirObject.Poisened = true;
        %PoisenEffect = new t2dParticleEffect(RedStuffPE)
    {
      scenegraph = scenewindow2d.getSceneGraph();
      effectFile = "~/data/particles/PoisenEffect.eff";
      useEffectCollisions = "1";
      effectMode = "KILL";
      effectTime = "3000";
      canSaveDynamicFields = "1";
      rotation = %theirObject.rotation;
      Position = %theirObject.position;
      size = "5.000 5.000";
      Layer = %theirObject.layer - 1;
      CollisionMaxIterations = "1";
             mountID = "224";
    };

    %link = %PoisenEffect.mount(%theirObject, "0 0.65");
    %PoisenEffect.playEffect(true);
    %PoisenEffect.isPlaying = true;
    %theirObject.maxMoveSpeed /= 2;
   %PoisenArea = new t2dTrigger()
    {
      scenegraph = scenewindow2d.getSceneGraph();
      canSaveDynamicFields = "1";
      Position = %theirObject.position;
      size = %theirObject.size;
      Layer = %theirObject.layer;
      CollisionActiveSend = "1";
      CollisionActiveReceive = "1";
         mountID = "166";
      _behavior0 = "AreaDamageBehavior	Amount	25	Interval	1";
   };

    %linkPois = %PoisenArea.mount(%theirObject, "0 0");

        }

    
    
    //End Conditions...
    }

    //There's sometimes a little trouble with this part so we're fixing it...
    if ( %theirObject.isMemberOfClass( "SnakeClass" ) )
    {
        // Damage the Target.
        %theirObject.takeDamage( %ourObject.ProjectileDamage, %ourObject, true, true );
    }

}

function Burn( %object )
{
if(%object.health > 0)
{
if(%object.sub)
{
%object.takeDamage( 50, %null, true, true );
}
else
{
%object.takeDamage( 25, %null, true, true );
}
schedule(1000, 0, "burn", %object);
}
}