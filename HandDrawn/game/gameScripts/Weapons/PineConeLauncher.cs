//-----------------------------------------------------------------------------
// Platformer Starter Kit
// Copyright (C) - Phillip O'Shea
//-----------------------------------------------------------------------------

datablock t2dSceneObjectDatablock( PineConeProjectileData : ProjectileBaseData )
{
    Class             = "PineConeProjectile";
    ImageMap     = "PineCone_NormalImageMap";

    CollisionCallback      = true;
    CollisionDetectionMode = "PLATFORM_CIRCLE";
    CollisionCircleScale   = 0.2;

    Lifetime          = 3;
    Size              = "3.000 2.500";
    AngularVelocity   = 1080;

    ProjectileDamage  = 100;
};

new ScriptObject( PineConeLauncherAction : ProjectileBaseAction )
{
    ProjectileType   = "t2dStaticSprite";
    ProjectileConfig = PineConeProjectileData;
    ProjectileSpeed  = 105;
    ProjectileOffset = 1;
    ProjectileArc    = 0;
    Ammunition       = PineConeAmmo;

    CoolDown         = 500;
    Continuous       = false;

    Burst            = false;
    BurstCount       = 3;
    BurstDelay       = 30;

    TriggerSound     = Lazershot;
};

//-----------------------------------------------------------------------------

new ScriptObject( PineConeLauncherWeapon : WeaponBase )
{
    // Action
    ActionCount = 1;
    Action[0]   = PineConeLauncherAction;
};

//-----------------------------------------------------------------------------
    $ExplodeSounds[1] = "Pine1";
    $ExplodeSounds[2] = "Pine2";
    $ExplodeSounds[3] = "Pine3";
    $ExplodeSounds[4] = "Pine4";

function PineConeProjectile::onAddToScene( %this )
{

    if($playerAmmo >= 1)
    {
    $playerAmmo -= 1;
    }

    $pineConeType = "Normal";

   %this.LinearVelocity.Y = -7.5;
   %this.setConstantForce( 0 SPC 12.5, true );
}

function PineConeProjectile::onRemove( %this )
{
   $PineConeType = "Normal";

    // Create Impact Animation.
    %impactEffect = new t2dParticleEffect()
    {
        SceneGraph    = %this.getSceneGraph();
        EffectFile    = "~/data/particles/PineConeImpact.eff";
        
        Position      = %this.Position;
        Rotation      = %this.Rotation;
        Size          = "5 1";
    };
        %impactEffect.playEffect();

    // Fetch the Volume for the Effect.
    %volume = $Game::Player.getSoundVolume( %this.Position );
    $ExplodeSound = $ExplodeSounds[getRandom(1,4)];

    // Play Sound Effect.
    playSound( $ExplodeSound, %volume );

}

function PineConeImpactEffect::onAnimationEnd( %this )
{
    %this.safeDelete();
}

new ScriptObject( PineConeAmmo : ProjectileBaseAmmo )
{
    ClipSize     = 100;
    MaxInventory = 1000;
};