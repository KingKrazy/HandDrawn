//-----------------------------------------------------------------------------
// Platformer Starter Kit
// Copyright (C) - Phillip O'Shea
//-----------------------------------------------------------------------------

datablock t2dSceneObjectDatablock( MultiPineConeProjectileData : ProjectileBaseData )
{
    Class             = "MultiPineConeProjectile";
    ImageMap     = "PineCone_NormalImageMap";

    CollisionCallback      = true;
    CollisionDetectionMode = "PLATFORM_CIRCLE";
    CollisionCircleScale   = 0.2;

    Lifetime          = 3;
    Size              = "3.000 2.500";
    AngularVelocity   = 1080;

    ProjectileDamage  = 25;
};

new ScriptObject( MultiPineConeLauncherAction : ProjectileBaseAction )
{
    ProjectileType   = "t2dStaticSprite";
    ProjectileConfig = MultiPineConeProjectileData;
    ProjectileSpeed  = 105;
    ProjectileOffset = 1;
    ProjectileArc    = 17.5;
    Ammunition       = MultiPineConeAmmo;

    CoolDown         = 500;
    Continuous       = false;

    Burst            = true;
    BurstCount       = getRandom( 3, 5 );
    BurstDelay       = 30;

    TriggerSound     = BurstShot;
};

//-----------------------------------------------------------------------------

new ScriptObject( MultiPineConeLauncherWeapon : WeaponBase )
{
    // Action
    ActionCount = 1;
    Action[0]   = MultiPineConeLauncherAction;
};

//-----------------------------------------------------------------------------
    $ExplodeSounds[1] = "Pine1";
    $ExplodeSounds[2] = "Pine2";
    $ExplodeSounds[3] = "Pine3";
    $ExplodeSounds[4] = "Pine4";

function MultiPineConeProjectile::onAddToScene( %this )
{
    $PineConeType = "Normal";
%VelocityNum = getRandom(7,10);

   %this.LinearVelocity.Y = -%velocityNum;
   %this.setConstantForce( 0 SPC 12.5, true );

}

function MultiPineConeProjectile::onRemove( %this )
{
   $PineConeType = "Normal";

    // Create Impact Animation.
    %impactEffect = new t2dParticleEffect()
    {
        SceneGraph    = scenewindow2D.getSceneGraph();
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

function MultiPineConeImpactEffect::onAnimationEnd( %this )
{
    %this.safeDelete();
}

new ScriptObject( MultiPineConeAmmo : ProjectileBaseAmmo )
{
    ClipSize     = 100;
    MaxInventory = 1000;
};