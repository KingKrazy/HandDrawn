//-----------------------------------------------------------------------------
// Platformer Starter Kit
// Copyright (C) Phillip O'Shea
//-----------------------------------------------------------------------------

exec( "game/data/shapes/players/BoomBot/BoomBot.cs" );

//-----------------------------------------------------------------------------
//
// Audio
//
//-----------------------------------------------------------------------------

datablock AudioProfile( BoomBotSpawnSound0 )
{
    filename    = "./data/audio/dragon/startup 1a.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( BoomBotSpawnSound1 )
{
    filename    = "./data/audio/dragon/startup 1b.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( BoomBotRunSound0 )
{
    filename    = "./data/audio/dragon/grass_step1.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( BoomBotRunSound1 )
{
    filename    = "./data/audio/dragon/grass_step2.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( BoomBotRunSound2 )
{
    filename    = "./data/audio/dragon/grass_step3.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( BoomBotSlideSound )
{
    filename    = "./data/audio/dragon/slide.wav";
    description = "SoundLoop";
    preload     = true;
};

datablock AudioProfile( BoomBotJumpSound )
{
    filename     = "./data/audio/dragon/jump.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( BoomBotLandSound )
{
    filename    = "./data/audio/dragon/land.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( BoomBotDamageSound )
{
    filename    = "./data/audio/dragon/ouch.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( BoomBotDieSound0 )
{
    filename    = "./data/audio/dragon/die 1.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( BoomBotDieSound1 )
{
    filename    = "./data/audio/dragon/die 2.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( BoomBotClimbUpSound )
{
    filename    = "./data/audio/dragon/rope_climb.wav";
    description = "SoundOnce";
    preload     = true;
};

datablock AudioProfile( BoomBotClimbDownSound )
{
    filename    = "./data/audio/dragon/rope_slide.wav";
    description = "SoundLoop";
    preload     = true;
};

//-----------------------------------------------------------------------------
//
// Graphics
//
//-----------------------------------------------------------------------------

new t2dImageMapDatablock( RocketLauncherRocketImageMap )
{
    imageName = "./data/images/Weapons/RocketLauncherRocket.png";
    imageMode = "FULL";
    frameCount = "-1";
    filterMode = "SMOOTH";
    filterPad = "0";
    preferPerf = "1";
    cellRowOrder = "1";
    cellOffsetX = "0";
    cellOffsetY = "0";
    cellStrideX = "0";
    cellStrideY = "0";
    cellCountX = "-1";
    cellCountY = "-1";
    cellWidth = "0";
    cellHeight = "0";
    preload = "1";
    allowUnload = "0";
};