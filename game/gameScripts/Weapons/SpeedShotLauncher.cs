//-----------------------------------------------------------------------------
// Platformer Starter Kit
// Copyright (C) - Phillip O'Shea
//-----------------------------------------------------------------------------

datablock t2dSceneObjectDatablock( SpeedshotProjectileData : ProjectileBaseData )
{
    Class             = "SpeedShotProjectile";
    Imagemap          = "BoltImagemap";

    CollisionCallback      = true;
    CollisionDetectionMode = "PLATFORM_CIRCLE";
    CollisionCircleScale   = 0.2;
    ProjectileSpread	= getRandom( 50, 150 );
    Lifetime          = 1.5;
    Size              = "1.000 0.500";
    
    ProjectileDamage  = 5;
};

new ScriptObject( SpeedShotLauncherAction : ProjectileBaseAction )
{
    ProjectileType   = "t2dStaticSprite";
    ProjectileConfig = SpeedShotProjectileData;
    ProjectileSpeed  = 100;
    ProjectileOffset = 5;
    ProjectileArc    = getRandom( 15, 20 );

    CoolDown         = 30;
    Continuous       = true;

    Burst            = false;
    BurstCount       = 3;
    BurstDelay       = 30;

    TriggerSound     = SpeedShotBlast;
};

//-----------------------------------------------------------------------------

new ScriptObject( SpeedShotLauncherWeapon : WeaponBase )
{
    // Action
    ActionCount = 1;
    Action[0]   = SpeedShotLauncherAction;
};

//-----------------------------------------------------------------------------

function SpeedShotProjectile::onRemove( %this )
{
    // Create Impact Animation.
    %impactAnimation = new t2dAnimatedSprite()
    {
        SceneGraph    = %this.getSceneGraph();
        Class         = "BoneImpactEffect";
        AnimationName = "BoneFragmentAnimation";
        
        Position      = %this.Position;
        Rotation      = getRandom( 0, 360 );
        Size          = "5 5";
    };
    
    // Create Impact Effect.
    %impactEffect = new t2dParticleEffect()
    {
        SceneGraph    = %this.getSceneGraph();
        EffectFile    = "resources/PlatformerArt/data/particles/BoneImpactEffect.eff";
        
        Position      = %this.Position;
        Rotation      = %this.Rotation;
        Size          = "5 1";
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