//-----------------------------------------------------------------------------
// Platformer Starter Kit
// Copyright (C) - JackRabbit Productions...
//-----------------------------------------------------------------------------

datablock t2dSceneObjectDatablock( BombProjectileData : ProjectileBaseData )
{
    Class             = "BombProjectile";
    AnimationName     = "BombAnimation";

    CollisionCallback      = true;
    CollisionDetectionMode = "PLATFORM_CIRCLE";
    CollisionCircleScale   = 0.4;

    Lifetime          = 10;
    Size              = "12.000 10.000";
 
    AngularVelocity   = 540;

    ProjectileDamage  = 500;
};

new ScriptObject( BombLauncherAction : ProjectileBaseAction )
{
    ProjectileType   = "t2dAnimatedSprite";
    ProjectileConfig = BombProjectileData;
    ProjectileSpeed  = 50;
    ProjectileOffset = 1;
    ProjectileArc    = 0;

    CoolDown         = 2000;
    Continuous       = true;

    Burst            = false;
    BurstCount       = 3;
    BurstDelay       = 30;

    //TriggerSound     = RocketLauncherFireSound;
};

//-----------------------------------------------------------------------------

new ScriptObject( BombLauncherWeapon : WeaponBase )
{
    // Action
    ActionCount = 1;
    Action[0]   = BombLauncherAction;
};

//-----------------------------------------------------------------------------

function BombProjectile::onAddToScene( %this )
{
   %this.LinearVelocity.Y = -100;
   %this.setConstantForce( 0 SPC 200, true );
}

function BombProjectile::onRemove( %this )
{
    // Create Impact Animation.
    %impactEffect = new t2dAnimatedSprite()
    {
        SceneGraph    = %this.getSceneGraph();
        Class         = "BombImpactEffect";
        AnimationName = "FireBallImpactAnimation";
        
        Position      = %this.Position;
        Rotation      = getRandom( 0, 360 );
        Size          = "25 25";
    };
    
    // Fetch the Volume for the Effect.
    %volume = $Game::Player.getSoundVolume( %this.Position );
    
    // Play Sound Effect.
    playSound( "FireballImpactSound", %volume );
}

function BombImpactEffect::onAnimationEnd( %this )
{
    %this.safeDelete();
}