//-----------------------------------------------------------------------------
// Platformer Starter Kit
// Copyright (C) - Phillip O'Shea
//-----------------------------------------------------------------------------

datablock t2dSceneObjectDatablock( SpreadshotProjectileData : ProjectileBaseData )
{
    Class             = "SpreadshotProjectile";
    AnimationName     = "FireBallAnimation1";

    CollisionCallback      = true;
    CollisionDetectionMode = "PLATFORM_CIRCLE";
    CollisionCircleScale   = 0.2;

    Lifetime          = 3;
    Size              = "9.000 7.000";
    
    ProjectileDamage  = 40;
};

new ScriptObject( SpreadshotLauncherAction : ProjectileBaseAction )
{
    ProjectileType   = "t2dAnimatedSprite";
    ProjectileConfig = SpreadshotProjectileData;
    ProjectileSpeed  = 117;
    ProjectileOffset = 0;
    ProjectileArc    = 17.5;

    CoolDown         = 1250;
    Continuous       = false;

    Burst            = true;
    BurstCount       = getRandom( 5, 10 );
    BurstDelay       = 30;

    TriggerSound     = BurstShot;
};

//-----------------------------------------------------------------------------

new ScriptObject( SpreadshotLauncherWeapon : WeaponBase )
{
    // Action
    ActionCount = 1;
    Action[0]   = SpreadshotLauncherAction;
};

//-----------------------------------------------------------------------------

function SpreadshotProjectile::onRemove( %this )
{
    // Create Impact Animation.
    %impactEffect = new t2dAnimatedSprite()
    {
        SceneGraph    = %this.getSceneGraph();
        Class         = "FireBallImpactEffect";
        AnimationName = "FireBallImpactAnimation";
        
        Position      = %this.Position;
        Rotation      = getRandom( 0, 360 );
        Size          = "15 15";
    };
    
    // Fetch the Volume for the Effect.
    %volume = $Game::Player.getSoundVolume( %this.Position );
    
    // Play Sound Effect.
    playSound( "SpeedshotExplode", %volume );
}

function FireBallImpactEffect::onAnimationEnd( %this )
{
    %this.safeDelete();
}