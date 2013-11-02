//-----------------------------------------------------------------------------
// Platformer Starter Kit
// Copyright (C) - Phillip O'Shea
//-----------------------------------------------------------------------------

datablock t2dSceneObjectDatablock( BlobProjectileData : ProjectileBaseData )
{
    Class             = "BlobProjectile";
    ImageMap     = "Blob_NormalImageMap";

    CollisionCallback      = true;
    CollisionDetectionMode = "PLATFORM_CIRCLE";
    CollisionCircleScale   = 0.4;

    Lifetime          = 5;
    Size              = "3.000 3.000";
    AngularVelocity   = 1080;

    ProjectileDamage  = 5;
};

new ScriptObject( BlobLauncherAction : ProjectileBaseAction )
{
    ProjectileType   = "t2dStaticSprite";
    ProjectileConfig = BlobProjectileData;
    ProjectileSpeed  = 105;
    ProjectileOffset = 1;
    ProjectileArc    = 0;
    Ammunition       = BlobAmmo;

    CoolDown         = 500;
    Continuous       = false;

    Burst            = false;
    BurstCount       = 3;
    BurstDelay       = 30;

    TriggerSound     = Lazershot;
};

//-----------------------------------------------------------------------------

new ScriptObject( BlobLauncherWeapon : WeaponBase )
{
    // Action
    ActionCount = 1;
    Action[0]   = BlobLauncherAction;
};

//-----------------------------------------------------------------------------
    $ExplodeSounds[1] = "Pine1";
    $ExplodeSounds[2] = "Pine2";
    $ExplodeSounds[3] = "Pine3";
    $ExplodeSounds[4] = "Pine4";

function BlobProjectile::SpawnBlob(%this, %targetPos)
{
echo("Blob phase 3. Spawning!");

    %object = new t2dStaticSprite()
    {
    scenegraph = scenewindow2d.getScenegraph();
    ImageMap     = "Blob_NormalImageMap";
    position = %targetPos;
    CollisionCallback      = true;
    CollisionDetectionMode = "PLATFORM_CIRCLE";
    CollisionCircleScale   = 0.2;
    rotation = getRandom(0,360);
    size = "3 3";
    Lifetime          = 8;
    _behavior0 = "PineConePickupBehavior\tamount\t1\ttype\tBlobLauncherWeapon";
    _behavior1 = "PickupBehavior";
    };
}

function BlobProjectile::checkSpawnBlob(%this, %targetPos)
{
echo("Blob phase 1. Check if spawn.");

if(getRandom(1,3) == 2)
{
echo("Blob phase 2. Spawn is okay!");
%this.spawnBlob(%targetPos);
}
}

function BlobProjectile::onAddToScene( %this )
{
%this.isBlob = 1;
    if($playerAmmo >= 1)
    {
    $playerAmmo -= 1;
    }

    %this.pineconeType = "Normal";

   %this.LinearVelocity.Y = -2.5;
   %this.setConstantForce( 0 SPC 7.5, true );
}

function BlobProjectile::onRemove( %this )
{
   $PineconeType = "Normal";
    %this.checkSpawnBlob(%this.position);

    // Create Impact Animation.
    %impactEffect = new t2dParticleEffect()
    {
        SceneGraph    = %this.getSceneGraph();
        EffectFile    = "~/data/particles/BlobImpact.eff";
        
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

function BlobImpactEffect::onAnimationEnd( %this )
{
    %this.safeDelete();
}

new ScriptObject( BlobAmmo : ProjectileBaseAmmo )
{
    ClipSize     = 100;
    MaxInventory = 1000;
};