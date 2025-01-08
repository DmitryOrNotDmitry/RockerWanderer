using Logic.Models.Game;
using Logic.Utils;
using System.Net.Sockets;
using System.Reflection.Metadata;

namespace Tests
{
  public class TestMap
  {
    private const int OFFSET = 10000;

    [Fact]
    public void MapCheckExistingCollisionRocketAndAsteroidBelt()
    {
      Map map = CreateMap();

      AsteroidBelt asteroidBelt = map.TopAsteroidBelt;
      asteroidBelt.Position = new Vector2(OFFSET, -100 + OFFSET);
      asteroidBelt.Size = new Vector2(100, 150);

      AssertRocketDestroying(map, true);
    }

    [Fact]
    public void MapCheckUnexistingCollisionRocketAndAsteroidBelt()
    {
      Map map = CreateMap();

      AsteroidBelt asteroidBelt = map.TopAsteroidBelt;
      asteroidBelt.Position = new Vector2(OFFSET, -100 + OFFSET);
      asteroidBelt.Size = new Vector2(10, 10);

      AssertRocketDestroying(map, false);
    }

    [Fact]
    public void MapCheckExistingCollisionRocketAndSun()
    {
      Map map = CreateMap();

      Sun sun = map.Sun;
      sun.Position = new Vector2(OFFSET + 50, OFFSET + 50);
      sun.Size = new Vector2(100, 100);

      AssertRocketDestroying(map, true);
    }

    [Fact]
    public void MapCheckUnexistingCollisionRocketAndSun()
    {
      Map map = CreateMap();

      Sun sun = map.Sun;
      sun.Position = new Vector2(OFFSET + 500, OFFSET + 500);
      sun.Size = new Vector2(100, 100);

      AssertRocketDestroying(map, false);
    }

    [Fact]
    public void MapCheckExistingCollisionRocketAndPlanet()
    {
      Map map = CreateMap();

      Planet startPlanet = map.StartPlanet;
      startPlanet.Position = new Vector2(OFFSET + 50, OFFSET + 50);
      startPlanet.Size = new Vector2(100, 100);

      AssertRocketDestroying(map, true);
    }

    [Fact]
    public void MapCheckUnexistingCollisionRocketAndPlanet()
    {
      Map map = CreateMap();

      Planet startPlanet = map.StartPlanet;
      startPlanet.Position = new Vector2(OFFSET + 5000, OFFSET + 5000);
      startPlanet.Size = new Vector2(100, 100);

      AssertRocketDestroying(map, false);
    }

    private Map CreateMap()
    {
      Map map = new Map(new Vector2(1920, 1080));

      Rocket rocket = map.Rocket;
      rocket.Position = new Vector2(OFFSET, OFFSET);
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

      Rocket rocket = map.Rocket;
      rocket.Velocity = new Vector2(1000, 1000);

      Vector2 expectedPosition = rocket.Position + rocket.Velocity;

      map.Update(1);

      Assert.Equal(expectedPosition.X, rocket.Position.X, 1e-3);
      Assert.Equal(expectedPosition.Y, rocket.Position.Y, 1e-3);
    }

    [Fact]
    public void MapsMustMoveRocketAroundPlanet()
    {
      Map map = CreateMap();

      Rocket rocket = map.Rocket;
      rocket.Velocity = new Vector2(100, 100);
      rocket.Position = map.StartPlanet.Position + new Vector2(0, 100);
      rocket.Location = map.StartPlanet;
      rocket.Size = new Vector2(20, 20);

      Vector2 expectedRadius = rocket.Position + map.StartPlanet.Position.Scale(-1);
      rocket.ReachedOrbit = expectedRadius.Length;

      double startDeltaTime = 0.1;
      int countIters = 10;

      for (int i = 0; i < countIters; i++)
      {
        map.Update(startDeltaTime * i);

        Vector2 actual = rocket.Position + map.StartPlanet.Position.Scale(-1);

        Assert.Equal(expectedRadius.Length, actual.Length, 1e-3);
      }
    }

    [Fact]
    public void MapsMustAttachRocketToPlanet()
    {
      Map map = CreateMap();

      Rocket rocket = map.Rocket;
      rocket.Velocity = new Vector2(1, 0);
      rocket.Size = new Vector2(20, 20);
      rocket.Position = new Vector2(0, 0);

      map.Update(1);

      Planet expectedPlanet = map.Planets.First.Value;

      rocket.Position = expectedPlanet.Position + new Vector2(0, expectedPlanet.Radius * 2);
      rocket.Location = null;

      map.Update(1);

      Planet actualLocation = rocket.Location;

      Assert.Equal(expectedPlanet, actualLocation);
    }

    [Fact]
    public void MapsNotAttachRocketToAnyPlanet()
    {
      Map map = CreateMap();

      Rocket rocket = map.Rocket;
      rocket.Velocity = new Vector2(1, 0);
      rocket.Size = new Vector2(20, 20);
      rocket.Position = new Vector2(0, 0);

      map.Update(1);

      Planet planet = map.Planets.First.Value;

      rocket.Position = planet.Position + new Vector2(0, planet.Radius * 100);
      rocket.Location = null;

      map.Update(1);

      Planet actualLocation = rocket.Location;

      Assert.Null(actualLocation);
    }

    [Fact]
    public void MapsGeneratePlanetsForSettedLength()
    {
      Map map = CreateMap();

      Rocket rocket = map.Rocket;
      rocket.Velocity = new Vector2(2555, 0);

      Vector2 prevPosition = new(-100, 500);

      for (int i = 0; i < 10; i++)
      {
        map.Update(1);

        Vector2 lastPlanetPosition = map.Planets.Last.Value.Position;

        Assert.NotEqual(lastPlanetPosition.X, prevPosition.X, 1e-3);
        Assert.NotEqual(lastPlanetPosition.Y, prevPosition.Y, 1e-3);

        prevPosition = lastPlanetPosition;
      }
    }

    [Fact]
    public void MapsGenerateNotIntersctPlanets()
    {
      Map map = CreateMap();

      Rocket rocket = map.Rocket;
      rocket.Velocity = new Vector2(2555, 0);

      for (int i = 0; i < 10; i++)
      {
        map.Update(1);

        foreach (Planet elPlanet in map.Planets)
        {
          foreach (Planet elInnerPlanet in map.Planets)
          {
            if (elPlanet != elInnerPlanet)
            {
              double distance = (elPlanet.Position + elInnerPlanet.Position.Scale(-1)).Length;

              Assert.True(distance > (elInnerPlanet.Radius + elPlanet.Radius));
            }
          }
        }
      }
    }

    [Fact]
    public void MapsDeletePlanetsLocatedBehindBorder()
    {
      Map map = CreateMap();

      Rocket rocket = map.Rocket;
      rocket.Velocity = new Vector2(2555, 0);

      double noiseDistance = 1000;
      double maxDistance = map.DeletePlanetDistance + noiseDistance;

      for (int i = 0; i < 10; i++)
      {
        double lastCameraOffset = map.XCameraOffset;
        
        map.Update(1);

        foreach (Planet elPlanet in map.Planets)
        {
          if (Math.Abs(elPlanet.Position.X - lastCameraOffset) > maxDistance)
          {
            Assert.Fail();
          }
        }
      }
    }

    [Fact]
    public void DeletedPlanetsIsDespawned()
    {
      Map map = CreateMap();

      Rocket rocket = map.Rocket;
      rocket.Velocity = new Vector2(10000, 0);

      map.Update(1);

      List<Planet> deletedPlanets = [.. map.Planets];

      int countDespawnedPlanets = 0;
      foreach (Planet elPlanet in deletedPlanets)
      {
        elPlanet.Despawned += () =>
        {
          countDespawnedPlanets++;
        };
      }

      map.Update(1);

      Assert.Equal(deletedPlanets.Count, countDespawnedPlanets);
    }

    [Fact]
    public void MapsMoveCameraWhileRocketFlyDirectly()
    {
      Map map = CreateMap();

      Rocket rocket = map.Rocket;
      rocket.Velocity = new Vector2(10000, 0);

      double prevCameraOffset = map.XMustCameraOffset;

      for (int i = 0; i < 10; i++)
      {
        map.Update(1);

        Assert.NotEqual(prevCameraOffset, map.XMustCameraOffset, 1e-3);

        prevCameraOffset = map.XMustCameraOffset;
      }
    }

    [Fact]
    public void MapsDoNotMoveCameraWhileRocketFlyAroundPlanet()
    {
      Map map = new Map(new Vector2(1920, 1080));

      double prevCameraOffset = map.XMustCameraOffset;

      for (int i = 0; i < 10; i++)
      {
        map.Update(1);

        Assert.Equal(prevCameraOffset, map.XMustCameraOffset, 1e-3);

        prevCameraOffset = map.XMustCameraOffset;
      }
    }

    [Fact]
    public void MapDepartsRocket()
    {
      Map map = new Map(new Vector2(1920, 1080));

      map.RocketDepart();

      Assert.Null(map.Rocket.Location);
    }

    [Fact]
    public void MapCreatesSunToLeftFromStartPlanet()
    {
      Map map = new Map(new Vector2(1920, 1080));

      Planet startPlanet = map.StartPlanet;
      Sun sun = map.Sun;

      Assert.True(sun.Position.X < startPlanet.Position.X);
    }

    [Fact]
    public void MapCreatesAsteroidBeltsToupAndDownFromStartPlanet()
    {
      Map map = new Map(new Vector2(1920, 1080));

      Planet startPlanet = map.StartPlanet;

      AsteroidBelt topBelt = map.TopAsteroidBelt;
      Assert.True(topBelt.Position.Y < startPlanet.Position.Y);

      AsteroidBelt bottomBelt = map.BottomAsteroidBelt;
      Assert.True(bottomBelt.Position.Y > startPlanet.Position.Y);
    }

  }
}