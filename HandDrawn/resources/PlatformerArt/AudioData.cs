//-----------------------------------------------------------------------------
//  Platformer Starter Kit
//  Copyright (C) Phillip O'Shea
//-----------------------------------------------------------------------------

//------------------------------------------------------------------------------
//
// Audio
//
//------------------------------------------------------------------------------


//--------------------------------------------------------------------------
// ogg-Music player
//--------------------------------------------------------------------------




$bubbleSound[1] = "Bubbles1";
$bubbleSound[2] = "Bubbles2";
$bubbleSound[3] = "Bubbles3";

new AudioDescription(MusicLooping)
{
    volume = 2.0;
    isLooping = true;
    is3D = false;
    type = $MusicAudioType;
};

new AudioDescription(MusicLooping2)
{
    volume = 2.0;
    isLooping = true;
    is3D = false;
    type = $MusicAudioType;
};


datablock AudioDescription( SoundOnce )
{
    volume    = 2.0;
    type      = 0;
    isLooping = false;
    is3D      = false;
};

datablock AudioDescription( BingSound )
{
    volume    = 0.4;
    type      = 0;
    isLooping = false;
    is3D      = false;
};


datablock AudioDescription( SoundLoop )
{
    volume    = 2.0;
    type      = 0;
    isLooping = true;
    is3D      = false;
};

datablock AudioDescription( MusicLoop )
{
    volume    = 1.0;
    type      = 1;
    isLooping = true;
    is3D      = false;
};

datablock AudioDescription( MusicLoop2 )
{
    volume    = 1.0;
    type      = 1;
    isLooping = true;
    is3D      = false;
};

datablock AudioDescription( MusicOnce )
{
    volume    = 1.0;
    type      = 1;
    isLooping = false;
    is3D      = false;
};

datablock AudioProfile( Explode1 )
{
    filename    = "./data/audio/vert/Explode1.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( Explode2 )
{
    filename    = "./data/audio/vert/Explode2.wav";
    description = "SoundOnce";
    preload     = true;
};


datablock AudioProfile( PepperPickupSound )
{
    filename    = "./data/audio/general/pepper_pickup.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( ExtinguishSound )
{
    filename    = "./data/audio/general/Extinguish.wav";
    description = "SoundOnce";
    preload     = true;
};


datablock AudioProfile( StartupSound )
{
    filename    = "./data/audio/general/Startup.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( MLBO )
{
    filename    = "./data/audio/general/MLButtonOver.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( MLBS )
{
    filename    = "./data/audio/general/MLButtonSelect.wav";
    description = "SoundOnce";
    preload     = true;
};


datablock AudioProfile( Bubbles1 )
{
    filename    = "./data/audio/general/Bubbles1.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( Bubbles2 )
{
    filename    = "./data/audio/general/Bubbles2.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( Bubbles3 )
{
    filename    = "./data/audio/general/Bubbles3.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( Wind )
{
    filename    = "./data/audio/general/Wind.wav";
    description = SoundLoop;
    preload     = true;
};

datablock AudioProfile( Talk )
{
    filename    = "./data/audio/general/talk.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( KrazyTalk )
{
    filename    = "./data/audio/general/KrazyTalk.wav";
    description = "SoundOnce";
    preload     = true;
};


datablock AudioProfile( TalkFin )
{
    filename    = "./data/audio/general/talkFin.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( TalkDone )
{
    filename    = "./data/audio/general/talkDone.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( Prompt )
{
    filename    = "./data/audio/general/Prompt.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( Bing1 )
{
    filename    = "./data/audio/general/bing1.wav";
    description = "BingSound";
    preload     = true;
};

datablock AudioProfile( Bing2 )
{
    filename    = "./data/audio/general/bing2.wav";
    description = "BingSound";
    preload     = true;
};

datablock AudioProfile( Bing3 )
{
    filename    = "./data/audio/general/bing3.wav";
    description = "BingSound";
    preload     = true;
};

datablock AudioProfile( Bing4 )
{
    filename    = "./data/audio/general/bing4.wav";
    description = "BingSound";
    preload     = true;
};

datablock AudioProfile( Bing5 )
{
    filename    = "./data/audio/general/bing5.wav";
    description = "BingSound";
    preload     = true; 
};

datablock AudioProfile( Bing6 )
{
    filename    = "./data/audio/general/bing6.wav";
    description = "BingSound";
    preload     = true;
};

datablock AudioProfile( Bing7 )
{
    filename    = "./data/audio/general/bing7.wav";
    description = "BingSound";
    preload     = true;
};

datablock AudioProfile( Back )
{
    filename    = "./data/audio/general/Back.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( PlatformMoving )
{
    filename    = "./data/audio/general/Converyer_Loop.wav";
    description = "SoundOnce";
    preload     = true;
};


datablock AudioProfile( Kaching )
{
    filename    = "./data/audio/general/Kaching.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( Pause )
{
    filename    = "./data/audio/general/Pause.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( Unpause )
{
    filename    = "./data/audio/general/Unpause.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( LevelSaved )
{
    filename    = "./data/audio/general/LevelSaved.wav";
    volume    = 0.5;
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( Error )
{
    filename    = "./data/audio/general/Error.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( Lazershot )
{
    filename    = "./data/audio/general/basiclazershot.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( SpeedshotBlast )
{
    filename    = "./data/audio/general/Speedshot_BlastLoop.wav";
    description = SoundLoop;
    preload     = true;
};

datablock AudioProfile( VertExplode )
{
    filename    = "./data/audio/general/VertExplode.wav";
    description = "SoundOnce";
    preload     = true;
};


datablock AudioProfile( YesMin1 )
{
    filename    = "./data/audio/general/YesA.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( YesMin2 )
{
    filename    = "./data/audio/general/YesB.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( YouLose )
{
    filename    = "./data/audio/general/YouLose.wav";
    description = "SoundOnce";
    preload     = true;
};


datablock AudioProfile( Yes )
{
    filename    = "./data/audio/general/YesC.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( Pine1 )
{
    filename    = "./data/audio/general/Pine1.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( Pine2 )
{
    filename    = "./data/audio/general/Pine2.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( Pine3 )
{
    filename    = "./data/audio/general/Pine3.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( Pine4 )
{
    filename    = "./data/audio/general/Pine4.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( SpeedshotExplode )
{
    filename    = "./data/audio/general/SpeedshotExplode.wav";
    description = "SoundOnce";
    preload     = true;
};
datablock AudioProfile( BurstShot )
{
    filename    = "./data/audio/general/Burst.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( CheckPointPickupSound )
{
    filename    = "./data/audio/general/checkpoint_reached.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( SoundTest )
{
    filename    = "./data/audio/general/SoundTest.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( PineConeLauncherWeaponPickupSound )
{
    filename    = "./data/audio/general/PineSound.wav";
    description = "SoundOnce";
    preload     = true;
};
datablock AudioProfile( BurningPineConeLauncherWeaponPickupSound )
{
    filename    = "./data/audio/general/BurningPineSound.wav";
    description = "SoundOnce";
    preload     = true;
};
datablock AudioProfile( FrozenPineConeLauncherWeaponPickupSound )
{
    filename    = "./data/audio/general/FrozenPineSound.wav";
    description = "SoundOnce";
    preload     = true;
};
datablock AudioProfile( PoisonedPineConeLauncherWeaponPickupSound )
{
    filename    = "./data/audio/general/PoisonedPineSound.wav";
    description = "SoundOnce";
    preload     = true;
};
datablock AudioProfile( PineConeLauncherWeaponPickupSound )
{
    filename    = "./data/audio/general/PineConeLauncherWeaponPickupSound.wav";
    description = "SoundOnce";
    preload     = true;
};


datablock AudioProfile( Explosion )
{
    filename    = "./data/audio/general/Explosion.wav";
    description = "SoundOnce";
    preload     = true;
};


datablock AudioProfile( MushroomBounceSound )
{
    filename    = "./data/audio/dragon/land_mushroom.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( OutdoorMusic )
{
    filename    = "./data/audio/music/Handrawn_-_The_Doodle_Flats.wav";
    description	= MusicLoop;
    preload     = true;
    volume    = 3.0;

    Alternate   = "OutdoorMusic";
};

datablock AudioProfile( PeristalsisMusic )
{
    filename    = "./data/audio/music/HandDrawn_-_Peristalsis.wav";
    description	= MusicLoop;
    preload     = true;
    volume    = 3.0;

    Alternate   = "OutdoorMusic";
};

datablock AudioProfile( AttackOfTheShardsMusic )
{
    filename    = "./data/audio/music/Attack Of The Shards.wav";
    description	= MusicLoop;
    preload     = true;
    volume    = 3.0;

    Alternate   = "OutdoorMusic";
};

datablock AudioProfile( EdgeclimbAndDescendMusic )
{
    filename    = "./data/audio/music/Edgeclimb and Descend.wav";
    description	= MusicLoop;
    preload     = true;
    volume    = 3.0;

    Alternate   = "OutdoorMusic";
};

datablock AudioProfile( WindyMountainMusic )
{
    filename    = "./data/audio/music/Windy Mountain.wav";
    description	= MusicLoop;
    preload     = true;
    volume    = 3.0;

    Alternate   = "OutdoorMusic";
};

new AudioProfile( NormalMusic )
{
    filename    = "./data/audio/music/Handrawn_-_The_Doodle_Flats.wav";
    description	= MusicLoop;
    preload     = true;
    volume    = 1.0;
};

new AudioProfile( WaterMusic )
{
    filename    = "./data/audio/music/HandDrawn_-_Water_Music1.wav";
    description	= MusicLoop;
    preload     = true;
    volume    = 1.0;
};

datablock AudioProfile( YouWin )
{
    filename    = "./data/audio/music/You_Win.wav";
    description	= MusicLoop;
    preload     = true;
    volume    = 3.0;

    Alternate   = "YouLose";
};


datablock AudioProfile( IndoorMusic )
{
    filename    = "./data/audio/music/HandDrawn_-_Main_Theme.wav";
    description	= MusicLoop;
    preload     = true;
    volume    = 1.5;

    Alternate   = "OutdoorMusic";
};

datablock AudioProfile( VillageMusic )
{
    filename    = "./data/audio/music/HandDrawn_-_Village.wav";
    description	= MusicLoop;
    preload     = true;
    volume    = 1.5;

    Alternate   = "VillageMusic";
};

datablock AudioProfile( MainMenuInit )
{
    filename    = "./data/audio/music/ImminentInit.wav";
    description	= MusicLoop;
    preload     = true;
    volume    = 1.5;

    Alternate   = "IndoorMusic";
};


datablock AudioProfile( MainMenu )
{
    filename    = "./data/audio/music/HandDrawn_-_Industrial.wav";
    description	= MusicLoop;
    preload     = true;
    volume    = 1.5;

    Alternate   = "IndoorMusic";
};

datablock AudioProfile( OneTwoThreeFour )
{
    filename    = "./data/audio/music/OneTwoThreeFour.wav";
    description	= MusicLoop;
    preload     = true;
    volume    = 1.5;
};
datablock AudioProfile( TerrorsAndLights )
{
    filename    = "./data/audio/music/HandDrawn TerrorsAndLights.wav";
    description	= MusicLoop;
    preload     = true;
    volume    = 1.5;
};

datablock AudioProfile( TALWaterMusic )
{
    filename    = "./data/audio/music/HandDrawn TALWaterMusic.wav";
    description	= MusicLoop;
    preload     = true;
    volume    = 1.5;
};



datablock AudioProfile( MainTitle )
{
    filename    = "./data/audio/music/HandDrawn_-_Title.wav";
    description	= MusicOnce;
    preload     = true;
    volume    = 1.5;

    Alternate   = "MainMenu";
};

datablock AudioProfile( UndergroundMusic )
{
    filename    = "./data/audio/music/HandDrawn_-_Reverse_Zone.wav";
    description	= MusicLoop;
    preload     = true;

    Alternate   = "MainMenu";
};

datablock AudioProfile( ClickButton )
{
    filename    = "./data/sfx/buttonClick.wav";
    description	= "SoundOnce";
    preload     = true;
};

datablock AudioProfile( gravityenter )
{
    filename    = "./data/sfx/GravEnt.wav";
    description	= "SoundOnce";
    preload     = false;
};

datablock AudioProfile( HeartRegen )
{
    filename    = "./data/sfx/powerups/HeartRegen.wav";
    description	= "SoundOnce";
    preload     = false;
};

datablock AudioProfile( TickTock )
{
    filename    = "./data/audio/general/TickTock.wav";
    description	= "SoundOnce";
    preload     = false;
};


datablock AudioProfile( gravityexit )
{
    filename    = "./data/sfx/GravEx.wav";
    description	= "SoundOnce";
    preload     = false;
};

datablock AudioProfile( Warp )
{
    filename    = "./data/sfx/Warp.wav";
    description	= "SoundOnce";
    preload     = true;
};

datablock AudioProfile( ExtraLifePickupSound )
{
    filename    = "./data/sfx/1up.wav";
    description	= "SoundOnce";
    preload     = true;
};

datablock AudioProfile( HoverButton )
{
    filename    = "./data/sfx/buttonOver.wav";
    description	= "SoundOnce";
    preload     = true;
};

datablock AudioProfile( LevelCompleteMusic )
{
    filename    = "./data/sfx/finish_level_loop.wav";
    description	= "SoundOnce";
    preload     = true;
};