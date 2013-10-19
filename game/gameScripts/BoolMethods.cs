//-----------------------------------------------------------------------------
// Platformer Starter Kit
// Copyright (C) Phillip O'Shea
//  
// Drill Methods - All of the methods that makes a Drill a Drill.
//-----------------------------------------------------------------------------

function BoolClass::onAddToScene( %this, %scenegraph )
{
    %this.alive = true;

    Parent::onAddToScene( %this );


%this.maxMoveSpeed = getRandom(15, 20);
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
            config     = DrillHeadTemplate;
            scenegraph = %scenegraph; //%this.scenegraph would probably work here as well

            FlipX = %this.FlipX;
        };
        %this.DrillHead.addToScene(%scenegraph);
        %this.DrillHead.mount( %this );
    }
}

function BoolClass::onRemove( %this )
{
    if ( isObject( %this.DrillHead ) )
    {
        %this.DrillHead.safeDelete();
    }
%this.aura.safeDelete();
%this.alive = false;

}

function BoolClass::onRespawn( %this, %dAmount, %srcObject )
{
    %this.DisableGravity = false;
    %this.alive = true;
}

function BoolClass::onDeath( %this, %dAmount, %srcObject )
{
$pref::points = $pref::points + 100;
    %this.alive = false;


EnemyHealthBar.setValue(0);
%puppet = %this.getAnimationPuppet();
CurrentEnemy.setSceneObject(%nothing);

    %this.DisableGravity = true;

    if ( isObject( %this.DrillHead ) )
    {
        %this.DrillHead.safeDelete();
    }

    %TextSprite = new t2dTextObject()
    {
        SceneGraph    = Scenewindow2D.getSceneGraph();
      canSaveDynamicFields = "1";
      Position = %This.Position;
      size = "14.758 4.920";
      text = "+100";
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
      BlendColor = "0 0 1 1";
      bilinearFilter = "1";
      snapToInteger = "0";
      noUnicode = "0";
         hideOverlap = "0";
         mountID = "794";
         snapToIntegerPos = "0";
      _behavior0 = "ScaleBehavior	xWidthMin	0.001	yWidthMin	0.001	xWidthMax	15	yWidthMax	5	DeleteObject	1";
      ConstantForce = "0 -50";

    };

}

function BoolClass::resolveEnemyCollision( %this, %theirObject, %normal )
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

function BoolClass::onWallCollision( %this, %wall, %normal )
{
    %this.Direction.X = %normal.X;
}

function BoolClass::onLanded( %this, %this, %platformObject )
{
echo("Landed!");
%number = %this.direction.X * 45;
%this.bounce(%this.jumpForce, %number);
}
