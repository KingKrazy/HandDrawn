//-----------------------------------------------------------------------------
// Platformer Starter Kit
// Copyright (C) - Phillip O'Shea
//-----------------------------------------------------------------------------

datablock t2dSceneObjectDatablock( MultiPoisonedPineConeProjectileData : ProjectileBaseData )
{
    Class             = "MultiPoisonedPineConeProjectile";
    ImageMap     = "PineCone_PoisonedImageMap";

    CollisionCallback      = true;
    CollisionDetectionMode = "PLATFORM_CIRCLE";
    CollisionCircleScale   = 0.2;

    Lifetime          = 3;
    Size              = "3.000 2.500";
    AngularVelocity   = 1080;

    ProjectileDamage  = 25;
};

new ScriptObject( MultiPoisonedPineConeLauncherAction : ProjectileBaseAction )
{
    ProjectileType   = "t2dStaticSprite";
    ProjectileConfig = MultiPoisonedPineConeProjectileData;
    ProjectileSpeed  = 105;
    ProjectileOffset = 1;
    ProjectileArc    = 0;
    Ammunition       = MultiPoisonedPineConeAmmo;

    CoolDown         = 250;
    Continuous       = false;

    Burst            = true;
    BurstCount       = getRandom(2, 4);
    BurstDelay       = 30;

    TriggerSound     = Lazershot;
};

//-----------------------------------------------------------------------------

new ScriptObject( MultiPoisonedPineConeLauncherWeapon : WeaponBase )
{
    // Action
    ActionCount = 1;
    Action[0]   = MultiPoisonedPineConeLauncherAction;
};

//-----------------------------------------------------------------------------
    $ExplodeSounds[1] = "Pine1";
    $ExplodeSounds[2] = "Pine2";
    $ExplodeSounds[3] = "Pine3";
    $ExplodeSounds[4] = "Pine4";

function MultiPoisonedPineConeProjectile::onAddToScene( %this )
{

    $pineConeType = "Poisoned";


%VelocityNum = getRandom(7,10);

   %this.LinearVelocity.Y = -%velocityNum;
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

function MultiPoisonedPineConeProjectile::onRemove( %this )
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

function MultiPoisonedPineConeImpactEffect::onAnimationEnd( %this )
{
    %this.safeDelete();
}

new ScriptObject( MultiPoisonedPineConeAmmo : ProjectileBaseAmmo )
{
    ClipSize     = 100;
    MaxInventory = 1000;
};