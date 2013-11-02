//-----------------------------------------------------------------------------
// Platformer Starter Kit
// Copyright (C) - Phillip O'Shea
//-----------------------------------------------------------------------------

datablock t2dSceneObjectDatablock( MultiFrozenPineConeProjectileData : ProjectileBaseData )
{
    Class             = "MultiFrozenPineConeProjectile";
    ImageMap     = "PineCone_FrozenImageMap";

    CollisionCallback      = true;
    CollisionDetectionMode = "PLATFORM_CIRCLE";
    CollisionCircleScale   = 0.2;

    Lifetime          = 3;
    Size              = "3.000 2.500";
    AngularVelocity   = 1080;

    ProjectileDamage  = 25;
};

new ScriptObject( MultiFrozenPineConeLauncherAction : ProjectileBaseAction )
{
    ProjectileType   = "t2dStaticSprite";
    ProjectileConfig = MultiFrozenPineConeProjectileData;
    ProjectileSpeed  = 105;
    ProjectileOffset = 1;
    ProjectileArc    = 0;
    Ammunition       = MultiFrozenPineConeAmmo;

    CoolDown         = 500;
    Continuous       = false;

    Burst            = true;
    BurstCount       = getRandom(3, 5);
    BurstDelay       = 30;

    TriggerSound     = Lazershot;
};

//-----------------------------------------------------------------------------

new ScriptObject( MultiFrozenPineConeLauncherWeapon : WeaponBase )
{
    // Action
    ActionCount = 1;
    Action[0]   = MultiFrozenPineConeLauncherAction;
};

//-----------------------------------------------------------------------------
    $ExplodeSounds[1] = "Pine1";
    $ExplodeSounds[2] = "Pine2";
    $ExplodeSounds[3] = "Pine3";
    $ExplodeSounds[4] = "Pine4";

function MultiFrozenPineConeProjectile::onAddToScene( %this )
{


%player = $game::player;
    if(%player.flipX)
    {
    %mod = 1;
    }
    else
    {
    %mod = -1;
    }

    %this.Pineconetype = "Frozen";
    %this.LinearVelocity.Y = -150;
    %this.setConstantForce( %mod * getRandom(60, 100) SPC 200, true );

   %BurnEffect = new t2dParticleEffect(FreezeStuffPE) 
   {
      scenegraph = scenewindow2d.getSceneGraph();
      effectFile = "~/data/particles/FrozenStuffBlue.eff";
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

function MultiFrozenPineConeProjectile::onRemove( %this )
{
    %this.Pineconetype = "Frozen";

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

function MultiFrozenPineConeImpactEffect::onAnimationEnd( %this )
{
    %this.safeDelete();
}

new ScriptObject( MultiFrozenPineConeAmmo : ProjectileBaseAmmo )
{
    ClipSize     = 100;
    MaxInventory = 1000;
};