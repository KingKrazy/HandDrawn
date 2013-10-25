function SnakeClass::onAddToScene( %this )
{
    Parent::onAddToScene( %this );

%this.maxMoveSpeed = getRandom(20, 25);
    %this.DisableGravity = false;
    echo(%this.Gravity);

  %this.aura = new t2dParticleEffect()
  {
      scenegraph = %this.getSceneGraph();
      effectFile = "~/data/particles/SpeedshotExplode2.eff";
      useEffectCollisions = "1";
      layer = %this.getLayer();
      effectMode = "INFINITE";
      effectTime = "100";
      canSaveDynamicFields = "1";
      Position = "44.630 34.560";
      size = "5 5";
      SortPoint = "0.038 0.042";
      CollisionMaxIterations = "1";
      MountOffset = "0 1.25";
      MountOwned = "0";
      MountInheritAttributes = "0";
         mountID = "10";
         mountToID = "9";
  };
  %link = %this.aura.mount(%this, "0 0.50");
  %this.aura.playEffect(true);
  %this.aura.isPlaying = true;

    if ( isObject( DrillHeadTemplate ) )
    {
        %this.DrillHead = new t2dSceneObject()
        {
            config     = DrillHeadTemplate;
            scenegraph = %scenegraph; //%this.scenegraph would probably work here as well

            FlipX = %this.FlipX;
        };
        %this.DrillHead.addToScene(%scenegraph);
        %this.DrillHead.mount( %this );
    }

}

function SnakeClass::onRemove( %this )
{

echo("SPLOSION!!!");

   %Explosion = new t2dStaticSprite()
   {
      SceneGraph    = Scenewindow2D.getSceneGraph();
      Class         = "PowExplodeEffect";
      imageMap      = "pow_2ImageMap";
      Layer         = 1;
      Position      = %this.Position;
      Rotation      = %this.Rotation;
      size = "50.000 50.000";
      _behavior0 = "ScaleBehavior\tTime\t0.5\tGrow\t1\tAutoRotate\t800\tDeleteObject\t1";
   };
       %this.aura.safeDelete();

   %SplodeArea = new t2dTrigger() 
   {
      SceneGraph    = Scenewindow2D.getSceneGraph();
      canSaveDynamicFields = "1";
      Position      = %Explosion.position;
      size = "50.000 50.000";
      Layer         = 1;
      CollisionActiveSend = "1";
      CollisionActiveReceive = "1";
      CollisionCallback = "1";
      CollisionDetectionMode = "CIRCLE";
         mountID = "175";
      _behavior0 = "AreaDamageBehavior\tAmount\t50";
      _behavior1 = "ScaleBehavior\tTime\t0.5\tGrow\t1\tAutoRotate\t800\tDeleteObject\t1";
   };


   // -----------------------------------------
   // This part right here
   %instance = ScaleBehavior.createInstance();   
   %this.addBehavior(%instance);
   echo(%instance);
   // -----------------------------------------

}

function SnakeClass::onRespawn( %this, %dAmount, %srcObject )
{
    %this.DisableGravity = false;
}

function SnakeClass::onLanded( %this, %platformObject )
{
}

$EFX[0] = "Explode1";
$EFX[1] = "Explode2";


function SnakeClass::onDeath( %this, %dAmount, %srcObject )       
{
if(%this.onGround)
{
%this.linearvelocity.Y = "0";
%this.ConstantForce.Y = "0";
%this.gravity = "0 0";
}

    if ( isObject( %this.DrillHead ) )
    {
        %this.DrillHead.safeDelete();
    }

if(!%this.killedbyAD)
{


%explodeEffect = $EFX[getRandom(0,1)];

    // Fetch the Volume for the Effect.
    %volume = $Game::Player.getSoundVolume( %this.Position );
    
    // Play Sound Effect.
    playSound( %explodeEffect, %volume );

echo(%explodeEffect, %volume);


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
    %this.startScale();

}

EnemyHealthBar.setValue(0);
%puppet = %this.getAnimationPuppet();
CurrentEnemy.setSceneObject(%nothing);

    %this.DisableGravity = true;
}

function SnakeClass::startScale(%this)
{
if(!%this.alive)
{
if(%this.getAnimationPuppet().size.X < 40 && %this.getAnimationPuppet().size.Y < 40)
{
%this.getAnimationPuppet().size.X += 0.5;
%this.getAnimationPuppet().size.Y += 0.5;
%this.schedule(32, "startScale");
}
}
}

function SnakeClass::onWallCollision( %this, %wall, %normal )
{
    %this.Direction.X = %normal.X;
}

function SnakeClass::resolveEnemyCollision( %ourObject, %theirObject, %normal )
{
    // Resolve the collisions differently for different ai types
    switch$ ( %theirObject.ActorType )
    {
        case "Drill" : %OurObject.Direction.X *= -1; break;
        case "Snake" : %OurObject.Direction.X *= -1;
    }
}

function SnakeDieAnimationClass::onAnimationEnd( %this )
{
playSound(FireballImpactSound);

    %this.DisableGravity = true;

}
