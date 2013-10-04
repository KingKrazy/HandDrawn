//-----------------------------------------------------------------------------
// Platformer Starter Kit
// Copyright (C) Phillip O'Shea
//  
// Check Point - Check points record spawn point and inventory information
//               for each spawn point, and actor in the scene. Check points
//               are a collectable item, meaning they must be added to an
//               object which contains a PickUp behavior.
//-----------------------------------------------------------------------------

if ( !isObject( CheckPointPickupBehavior ) )
{
    %template = new BehaviorTemplate( CheckPointPickupBehavior );
    
    %template.friendlyName = "Check Point Pick Up";
    %template.behaviorType = "Collectable";
    %template.description  = "Set the actor's restore point to this position";
}

function CheckPointPickupBehavior::onAddToScene(%this, %scenegraph)
{
%this.Owner.AngularVelocity = 180;
%this.Size = "10 10";
}

function CheckPointPickupBehavior::confirmPickup( %this, %targetObject, %inventoryItem )
{
    // Change the respawn position
    %targetObject.RespawnPosition = %this.Owner.Position;
    
    // Save the check point data
    saveCheckPoint();

    // Play the sound
    if ( isObject( checkPointPickupSound ) )
    {
        playSound( CheckPointPickupSound );
    }
    
    
        %impactSprite = new t2dStaticSprite()
    {
        SceneGraph    = Scenewindow2D.getSceneGraph();
        Class         = "EggImpactEffect";
        ImageMap      = "EggImageMap";
        Layer         = %this.Owner.Layer - 1;
        Position      = %this.Owner.Position;
        Rotation      = %this.Owner.Rotation;
        AutoRotation  = "1800";
        Lifetime = 2.0;
        Size          = "10 10";
        _behavior0 = "ScaleBehavior\txWidthMin\t0\tyWidthMin\t0\txWidthMax\t10\tyWidthMax\t10\tTime\t1\tDelayStart\t0.5";
    };


  %aura = new t2dParticleEffect()
  {
      scenegraph = sceneWindow2D.getSceneGraph();
      layer      = %impactSprite.layer - 1;
      effectFile = "~/data/particles/PurpleEffect.eff";
      useEffectCollisions = "1";
      class = "EggImpactParticles";
      effectMode = "kill";
      effectTime = "0.2";
      canSaveDynamicFields = "1";
      Position = %this.Owner.Position;
      size = "30.400 30.293";
      SortPoint = "-0.037 -0.295";
      CollisionMaxIterations = "1";
  };
    %aura.playEffect(true);
  %aura.isPlaying = true;
$pref::points = $pref::points + 1000;

    
    return true;


}

function saveCheckPoint()
{
    // The object list we'll use
    %SpawnPointList = getObjectTypeList( "SpawnPointObject" );
    if ( !isObject( %SpawnPointList ) )
    {
        return false;
    }
        
    // Record the number of objects spawned from each spawn point
    for ( %i = 0; %i < %SpawnPointList.getCount(); %i++ )
    {
        // Get the id
        %SpawnPoint = %SpawnPointList.getObject( %i ).getSpawnPointInstance();
        
        if ( !%SpawnPoint )
        {
            continue;
        }
        
        // Record the number of objects spawned at this time
        %SpawnPoint.CheckPointRecord = %SpawnPoint.SpawnCount;
        
        // Deduct the number of objects alive
        %SpawnPoint.CheckPointRecord -= %SpawnPoint.getSpawnedObjectCount();
    }
    
    // Save the contents of each actor's inventory
    %ActorList = getObjectTypeList( "ActorObject" );
    
    // Record all of the objects in the actor's inventory
    for ( %i = 0; %i < %ActorList.getCount(); %i++ )
    {
        %itemList = %ActorList.getObject( %i ).InventoryList;
        if ( isObject( %itemList ) )
        {
            %itemList.CheckPointRecord = %itemList.storeSet();
        }
    }
    
    return true;
}

function loadCheckPoint()
{        
    // The object list we'll use
    %SpawnPointList = getObjectTypeList( "SpawnPointObject" );
    if ( !isObject( %SpawnPointList ) )
    {
        return false;
    }
    
    for ( %i = 0; %i < %SpawnPointList.getCount(); %i++ )
    {
        // Get the id
        %SpawnPoint = %SpawnPointList.getObject( %i ).getSpawnPointInstance();
        
        if ( !%SpawnPoint || !%SpawnPoint.AutoDespawn )
        {
            continue;
        }
        
        // Destroy any spawned objects that haven't been removed
        %SpawnPoint.despawnAll();
        
        // Revert the number spawned to the number at the last check less removed object
        %SpawnPoint.SpawnCount = %SpawnPoint.CheckPointRecord;
        
        // Disable used spawn points
        if ( %SpawnPoint.SpawnCount == %SpawnPoint.MaxSpawnCount )
        {
            %SpawnPoint.Owner.enableUpdateCallback();
        }
    }
    
    // Restore the contents of each actor's inventory
    %ActorList = getObjectTypeList( "ActorObject" );
    
    // Restore the objects in the actor's inventory
    for ( %i = 0; %i < %ActorList.getCount(); %i++ )
    {
        %itemList = %ActorList.getObject( %i ).InventoryList;
        if ( isObject( %itemList ) )
        {
            %itemList.restoreSet( %itemList.CheckPointRecord, true );
        }
    }
    
    return true;
}

new SimGroup(CheckPoints) {

      new SpawnSphere(1) {
         Position = "34.1473 -152.619 108.67";
         rotation = "0 0 1 130.062";
         scale = "0.940827 1.97505 1";
         dataBlock = "SpawnSphereMarker";
         Radius = "10";
         sphereWeight = "1";
         indoorWeight = "1";
         outdoorWeight = "1";
            locked = "False";
            homingCount = "0";
            lockCount = "0";
      };
      new SpawnSphere(2) {
         Position = "42.7715 -225.175 165.694";
         rotation = "0 0 1 130.062";
         scale = "0.940827 1.97505 1";
         dataBlock = "SpawnSphereMarker";
         Radius = "10";
         sphereWeight = "1";
         indoorWeight = "1";
         outdoorWeight = "1";
            locked = "False";
            homingCount = "0";
            lockCount = "0";
      };
   };
   new Trigger(1) {
      Position = "23.0141 -134.828 102.986";
      rotation = "1 0 0 0";
      scale = "1 1 1";
      dataBlock = "CheckpointTrigger";
      polyhedron = "0.0000000 0.0000000 0.0000000 1.0000000 0.0000000 0.0000000 0.0000000 -1.0000000 0.0000000 0.0000000 0.0000000 1.0000000";
   };
   new Trigger(2) {
      Position = "23.0141 -134.828 102.986";
      rotation = "1 0 0 0";
      scale = "1 1 1";
      dataBlock = "CheckpointTrigger";
      polyhedron = "0.0000000 0.0000000 0.0000000 1.0000000 0.0000000 0.0000000 0.0000000 -1.0000000 0.0000000 0.0000000 0.0000000 1.0000000";
   };