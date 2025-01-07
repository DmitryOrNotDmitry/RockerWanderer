using Logic.Models.Game;
using Logic.Utils;
using System.Net.Sockets;
using System.Reflection.Metadata;

namespace Tests
{
  public class TestMap
  {
    private const int _offset = 10000;

    [Fact]
    public void MapCheckExistingCollisionRocketAndAsteroidBelt()
    {
      Map map = CreateMap();

      AsteroidBelt asteroidBelt = map.TopAsteroidBelt;
      asteroidBelt.Position = new Vector2(_offset, -100 + _offset);
      asteroidBelt.Size = new Vector2(100, 150);

      AssertRocketDestroying(map, true);
    }

    [Fact]
    public void MapCheckUnexistingCollisionRocketAndAsteroidBelt()
    {
      Map map = CreateMap();

      AsteroidBelt asteroidBelt = map.TopAsteroidBelt;
      asteroidBelt.Position = new Vector2(_offset, -100 + _offset);
      asteroidBelt.Size = new Vector2(10, 10);

      AssertRocketDestroying(map, false);
    }

    [Fact]
    public void MapCheckExistingCollisionRocketAndSun()
    {
      Map map = CreateMap();

      Sun sun = map.Sun;
      sun.Position = new Vector2(_offset + 50, _offset + 50);
      sun.Size = new Vector2(100, 100);

      AssertRocketDestroying(map, true);
    }

    [Fact]
    public void MapCheckUnexistingCollisionRocketAndSun()
    {
      Map map = CreateMap();

      Sun sun = map.Sun;
      sun.Position = new Vector2(_offset + 500, _offset + 500);
      sun.Size = new Vector2(100, 100);

      AssertRocketDestroying(map, false);
    }

    [Fact]
    public void MapCheckExistingCollisionRocketAndPlanet()
    {
      Map map = CreateMap();

      Planet startPlanet = map.StartPlanet;
      startPlanet.Position = new Vector2(_offset + 50, _offset + 50);
      startPlanet.Size = new Vector2(100, 100);

      AssertRocketDestroying(map, true);
    }

    [Fact]
    public void MapCheckUnexistingCollisionRocketAndPlanet()
    {
      Map map = CreateMap();

      Planet startPlanet = map.StartPlanet;
      startPlanet.Position = new Vector2(_offset + 5000, _offset + 5000);
      startPlanet.Size = new Vector2(100, 100);

      AssertRocketDestroying(map, false);
    }

    private Map CreateMap()
    {
      Map map = new Map(new Vector2(1920, 1080));

      Rocket rocket = map.Rocket;
      rocket.Position = new Vector2(_offset, _offset);
      rocket.Size = new Vector2(100, 100);
      rocket.Velocity = new Vector2(0, 0);
      rocket.Location = null;

      return map;
    }

    private void AssertRocketDestroying(Map parMap, bool parMustRocketDestroyed)
    {
      bool isDestroyed = false;

      parMap.Rocket.Destroyed += () =>
      {
        isDestroyed = true;
      };

      parMap.Update(1);

      Assert.Equal(parMustRocketDestroyed, isDestroyed);
    }


    [Fact]
    public void TestResetMap()
    {
      Map map = CreateMap();

      bool isResetedEventInvoked = false;

      map.Reseted += () =>
      {
        isResetedEventInvoked = true;
      };

      map.Reset();

      Assert.True(isResetedEventInvoked);

      Assert.Equal(map.Rocket.Location, map.StartPlanet);
      
      Assert.Empty(map.Planets);

      Assert.Equal(0, map.XCameraOffset);
      Assert.Equal(0, map.XMustCameraOffset);
    }

    [Fact]
    public void MapsMustMoveRocketDirectly()
    {
      Map map = CreateMap();


      Assert.False(true);
    }

    [Fact]
    public void MapsMustMoveRocketAroundPlanet()
    {
      Map map = CreateMap();


      Assert.False(true);
    }

    [Fact]
    public void MapsMustAttachRocketToPlanet()
    {
      Map map = CreateMap();


      Assert.False(true);
    }

    [Fact]
    public void MapsNotAttachRocketToAnyPlanet()
    {
      Map map = CreateMap();


      Assert.False(true);
    }

    [Fact]
    public void MapsGeneratePlanetsForSettedLength()
    {
      Map map = CreateMap();


      Assert.False(true);
    }

    [Fact]
    public void MapsGenerateNotIntersctPlanets()
    {
      Map map = CreateMap();


      Assert.False(true);
    }

    [Fact]
    public void MapsDeletePlanetsLocatedBehindBorder()
    {
      Map map = CreateMap();


      Assert.False(true);
    }

    [Fact]
    public void DeletedPlanetsIsDespawned()
    {
      Map map = CreateMap();


      Assert.False(true);
    }

    [Fact]
    public void MapsMoveCameraWhileRocketFlyDirectly()
    {
      Map map = CreateMap();


      Assert.False(true);
    }

    [Fact]
    public void MapsDoNotMoveCameraWhileRocketFlyAroundPlanet()
    {
      Map map = CreateMap();


      Assert.False(true);
    }

    [Fact]
    public void MapDepartsRocket()
    {
      Map map = CreateMap();


      Assert.False(true);
    }

    [Fact]
    public void MapCreatesSunToLeftFromStartPlanet()
    {
      Map map = CreateMap();


      Assert.False(true);
    }

    [Fact]
    public void MapCreatesAsteroidBeltsToupAndDownFromStartPlanet()
    {
      Map map = CreateMap();

      Assert.False(true);
    }

  }
}