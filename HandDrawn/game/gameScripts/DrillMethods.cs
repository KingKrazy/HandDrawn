//-----------------------------------------------------------------------------
// Platformer Starter Kit
// Copyright (C) Phillip O'Shea
//  
// Drill Methods - All of the methods that makes a Drill a Drill.
//-----------------------------------------------------------------------------

function DrillClass::onAddToScene( %this, %scenegraph )
{
    %this.alive = true;

    Parent::onAddToScene( %this );


%this.maxMoveSpeed = getRandom(20, 25);
  %this.aura = new t2dParticleEffect()
  {
      scenegraph = %this.getSceneGraph();
      effectFile = "~/data/particles/SpeedshotExplode.eff";
      useEffectCollisions = "1";
      layer = %this.getLayer();
      effectMode = "INFINITE";
      effectTime = "100";
      canSaveDynamicFields = "1";
      Position = "44.630 34.560";
      size = "30.400 30.293";
      SortPoint = "-0.037 -0.295";
      CollisionMaxIterations = "1";
      MountOffset = "-0.024 0.488";
      MountOwned = "0";
      MountInheritAttributes = "0";
         mountID = "10";
         mountToID = "9";
  };
  %link = %this.aura.mount(%this, "0 0");
  %this.aura.playEffect(true);
  %this.aura.isPlaying = true;

    if ( isObject( DrillHeadTemplate ) )
    {
        %this.DrillHead = new t2dSceneObject()
        {
            CollisionPolyList = "-1.000 1.000 -1.000 -1.000 -0.481 0.005";
            config     = DrillHeadTemplate;
            scenegraph = %scenegraph; //%this.scenegraph would probably work here as well

            FlipX = %this.FlipX;
        };
        %this.DrillHead.addToScene(%scenegraph);
        %this.DrillHead.mount( %this );
    }
}

function DrillClass::onRemove( %this )
{
    if ( isObject( %this.DrillHead ) )
    {
        %this.DrillHead.safeDelete();
    }
%this.aura.safeDelete();
%this.alive = false;

}

function DrillClass::onRespawn( %this, %dAmount, %srcObject )
{
    %this.DisableGravity = false;
    %this.alive = true;
}

function DrillClass::onDeath( %this, %dAmount, %srcObject )
{

    if ( isObject( %this.DrillHead ) )
    {
        %this.DrillHead.safeDelete();
    }

echo("HORATIO, I AM DEAD. AND IS IT THE FAULT OF AN AD TRIGGER? " @ %this.killedbyAD);
if(%this.onGround)
{
%this.linearvelocity.Y = "0";
%this.ConstantForce.Y = "0";
%this.gravity = "0 0";
}
if(!%this.killedByAD)
{
cancel($ComboEvent);
$PointsEarned += 100;




if($pointsEarned >= 100)
{
%Color = "0 0 1 1";
}

if($pointsEarned >= 500)
{
%Color = "0 1 1 1";
}

if($pointsEarned >= 1000)
{
%Color = "0 1 0 1";
}

if($pointsEarned >= 2000)
{
%Color = "1 1 0 1";
}

if($pointsEarned >= 5000)
{
%Color = "1 0 0 1";
}

if($pointsEarned >= 10000)
{
%Color = "0 0 0 1";
$pointsEarned = 10000;
}

    %TextSprite = new t2dTextObject()
    {
        SceneGraph    = Scenewindow2D.getSceneGraph();
      canSaveDynamicFields = "1";
      Position = %This.Position;
      size = "14.758 4.920";
      text = $PointsEarned;
      font = "OCR A Std";
      wordWrap = "1";
      hideOverflow = "1";
      textAlign = "Left";
      lineHeight = "4.91946";
      aspectRatio = "1.15903";
      lineSpacing = "0";
      characterSpacing = "0";
      autoSize = "0";
      fontSizes = "42";
      BlendColor = %Color;
      bilinearFilter = "1";
      snapToInteger = "0";
      noUnicode = "0";
         hideOverlap = "0";
         mountID = "794";
         snapToIntegerPos = "0";
      _behavior0 = "ScaleBehavior	xWidthMin	0.001	yWidthMin	0.001	xWidthMax	15	yWidthMax	5	DeleteObject	1";
      ConstantForce = "0 -50";

    };

$pref::points += $PointsEarned;

$ComboEvent = schedule(1500, 0, "ResetComboMeter");

%thingy = new t2dAnimatedSprite()
{
        SceneGraph    = Scenewindow2D.getSceneGraph();
        Animation     = "DrillDieAnimation";
        Class         = "CoolStuff";
        Animation      = %this.Animation;
        Layer         = %this.Layer - 1;
        Position      = %this.Position;
        Rotation      = %this.Rotation;
        AutoRotation  = $PencilAutoRotation[getRandom(0,1)];
        Lifetime = 2.0;
        ConstantForce = "0 50";
        Size          = %this.Size;
        _behavior0 = "ScaleBehavior\txWidthMin\t0\tyWidthMin\t0\txWidthMax\t7.5\tyWidthMax\t7.5\tTime\t1\tDelayStart\t0.5";

};
}

EnemyHealthBar.setValue(0);
%puppet = %this.getAnimationPuppet();
CurrentEnemy.setSceneObject(%nothing);

    %this.DisableGravity = true;

    
}

function DrillClass::resolveEnemyCollision( %this, %theirObject, %normal )
{
    // Resolve the collisions differently for different ai types    
    
    if( %this.Burning )
    {
            %BurnEffect = new t2dParticleEffect(RedStuffPE)
    {
      scenegraph = scenewindow2d.getSceneGraph();
      effectFile = "~/data/particles/FireEffect.eff";
      useEffectCollisions = "1";
      effectMode = "KILL";
      effectTime = "3000";
      canSaveDynamicFields = "1";
      rotation = %theirObject.rotation;
      Position = %theirObject.position;
      size = "5.000 5.000";
      Layer = %theirObject.layer - 1;
      CollisionMaxIterations = "1";
             mountID = "224";
    };

    %link = %BurnEffect.mount(%theirObject, "0 0.65");
    %BurnEffect.playEffect(true);
    %BurnEffect.isPlaying = true;

   %burnArea = new t2dTrigger()
    {
      scenegraph = scenewindow2d.getSceneGraph();
      canSaveDynamicFields = "1";
      Position = %theirObject.position;
      size = %theirObject.size;
      Layer = %theirObject.layer;
      CollisionActiveSend = "1";
      CollisionActiveReceive = "1";
         mountID = "166";
      _behavior0 = "AreaDamageBehavior	Amount	25	Interval	1";
   };

    %link2 = %BurnArea.mount(%theirObject, "0 0");
    }


    if( %theirObject.Burning )
    {
            %BurnEffect = new t2dParticleEffect(RedStuffPE)
    {
      scenegraph = scenewindow2d.getSceneGraph();
      effectFile = "~/data/particles/FireEffect.eff";
      useEffectCollisions = "1";
      effectMode = "KILL";
      effectTime = "3000";
      canSaveDynamicFields = "1";
      rotation = %this.rotation;
      Position = %this.position;
      size = "5.000 5.000";
      Layer = %theirObject.layer - 1;
      CollisionMaxIterations = "1";
             mountID = "224";
    };

    %link = %BurnEffect.mount(%this, "0 0.65");
    %BurnEffect.playEffect(true);
    %BurnEffect.isPlaying = true;

   %burnArea = new t2dTrigger()
    {
      scenegraph = scenewindow2d.getSceneGraph();
      canSaveDynamicFields = "1";
      Position = %this.position;
      size = %this.size;
      Layer = %this.layer;
      CollisionActiveSend = "1";
      CollisionActiveReceive = "1";
         mountID = "166";
      _behavior0 = "AreaDamageBehavior	Amount	25	Interval	1";
   };

    %link2 = %BurnArea.mount(%this, "0 0");
    }
}

function DrillClass::onWallCollision( %this, %wall, %normal )
{
    %this.Direction.X = %normal.X;
}

function DrillClass::onLanded( %this, %this, %platformObject )
{
//Blank for now...
}

function resetComboMeter()
{
$pointsEarned = 0;
}

