//-----------------------------------------------------------------------------
// Platformer Starter Kit
// Copyright (C) - Phillip O'Shea
//-----------------------------------------------------------------------------

datablock t2dSceneObjectDatablock( MultiBurningPineConeProjectileData : ProjectileBaseData )
{
    Class             = "MultiBurningPineConeProjectile";
    ImageMap     = "PineCone_BurningImageMap";

    CollisionCallback      = true;
    CollisionDetectionMode = "PLATFORM_CIRCLE";
    CollisionCircleScale   = 0.2;

    Lifetime          = 3;
    Size              = "3.000 2.500";
    AngularVelocity   = 1080;

    ProjectileDamage  = 25;
};

new ScriptObject( MultiBurningPineConeLauncherAction : ProjectileBaseAction )
{
    ProjectileType   = "t2dStaticSprite";
    ProjectileConfig = MultiBurningPineConeProjectileData;
    ProjectileSpeed  = 105;
    ProjectileOffset = 1;
    ProjectileArc    = 0;
    Ammunition       = MultiBurningPineConeAmmo;

    CoolDown         = 500;
    Continuous       = false;

    Burst            = true;
    BurstCount       = getRandom(2, 4);
    BurstDelay       = 30;

    TriggerSound     = Lazershot;
};

//-----------------------------------------------------------------------------

new ScriptObject( MultiBurningPineConeLauncherWeapon : WeaponBase )
{
    // Action
    ActionCount = 1;
    Action[0]   = MultiBurningPineConeLauncherAction;
};

//-----------------------------------------------------------------------------
    $ExplodeSounds[1] = "Pine1";
    $ExplodeSounds[2] = "Pine2";
    $ExplodeSounds[3] = "Pine3";
    $ExplodeSounds[4] = "Pine4";

function MultiBurningPineConeProjectile::onAddToScene( %this )
{

    %this.Pineconetype = "Burn";
%VelocityNum = getRandom(7,10);

   %this.LinearVelocity.Y = -%velocityNum;
   %this.setConstantForce( 0 SPC 12.5, true );

   %BurnEffect = new t2dParticleEffect(RedStuffPE) 
   {
      scenegraph = scenewindow2d.getSceneGraph();
      effectFile = "~/data/particles/BurningStuffRed.eff";
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

  %link = %BurnEffect.mount(%this, "0 0");
  %BurnEffect.playEffect(true);
  %BurnEffect.isPlaying = true;

}

function MultiBurningPineConeProjectile::onRemove( %this )
{
    %this.Pineconetype = "Burn";

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

function MultiBurningPineConeImpactEffect::onAnimationEnd( %this )
{
    %this.safeDelete();
}

new ScriptObject( MultiBurningPineConeAmmo : ProjectileBaseAmmo )
{
    ClipSize     = 100;
    MaxInventory = 1000;
};