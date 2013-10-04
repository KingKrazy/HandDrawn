//-----------------------------------------------------------------------------  
    //-----------------------------------------------------------------------------  
    // Torque Game Builder  
    // Copyright (C) GarageGames.com, Inc.  
    //   
    // A Swimming-Zone Behavior written by JackRabbit  
    //-----------------------------------------------------------------------------  
    /*
      1) Add a global to point to your player, called $player.
      2) Create a sceneObject, named MyTrigger and drop this behavior on it.
      3) Turn off all collisions for this.
    */  
    if (!isObject(SZBehavior))  
    {  
       %template = new BehaviorTemplate(SZBehavior);  
         
       %template.friendlyName = "Swimming Zone Trigger";  
       %template.behaviorType = "System";  
       %template.description  = "Preform actions when the player is in the water.";  
       %template.addBehaviorField( PlayerOnly, "Collide with the player, not other actors",       BOOL,  true );

       %template.addBehaviorField(NormalMusic, "What the person should say when they are collided with.", string, "NormalMusic");
       %template.addBehaviorField(WaterMusic, "What the person should say when  they are collided with.", string, "WaterMusic");


    }
        
function SZBehavior::WaterMusicOn(%this)
{
alxStopAll();
$musicHandle1 = alxPlay(%this.NormalMusic); 
alxSourcef($musicHandle1, "AL_GAIN_LINEAR", 1);
$musicHandle2 = alxPlay(%this.WaterMusic); 
alxSourcef($musicHandle2, "AL_GAIN", 1);
turnOnWM();
turnOnNorm();
}

function turnonWM()
{
alxSourcef($musicHandle2, "AL_GAIN", 1);
}

function turnOffWM()
{
alxSourcef($musicHandle2, "AL_GAIN", 0);
}

function turnonNorm()
{
alxSourcef($musicHandle1, "AL_GAIN_LINEAR", 1);
}

function turnOffNorm()
{
alxSourcef($musicHandle1, "AL_GAIN_LINEAR", 0);
}

          

    function WMKickstart()
    {
    //Placeholder!
    }

    function SZBehavior::onAddToScene(%this, %scenegraph)
    {
    alxStopAll();
    %this.WaterMusicOn();
    
    %this.Owner.setObjectType( "PlayerTrigger" );
    %this.Owner.setCollidesWith( "PlayerObject" );
    }
    
    function SZBehavior::onEnter(%this, %theirObject)
    {
    if($game::player.linearVelocity.Y > 0)
    {
    
        %theirObject.inWater = 1;

       // get the extents of this scene object
    $game::player.gravity = "0 -10";

      %aura = new t2dParticleEffect()
  {
      scenegraph = sceneWindow2D.getSceneGraph();
      layer      = 0;
      effectFile = "~/data/particles/WaterStuff.eff";
      useEffectCollisions = "1";
      class = "WaterParticles";
      effectMode = "kill";
      effectTime = "0.2";
      canSaveDynamicFields = "1";
      Position = %theirObject.Position;
      size = "30.400 30.293";
      SortPoint = "-0.037 -0.295";
      CollisionMaxIterations = "1";
  };
    %aura.playEffect(true);
  %aura.isPlaying = true;

if(!$game::player.canSwim)
{
newtimer(25, "KillPlayer", "You're going to drown in:");
startSwimming();
}
else
{
startSwimming();
}
}
else
{
echo("Bad velocity on enter!");
}
}

function SZBehavior::onLeave(%this, %theirObject, %noVelCheck)
{
echo("Called \"SZBehavior::OnLeave,\" checking if we have a good velocity.");

if($game::player.linearVelocity.Y < 0)
{
    %theirobject.inWater = 0;

    echo($game::player.LinearVelocity.Y @ " IS A GOOD VELOCITY!!! - SZBehavior::OnLeave");
    %theirObject.setAnimationState( "Jump" );


      %aura = new t2dParticleEffect()
  {
      scenegraph = sceneWindow2D.getSceneGraph();
      layer      = 0;
      effectFile = "~/data/particles/WaterStuff.eff";
      useEffectCollisions = "1";
      class = "WaterParticles";
      effectMode = "kill";
      effectTime = "0.2";
      canSaveDynamicFields = "1";
      Position = %theirObject.Position;
      size = "30.400 30.293";
      SortPoint = "-0.037 -0.295";
      CollisionMaxIterations = "1";
  };
    %aura.playEffect(true);
    %aura.isPlaying = true;


    if(!$game::player.canSwim)
    {
    killTimer();
    stopSwimming();
    }
    else
    {
    stopSwimming();
    }
}
else
{
error($game::player.LinearVelocity.Y @ " IS A BAD VELOCITY!!! - SZBehavior::OnLeave");
}
}

	function startSwimming()
	{
    turnOnWM();
    TurnOffNorm();

    echo("Swimming!");
    $game::player.isSwimming = 1;
    
    $game::player.maxMoveSpeed = 40;
    $game::player.AirAccel = 30;
    $game::player.AirDecel = 12.5;
    $game::player.GroundAccel = 45;
    $game::player.GroundDecel = 125;

    echo("StartSwimming method gravity... " @ $game::player.gravity);
    echo("StartSwimming Method: isSwimming = " @ $game::player.isSwimming);
    

    }

    function stopSwimming()
	{
    TurnOffWM();
    TurnOnNorm();

    warn("Not Swimming!");
    $game::player.isSwimming = 0;
    $game::player.maxMoveSpeed = 80;
    $game::player.AirAccel = 60;
    $game::player.AirDecel = 25;
    $game::player.GroundAccel = 90;
    $game::player.GroundDecel = 250;
    $game::player.gravity = "0 200";

    echo("StopSwimming Method: isSwimming = " @ %theirobject.isSwimming);
    
    }