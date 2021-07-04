using System.Reflection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Moq;

namespace kata.rover.test
{
    public class Tests
    {
        IDetector detector;

        [SetUp]
        public void Setup()
        {
            detector = Mock.Of<IDetector>();
        }
        
        [Test]
        public void RoverCreationShouldBeinitializeAt0x0y()
        {
            Coordinates coordinates = new Coordinates(0, 0, 'N');
            Rover robot = new Rover(coordinates);

            Assert.AreEqual(0, robot.GetX());
            Assert.AreEqual(0, robot.GetY());
        }

        [Test]
        public void RoverCreationShouldBeinitializeAt10x10y()
        {
            Coordinates coordinates = new Coordinates(10, 10, 'S');
            Rover robot = new Rover(coordinates);

            Assert.AreEqual(10, robot.GetX());
            Assert.AreEqual(10, robot.GetY());
        }
        
        [Test]
        public void ShouldReceiveOneForwardCommandWhenFacingSouth()
        {
            Coordinates coordinates = new Coordinates(10, 10, 'S');
            Rover robot = new Rover(coordinates);

            robot.ReceiveCommand(new char[]{'f'});
            
            Assert.AreEqual(10, robot.GetX());
            Assert.AreEqual(9, robot.GetY());
        }
        
        
        [Test]
        public void ShouldReceiveOneForwardCommandWhenFacingNorth()
        {
            Coordinates coordinates = new Coordinates(10, 10, 'N');
            Rover robot = new Rover(coordinates);

            robot.ReceiveCommand(new char[]{'f'});
            
            Assert.AreEqual(10, robot.GetX());
            Assert.AreEqual(11, robot.GetY());
        }

        [Test]
        public void ShouldReceiveOneForwardCommandWhenFacingEast()
        {
            Coordinates coordinates = new Coordinates(10, 10, 'E');
            Rover robot = new Rover(coordinates);

            robot.ReceiveCommand(new char[]{'f'});
            
            Assert.AreEqual(11, robot.GetX());
            Assert.AreEqual(10, robot.GetY());
        }

        [Test]
        public void ShouldReceiveOneForwardCommandWhenFacingWest()
        {
            Coordinates coordinates = new Coordinates(10, 10, 'W');
            Rover robot = new Rover(coordinates);

            robot.ReceiveCommand(new char[]{'f'});
            
            Assert.AreEqual(9, robot.GetX());
            Assert.AreEqual(10, robot.GetY());
        }
        
        [Test]
        public void ShouldThrowExceptionWhenFacingUnkownDirection()
        {
            Assert.Catch<Exception>(() => new Coordinates(10, 10, 'Y'));
        }

        [Test]
        public void ShouldReceiveOneBackwardCommandWhenFacingSouth()
        {
            Coordinates coordinates = new Coordinates(10, 10, 'S');
            Rover robot = new Rover(coordinates);

            robot.ReceiveCommand(new char[]{'b'});
            
            Assert.AreEqual(10, robot.GetX());
            Assert.AreEqual(11, robot.GetY());
        }

        [Test]
        public void ShouldReceiveOneBackwardCommandWhenFacingNorth()
        {
            Coordinates coordinates = new Coordinates(10, 10, 'N');
            Rover robot = new Rover(coordinates);

            robot.ReceiveCommand(new char[]{'b'});
            
            Assert.AreEqual(10, robot.GetX());
            Assert.AreEqual(9, robot.GetY());
        }

        [Test]
        public void ShouldReceiveOneBackwardCommandWhenFacingEast()
        {
            Coordinates coordinates = new Coordinates(10, 10, 'E');
            Rover robot = new Rover(coordinates);

            robot.ReceiveCommand(new char[]{'b'});
            
            Assert.AreEqual(9, robot.GetX());
            Assert.AreEqual(10, robot.GetY());
        }

        [Test]
        public void ShouldReceiveOneBackwardCommandWhenFacingWest()
        {
            Coordinates coordinates = new Coordinates(10, 10, 'W');
            Rover robot = new Rover(coordinates);

            robot.ReceiveCommand(new char[]{'b'});
            
            Assert.AreEqual(11, robot.GetX());
            Assert.AreEqual(10, robot.GetY()); 
        }

        [Test]
        public void ShouldThrowExceptionWhenReceiveUnkownCommand()
        {
            Coordinates coordinates = new Coordinates(10, 10, 'N');
            Rover robot = new Rover(coordinates);

            Assert.Catch<Exception>(() => robot.ReceiveCommand(new char[]{'y'}));            
        }

        [Test]
        public void ShouldReceiveLeftAndForwardCommandWhenFacingWest()
        {
            Coordinates coordinates = new Coordinates(10, 10, 'W');
            Rover robot = new Rover(coordinates);
            // modif 
            robot.ReceiveCommand(new char[]{'l','f'});
            Assert.AreEqual(EDirection.South, robot.GetCurrentDirection());
            Assert.AreEqual(10, robot.GetX());
            Assert.AreEqual(9, robot.GetY());
        }

        [Test]
        public void ShouldReceiveRightAndForwardCommandWhenFacingWest()
        {
            Coordinates coordinates = new Coordinates(10, 10, 'W');
            Rover robot = new Rover(coordinates);

            robot.ReceiveCommand(new char[]{'r','f'});
            Assert.AreEqual(EDirection.North, robot.GetCurrentDirection());
            Assert.AreEqual(10, robot.GetX());
            Assert.AreEqual(11, robot.GetY());
        }



        // Dim of the grid is 15x15
        [Test]
        public void ShouldReceiveForwardCommandWhenFacingWestAndAtMinX()
        {
            Coordinates coordinates = new Coordinates(0, 10, 'W');
            Rover robot = new Rover(coordinates);

            robot.ReceiveCommand(new char[]{'f'});

            Assert.AreEqual(15, robot.GetX());
            Assert.AreEqual(10, robot.GetY());
            Assert.AreEqual(EDirection.West, robot.GetCurrentDirection());
        }
        
        // ----------------------------------------------------------------------------------------------------

        [Test]
        public void ShouldMoveToEast()
        {
            GPSMarsRover gPSMarsRover = new GPSMarsRover();
            Coordinates roverInitialPosition = new Coordinates(1, 1,'E');
            VecteurMovement movement = VecteurMovement.Create(1, 0);

            Coordinates position = gPSMarsRover.Move(roverInitialPosition, movement);

            Assert.AreEqual(RoverPosition.CreatePosition(2, 1), position.Position);
        }

        [Test]
        public void ShouldMoveToWest()
        {
            GPSMarsRover gPSMarsRover = new GPSMarsRover();
            Coordinates roverInitialPosition = new Coordinates(1, 1,'W');
            VecteurMovement movement = VecteurMovement.Create(-1, 0);

            Coordinates position = gPSMarsRover.Move(roverInitialPosition, movement);

            Assert.AreEqual(RoverPosition.CreatePosition(0, 1), position.Position);
        }

        [Test]
        public void ShouldMoveToNorth()
        {
            GPSMarsRover gPSMarsRover = new GPSMarsRover();
            Coordinates roverInitialPosition = new Coordinates(1, 1,'N');
            VecteurMovement movement = VecteurMovement.Create(0, 1);

            Coordinates position = gPSMarsRover.Move(roverInitialPosition, movement);

            Assert.AreEqual(RoverPosition.CreatePosition(1, 2), position.Position);
        }

        [Test]
        public void ShouldMoveToSouth()
        {
            GPSMarsRover gPSMarsRover = new GPSMarsRover();
            Coordinates roverInitialPosition = new Coordinates(1, 1,'S');
            VecteurMovement movement = VecteurMovement.Create(0, -1);

            Coordinates position = gPSMarsRover.Move(roverInitialPosition, movement);

            Assert.AreEqual(RoverPosition.CreatePosition(1, 0), position.Position);
        }

        [Test]
        public void ShouldMoveToWestWhenMinX()
        {
            GPSMarsRover gpsMarsRover = new GPSMarsRover();
            Coordinates roverInitialPosition = new Coordinates(0, 0,'W');
            VecteurMovement movement = VecteurMovement.Create(-1, 0);

            Coordinates position = gpsMarsRover.Move(roverInitialPosition, movement);

            Assert.AreEqual(RoverPosition.CreatePosition(GPSMarsRover.XMax, 0), position.Position);
        }

        [Test]
        public void ShouldMoveToEastWhenMinX()
        {
            GPSMarsRover gpsMarsRover = new GPSMarsRover();
            Coordinates roverInitialPosition = new Coordinates(0, 0,'E');
            VecteurMovement movement = VecteurMovement.Create(1, 0);

            Coordinates position = gpsMarsRover.Move(roverInitialPosition, movement);

            Assert.AreEqual(RoverPosition.CreatePosition(1, 0), position.Position);
        }

        [Test]
        public void ShouldMoveToEastWhenMaxX()
        {
            GPSMarsRover gpsMarsRover = new GPSMarsRover();
            Coordinates roverInitialPosition = new Coordinates(GPSMarsRover.XMax, 0,'E');
            VecteurMovement movement = VecteurMovement.Create(1, 0);

            Coordinates position = gpsMarsRover.Move(roverInitialPosition, movement);

            Assert.AreEqual(RoverPosition.CreatePosition(0, 0), position.Position);
        }
        
        [Test]
        public void ShouldMoveToWestWhenMaxX()
        {
            GPSMarsRover gpsMarsRover = new GPSMarsRover();
            Coordinates roverInitialPosition = new Coordinates(GPSMarsRover.XMax, 0,'W');
            VecteurMovement movement = VecteurMovement.Create(-1, 0);

            Coordinates position = gpsMarsRover.Move(roverInitialPosition, movement);

            Assert.AreEqual(RoverPosition.CreatePosition(GPSMarsRover.XMax-1, 0), position.Position);
        }

        [Test]
        public void ShouldMoveToSouthWhenMinY()
        {
            GPSMarsRover gpsMarsRover = new GPSMarsRover();
            Coordinates roverInitialPosition = new Coordinates(4, 0,'S');
            VecteurMovement movement = VecteurMovement.Create(0, -1);

            Coordinates position = gpsMarsRover.Move(roverInitialPosition, movement);

            Assert.AreEqual(RoverPosition.CreatePosition(11, 0), position.Position);
        }

        [Test]
        public void ShouldMoveToNorthWhenMinY()
        {
            GPSMarsRover gpsMarsRover = new GPSMarsRover();
            Coordinates roverInitialPosition = new Coordinates(4, 0,'N');
            VecteurMovement movement = VecteurMovement.Create(0, 1);

            Coordinates position = gpsMarsRover.Move(roverInitialPosition, movement);

            Assert.AreEqual(RoverPosition.CreatePosition(4, 1), position.Position);
        }

        [Test]
        public void ShouldMoveToNorthWhenMaxY()
        {
            GPSMarsRover gpsMarsRover = new GPSMarsRover();
            RoverPosition roverInitialPosition = RoverPosition.CreatePosition(4, GPSMarsRover.YMax);
            
            Coordinates coordinates = new Coordinates(roverInitialPosition, EDirection.North);
            VecteurMovement movement = VecteurMovement.Create(0, 1);

            Coordinates position = gpsMarsRover.Move(coordinates, movement);

            Assert.AreEqual(RoverPosition.CreatePosition(11, GPSMarsRover.YMax), position.Position);
        }

        [Test]
        public void ShouldMoveToSouthWhenMaxY()
        {
            GPSMarsRover gpsMarsRover = new GPSMarsRover();
            RoverPosition roverInitialPosition = RoverPosition.CreatePosition(4, GPSMarsRover.YMax);

            Coordinates coordinates = new Coordinates(roverInitialPosition, EDirection.North);
            VecteurMovement movement = VecteurMovement.Create(0, -1);

            Coordinates position = gpsMarsRover.Move(coordinates, movement);

            Assert.AreEqual(RoverPosition.CreatePosition(4, 14), position.Position);
        }

        [Test]
        public void ShouldMoveToNorthWithObstacleAndStopAction()
        {
            Mock.Get<IDetector>(detector)
                .Setup(x => x.Scan(It.IsAny<ForwardCommand>()))
                .Returns(true);

            GPSMarsRover gpsMarsRover = new GPSMarsRover();
            RoverPosition roverInitialPosition = RoverPosition.CreatePosition(4, 4);

            Coordinates coordinates = new Coordinates(roverInitialPosition, EDirection.North);
            
            Rover robot = new Rover(coordinates, detector);
            robot.ReceiveCommand(new char[]{'f'});

            Assert.AreEqual(coordinates.Position.X, robot.GetX(),"Check X position");
            Assert.AreEqual(coordinates.Position.Y, robot.GetY(),"Check Y position");
        }

        [Test]
        public void ShouldMoveToSouthWithObstacleAndStopAction()
        {
            Mock.Get<IDetector>(detector)
                .Setup(x => x.Scan(It.IsAny<BackwardCommand>()))
                .Returns(true);

            GPSMarsRover gpsMarsRover = new GPSMarsRover();
            RoverPosition roverInitialPosition = RoverPosition.CreatePosition(4, 4);

            Coordinates coordinates = new Coordinates(roverInitialPosition, EDirection.North);
            
            Rover robot = new Rover(coordinates, detector);
            robot.ReceiveCommand(new char[]{'b'});

            Assert.AreEqual(coordinates.Position.X, robot.GetX(),"Check X position");
            Assert.AreEqual(coordinates.Position.Y, robot.GetY(),"Check Y position");
        }
        

        [Test]
        public void ShouldMoveToXWithObstacleInBackwardCommandAndStopAction()
        {
            Mock.Get<IDetector>(detector)
                .Setup(x => x.Scan(It.IsAny<BackwardCommand>()))
                .Returns(true);

            GPSMarsRover gpsMarsRover = new GPSMarsRover();
            RoverPosition roverInitialPosition = RoverPosition.CreatePosition(4, 4);

            Coordinates coordinates = new Coordinates(roverInitialPosition, EDirection.North);
            
            Rover robot = new Rover(coordinates, detector);
            robot.ReceiveCommand(new char[]{'f','r','f', 'l','b'});

            Assert.AreEqual(coordinates.Position.X+1, robot.GetX(),"Check X position");
            Assert.AreEqual(coordinates.Position.Y+1, robot.GetY(),"Check Y position");
        }

        [Test]
        public void ShouldRiseEventWhenEncounterAnObstacle()
        {
             Mock.Get<IDetector>(detector)
                .Setup(x => x.Scan(It.IsAny<BackwardCommand>()))
                .Returns(true);

            GPSMarsRover gpsMarsRover = new GPSMarsRover();
            RoverPosition roverInitialPosition = RoverPosition.CreatePosition(4, 4);

            Coordinates coordinates = new Coordinates(roverInitialPosition, EDirection.North);
            
            Rover robot = new Rover(coordinates, detector);
            bool result = false;
            
            robot.ObstacleDetected += (object sender, EventArgs e) => {
                result = true;    
            };
            robot.ReceiveCommand(new char[]{'b'});
            Assert.IsTrue(result);
        }    
    }
    
}