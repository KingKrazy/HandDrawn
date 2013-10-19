//-----------------------------------------------------------------------------
// Platformer Starter Kit
// Copyright (C) - Phillip O'Shea
//-----------------------------------------------------------------------------

datablock t2dSceneObjectDatablock( PoisonedPineConeProjectileData : ProjectileBaseData )
{
    Class             = "PoisonedPineConeProjectile";
    ImageMap     = "PineCone_PoisonedImageMap";

    CollisionCallback      = true;
    CollisionDetectionMode = "PLATFORM_CIRCLE";
    CollisionCircleScale   = 0.2;

    Lifetime          = 3;
    Size              = "3.000 2.500";
    AngularVelocity   = 1080;

    ProjectileDamage  = 25;
};

new ScriptObject( PoisonedPineConeLauncherAction : ProjectileBaseAction )
{
    ProjectileType   = "t2dStaticSprite";
    ProjectileConfig = PoisonedPineConeProjectileData;
    ProjectileSpeed  = 105;
    ProjectileOffset = 1;
    ProjectileArc    = 0;
    Ammunition       = PoisonedPineConeAmmo;

    CoolDown         = 250;
    Continuous       = false;

    Burst            = false;
    BurstCount       = 3;
    BurstDelay       = 30;

    TriggerSound     = Lazershot;
};

//-----------------------------------------------------------------------------

new ScriptObject( PoisonedPineConeLauncherWeapon : WeaponBase )
{
    // Action
    ActionCount = 1;
    Action[0]   = PoisonedPineConeLauncherAction;
};

//-----------------------------------------------------------------------------
    $ExplodeSounds[1] = "Pine1";
    $ExplodeSounds[2] = "Pine2";
    $ExplodeSounds[3] = "Pine3";
    $ExplodeSounds[4] = "Pine4";

function PoisonedPineConeProjectile::onAddToScene( %this )
{
    $pineConeType = "Poisoned";

    if($playerAmmo >= 5)
    {
    $playerAmmo -= 5;
    }

   %this.LinearVelocity.Y = -7.5;
   %this.setConstantForce( 0 SPC 12.5, true );

   %PoisonedEffect = new t2dParticleEffect(PoisonedStuffPE) 
   {
      scenegraph = scenewindow2d.getSceneGraph();
      effectFile = "~/data/particles/PoisenEffect.eff";
      useEffectCollisions = "1";
      effectMode = "INFINITE";
      effectTime = "500";
      canSaveDynamicFields = "1";
      Position = %targetObject.position;
      size = "5.000 5.000";
      Layer = %targetObject.layer + 1;
      CollisionMaxIterations = "1";
         mountID = "224";
   };

  %link = %PoisonedEffect.mount(%this, "0 0");
  %PoisonedEffect.playEffect(true);
  %PoisonedEffect.isPlaying = true;

}

function PoisonedPineConeProjectile::onRemove( %this )
{
    $pineConeType = "Poisoned";

    //%effect.safeDelete();
    
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
    
    // Play Sound Effect.
    $ExplodeSound = $ExplodeSounds[getRandom(1,4)];

    // Play Sound Effect.
    playSound( $ExplodeSound, %volume );
}

function PoisonedPineConeImpactEffect::onAnimationEnd( %this )
{
    %this.safeDelete();
}

new ScriptObject( PoisonedPineConeAmmo : ProjectileBaseAmmo )
{
    ClipSize     = 100;
    MaxInventory = 1000;
};