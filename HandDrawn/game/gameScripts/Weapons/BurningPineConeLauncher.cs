//-----------------------------------------------------------------------------
// Platformer Starter Kit
// Copyright (C) - Phillip O'Shea
//-----------------------------------------------------------------------------

datablock t2dSceneObjectDatablock( BurningPineConeProjectileData : ProjectileBaseData )
{
    Class             = "BurningPineConeProjectile";
    ImageMap     = "PineCone_BurningImageMap";

    CollisionCallback      = true;
    CollisionDetectionMode = "PLATFORM_CIRCLE";
    CollisionCircleScale   = 0.2;

    Lifetime          = 3;
    Size              = "3.000 2.500";
    AngularVelocity   = 1080;

    ProjectileDamage  = 25;
};

new ScriptObject( BurningPineConeLauncherAction : ProjectileBaseAction )
{
    ProjectileType   = "t2dStaticSprite";
    ProjectileConfig = BurningPineConeProjectileData;
    ProjectileSpeed  = 105;
    ProjectileOffset = 1;
    ProjectileArc    = 0;
    Ammunition       = BurningPineConeAmmo;

    CoolDown         = 500;
    Continuous       = false;

    Burst            = false;
    BurstCount       = 3;
    BurstDelay       = 30;

    TriggerSound     = Lazershot;
};

//-----------------------------------------------------------------------------

new ScriptObject( BurningPineConeLauncherWeapon : WeaponBase )
{
    // Action
    ActionCount = 1;
    Action[0]   = BurningPineConeLauncherAction;
};

//-----------------------------------------------------------------------------
    $ExplodeSounds[1] = "Pine1";
    $ExplodeSounds[2] = "Pine2";
    $ExplodeSounds[3] = "Pine3";
    $ExplodeSounds[4] = "Pine4";

function BurningPineConeProjectile::onAddToScene( %this )
{

    if($playerAmmo >= 2)
    {
    $playerAmmo -= 2;
    }

   if(!$game::player.isSwimming)
   {
   %this.Pineconetype = "Burn";
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
   else
   {
   playSound(extinguish);
   %this.blendColor = "0.1 0.1 0.1 1";
   %this.Pineconetype = "Normal";
   }
   
   %this.LinearVelocity.Y = -7.5;
   %this.setConstantForce( 0 SPC 12.5, true );


}

function BurningPineConeProjectile::onRemove( %this )
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

function BurningPineConeImpactEffect::onAnimationEnd( %this )
{
    %this.safeDelete();
}

new ScriptObject( BurningPineConeAmmo : ProjectileBaseAmmo )
{
    ClipSize     = 100;
    MaxInventory = 1000;
};